using Helping_Hands.Data;
using Helping_Hands.Data.Repositories;
using Helping_Hands.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace Helping_Hands.Areas.Manager.Controllers
{

    [Authorize(Roles = "Manager")]
    [Area("Manager")]
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

        public IActionResult Index()
        {

            return RedirectToAction("List");
        }

        public IActionResult List(NurseGridDTO vals)
        {

            // get GridBuilder object, load route segment values, store in session
            string defaultSort = nameof(Nurses.FirstName);
            var builder = new NurseGridBuilder(HttpContext.Session, vals, defaultSortField: nameof(Nurses.FirstName));

            // create options for querying 
            var options = new NurseQueryOptions
            {


                PageNumber = builder.CurrentRoute.PageNumber,
                PageSize = builder.CurrentRoute.PageSize,
                OrderByDirection = builder.CurrentRoute.SortDirection
            };




            // options.SortFilter(builder); uncheck if errors are encountered sorting
            options.SortFilter(builder);

            var vm = new NursesListViewModel
            {
                Nurses = data.Nurses.List(options),
                Suburbs = data.Suburb.List(new QueryOptions<Suburbs>
                {
                    OrderBy = a => a.Name
                }),
                CurrentRoute = builder.CurrentRoute,
                TotalPages = builder.GetTotalPages(data.Nurses.Count)
            };

            //Care Visits
            ViewBag.CareVisitsActive = _context.CareVisits.Where(x => x.Status == "Active").Count();
            ViewBag.CareVisitsTotal = _context.CareVisits.Count();

            //Care Contract
            ViewBag.CareContractTotal = _context.CareContracts.Count();
            ViewBag.CareContractAcive = _context.CareContracts.Where(x => x.Status == "Closed").Count();
            ViewBag.CareContractAssigned = _context.CareContracts.Where(x => x.NurseUserID > 0).Count();
            ViewBag.CareContractUnAssigned = _context.CareContracts.Where(x => x.NurseUserID <= 0).Count();

            //Conditions
            ViewBag.ConditionsTotal = _context.ChronicInfections.Count();
            ViewBag.ConditionsActive = _context.ChronicInfections.Where(x => x.Status == "Status").Count();

            //Nurses
            ViewBag.NursesTotal = _context.Nurses.Count();
            ViewBag.NursesActive = _context.Nurses.Where(x => x.Status == "Active").Count();

            //City
            ViewBag.CityTotal = _context.Cities.Count();
            ViewBag.CityActive = _context.Cities.Where(x => x.Status == "Active").Count();

            //Suburb
            ViewBag.SuburbTotal = _context.Suburbs.Count();
            ViewBag.SuburbActive = _context.Suburbs.Where(x => x.Status == "Active").Count();

            //Province           
            ViewBag.ProvinceTotal = _context.Provinces.Count();
            ViewBag.ProvinceActive = _context.Provinces.Where(x => x.Status == "Active").Count();


            //Organisations
            ViewBag.Organisation = _context.Organisations.Count();


            return View(vm);
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
            return RedirectToAction("List", builder.CurrentRoute);
        }

        [HttpPost]
        public RedirectToActionResult PageSize(int pagesize)
        {
            var builder = new NurseGridBuilder(HttpContext.Session);

            builder.CurrentRoute.PageSize = pagesize;
            builder.SaveRouteSegments();

            return RedirectToAction("List", builder.CurrentRoute);
        }


        [HttpGet]
        public async Task<IActionResult> LogOut()
        {

            await SignInManager.SignOutAsync();
            return RedirectToAction("Index", "Home", new { area = "" });
        }

    }
}
