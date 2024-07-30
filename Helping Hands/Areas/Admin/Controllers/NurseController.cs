using Helping_Hands.Data;
using Helping_Hands.Data.Repositories;
using Helping_Hands.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace Helping_Hands.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class NurseController : Controller
    {

        private HelpingHandsUnitOfWork data { get; set; }
        private readonly ILogger<NurseController> _logger;
        private UserManager<UserApp> userManager;
        private SignInManager<UserApp> SignInManager;
        private GRP0452HelpingHandsDBContext _context;

        private RoleManager<IdentityRole> roleManager;


        public NurseController(GRP0452HelpingHandsDBContext ctx, UserManager<UserApp> userMngr, SignInManager<UserApp> signInManager, RoleManager<IdentityRole> roleManagerr)
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



        [HttpGet]
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
                TotalPages = builder.GetTotalPages(data.Nurses.Count)
            };


            return View(vw);


        }

        [HttpPost]
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
                    //   await SignInManager.SignInAsync(usr, isPersistent: false);

                    TempData["NurseStatus"] = "User Successfully Created";
                    return RedirectToAction("NurseUser"); ///Fix Customer Controller
                }
            }
            catch
            {
                TempData["NurseStatus"] = "Something Went wrong";
                return RedirectToAction("NurseUser");
            }
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
    }
}
