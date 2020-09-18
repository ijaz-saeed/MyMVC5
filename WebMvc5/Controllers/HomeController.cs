using System.Web.Mvc;

namespace WebMvc5.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Angular()
        {
            return View();
        }
	}
}