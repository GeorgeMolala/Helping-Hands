using Helping_Hands.Data;
using Helping_Hands.Data.GRID;
using Helping_Hands.Data.Repositories;
using Helping_Hands.Models;
using Helping_Hands.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Helping_Hands.Areas.Manager.Controllers
{
    [Area("Manager")]
    [Authorize(Roles = "Manager")]
    public class CareVisitController : Controller
    {
        private HelpingHandsUnitOfWork data { get; set; }
        private GRP0452HelpingHandsDBContext _context { get; set; }

        private static int CareID;

        public CareVisitController(GRP0452HelpingHandsDBContext ctx)
        {
            data = new HelpingHandsUnitOfWork(ctx);
            _context = ctx;
        }

        public IActionResult Index()
        {
            return RedirectToAction("List");
        }


        public IActionResult NurseDetails(int id)
        {
            CareContracts contra = new CareContracts();
            Nurses patie = new Nurses();

        //    contra = data.CareContracts.Get(id);

           // int? ID = contra.NurseUserID;
            patie = data.Nurses.Get(id);

            var pt = new NursesListViewModel
            {


               Nurses = data.Nurses.List(new QueryOptions<Nurses> { 
                
                   Where = a =>a.NurseUserID == id
               
               }),

                Suburbs = data.Suburb.List(new QueryOptions<Suburbs>
                {
                    Where = b => b.SuburbID == patie.SuburbID
                }),
                Cities = data.Cities.List(new QueryOptions<Cities>
                {
                    Where = c => c.CityID == patie.CityID
                }),

                PreferedSuburbs = data.PreferedSub.List(new QueryOptions<PreferedSuburbs>
                {
                    Where =b=>b.NurseUserID == id

                })

             


            };


      //      var Patient = data.Patients.Get(Convert.ToInt32(ID));


            return View(pt);
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
                    OrderBy = b=>b.FirstName

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
        public IActionResult StartSession(CareVisits visit)
        {
            CareVisits vs = new CareVisits();
            vs = data.CareVisits.Get(visit.CareVisitsID);


            //Start Session
            if (visit.DepartTime == null && visit.WoundCondition == null)
            {

                vs.ArrivalTime = visit.ArrivalTime;

                data.CareVisits.Update(vs);

                data.CareVisits.Save();
            }

            //End Session
            else if (visit.ArrivalTime != null && visit.WoundCondition != null)
            {
                vs.DepartTime = visit.DepartTime;
                vs.WoundCondition = visit.WoundCondition;
                vs.Notes = visit.Notes;
                vs.Status = "Closed";

                data.CareVisits.Update(vs);
                data.CareVisits.Save();
            }

            //schedule session
            else
            {

            }



            CareID = visit.CareVisitsID;
            TempData["StartStatus"] = "Appointment Started";
            return RedirectToAction("VisitDetails", CareID);
        }


        [HttpPost]
        public IActionResult EndSession(CareVisits visits)
        {

            CareVisits vs = new CareVisits();
            vs = data.CareVisits.Get(visits.CareVisitsID);

            vs.ArrivalTime = visits.ArrivalTime;
            vs.DepartTime = visits.DepartTime;
            vs.WoundCondition = visits.WoundCondition;
            vs.Notes = visits.Notes;
            vs.Status = "Closed";

            data.CareVisits.Update(vs);
            data.CareVisits.Save();


            CareID = visits.CareVisitsID;
            TempData["EndStatus"] = "Appointment Ended";
            return RedirectToAction("VisitDetails", CareID);
        }


        [HttpGet]
        public IActionResult VisitDetails(int ID)
        {
            CareVisits visits = new CareVisits();
            CareContracts contract = new CareContracts();


            if (ID > 0)
            {
                visits = data.CareVisits.Get(ID);
            }
            else
            {
                visits = data.CareVisits.Get(CareID);
            }


            contract = data.CareContracts.Get(visits.ContractNumberID);

            var vw = new CareVisitListViewModel
            {
                CareVisit = data.CareVisits.List(new QueryOptions<CareVisits>
                {

                    Where = b => b.CareVisitsID == visits.CareVisitsID

                }),

                Contracts = data.CareContracts.List(new QueryOptions<CareContracts>
                {
                    Where = a => a.ContractNumberID == visits.ContractNumberID
                }),

                Patients = data.Patients.List(new QueryOptions<Patients>
                {

                    Where = c => c.PatientUserID == contract.PatientUserID

                }),

                Suburbs = data.Suburb.List(new QueryOptions<Suburbs>
                {

                    Where = d => d.SuburbID == contract.SuburbID

                }),

                Cities = data.Cities.List(new QueryOptions<Cities>
                {

                    Where = e => e.CityID == contract.CityID

                }),






            };


            return View(vw);
        }


        [HttpPost]
        public IActionResult Appointment(CareVisits visit)
        {
            int ID = Convert.ToInt32(TempData.Peek("UserID").ToString());

            visit.Status = "Open";
            visit.NurseUserID = ID;

            data.CareVisits.Insert(visit);
            data.CareVisits.Save();

            TempData["CreatedStatus"] = "Appoinment Scheduled Successfully";

            return RedirectToAction("");
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
