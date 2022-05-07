using Kursach.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace Kursach.Controllers
{
    [ApiController]
    [Route("/[controller]/Index")]
    public class UserController : Controller
    {
        [HttpPost]
        public string Index(string login, string password)
        {
            User us1 = new User(login, password);
            return us1.Id;
        }


    }
}
