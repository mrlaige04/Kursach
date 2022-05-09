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

        
        [HttpGet]
        [Route("[controller]/Logout")]
        public  IActionResult Logout()
        {
            
            ViewData["LOGGEDIN"] = false;
            ViewData["CURRENTUSERLOGIN"] = null;
            return View("~/Views/Hello/Hello.cshtml");
            
        }
    }
}
