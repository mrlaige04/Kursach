namespace Kursach.Models.Edamam_Food
{
    public class FoodEdamam
    {
        public string text { get; set; }
        public Hint[] hints { get; set; }
    }

    public class Hint
    {
        public Food food { get; set; }
        public record Food
        {
            public string foodId { get; set; }
            public string uri { get; set; }
            public string label { get; set; }
        }
        public string category { get; set; }
        public string foodContentsLabel { get; set; }
        public string image { get; set; }
    }
}
