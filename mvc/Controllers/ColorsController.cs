using Microsoft.AspNetCore.Mvc;
using strona.Models;

namespace strona.Controllers
{
    public class ColorsController : Controller
    {
        // GET: ColorsController
        public ActionResult Show()
        {
            return View(ColorsRepo.GetColors());
        }

    }
}
