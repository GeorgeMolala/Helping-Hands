using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Helping_Hands.Areas.Nurse.Controllers
{
    [Area("Nurse")]
    [Authorize(Roles = "Nurse")]
    public class NurseController : Controller
    {

       

        public IActionResult Index()
        {
            return View();
        }
    }
}
