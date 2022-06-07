using Kursach.Models.Spoonacular;
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
        
        /// <summary>
        /// Random Meal
        /// </summary>
        /// <returns>Web Page</returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            message = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://api.spoonacular.com/recipes/random?apiKey=83c7e059495b468e87e5ea32c1215288")
            };
            using (response = await client.SendAsync(message))
            {
                var body = response.Content.ReadAsStringAsync().Result;
                RandomMeal sresult = JsonSerializer.Deserialize<RandomMeal>(body);

                try { 
                    sresult.recipes.First().menuItems = WhereServing(sresult?.recipes.First().title).Result; 
                } catch { }
                return View("Meal", sresult?.recipes?.ToList());
            }
        }

        /// <summary>
        /// Search by Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("name")]
        [Route("/[controller]/MealByName")]
        public async Task<IActionResult> MealByName(string name)
        {
            message = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://api.spoonacular.com/recipes/complexSearch?query={name}&apiKey=83c7e059495b468e87e5ea32c1215288")
            };
            List<MealFull> mealsfull = new List<MealFull>();
            using (response = await client.SendAsync(message))
            {
                var res = response.Content.ReadAsStringAsync().Result;
                SearchResult sres = JsonSerializer.Deserialize<SearchResult>(res);
                List<string> ids = new List<string>();
                if (sres != null && sres.results != null)
                {
                    foreach (var item in sres?.results)
                    {
                        ids.Add(item.id.ToString());
                    }
                }
                mealsfull = ReturnMealsById(ids).Result;                
                return View("Meal", mealsfull);
            }
        }
    
        private async Task<MenuItems> WhereServing(string name)
        {
            message = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://api.spoonacular.com/food/menuItems/search?query={name}&apiKey=83c7e059495b468e87e5ea32c1215288")
            };
            using (var resp = await client.SendAsync(message))
            {
                var res = resp.Content.ReadAsStringAsync().Result;
                MenuItems body = new();
                if (res != null)
                {
                    body = JsonSerializer.Deserialize<MenuItems>(res);
                }
                return body;
            }
        }

        //Parse Meals by ID
        private async Task<List<MealFull>> ReturnMealsById(List<string> id)
        {
            #nullable disable
            return await Task.Run(() =>
            {
                List<MealFull> meals = new List<MealFull>();
                try
                {
                    string ids = String.Join(',', id);
                    message = new HttpRequestMessage()
                    {
                        Method = HttpMethod.Get,
                        RequestUri = new Uri($"https://api.spoonacular.com/recipes/informationBulk?ids={ids}&apiKey=83c7e059495b468e87e5ea32c1215288")
                    };
                    using (var response = client.Send(message))
                    {
                        var res = response.Content.ReadAsStringAsync().Result;
                        try
                        {
                            if (res != null) meals = JsonSerializer.Deserialize<List<MealFull>>(res);
                        } catch
                        {
                            meals = null;
                        }
                    }
                    if (meals != null)
                    {
                        foreach (var meal in meals)
                        {
                            meal.menuItems = WhereServing(meal.title).Result;
                        }
                    }
                }
                catch { }
                return meals;
            });
            #nullable restore
        }
    }
}