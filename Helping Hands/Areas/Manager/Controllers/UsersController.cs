using Helping_Hands.Data;
using Helping_Hands.Data.GRID;
using Helping_Hands.Data.Repositories;
using Helping_Hands.Models;
using Helping_Hands.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Helping_Hands.Areas.Manager.Controllers
{

    [Area("Manager")]
    [Authorize(Roles = "Manager")]
    public class UsersController : Controller
    {

        private HelpingHandsUnitOfWork data { get; set; }
        private readonly ILogger<UsersController> _logger;
        private UserManager<UserApp> userManager;
        private SignInManager<UserApp> SignInManager;
        private GRP0452HelpingHandsDBContext _context;

        private RoleManager<IdentityRole> roleManager;


        public UsersController(GRP0452HelpingHandsDBContext ctx, UserManager<UserApp> userMngr, SignInManager<UserApp> signInManager, RoleManager<IdentityRole> roleManagerr)
        {
            data = new HelpingHandsUnitOfWork(ctx);
            userManager = userMngr;
            SignInManager = signInManager;
            roleManager = roleManagerr;
            _context = ctx;
        }


        public IActionResult Index()
        {
            return RedirectToAction("NurseUser");
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

        public IActionResult PatientUsers()
        {
            return RedirectToAction("PatientUser");
        }

        public IActionResult PatientUser(PatientGridDTO vals)
        {

            string DefaultSort = nameof(Patients.FirstName);
            var builder = new PatientGridBuilder(HttpContext.Session, vals, defaultSortField: nameof(Patients.FirstName));
            //  int ID = Convert.ToInt32(TempData.Peek("UserID").ToString());
            //Querying Data
            var options = new PatientQueryOptions
            {
                PageNumber = builder.CurrentRoute.PageNumber,
                PageSize = builder.CurrentRoute.PageSize,
                OrderByDirection = builder.CurrentRoute.SortDirection,


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

            var vw = new PatientViewModels
            {

                Patients = data.Patients.List(options),

                Suburbs = data.Suburb.List(new QueryOptions<Suburbs> { }),
                Cities = data.Cities.List(new QueryOptions<Cities> { }),

                CurrentRoute = builder.CurrentRoute,
                TotalPages = builder.GetTotalPages(data.CareContracts.Count)
            };


            return View(vw);



        }



        //Lisitng one User
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


            // var Patient = data.Patients.Get(Convert.ToInt32(ID));


            return View(pt);
        }

        public IActionResult DeletePatient(int id)
        {
            try
            {
                Patients patient = new Patients();
                patient = data.Patients.Get(id);
                patient.Status = "InActive";

                data.Patients.Update(patient);
                data.Patients.Save();

                TempData["PatientStatus"] = " Succesfully Deleted";

            }
            catch
            {
                TempData["PatientStatus"] = "Something went wrong";
                return RedirectToAction("PatientUser");
            }


            return RedirectToAction("PatientUser");
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
        public async Task<IActionResult> AddNurse(Nurses nurse)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    nurse.Status = "Active";
                    data.Nurses.Insert(nurse);
                    data.Nurses.Save();
                }
                else
                {
                    TempData["NurseStatus"] = "Something Went wrong";
                    return RedirectToAction("NurseUser");
                }

                int UserID = _context.Nurses.Max(x => x.NurseUserID);
                Nurses nt = new Nurses();
                nt = data.Nurses.Get(UserID);



                var usr = new UserApp
                {
                    UserName = nurse.UserName,
                    UserID = UserID,
                    PhoneNumber = nt.NurseContact.ToString(),
                    PhoneNumberConfirmed = true,
                    Email = nt.EmailAddress,
                    EmailConfirmed = true,

                };

                var result = await userManager.CreateAsync(usr, nurse.Password);
                var resultss = await roleManager.CreateAsync(new IdentityRole("Nurse"));
                var resultROle = await userManager.AddToRoleAsync(usr, "Nurse");

                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(usr, isPersistent: false);

                    TempData["NurseStatus"] = "User Successfully Created";
                    return RedirectToAction("NurseUser", "Users"); ///Fix Customer Controller
                }
            }
            catch
            {
                TempData["NurseStatus"] = "Something Went wrong";
            }
            return RedirectToAction("NurseUser");
        }
    }
}
