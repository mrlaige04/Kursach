using Microsoft.AspNetCore.Mvc;

namespace Kursach.Controllers
{
    [ApiController]
    [Route("[controller]/Index")]
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Account/Account.cshtml");
        }
    }
}
