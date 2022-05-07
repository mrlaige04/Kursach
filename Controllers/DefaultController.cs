using Microsoft.AspNetCore.Mvc;

namespace Kursach.Controllers
{


    /// <summary>
    /// Welcome Page
    /// </summary>
    [ApiController]
    [Route("/")]
    public class DefaultController : Controller
    {
        public IActionResult Hello()
        {
            return View("~/Views/Hello/Hello.cshtml");
        }


        [HttpGet]
        [Route("/APIDOCS")]
        public IActionResult APIDOCS()
        {
            return View("~/Views/APIDOCS.cshtml");
        }
    }
}
