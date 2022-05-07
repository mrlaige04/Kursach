using Microsoft.AspNetCore.Mvc;

namespace Kursach.Controllers
{
    [ApiController]
    [Route("/[controller]/Index")]
    public class MealsAllController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public string Index(string name, int age) => $"{name}: {age}";


        [HttpGet]
        [Route("/hello")]
        public string Hello() => "HELLODEAR!";
    }
}