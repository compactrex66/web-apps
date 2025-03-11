using egzamin.Models;
using Microsoft.AspNetCore.Mvc;

namespace egzamin.Controllers
{
    public class HomeController : Controller
    {
        private RepoReservation _repo;
        public HomeController(IConfiguration configuration)
        {
            _repo = new RepoReservation(configuration);
        }
        // GET: HomeController
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Result(Reservation reservation) {
            if(reservation == null) {
                return RedirectToAction("Index");
            }
            reservation.TableNumber = 1;
            if(!String.IsNullOrEmpty(reservation.Date) && !String.IsNullOrEmpty(reservation.PhoneNumber) && reservation.PeopleCount > 0) {
                _repo.SaveToDb(reservation);
                return RedirectToAction(nameof(List));
            }
            return View(reservation);
        }
        public IActionResult List() {
            return View(_repo.GetAllReservations());
        }
    }
}
