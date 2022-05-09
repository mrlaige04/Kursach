using Kursach.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace Kursach.Controllers
{
    [ApiController]
    [Route("/[controller]/Index")]
    public class UserController : Controller
    {
        public ApplicationContext db = new ApplicationContext();


        [HttpPost]
        public IActionResult Index()
        {
            var log = Request.Form["login"].ToString();
            var pas = Request.Form["password"].ToString();
            User us1 = new User(log, pas);

            try
            {
                
                if(db.Users.Where(user=>user.login == log).Count()>0)
                {
                    throw new Exception();
                }
                db.Users.Add(us1);
                db.SaveChanges();
                ViewData["successfullsignup"] = true;
            } catch
            {
                
                ViewData["successfullsignup"] = false;
            }
            return View("~/Views/Account/Account.cshtml");
            
        }



        [HttpPost]
        [Route("~/User/Logining")]
        public IActionResult Logining()
        {
            var log = Request.Form["login"].ToString();
            var pas = Request.Form["password"].ToString();

            try
            {
                if(db.Users.Where(user=>(user.login==log))?.Where(user=>user.password==pas).Count()>0)
                {
                    ViewData["LOGGEDIN"] = true;
                    ViewData["CURRENTUSERLOGIN"] = log.ToString();
                } else {
                    ViewData["LOGGEDIN"] = false;
                }
            } catch
            {
                ViewData["LOGGEDIN"] = false;
            }
            return View("~/Views/Account/Account.cshtml");
        }
        



        [HttpGet]
        [Route("[controller]/UsersAll")]
        public string UsersAll()
        {
            string ret = "";
            var users = db.Users.ToList();
            foreach (var item in users)
            {
                ret += item.ToString();
                ret += "\n";
            }
            return ret;
        }



        [HttpGet("login")]
        public string Index(string login)
        {
            string ret = "";
            var users = db.Users.Where(user => user.login == login).Select(user => user);
            foreach (var item in users)
            {
                ret += item.ToString();
                ret += "\n";
            }
            return ret;
        }
    }
}
