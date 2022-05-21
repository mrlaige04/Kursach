using Kursach.Models.Meals;
using Kursach.Models.User;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

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

                if (db.Users.Where(user => user.login == log).Count() > 0)
                {
                    throw new Exception();
                }
                db.Users.Add(us1);
                db.SaveChanges();
                ViewData["successfullsignup"] = true;
            }
            catch
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
                if (db.Users.Where(user => (user.login == log))?.Where(user => user.password == pas).Count() > 0)
                {
                    currentuser.isLogged = true;
                    currentuser.LOGIN = log.ToString();
                    
                }
                else
                {
                    currentuser.isLogged = false;
                }
            }
            catch
            {
                currentuser.isLogged = false;
            }
            return View("~/Views/Account/Account.cshtml");
        }




        


        [HttpPost]
        [Route("~/[controller]/UnLikeRecept")]
        public void UnLikeRecept(string id) // TODO : DELETE CREATED MEALS BY NAME
        {
            if(currentuser.isLogged == true)
            {
                HttpClient client = new HttpClient();
                HttpRequestMessage message = new HttpRequestMessage()
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://www.themealdb.com/api/json/v1/1/lookup.php?i={id}")
                };
                using (var response = client.Send(message))
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    Meal meal = JsonSerializer.Deserialize<ListOfMeals>(result).meals.First();
                    db.Users.Where(user => user.login == currentuser.LOGIN).First().RemoveRecipe(meal);
                    db.SaveChanges();
                }
                
            }
            
        }


        [HttpPost]
        [Route("~/[controller]/LikeRecept")]
        public void LikeRecept(string id)
        {
            if (currentuser.isLogged == true)
            {
                Meal meal;
                HttpClient client = new HttpClient();
                HttpRequestMessage message = new HttpRequestMessage()
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://www.themealdb.com/api/json/v1/1/lookup.php?i={id}")
                };
                using (var response = client.Send(message))
                {
                    meal = JsonSerializer.Deserialize<ListOfMeals>(response.Content.ReadAsStringAsync().Result).meals.First();
                }
                db.Users.Where(user => user.login == currentuser.LOGIN)?.First()?.AddRecipe(meal);
                db.SaveChanges();
            }
            else
            {
                Response.StatusCode = 403;
                return;
            }
            
        }


        [HttpPost]
        [Route("~/[controller]/CreateNew")]
        public void CreateNew()
        {
            var img = Request.Form["mealimg"].ToString();
            var name = Request.Form["mealname"].ToString();
            var area = Request.Form["mealarea"].ToString();
            var tag = Request.Form["mealtag"].ToString();
            var Instructions = Request.Form["mealinstructions"].ToString();

            Meal meal = new Meal() { strMealThumb = img, strMeal = name, strArea = area, strTags = tag, strInstructions = Instructions };
            if (currentuser.isLogged == true)
            {
                db.Users.Where(user => user.login == currentuser.LOGIN)?.First()?.AddRecipe(meal);
                db.SaveChanges();
            }
            else
            {
                Response.StatusCode = 403;
                return;
            }
            Response.Redirect("../Account/Index");
        }

    }
}
