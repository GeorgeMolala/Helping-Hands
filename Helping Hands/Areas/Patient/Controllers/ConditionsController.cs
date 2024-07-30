using Helping_Hands.Data.GRID;
using Helping_Hands.Data.Repositories;
using Helping_Hands.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Helping_Hands.Areas.Patient.Controllers
{

    [Authorize(Roles = "Patient")]
    [Area("Patient")]
    public class ConditionsController : Controller
    {
        private HelpingHandsUnitOfWork data { get; set; }
        public ConditionsController(GRP0452HelpingHandsDBContext ctx) => data = new HelpingHandsUnitOfWork(ctx);

        private static int ContraID { get; set; }

        [HttpGet]
        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult List(ConditionsGridDTO vals)
        {

            int ID = Convert.ToInt32(TempData.Peek("UserID").ToString());

            // get GridBuilder object, load route segment values, store in session
            string defaultSort = nameof(ChronicInfections.ConditionName);
            var builder = new ConditionsGridBuilder(HttpContext.Session, vals, defaultSortField: nameof(ChronicInfections.ConditionName));
            // builder.SaveRouteSegments();

            // create options for querying authors
            var options = new ConditionsQueryOptions
            {
                //Includes = "BookAuthors.Book",

                PageNumber = builder.CurrentRoute.PageNumber,
                PageSize = builder.CurrentRoute.PageSize,
                OrderByDirection = builder.CurrentRoute.SortDirection,
                Where = a => a.Status == "Active"
            };

            // options.SortFilter(builder); uncheck if errors are encountered sorting
            options.SortFilter(builder);
            // OrderBy depends on value of SortField route
            //if (builder.CurrentRoute.SortField.EqualsNoCase(defaultSort))
            //    options.OrderBy = a => a.FirstName;

            //else
            //    options.OrderBy = a => a.Surname;

            var vm = new ConditionsViewModels
            {
                ChronicInfections = data.ChronicInfections.List(options),
                ChronicAccoms = data.ChronicAccoms.List(new QueryOptions<ChronicAccoms>
                {
                    Where = a => a.PatientUserID == ID && a.Status == "Active"
                }),
                CurrentRoute = builder.CurrentRoute,
                TotalPages = builder.GetTotalPages(data.ChronicInfections.Count)
            };


            return View(vm);

        }


        [HttpPost]
        public IActionResult Add(ChronicAccoms pref)
        {
            int ID = Convert.ToInt32(TempData.Peek("UserID").ToString());
            try
            {

                pref.Status = "Active";
                pref.PatientUserID = ID;
                data.ChronicAccoms.Insert(pref);
                data.Save();

                TempData["ConditionStatus"] = "Something went wrong";
            }
            catch
            {
                TempData["ConditionStatus"] = "Something went wrong";
                return RedirectToAction("List");
            }


            return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
            try
            {
                ChronicAccoms coms = new ChronicAccoms();
                coms = data.ChronicAccoms.Get(id);
                coms.Status = "InActive";

                data.ChronicAccoms.Update(coms);
                data.ChronicAccoms.Save();

                TempData["ConditionStatus"] = " Succesfully Deleted";

            }
            catch
            {
                TempData["ConditionStatus"] = "Something went wrong";
                return RedirectToAction("List");
            }


            return RedirectToAction("List");
        }

    }
}
