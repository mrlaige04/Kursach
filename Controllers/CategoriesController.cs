using Microsoft.AspNetCore.Mvc;

namespace Kursach.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
