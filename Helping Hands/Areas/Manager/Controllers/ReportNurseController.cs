using Helping_Hands.Data;
using Helping_Hands.Data.Repositories;
using Helping_Hands.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helping_Hands.Areas.Manager.Controllers
{
    [Area("Manager")]
    [Authorize(Roles = "Manager")]
    public class ReportNurseController : Controller
    {

        private HelpingHandsUnitOfWork data { get; set; }
        public ReportNurseController(GRP0452HelpingHandsDBContext ctx) => data = new HelpingHandsUnitOfWork(ctx);

        private static int ContraID { get; set; }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NurseUser(NurseGridDTO vals)
        {
            string DefaultSort = nameof(Nurses.FirstName);
            var builder = new NurseGridBuilder(HttpContext.Session, vals, defaultSortField: nameof(Nurses.FirstName));
            //  int ID = Convert.ToInt32(TempData.Peek("UserID").ToString());
            //Querying Data
            var options = new NurseQueryOptions
            {
                PageNumber = builder.CurrentRoute.PageNumber,
                PageSize = builder.CurrentRoute.PageSize,
                OrderByDirection = builder.CurrentRoute.SortDirection


            };

            options.SortFilter(builder);

            // OrderBy depends on value of SortField route
            //if (builder.CurrentRoute.SortField.EqualsNoCase(DefaultSort))
            //{
            //    options.OrderBy = x => x.Status;
            //}
            //else
            //{
            //    options.OrderBy = x => x.Status;
            //}

            var vw = new NursesListViewModel
            {
                Nurses = data.Nurses.List(options),
                Cities = data.Cities.List(new QueryOptions<Cities>
                {


                }),

                Suburbs = data.Suburb.List(new QueryOptions<Suburbs> { }),

                CurrentRoute = builder.CurrentRoute,
                TotalPages = builder.GetTotalPages(data.CareContracts.Count)
            };


            return View(vw);


        }

        [HttpPost]
        public RedirectToActionResult Filter(string[] filter, bool clear = false)
        {
            // get current route segments from session
            var builder = new NurseGridBuilder(HttpContext.Session);

            // clear or update filter route segment values. If update, get author data
            // from database so can add author name slug to author filter value.
            if (clear)
            {
                builder.ClearFilterSegments();
            }
            else
            {
                var suburb = data.Suburb.Get(filter[0].ToInt());
                builder.CurrentRoute.PageNumber = 1;
                builder.LoadFilterSegments(filter, suburb);
            }

            // save route data back to session and redirect to Book/List action method,
            // passing dictionary of route segment values to build URL
            builder.SaveRouteSegments();
            return RedirectToAction("NurseUser", builder.CurrentRoute);
        }

        public RedirectToActionResult PageSize(int pagesize)
        {
            var builder = new CareContractGridBuilder(HttpContext.Session);

            builder.CurrentRoute.PageSize = pagesize;
            builder.SaveRouteSegments();

            return RedirectToAction("List", builder.CurrentRoute);
        }
    }
}
