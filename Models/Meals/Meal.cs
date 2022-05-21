namespace Kursach.Models.Meals
{
    public class Meal
    {
        public string idMeal { get; set; }
        public string strMeal { get; set; }
        public string strDrinkAlternate { get; set; }
        public string strCategory { get; set; }
        public string strArea { get; set; }
        public string strInstructions { get; set; }
        public string strMealThumb { get; set; }
        public string strTags { get; set; }
        public string strYoutube { get; set; }

        public List<string> ingredients;


        public void SetIngrs()
        {
            ingredients = SummarizeIngredients();
        }
        private List<string> SummarizeIngredients()
        {
            List<string> ingrs = new List<string>();
            ingrs.Add(strIngredient1);
            ingrs.Add(strIngredient2);
            ingrs.Add(strIngredient3);
            ingrs.Add(strIngredient4);
            ingrs.Add(strIngredient5);
            ingrs.Add(strIngredient6);
            ingrs.Add(strIngredient7);
            ingrs.Add(strIngredient8);
            ingrs.Add(strIngredient9);
            ingrs.Add(strIngredient10);
            ingrs.Add(strIngredient11);
            ingrs.Add(strIngredient12);
            ingrs.Add(strIngredient13);
            ingrs.Add(strIngredient14);
            ingrs.Add(strIngredient15);
            ingrs.Add(strIngredient16);
            ingrs.Add(strIngredient17);
            ingrs.Add(strIngredient18);
            ingrs.Add(strIngredient19);
            ingrs.Add(strIngredient20);
            return ingrs;
        }

        #region Ingredients
        public string strIngredient1 { get; set; }
        public string strIngredient2 { get; set; }
        public string strIngredient3 { get; set; }
        public string strIngredient4 { get; set; }
        public string strIngredient5 { get; set; }
        public string strIngredient6 { get; set; }
        public string strIngredient7 { get; set; }
        public string strIngredient8 { get; set; }
        public string strIngredient9 { get; set; }
        public string strIngredient10 { get; set; }
        public string strIngredient11 { get; set; }
        public string strIngredient12 { get; set; }
        public string strIngredient13 { get; set; }
        public string strIngredient14 { get; set; }
        public string strIngredient15 { get; set; }
        public string strIngredient16 { get; set; }
        public string strIngredient17 { get; set; }
        public string strIngredient18 { get; set; }
        public string strIngredient19 { get; set; }
        public string strIngredient20 { get; set; }

        #endregion

        #region Measures
        public string strMeasure1 { get; set; }
        public string strMeasure2 { get; set; }
        public string strMeasure3 { get; set; }
        public string strMeasure4 { get; set; }
        public string strMeasure5 { get; set; }
        public string strMeasure6 { get; set; }
        public string strMeasure7 { get; set; }
        public string strMeasure8 { get; set; }
        public string strMeasure9 { get; set; }
        public string strMeasure10 { get; set; }
        public string strMeasure11 { get; set; }
        public string strMeasure12 { get; set; }
        public string strMeasure13 { get; set; }
        public string strMeasure14 { get; set; }
        public string strMeasure15 { get; set; }
        public string strMeasure16 { get; set; }
        public string strMeasure17 { get; set; }
        public string strMeasure18 { get; set; }
        public string strMeasure19 { get; set; }
        public string strMeasure20 { get; set; }

        #endregion


        public string strSource { get; set; }
        public string strImageSource { get; set; }


    }
}
