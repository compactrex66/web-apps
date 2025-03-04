using egzamin.Models;
using Microsoft.AspNetCore.Mvc;

namespace egzamin.Controllers
{
    public class HomeController : Controller
    {
        // GET: HomeController
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Reserve(Reservation reservation) {
            return View(reservation);
        }
    }
}
