using Microsoft.AspNetCore.Mvc;

namespace Helping_Hands.Areas.Admin.Controllers
{
    public class BusinessController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
