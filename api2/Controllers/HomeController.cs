using Microsoft.AspNetCore.Mvc;

namespace api2.Controllers
{
    public class HomeController : Controller
    {
        // GET: HomeController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddBook()
        {
            return View();
        }
    }
}
