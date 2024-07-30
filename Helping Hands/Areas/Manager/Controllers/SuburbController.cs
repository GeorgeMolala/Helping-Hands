using Helping_Hands.Data.GRID;
using Helping_Hands.Data.Repositories;
using Helping_Hands.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Helping_Hands.Areas.Manager.Controllers
{

    [Authorize(Roles = "Manager")]
    [Area("Manager")]
    public class SuburbController : Controller
    {

        private HelpingHandsUnitOfWork data { get; set; }
        //   private GRP0452HelpingHandsDBContext _context;

        public SuburbController(GRP0452HelpingHandsDBContext ctx) => data = new HelpingHandsUnitOfWork(ctx);

        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        public IActionResult List(SuburbGridDTO vals)
        {
            string DefaultSort = nameof(Suburbs.Name);
            var builder = new SuburbGridBuilder(HttpContext.Session, vals, defaultSortField: nameof(Suburbs.Name));
            //  int ID = Convert.ToInt32(TempData.Peek("UserID").ToString());
            //Querying Data
            var options = new SuburbQueryOptions
            {
                PageNumber = builder.CurrentRoute.PageNumber,
                PageSize = builder.CurrentRoute.PageSize,
                OrderByDirection = builder.CurrentRoute.SortDirection,
                Where = a => a.Status == "Active"

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

            var vw = new SuburbsViewModel
            {
                Suburbs = data.Suburb.List(options),
                Cities = data.Cities.List(new QueryOptions<Cities> { }),

                CurrentRoute = builder.CurrentRoute,
                TotalPages = builder.GetTotalPages(data.Suburb.Count)
            };


            return View(vw);

        }

        [HttpPost]
        public IActionResult Add(Suburbs pref)
        {
            try
            {
                Suburbs city = new Suburbs()
                {
                    Name = pref.Name,
                    PostalCode = pref.PostalCode,
                    Status = "Active",
                    CityID = pref.CityID
                };

                data.Suburb.Insert(city);
                data.Suburb.Save();

                TempData["CityStatus"] = " Succesfully Added";
            }
            catch
            {
                TempData["CityStatus"] = "Something went wrong";
                return RedirectToAction("List");
            }

            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            try
            {
                Suburbs city = new Suburbs();
                city = data.Suburb.Get(Id);
                city.Status = "InActive";

                data.Suburb.Update(city);
                data.Suburb.Save();

                TempData["CityStatus"] = " Succesfully Deleted";

            }
            catch
            {
                TempData["CityStatus"] = "Operation Failed";
                return RedirectToAction("List");
            }


            return RedirectToAction("List");
        }
    }
}
