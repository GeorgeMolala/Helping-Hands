using Helping_Hands.Data;
using Helping_Hands.Data.Repositories;
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
            //  ViewBag.Nurse = _context.Nurses.ToList();
            var data = new Datas(_context);

            int use = _context.Patients.Max(x => x.PatientUserID);

            var Nurses = data.GetNurses(new Data.Repositories.QueryOptions<Nurses> { });
            ViewBag.Nurses = _context.Nurses.Count();
            ViewBag.NursesActive = _context.Nurses.Where(x => x.Status == "Active").Count();


            ViewBag.Organisations = _context.Organisations.Count();

            ViewBag.Managers = _context.Managers.Count();
            ViewBag.ManagersActive = _context.Managers.Where(x => x.Status == "Active").Count();


            ViewBag.City = _context.Cities.Count();
            ViewBag.Patient = _context.Patients.Count();
            ViewBag.PatientActive = _context.Patients.Where(x => x.Status == "Active").Count();
            ViewBag.Suburb = _context.Suburbs.Count();
            ViewBag.Province = _context.Provinces.Count();


            return View(Nurses);
        }


        [HttpGet]
        public async Task<IActionResult> LogOut()
        {

            await SignInManager.SignOutAsync();
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}
