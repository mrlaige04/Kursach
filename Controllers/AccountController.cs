using Microsoft.AspNetCore.Mvc;

namespace Kursach.Controllers
{
    [ApiController]

    public class AccountController : Controller
    {
        ApplicationContext db = new ApplicationContext();

        [HttpGet]
        [Route("[controller]/Index")]
        public IActionResult Index()
        {
            return View("~/Views/Account/Account.cshtml");
        }


        [HttpGet]
        [Route("[controller]/Logout")]
        public IActionResult Logout()
        {

            currentuser.isLogged = false;
            currentuser.LOGIN = null;
            return Redirect("~/");

        }
    }
}
