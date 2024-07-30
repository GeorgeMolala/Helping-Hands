using Helping_Hands.Data;
using Helping_Hands.Data.Repositories;
using Helping_Hands.Models;
using Helping_Hands.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Helping_Hands.Areas.Patient.Controllers
{

    [Authorize(Roles = "Patient")]
    [Area("Patient")]
    public class CareContractsController : Controller
    {
        private HelpingHandsUnitOfWork data { get; set; }
        public CareContractsController(GRP0452HelpingHandsDBContext ctx) => data = new HelpingHandsUnitOfWork(ctx);

        private static int ContraID { get; set; }



        public IActionResult Index()
        {
            return RedirectToAction("List");
        }



        public IActionResult List(CareContractGridDTO vals)
        {
            string DefaultSort = nameof(CareContracts.Status);
            var builder = new CareContractGridBuilder(HttpContext.Session, vals, defaultSortField: nameof(CareContracts.Status));
            int ID = Convert.ToInt32(TempData.Peek("UserID").ToString());
            //Querying Data
            var options = new CareContractQueryOptions
            {
                PageNumber = builder.CurrentRoute.PageNumber,
                PageSize = builder.CurrentRoute.PageSize,
                OrderByDirection = builder.CurrentRoute.SortDirection,
                WhereClauses = new WhereClauses<CareContracts>
                {
                    t =>t.PatientUserID == ID
                }

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

            var vw = new CareContractListViewModel
            {
                CareContracts = data.CareContracts.List(options),
                Patients = data.Patients.List(new QueryOptions<Patients>
                {

                    OrderBy = a => a.FirstName
                }),

                Suburbs = data.Suburb.List(new QueryOptions<Suburbs> { }),
                Cities = data.Cities.List(new QueryOptions<Cities> { }),
                Nurses = data.Nurses.List(new QueryOptions<Nurses> { }),
                CurrentRoute = builder.CurrentRoute,
                TotalPages = builder.GetTotalPages(data.CareContracts.Count)
            };


            return View(vw);
        }


        [HttpPost]
        public RedirectToActionResult Filter(string[] filter, bool clear = false)
        {
            // get current route segments from session
            var builder = new CareContractGridBuilder(HttpContext.Session);

            // clear or update filter route segment values. If update, get author data
            // from database so can add author name slug to author filter value.
            if (clear)
            {
                builder.ClearFilterSegments();
            }
            else
            {
                var suburb = data.CareContracts.Get(filter[0].ToInt());
                builder.CurrentRoute.PageNumber = 1;
                builder.LoadFilterSegments(filter, suburb);
            }

            // save route data back to session and redirect to Book/List action method,
            // passing dictionary of route segment values to build URL
            builder.SaveRouteSegments();
            return RedirectToAction("List", builder.CurrentRoute);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {

            if (id == 0 || id < 0)
            {
                var Care = data.CareContracts.Get(ContraID);
                TempData["StatusUpdate"] = "Updated";

                var vm = new CareContractListViewModel
                {
                    CareContracts = data.CareContracts.List(new QueryOptions<CareContracts>
                    {

                        Where = a => a.ContractNumberID == ContraID

                    }),

                    Patients = data.Patients.List(new QueryOptions<Patients>
                    {
                        Where = b => b.PatientUserID == Care.PatientUserID

                    }),

                    Suburbs = data.Suburb.List(new QueryOptions<Suburbs>
                    {
                        Where = c => c.SuburbID == Care.SuburbID

                    }),

                    Cities = data.Cities.List(new QueryOptions<Cities>
                    {
                        Where = d => d.CityID == Care.CityID
                    }),

                    Nurses = data.Nurses.List(new QueryOptions<Nurses>
                    {
                        Where = e => e.NurseUserID == Care.NurseUserID
                    }),

                    CareVisits = data.CareVisits.List(new QueryOptions<CareVisits>
                    {

                    })


                };
                return View(vm);
            }
            else
            {
                var Care = data.CareContracts.Get(id);


                var vm = new CareContractListViewModel
                {
                    CareContracts = data.CareContracts.List(new QueryOptions<CareContracts>
                    {

                        Where = a => a.ContractNumberID == id

                    }),

                    Patients = data.Patients.List(new QueryOptions<Patients>
                    {
                        Where = b => b.PatientUserID == Care.PatientUserID

                    }),

                    Suburbs = data.Suburb.List(new QueryOptions<Suburbs>
                    {
                        Where = c => c.SuburbID == Care.SuburbID

                    }),

                    Cities = data.Cities.List(new QueryOptions<Cities>
                    {
                        Where = d => d.CityID == Care.CityID
                    }),

                    Nurses = data.Nurses.List(new QueryOptions<Nurses>
                    {
                        Where = e => e.NurseUserID == Care.NurseUserID
                    }),

                    CareVisits = data.CareVisits.List(new QueryOptions<CareVisits>
                    {

                    })


                };
                return View(vm);
            }


        }


        [HttpPost]
        public IActionResult CreateCOntract(CareContracts contra)
        {

            try
            {
                int ID = Convert.ToInt32(TempData.Peek("UserID").ToString());
                contra.PatientUserID = ID;
                contra.ContractDate = DateTime.Today;
                contra.ProvinceID = 1;
                contra.Status = "New";

                data.CareContracts.Insert(contra);
                data.CareContracts.Save();

                TempData["ContractStatus"] = "Reuested Submitted";
            }
            catch
            {
                TempData["ContractStatus"] = "Something went wrong";
                return RedirectToAction("List");
            }

            return RedirectToAction("List");
        }



        public IActionResult PatientDetails(int id)
        {
            CareContracts contra = new CareContracts();
            Patients patie = new Patients();

            contra = data.CareContracts.Get(id);

            int? ID = contra.PatientUserID;
            patie = data.Patients.Get(Convert.ToInt32(contra.PatientUserID));

            var pt = new PatientViewModels
            {
                Patients = data.Patients.List(new QueryOptions<Patients>
                {
                    Where = a => a.PatientUserID == Convert.ToInt32(contra.PatientUserID)

                }),

                Suburbs = data.Suburb.List(new QueryOptions<Suburbs>
                {
                    Where = b => b.SuburbID == patie.SuburbID
                }),
                Cities = data.Cities.List(new QueryOptions<Cities>
                {
                    Where = c => c.CityID == patie.CityID
                }),

                ChronicAccoms = data.ChronicAccoms.List(new QueryOptions<ChronicAccoms>
                {
                    Where = d => d.PatientUserID == patie.PatientUserID
                }),

                ChronicInfections = data.ChronicInfections.List(new QueryOptions<ChronicInfections>
                {

                })


            };


            var Patient = data.Patients.Get(Convert.ToInt32(ID));


            return View(pt);
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
