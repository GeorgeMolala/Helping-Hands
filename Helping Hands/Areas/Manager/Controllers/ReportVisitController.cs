using Helping_Hands.Data;
using Helping_Hands.Data.GRID;
using Helping_Hands.Data.Repositories;
using Helping_Hands.Models;
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
    public class ReportVisitController : Controller
    {

        private HelpingHandsUnitOfWork data { get; set; }
        public ReportVisitController(GRP0452HelpingHandsDBContext ctx) => data = new HelpingHandsUnitOfWork(ctx);

        private static int ContraID { get; set; }
        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult List(CareVisitGridDTO vals)
        {
            string DefaultSort = nameof(CareVisits.VisitDate);
            var builder = new CareVisitGridBuilder(HttpContext.Session, vals, defaultSortField: nameof(CareVisits.VisitDate));
            int ID = Convert.ToInt32(TempData.Peek("UserID").ToString());

            var options = new CareVisitQueryOptions
            {

                PageNumber = builder.CurrentRoute.PageNumber,
                PageSize = builder.CurrentRoute.PageSize,
                OrderByDirection = builder.CurrentRoute.SortDirection,
                WhereClauses = new WhereClauses<CareVisits>
                {
                    t =>t.NurseUserID == ID
                }

            };




            options.SortFilter(builder);


            var vw = new CareVisitListViewModel
            {

                CareVisit = data.CareVisits.List(options),

                Patients = data.Patients.List(new QueryOptions<Patients>
                {

                    OrderBy = a => a.FirstName
                }),

                Nurses = data.Nurses.List(new QueryOptions<Nurses>
                {
                    OrderBy = b => b.FirstName

                }),

                Suburbs = data.Suburb.List(new QueryOptions<Suburbs> { }),
                Cities = data.Cities.List(new QueryOptions<Cities> { }),
                Contracts = data.CareContracts.List(new QueryOptions<CareContracts> { }),

                CurrentRoute = builder.CurrentRoute,


                TotalPages = builder.GetTotalPages(data.CareVisits.Count)


            };

            ////Substrating time and date

            //DateTime date = DateTime.Today;

            //DateTime fort = date.AddDays(-32);
            //ViewBag.Date = fort.ToString("D"); //|| DateTime.Today.ToString("dd");

            return View(vw);


        }

        [HttpPost]
        public RedirectToActionResult Filter(string[] filter, bool clear = false)
        {
            // get current route segments from session
            var builder = new CareVisitGridBuilder(HttpContext.Session);

            // clear or update filter route segment values. If update, get author data
            // from database so can add author name slug to author filter value.
            if (clear)
            {
                builder.ClearFilterSegments();
            }
            else
            {
                var Care = data.CareVisits.Get(filter[0].ToInt());
                builder.CurrentRoute.PageNumber = 1;
                builder.LoadFilterSegments(filter, Care);
            }

            // save route data back to session and redirect to Book/List action method,
            // passing dictionary of route segment values to build URL
            builder.SaveRouteSegments();
            return RedirectToAction("List", builder.CurrentRoute);
        }
    }
}
