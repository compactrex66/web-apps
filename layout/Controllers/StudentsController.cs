using layout.Models;
using layout.Models.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace layout.Controllers
{
    public class StudentsController : Controller
    {
        // GET: StudentsController
        private readonly IStudentRepo _studentRepo;
        private readonly string? _connectionString;
        public StudentsController(IConfiguration configuration) {
            _connectionString = configuration.GetConnectionString("mysql");
            _studentRepo = new MySqlStudentRepo(_connectionString);
        }
        public ActionResult List()
        {
            return View(_studentRepo.GetAllStudents());
        }
        [HttpGet]
        public IActionResult Create() {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student student) {
            if(ModelState.IsValid) {
                _studentRepo.AddStudent(student);
                return RedirectToAction("List");
            }
            return View();
        }
        public IActionResult Delete(int? id) {
            _studentRepo.DeleteStudent();
            return RedirectToAction("List");
        }
    }
}
