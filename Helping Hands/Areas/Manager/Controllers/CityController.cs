using Helping_Hands.Data.GRID;
using Helping_Hands.Data.Repositories;
using Helping_Hands.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Helping_Hands.Areas.Manager.Controllers
{
    [Area("Manager")]
    [Authorize(Roles = "Manager")]
    public class CityController : Controller
    {
        private HelpingHandsUnitOfWork data { get; set; }
        //   private GRP0452HelpingHandsDBContext _context;

        public CityController(GRP0452HelpingHandsDBContext ctx) => data = new HelpingHandsUnitOfWork(ctx);

        [HttpGet]
        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            try
            {
                Cities city = new Cities();
                city = data.Cities.Get(Id);
                city.Status = "InActive";

                data.Cities.Update(city);
                data.Cities.Save();

                TempData["CityStatus"] = " Succesfully Deleted";

            }
            catch
            {
                TempData["CityStatus"] = "Operation Failed";
                return RedirectToAction("List");
            }


            return RedirectToAction("List");
        }

        public IActionResult List(CityGridDTO vals)
        {
            string DefaultSort = nameof(Cities.Name);
            var builder = new CityGridBuilder(HttpContext.Session, vals, defaultSortField: nameof(Cities.Name));
            //  int ID = Convert.ToInt32(TempData.Peek("UserID").ToString());
            //Querying Data
            var options = new CityQueryOptions
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
                Cities = data.Cities.List(options),

                CurrentRoute = builder.CurrentRoute,
                TotalPages = builder.GetTotalPages(data.Cities.Count)
            };


            return View(vw);
        }

        [HttpPost]
        public IActionResult Add(Cities pref)
        {
            try
            {
                Cities city = new Cities()
                {
                    Name = pref.Name,
                    Abbrev = pref.Abbrev,
                    Status = "Active",
                    ProvinceID = 1
                };

                data.Cities.Insert(city);
                data.Cities.Save();

                TempData["CityStatus"] = " Succesfully Added";
            }
            catch
            {
                TempData["CityStatus"] = "Something went wrong";
                return RedirectToAction("List");
            }

            return RedirectToAction("List");
        }


    }
}
