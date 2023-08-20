using Helping_Hands.Data;
using Helping_Hands.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace Helping_Hands.Controllers
{
    
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private UserManager<UserApp> userManager;
        private SignInManager<UserApp> SignInManager;

        private RoleManager<IdentityRole> roleManager;

        private GRP0452HelpingHandsDBContext _context;

       // private Queue<Admins> Admins = new Queue<Admins>();


        public AccountController(UserManager<UserApp> userMngr, SignInManager<UserApp> signInManager, RoleManager<IdentityRole> roleManagerr, GRP0452HelpingHandsDBContext context)
        {
            userManager = userMngr;
            SignInManager = signInManager;
            _context = context;
            roleManager = roleManagerr;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult RegisterDetails(Patients admin)
        {
            //  if (ModelState.IsValid)
            //     {
            // Admins.Enqueue(admin);

            _context.Patients.Add(admin);
            _context.SaveChanges();

            return RedirectToAction("UserCredentials");
            //  }
            //   else
            //   {
            //       return RedirectToAction("RegisterDetails");
            //   }

        }

        [HttpPost]
        public async Task<IActionResult> UserCredentials(UserCred userCred)
        {


            if (ModelState.IsValid)
            {
              Patients admin = new Patients();
                //   _context.Admins.Add(Admins.Dequeue());
                //  _context.SaveChanges();

                int UserID = _context.Patients.Max(x => x.PatientUserID);

                
                admin = _context.Patients.Find(UserID);

                var usr = new UserApp
                {
                    UserName = userCred.UserName,
                    UserID = UserID,
                    PhoneNumber = admin.PatientContact.ToString(),
                    PhoneNumberConfirmed = true,
                    Email = admin.EmailAddress,
                    EmailConfirmed = true,

                };

                var result = await userManager.CreateAsync(usr, userCred.Password);
                var resultss = await roleManager.CreateAsync(new IdentityRole("Patient"));
                var resultROle = await userManager.AddToRoleAsync(usr, "Patient");

                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(usr, isPersistent: false);
                    return RedirectToAction("Index", "Admin"); ///Fix Customer Controller
                }

            }

            else
            {
                return RedirectToAction("RegisterCred");
            }

            return RedirectToAction("RegisterCred");
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(Log log)
        {

            if (ModelState.IsValid)
            {
                var result = await SignInManager.PasswordSignInAsync(log.UserName, log.Password, log.RememberMe, lockoutOnFailure: false);


                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(log.ReturnUrl) && Url.IsLocalUrl(log.ReturnUrl))
                    {

                        
                        return Redirect(log.ReturnUrl);

                    }
                    else
                     {
                        var use = await userManager.FindByNameAsync(log.UserName);

                        var role = await userManager.GetRolesAsync(use);

                        switch (role.FirstOrDefault())
                        {
                            case "Admin":
                                return RedirectToAction("Index", "Home", new { area = "Admin" });


                            case "Manager":
                                return RedirectToAction("Index", "Home", new { Area = "Manager" });

                            case "Nurse":
                                return RedirectToAction("Index", "Nurse", new { area = "Nurse" });

                            case "Patient":
                                return RedirectToAction("Index", "Home", new { area = "Patient" });

                        }
                        return Redirect(log.ReturnUrl);
                    }

                }

            }

            ModelState.AddModelError(" ", "Invalid username/password.");


            return View(log);

        }


        [HttpGet]
        public IActionResult LogIn(string returnURL = "")
        {
            var model = new Log { ReturnUrl = returnURL };
            return View(model);
        }


        [HttpGet]
        public IActionResult UserCredentials()
        {
            return View();
        }


        [HttpGet]
        public IActionResult RegisterDetails()
        {
            var provinces = new SelectList(_context.Provinces.ToList());
            var Cities = _context.Cities.ToList();
            var Suburs = _context.Suburbs.ToList();
            // Patient patient = new Patient();
            ViewBag.province = _context.Provinces.ToList();
            ViewBag.Suburb = new SelectList(_context.Suburbs, "CityID", "Name");

            ViewBag.cities = _context.Cities.ToList();
            ViewBag.suburbs = _context.Suburbs.ToList();

            /* 
             * ViewBag.Suburb_s = JsonConvert.SerializeObject(_context.Suburbs.ToList());
             ViewBag.City_s = JsonConvert.SerializeObject(_context.Cities.ToList());
             ViewBag.Prov_s = JsonConvert.SerializeObject(_context.Provinces.ToList());

             */
            return View();


        }
    }
}
