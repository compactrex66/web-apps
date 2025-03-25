using arkusz2.Models;
using Microsoft.AspNetCore.Mvc;

namespace arkusz2.Controllers
{
    public class FootballController : Controller
    {
        private PlayerRepo _repo;
        public FootballController(IConfiguration configuration) {
            _repo = new PlayerRepo(configuration);
        }
        public ActionResult Index()
        {
            return View();
        }

        public IActionResult ListChosen(int chosen)
        {
            return View(_repo.GetFromChosenPosition(chosen));
        }
    }
}
