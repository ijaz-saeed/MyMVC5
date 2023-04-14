using Microsoft.AspNetCore.Mvc;

namespace CoreMVCApp.Controllers
{
    public class HealthController : Controller
    {
        public IActionResult Index()
        {
            return View("Health");
        }
    }
}
