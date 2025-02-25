using Microsoft.AspNetCore.Mvc;
using strona.Models;

namespace strona.Controllers
{
    public class BooksController : Controller
    {
        // GET: BooksController
        public ActionResult List()
        {
            return View(MyBooks.GetBooks());
        }

    }
}
