using layout.Models;
using Microsoft.AspNetCore.Mvc;

namespace layout.Controllers
{
    public class GamesController : Controller
    {
        // GET: StudentsController
        private readonly GamesRepo _gamesRepo;
        private readonly string? _connectionString;
        public GamesController(IConfiguration configuration) {
            _connectionString = configuration.GetConnectionString("mysql");
            _gamesRepo = new GamesRepo(_connectionString);
        }
        public ActionResult List()
        {
            return View(_gamesRepo.GetAllGames());
        }
        [HttpGet]
        public IActionResult Create() {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Game game) {
            if(ModelState.IsValid) {
                _gamesRepo.AddGame(game);
                return RedirectToAction("List");
            }
            return View();
        }
        public IActionResult Delete(int id) {
            _gamesRepo.DeleteGame(id);
            return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult Update(int id) {
            return View(_gamesRepo.GetGameById(id));
        }
        [HttpPost]
        public IActionResult Update(Game game) {
            _gamesRepo.UpdateGame(game);
            return RedirectToAction("List");
        }
    }
}
