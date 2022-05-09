using Kursach.Models.Meals;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
namespace Kursach.Controllers
{



    /// <summary>
    /// GetMeals from MEALDB(API)
    /// </summary>
    [ApiController]
    [Route("/[controller]/Index")]
    public class MealsAllController : Controller
    {
        HttpClient client = new HttpClient();
        HttpRequestMessage message;
        HttpResponseMessage response;
        string body = "";




        /// <summary>
        /// Random Meal
        /// </summary>
        /// <returns>Web Page</returns>
        [HttpGet]
        public IActionResult Index()
        {
            message = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://www.themealdb.com/api/json/v1/1/random.php")
            };

            using (response = client.Send(message))
            {
                var body = response.Content.ReadAsStringAsync().Result;
                ListOfMeals meals = JsonSerializer.Deserialize<ListOfMeals>(body);
                return View("Meal", meals);
            }
        }




        /// <summary>
        /// Search by ingredient
        /// </summary>
        /// <param name="ingredient"></param>
        /// <returns></returns>
        [HttpGet("ingredient")]
        [Route("/[controller]/MealByMainIngredient")]
        public IActionResult MealByMainIngredient(string ingredient)
        {
            message = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://www.themealdb.com/api/json/v1/1/filter.php?i={ingredient}")
            };

            using (response = client.Send(message))
            {
                var body = response.Content.ReadAsStringAsync().Result;
                ListOfMeals meals = JsonSerializer.Deserialize<ListOfMeals>(body);
                return View("Meal", meals);
            }
        }





        /// <summary>
        /// Search by category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpGet("category")]
        [Route("/[controller]/MealByCategory")]
        public IActionResult MealByCategory(string category)
        {
            message = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://www.themealdb.com/api/json/v1/1/filter.php?c={category}")
            };

            using (response = client.Send(message))
            {
                var body = response.Content.ReadAsStringAsync().Result;
                ListOfMeals meals = JsonSerializer.Deserialize<ListOfMeals>(body);
                return View("Meal", meals);
            }
        }




        /// <summary>
        /// Search by Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("name")]
        [Route("/[controller]/MealByName")]
        public IActionResult MealByName(string name)
        {
            message = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://www.themealdb.com/api/json/v1/1/search.php?s={name}")
            };

            using (response = client.Send(message))
            {
                var body = response.Content.ReadAsStringAsync().Result;
                ListOfMeals meals = JsonSerializer.Deserialize<ListOfMeals>(body);
                return View("Meal", meals);
            }
        }





        /// <summary>
        /// Search by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("id")]
        [Route("/[controller]/MealById")]
        public IActionResult MealById(long id)
        {
            message = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://www.themealdb.com/api/json/v1/1/lookup.php?i={id}")
            };
            using (var response = client.Send(message))
            {
                var body = response.Content.ReadAsStringAsync().Result;
                ListOfMeals meals = JsonSerializer.Deserialize<ListOfMeals>(body);
                return View("Meal", meals);
            }
        }




        /// <summary>
        /// Search by Area(Geography)
        /// </summary>
        /// <param name="area"></param>
        /// <returns></returns>
        [HttpGet("area")]
        [Route("/[controller]/AreaMeal")]
        public IActionResult AreaMeal(string area)
        {
            message = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://www.themealdb.com/api/json/v1/1/filter.php?a={area}")
            };

            using (response = client.Send(message))
            {
                var body = response.Content.ReadAsStringAsync().Result;
                ListOfMeals meals = JsonSerializer.Deserialize<ListOfMeals>(body);
                return View("Meal", meals);

            }



        }
    }
}