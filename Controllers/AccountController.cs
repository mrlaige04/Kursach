using Microsoft.AspNetCore.Mvc;

namespace Kursach.Controllers
{
    [ApiController]
    
    public class AccountController : Controller
    {
        [HttpGet]
        [Route("[controller]/Index")]
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
            return Redirect("~/");
            
        }
    }
}
