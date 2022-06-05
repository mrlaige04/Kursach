namespace Kursach.Models.Spoonacular
{
    public class MenuItems
    {
        public int number { get; set; }
        public MenuItem[] menuItems { get; set; }
    }
    public class MenuItem
    {
        public int id { get; set; }
        public string title { get; set; }
        public string image { get; set; }
        public string restaurantChain { get; set; }
    }
}
