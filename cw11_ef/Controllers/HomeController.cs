using cw11_ef.Models;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;


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

            var editor = _context.Editors.FirstOrDefault(e => e.Id == book.EditorId);
            if (editor != null)
            {
                _context.Books.Add(book);
                editor.Books.Add(book);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult DeleteBook(int? id)
        {
            var toDelete = _context.Books.FirstOrDefault(e => e.Id == id);
            if (toDelete != null)
            {
                _context.Books.Remove(toDelete);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
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
            var editorWithBooks = _context.Editors.Include(e => e.Books).ToList();
            return View(editorWithBooks);
        }   
    }
}
