using layout.Models;
using layout.Models.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace layout.Controllers
{
    public class StudentsController : Controller
    {
        // GET: StudentsController
        private readonly IStudentRepo _studentRepo;
        public StudentsController() {
            _studentRepo = new FakeStudentRepo();
        }
        public ActionResult List()
        {
            return View(_studentRepo.GetAllStudents());
        }
        public IActionResult Create() {
            return View();
        }
    }
}
