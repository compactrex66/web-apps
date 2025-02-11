using Microsoft.AspNetCore.Mvc;

namespace layoutGry.Controllers
{
    public class GameController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
