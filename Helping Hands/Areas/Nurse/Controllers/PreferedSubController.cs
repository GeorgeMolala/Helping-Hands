using Helping_Hands.Data.GRID;
using Helping_Hands.Data.Repositories;
using Helping_Hands.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
namespace Helping_Hands.Areas.Nurse.Controllers
{

    [Area("Nurse")]
    [Authorize(Roles = "Nurse")]
    public class PreferedSubController : Controller
    {
        private HelpingHandsUnitOfWork data { get; set; }
        private GRP0452HelpingHandsDBContext _context { get; set; }

        public PreferedSubController(GRP0452HelpingHandsDBContext ctx)
        {
            data = new HelpingHandsUnitOfWork(ctx);
            _context = ctx;
        }


        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        public IActionResult List(PreferedSuburbGridDTO vals)
        {
            string DefaultSort = nameof(PreferedSuburbs.Suburb);
            var builder = new PreferedSuburbGridBuilder(HttpContext.Session, vals, defaultSortField: nameof(PreferedSuburbs.Suburb));
            int ID = Convert.ToInt32(TempData.Peek("UserID").ToString());

            var options = new PreferedSuburbQueryOption
            {
                PageNumber = builder.CurrentRoute.PageNumber,
                PageSize = builder.CurrentRoute.PageSize,
                OrderByDirection = builder.CurrentRoute.SortDirection,
                WhereClauses = new WhereClauses<PreferedSuburbs>
                {
                    t =>t.NurseUserID == ID
                }

            };




            //     options.SortFilter(builder);


            var vw = new PreferedListView
            {

                PreferSub = data.PreferedSub.List(options),
                PreferModal = data.PreferedSub.List(new QueryOptions<PreferedSuburbs> { }),

                Suburbs = data.Suburb.List(new QueryOptions<Suburbs>
                {
                    OrderBy = a => a.Name
                }),

                Cities = data.Cities.List(new QueryOptions<Cities>
                {

                }),

                CurrentRoute = builder.CurrentRoute,


                TotalPages = builder.GetTotalPages(data.Suburb.Count)


            };

            ////Substrating time and date

            //DateTime date = DateTime.Today;

            //DateTime fort = date.AddDays(-32);
            //ViewBag.Date = fort.ToString("D"); //|| DateTime.Today.ToString("dd");

            return View(vw);


        }

        [HttpGet]
        public IActionResult Delete(int id) => DeletePrefered(id);

        [HttpPost]
        public IActionResult DeletePrefered(int id)
        {

            try
            {
                int NurseID = Convert.ToInt32(TempData.Peek("UserID").ToString());
                PreferedSuburbs sub = new PreferedSuburbs();
                sub = data.PreferedSub.Get(id);

                var Care = data.CareContracts.List(new QueryOptions<CareContracts>
                {

                    OrderBy = a => a.ContractNumberID,
                    Where = b => b.Status == "Assigned" && b.NurseUserID == NurseID

                });

                if (Care.Count() > 0)
                {
                    foreach (CareContracts contr in Care)
                    {

                        if (sub.SuburbID == contr.SuburbID)
                        {
                            TempData["DeleteStatus"] = "Operation Can't be completed, Until you close your contract";
                        }
                        else
                        {

                            //var  subs =   data.PreferedSub.Whe;

                            data.PreferedSub.Delete(sub);
                            data.Save();
                            TempData["DeleteStatus"] = "Successfully Removed";

                        }
                    }
                }
                else
                {
                    data.PreferedSub.Delete(sub);
                    data.Save();
                    TempData["DeleteStatus"] = "Successfully Removed";
                }
            }
            catch
            {
                TempData["DeleteStatus"] = "Something Went wrong";
                return RedirectToAction("List");
            }



            return RedirectToAction("List");
        }


        [HttpPost]
        public IActionResult Add(PreferedSuburbs pref)
        {
            int ID = Convert.ToInt32(TempData.Peek("UserID").ToString());



            try
            {
                int city = _context.Suburbs.Where(x => x.SuburbID == pref.SuburbID).Select(a => a.CityID).FirstOrDefault();
                pref.NurseUserID = ID;
                pref.CityID = city;
                data.PreferedSub.Insert(pref);
                data.PreferedSub.Save();
                TempData["AddStatus"] = "Successfully Added";
            }
            catch
            {
                TempData["AddStatus"] = "Something Went wrong";
                return RedirectToAction("List");
            }




            return RedirectToAction("List");

        }


    }
}
