using TodoList.Entities;

namespace AlpineMode.Models
{
    public class TourCreateViewModel
    {
        public Tour Tour { get; set; }
        public List<City> Cities { get; set; } = new();
        public List<Hotel> Hotels { get; set; } = new();
        public List<FlyCompany> Companies { get; set; } = new();
        public List<FoodSystem> MealPlans { get; set; } = new();
        public List<Country> Countries { get; set; } = new();
        public List<Category> Categories { get; set; } = new();
    }


}