using cw7.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace cw7.Pages
{
    public class AddMovieModel : PageModel
    {
        [BindProperty]
        public Movie? Movie { get; set; }
        public void OnGet()
        {
        }
    }
}
