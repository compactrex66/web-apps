using cw7.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace cw7.Pages
{
    public class GamesModel : PageModel
    {
        public List<Game> Games { get; set; }
        private GamesRepo _repo;
        
        public GamesModel() {
            _repo = new GamesRepo("games.json");
        }

        public void OnGet()
        {
            Games = _repo.Games ?? new List<Game>();
        }
    }
}
