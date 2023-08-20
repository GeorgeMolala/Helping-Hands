using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helping_Hands.Areas.Manager.Controllers
{
    public class CityController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
