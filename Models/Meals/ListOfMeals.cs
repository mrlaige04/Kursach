using Kursach.Models.Edamam_Food;

namespace Kursach.Models.Meals
{
    public class ListOfMeals
    {
        public List<Meal> meals { get; set; } = new List<Meal>();

        public FoodEdamam edamam { get; set; }
    }
}
