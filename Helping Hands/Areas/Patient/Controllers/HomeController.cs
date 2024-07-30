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
using System.Threading.Tasks;

namespace Helping_Hands.Areas.Patient.Controllers
{

    [Authorize(Roles = "Patient")]
    [Area("Patient")]
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private UserManager<UserApp> userManager;
        private SignInManager<UserApp> SignInManager;
        private GRP0452HelpingHandsDBContext _context;

        private RoleManager<IdentityRole> roleManager;
        private HelpingHandsUnitOfWork data { get; set; }
        public HomeController(GRP0452HelpingHandsDBContext ctx, UserManager<UserApp> userMngr, SignInManager<UserApp> signInManager, RoleManager<IdentityRole> roleManagerr)
        {
            data = new HelpingHandsUnitOfWork(ctx);
            userManager = userMngr;
            SignInManager = signInManager;
            roleManager = roleManagerr;
            _context = ctx;
        }

        private static int ContraID { get; set; }



        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UpdateMed()
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

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> LogOut()
        {

            await SignInManager.SignOutAsync();
            return RedirectToAction("Index", "Home", new { area = "" });
        }


        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePass pat)
        {
            try
            {

                string name = TempData.Peek("UserNamePass").ToString();
                UserApp user = await userManager.FindByNameAsync(name);
                var Result = await userManager.ChangePasswordAsync(user, pat.OldPassword, pat.NewPasword);

                if (Result.Succeeded)
                {
                    TempData["ChangePassStatus"] = "Password Changed";
                    return RedirectToAction("PatientDetails");
                }
                else
                {
                    TempData["ChangePassStatus"] = "Something went wrong";
                    return RedirectToAction("PatientDetails");
                }


            }
            catch
            {
                TempData["ChangePassStatus"] = "Something went wrong";
                return RedirectToAction("PatientDetails");
            }
            return RedirectToAction("PatientDetails");
        }

        [HttpGet]
        public IActionResult PatientDetails()
        {
            int user = Convert.ToInt32(TempData.Peek("UserID").ToString());


            Patients patie = new Patients();



            int? ID = Convert.ToInt32(TempData.Peek("UserID").ToString());
            patie = data.Patients.Get(user);

            var pt = new PatientViewModels
            {
                Patients = data.Patients.List(new QueryOptions<Patients>
                {
                    Where = a => a.PatientUserID == Convert.ToInt32(user)

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

        [HttpPost]
        public IActionResult UpdateBio(Patients pat)
        {
            int user = Convert.ToInt32(TempData.Peek("UserID").ToString());

            try
            {
                Patients patients = new Patients();
                patients = data.Patients.Get(user);

                patients.FirstName = pat.FirstName;
                patients.Surname = pat.Surname;
                patients.Gender = pat.Gender;
                patients.Dob = pat.Dob;
                data.Patients.Update(patients);
                data.Save();

                TempData["PatientUpdate"] = "Profile Updated Successfully";

                return RedirectToAction("PatientDetails");
            }
            catch
            {
                TempData["PatientUpdate"] = "Something Went";

            }

            return RedirectToAction("PatientDetails");
        }

        [HttpPost]
        public IActionResult UpdateContact(Patients pat)
        {
            int user = Convert.ToInt32(TempData.Peek("UserID").ToString());
            try
            {
                Patients patients = new Patients();
                patients = data.Patients.Get(user);

                patients.PatientContact = pat.PatientContact;
                patients.EmailAddress = pat.EmailAddress;
                patients.LineAddress1 = pat.LineAddress1;
                patients.LineAddress2 = pat.LineAddress2;
                patients.SuburbID = pat.SuburbID;
                patients.CityID = pat.CityID;

                data.Patients.Update(patients);
                data.Save();
                TempData["PatientUpdate"] = "Profile Updated Successfully";

                return RedirectToAction("PatientDetails");
            }
            catch
            {
                TempData["PatientUpdate"] = "Something Went wrong";
                return RedirectToAction("PatientDetails");
            }
            return RedirectToAction("PatientDetails");
        }

        [HttpPost]
        public IActionResult UpdateNextOFKin(Patients pat)
        {
            int user = Convert.ToInt32(TempData.Peek("UserID").ToString());
            try
            {
                Patients patients = new Patients();
                patients = data.Patients.Get(user);
                patients.NextOfKinName = pat.NextOfKinName;
                patients.NextOfKinContact = pat.NextOfKinContact;

                data.Patients.Update(patients);
                data.Save();
                TempData["PatientUpdate"] = "Profile Updated Successfully";

                return RedirectToAction("PatientDetails");
            }
            catch
            {
                TempData["PatientUpdate"] = "Something Went wrong";
                return RedirectToAction("PatientDetails");
            }
            return RedirectToAction("PatientDetails");
        }

    }
}
