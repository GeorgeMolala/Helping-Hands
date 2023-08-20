using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;


namespace Helping_Hands.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class HomeController : Controller
    {
        private GRP0452HelpingHandsDBContext _context;

        public HomeController(GRP0452HelpingHandsDBContext context)
        {
            _context= context;
        }

        public IActionResult Index()
        {
          //  ViewBag.Nurse = _context.Nurses.ToList();
           int use = _context.Patients.Max(x => x.PatientUserID);
            var Nurse = _context.Patients.ToList();

            return View(Nurse);
        }
    }
}
