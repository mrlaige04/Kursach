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
        public string Index(string login, string password)
        {
            User us1 = new User(login, password);
            
            db.Users.Add(us1);
            db.SaveChanges();
            return us1.hash;
        }

        [HttpGet]
        public string Index()
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
