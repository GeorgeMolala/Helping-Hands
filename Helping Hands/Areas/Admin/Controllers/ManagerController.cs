using Helping_Hands.Data;
using Helping_Hands.Data.GRID;
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
    public class ManagerController : Controller
    {
        
        
        private HelpingHandsUnitOfWork data { get; set; }
        private readonly ILogger<ManagerController> _logger;
        private UserManager<UserApp> userManager;
        private SignInManager<UserApp> SignInManager;
        private GRP0452HelpingHandsDBContext _context;

        private RoleManager<IdentityRole> roleManager;
     

      


        public ManagerController(GRP0452HelpingHandsDBContext ctx, UserManager<UserApp> userMngr, SignInManager<UserApp> signInManager, RoleManager<IdentityRole> roleManagerr)
        {
            data = new HelpingHandsUnitOfWork(ctx);
            userManager = userMngr;
            SignInManager = signInManager;
            roleManager = roleManagerr;
            _context = ctx;
        }


        public IActionResult Index()
        {
            return RedirectToAction("ManagerUser");
        }

        public IActionResult Delete(int id)
        {
            try
            {
                Managers man = new Managers();

                man = data.Managers.Get(id);
                man.Status = "InActive";
                data.Managers.Update(man);
                data.Save();

                TempData["ManagerStatus"] = "Manager deleted succesfully";
            }
            catch
            {
                TempData["ManagerStatus"] = "Delete Unsuccesful, Try again";
                return RedirectToAction("ManagerUser");
            }


            return RedirectToAction("ManagerUser");
        }



        [HttpGet]
        public IActionResult ManagerUser(ManagerGridDTO vals)
        {
            string DefaultSort = nameof(Managers.FirstName);
            var builder = new ManagerGridBuilder(HttpContext.Session, vals, defaultSortField: nameof(Managers.FirstName));
            //  int ID = Convert.ToInt32(TempData.Peek("UserID").ToString());
            //Querying Data
            var options = new ManagerQueryOptions
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

            var vw = new ManagerViewModel
            {
                Managers = data.Managers.List(options),
               

                CurrentRoute = builder.CurrentRoute,
                TotalPages = builder.GetTotalPages(data.Nurses.Count)
            };


            return View(vw);


        }

        [HttpPost]
        public async Task<IActionResult> AddManager(Managers nurse)
        {
            try
            {
              
                    nurse.Status = "Active";
                    data.Managers.Insert(nurse);
                    data.Managers.Save();

                int UserID =  _context.Managers.Max(x => x.ManagerUserID);
                Managers nt = new Managers();
                nt = data.Managers.Get(UserID);



                var usr = new UserApp
                {
                    UserName = nurse.UserName,
                    UserID = UserID,
                    PhoneNumber = nt.ManagerContact.ToString(),
                    PhoneNumberConfirmed = true,
                    Email = nt.EmailAddress,
                    EmailConfirmed = true,

                };

                var result = await userManager.CreateAsync(usr, nurse.Password);
                var resultss = await roleManager.CreateAsync(new IdentityRole("Manager"));
                var resultROle = await userManager.AddToRoleAsync(usr, "Manager");

                if (result.Succeeded)
                {
                    //   await SignInManager.SignInAsync(usr, isPersistent: false);

                    TempData["NurseStatus"] = "User Successfully Created";
                    return RedirectToAction("ManagerUser"); ///Fix Customer Controller
                }
            }
            catch
            {
                TempData["NurseStatus"] = "Something Went wrong";
                return RedirectToAction("ManagerUser");
            }
            return RedirectToAction("ManagerUser");
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
            return RedirectToAction("ManagerUser", builder.CurrentRoute);
        }
    }
}
