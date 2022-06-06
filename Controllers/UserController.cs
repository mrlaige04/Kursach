
using Kursach.Models.Spoonacular;
using Kursach.Models.User;
using Microsoft.AspNetCore.Mvc;

using System.Text.Json;

namespace Kursach.Controllers
{
    [ApiController]
    [Route("/[controller]/Index")]
    public class UserController : Controller
    {
        public ApplicationContext db = new();


        

        [HttpPost]
        public IActionResult Index()
        {
            var log = Request.Form["login"].ToString();
            var pas = Request.Form["password"].ToString();
            User us1 = new User(log, pas,db);
            

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
                    Response.Cookies.Append("login", log);
                    //currentuser.isLogged = true;
                    //currentuser.LOGIN = log.ToString();
                    
                }
                else
                {
                    Response.Cookies.Append("login", "");
                    //currentuser.isLogged = false;
                }
            }
            catch
            {
                Response.Cookies.Append("login", "");
                //currentuser.isLogged = false;
            }
            //return View("~/Views/Account/Account.cshtml");
            return Redirect("~/Account/Index");
        }




        


        [HttpPost]
        [Route("~/[controller]/UnLikeRecept")]
        public IActionResult UnLikeRecept(string id) // TODO : DELETE CREATED MEALS BY NAME
        {
            var log = Request.Cookies["login"];
            if(!string.IsNullOrEmpty(Request.Cookies["login"]))
            {
                var usersLog = db.Users.FirstOrDefault(user => user.login == log);
                usersLog.RemoveRecipe(id, log);
                //db.Users.Where(user => user.login == log).First().RemoveRecipe(id);
                db.SaveChanges();
            }
            return Redirect("~/Account/Index");
            //if(currentuser.isLogged == true)
            //{
            //    db.Users.Where(user => user.login == currentuser.LOGIN).First().RemoveRecipe(id);
            //    db.SaveChanges();
            //}

        }


        
        [HttpPost]
        [Route("~/[controller]/LikeRecept")]
        public void LikeRecept(string id)
        {
            var login = Request.Cookies["login"];
            
            
            if(!string.IsNullOrEmpty(login))
            {
                MealFull likedmeal;
                HttpClient client = new HttpClient();
                HttpRequestMessage message = new HttpRequestMessage()
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://api.spoonacular.com/recipes/{id}/information?apiKey=83c7e059495b468e87e5ea32c1215288")
                };
                using (var response = client.Send(message))
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    likedmeal = JsonSerializer.Deserialize<MealFull>(res);
                }
                db.Users.Where(user => user.login == login)?.First()?.AddRecipe(likedmeal,login);
                db.SaveChanges();
            }
            //if (currentuser.isLogged == true)
            //{
            //    MealFull likedmeal;
            //    HttpClient client = new HttpClient();
            //    HttpRequestMessage message = new HttpRequestMessage()
            //    {
            //        Method = HttpMethod.Get,
            //        RequestUri = new Uri($"https://api.spoonacular.com/recipes/{id}/information?apiKey=83c7e059495b468e87e5ea32c1215288")
            //    };
            //    using (var response = client.Send(message))
            //    {
            //        var res = response.Content.ReadAsStringAsync().Result;
            //        likedmeal = JsonSerializer.Deserialize<MealFull>(res);
            //    }
            //    db.Users.Where(user => user.login == currentuser.LOGIN)?.First()?.AddRecipe(likedmeal);
            //    db.SaveChanges();
            //}
            //else
            //{
            //    Response.StatusCode = 403;
            //    return;
            //}

        }


        [HttpPost]
        [Route("~/[controller]/CreateNew")]
        public void CreateNew()
        {
            var img = Request.Form["mealimg"].ToString();
            var name = Request.Form["mealname"].ToString();
            var readyinminutes = Request.Form["readyInMinutes"].ToString();
            
            var Instructions = Request.Form["mealinstructions"].ToString();

            MealFull meal = new();
            meal.image = img;
            meal.title = name;
            meal.readyInMinutes = int.Parse(readyinminutes);
            meal.instructions = Instructions;


            meal.id = (readyinminutes.ToString() + name.ToString()).GetHashCode();

            //meal.ingredients = ingredients.Split(',').ToList();


            var login = Request.Cookies["login"];

            if (!string.IsNullOrEmpty(login))
            {
                try
                {
                    var usersLog = db.Users.FirstOrDefault(user => user.login == login);
                    usersLog.AddRecipe(meal, login);
                } catch
                {
                    
                }
            }
            else
            {
                Response.StatusCode = 403;
                return;
            }
            Response.Redirect("../Account/Index");
        }




        [HttpGet]
        [Route("~/[controller]/GetEditRecipePage")]
        public IActionResult GetEditRecipePage(int id)
        {
            var User = db.Users.Where(user => user.login == currentuser.LOGIN).First();
            User.listrecipes = JsonSerializer.Deserialize<List<MealFull>>(User.recipes);
            return View("~/Views/Account/EditPage.cshtml", User.listrecipes.Where(recipe=>recipe.id==id).First());
        }


        [HttpPost]
        [Route("~/[controller]/EditRecipe")]
        public IActionResult EditRecipe() // TODO: EDIT RECIPE
        {
            var img = Request.Form["imagesrc"].ToString();
            var title = Request.Form["title"].ToString();
            var readyin = Request.Form["readyin"].ToString();
            var instructions = Request.Form["instructions"].ToString();
            var id = Request.Form["id"].ToString();

            var curuser = db.Users.Where(user => user.login == currentuser.LOGIN).First();
            var recipe = curuser.listrecipes.Where(recipe => recipe.id.ToString() == id).First();
            recipe.image = img;
            recipe.title = title;
            recipe.readyInMinutes = int.Parse(readyin);
            recipe.instructions = instructions;
            return Redirect("~/Account/Index");
        }
    }
}
