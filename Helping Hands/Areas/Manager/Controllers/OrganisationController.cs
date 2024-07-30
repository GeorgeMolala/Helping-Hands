using Microsoft.AspNetCore.Mvc;

namespace Helping_Hands.Areas.Manager.Controllers
{
    public class OrganisationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
