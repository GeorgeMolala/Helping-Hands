using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Helping_Hands.Areas.Patient.Controllers
{

    [Authorize(Roles = "Patient")]
    [Area("Patient")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Content("Patient");
        }
    }
}
