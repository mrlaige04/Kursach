namespace Kursach.Models.Spoonacular
{
    public class MealFull
    {
        #region MainInfo
        public int id { get; set; }
        public string title { get; set; }
        public int readyInMinutes { get; set; }
        public string sourceUrl { get; set; }
        public string image { get; set; }
        public string[] dishTypes { get; set; }
        public ingredient[] extendedIngredients { get; set; }
        #endregion



        public string instructions { get; set; }
        public string spoonacularSourceUrl { get; set; }


        public MenuItems menuItems { get; set; }
        
    }

    public record Restaurant
    {
        public int id { get; set; }
        public string title { get; set; }
        public string restaurantChain { get; set; }
        public int image { get; set; }

    }

    public record ingredient
    {
        public int id { get; set; }
        public string name { get; set; }
        public string nameClean { get; set; }
        public Measures measures { get; set; }
        public record Measures
        {
            public meas us { get; set; }
            public meas metric { get; set; }
            public record meas
            {
                public float amount { get; set; }
                public string unitLong { get; set; }
            }

        }
    }


    

}
