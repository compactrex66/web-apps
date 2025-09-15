using cw11_ef.Models;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace cw11_ef.Controllers
{
    public class HomeController : Controller
    {
        private readonly BooksContext _context;
        public HomeController(BooksContext context)
        {
            _context = context;
        }
        // GET: HomeController
        public ActionResult Index()
        {
            var books = _context.Books.ToList();
            return View(books);
        }
        [HttpGet]
        public ActionResult AddBook()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Books.Add(book);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public ActionResult AddEditor()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddEditor(Editor editor)
        {
            System.Console.WriteLine("nazwa " + editor.Name);
            if (ModelState.IsValid)
            {
                _context.Editors.Add(editor);
                _context.SaveChanges();
                return RedirectToAction("Editors");
            }
            return View();
        }
        public IActionResult DeleteEditor(int? id)
        {
            var toDelete = _context.Editors.FirstOrDefault(e => e.Id == id);
            if (toDelete != null)
            {
                _context.Editors.Remove(toDelete);
                _context.SaveChanges();
            }
            return RedirectToAction("Editors");
        }
        [HttpGet]
        public IActionResult EditEditor(int? id)
        {
            var toEdit = _context.Editors.FirstOrDefault(e => e.Id == id);
            if (toEdit != null)
            {
                return View(toEdit);
            }
            return Redirect(nameof(EditEditor));
        }
        [HttpPost]
        public IActionResult EditEditor(Editor editor)
        {
            if (ModelState.IsValid)
            {
                _context.Editors.Update(editor);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Editors));
        }
        public ActionResult Editors()
        {
            return View(_context.Editors.ToList());
        }
    }
}
