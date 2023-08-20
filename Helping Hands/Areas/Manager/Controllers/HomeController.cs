using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Helping_Hands.Areas.Manager.Controllers
{

    [Authorize(Roles = "Manager")]
    [Area("Manager")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            
            return View();
        }
    }
}
