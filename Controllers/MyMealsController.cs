using Kursach.Models.Meals;
using Microsoft.AspNetCore.Mvc;
namespace Kursach.Controllers
{
    [ApiController]
    [Route("/[controller]/getall")]
    public class MyMealsController : Controller
    {
        [HttpGet]
        public string GetAll()
        {
            return "getall";
        }


        [HttpPost]
        [Route("/[controller]/sendmeal")]
        public string SendMeal(Meal meal)
        {
            return "sendmeal";
        }


        [HttpDelete]
        [Route("/[controller]/deletemeal")]
        public string DeleteMeal(Meal meal)
        {
            return "delete";
        }

    }
}
