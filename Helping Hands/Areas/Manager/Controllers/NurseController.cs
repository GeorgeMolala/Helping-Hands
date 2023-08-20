using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helping_Hands.Areas.Manager.Controllers
{
    public class NurseController : Controller
    {
        private GRP0452HelpingHandsDBContext _context;
        public NurseController(GRP0452HelpingHandsDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var Nurses = _context.Nurses.ToList();

            return View(Nurses);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

 
    }
}
