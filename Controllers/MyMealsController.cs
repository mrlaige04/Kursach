using Kursach.Models.Meals;
using Microsoft.AspNetCore.Mvc;
namespace Kursach.Controllers
{

    

    /// <summary>
    /// My Meals
    /// </summary>
    [ApiController]
    [Route("/[controller]/GetAll")]
    public class MyMealsController : Controller
    {


        /// <summary>
        /// Get My Meals
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string GetAll()
        {
            return "getall";
        }




        /// <summary>
        /// Put meal to own recipe book
        /// </summary>
        /// <param name="meal"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/[controller]/SendMeal")]
        public string SendMeal(Meal meal)
        {
            return "sendmeal";
        }



        /// <summary>
        /// Delete recipe from book
        /// </summary>
        /// <param name="meal"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("/[controller]/DeleteMeal")]
        public string DeleteMeal(Meal meal)
        {
            return "delete";
        }

    }
}
