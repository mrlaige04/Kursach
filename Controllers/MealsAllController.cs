using Kursach.Models.Edamam_Food;
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
            //var asyncresult = MealsIdAsync($"https://www.themealdb.com/api/json/v1/1/filter.php?i={ingredient}");
            //return View("Meal", asyncresult.Result);
            message = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://www.themealdb.com/api/json/v1/1/filter.php?i={ingredient}")
            };

            using (response = client.Send(message))
            {
                var body = response.Content.ReadAsStringAsync().Result;
                ListOfMeals meals = JsonSerializer.Deserialize<ListOfMeals>(body);
                //return Redirect($"../MealsAll/MealById?id={meals?.meals.First().idMeal}");
                return View("Meal", ReturnMealsById(CalculateIdsAsync(meals)?.Result?.ToArray()).Result);
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
                return View("Meal", ReturnMealsById(CalculateIdsAsync(meals)?.Result?.ToArray()).Result);
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
                return View("Meal", ReturnMealsById(CalculateIdsAsync(meals)?.Result?.ToArray()).Result);
            }
        }

        

        private async Task<List<string>> CalculateIdsAsync(ListOfMeals meals)
        {
            return await Task.Run(async () => {
                
                List<string> ids = new List<string>();
                if (meals != null && meals.meals != null)
                {
                    foreach (var item in meals?.meals)
                    {
                        ids.Add(item.idMeal);
                    }
                }
                return ids;
            });
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
                var res = response.Content.ReadAsStringAsync().Result;
                var recipes = JsonSerializer.Deserialize<ListOfMeals>(res);
                return View("Meal", recipes);
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
                return View("Meal", ReturnMealsById(CalculateIdsAsync(meals)?.Result?.ToArray()).Result);

            }



        }





        



        // Parse Meals by ID
        private async Task<ListOfMeals> ReturnMealsById(params string[] id)
        {
            return await Task.Run(() => {
                ListOfMeals meals = new ListOfMeals();
                try
                {
                    foreach (var item in id)
                    {
                        message = new HttpRequestMessage()
                        {
                            Method = HttpMethod.Get,
                            RequestUri = new Uri($"https://www.themealdb.com/api/json/v1/1/lookup.php?i={item}")
                        };
                        using (var response = client.Send(message))
                        {
                            var res = response.Content.ReadAsStringAsync().Result;
                            var recipes = JsonSerializer.Deserialize<ListOfMeals>(res);
                            foreach (var recps in recipes?.meals)
                            {
                                meals.meals.Add(recps);
                            }
                        }
                    }
                }
                catch
                {

                    //return null;

                }
                return meals;

            });
            
        }
    }
}