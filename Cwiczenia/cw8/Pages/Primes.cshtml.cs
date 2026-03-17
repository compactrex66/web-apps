using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace cw8.Pages
{
    public class PrimesModel : PageModel
    {
        [BindProperty]
        public int Amount { get; set; }
        public void OnGet() {

        }
        public void OnPost() {
            
        }
    }
}
