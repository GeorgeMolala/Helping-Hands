﻿using Microsoft.AspNetCore.Mvc;

namespace Helping_Hands.Areas.Manager.Controllers
{
    public class PatientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
