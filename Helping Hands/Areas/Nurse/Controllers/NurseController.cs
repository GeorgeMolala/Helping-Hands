using Helping_Hands.Data;
using Helping_Hands.Data.Repositories;
using Helping_Hands.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Helping_Hands.Areas.Nurse.Controllers
{
    [Area("Nurse")]
    [Authorize(Roles = "Nurse")]
    public class NurseController : Controller
    {

        private readonly ILogger<NurseController> _logger;
        private UserManager<UserApp> userManager;
        private SignInManager<UserApp> SignInManager;
        private GRP0452HelpingHandsDBContext _context;

        private RoleManager<IdentityRole> roleManager;
        private HelpingHandsUnitOfWork data { get; set; }
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

                    {t =>t.NurseUserID == ID }
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
                CurrentRoute = builder.CurrentRoute,
                TotalPages = builder.GetTotalPages(data.CareContracts.Count)

            };


            return View(vw);
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {

            await SignInManager.SignOutAsync();
            return RedirectToAction("Index", "Home", new { area = "" });
        }

    }
}
