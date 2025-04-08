using ark2_sol.Models;
using Microsoft.AspNetCore.Mvc;

namespace ark2_sol.Controllers;

public class FootballController : Controller
{
    private readonly MyGamesRepo _gamesRepo;
    private readonly MyPlayersRepo _playersRepo;
    private readonly string _connectionString;
    public FootballController(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("mysql");
        _gamesRepo = new MyGamesRepo(_connectionString);
        _playersRepo = new MyPlayersRepo(_connectionString);
    }
    [HttpGet]
    public IActionResult Index()
    {
        ViewBag.games = _gamesRepo.GetAllGames();
        return View();
    }
    [HttpPost]
    public IActionResult Players(MyPlayer player)
    {
        ViewBag.games = _gamesRepo.GetAllGames();
        ViewBag.players = _playersRepo.GetPlayers(player.Number);
        return View();
    }
    [HttpGet]
    public IActionResult Gallery() {
        return View();
    }
}