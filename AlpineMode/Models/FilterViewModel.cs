using TodoList.Entities;

namespace AlpineMode.Models
{
    public class FilterViewModel
    {
        public List<Country> Countries { get; set; } = new List<Country>();
        public List<City> Cities { get; set; } = new List<City>();
        public List<Category> Categories { get; set; } = new List<Category>();

        public int? SelectedCountryId { get; set; }
        public int? SelectedCityId { get; set; }
        public int? SelectedCategoryId { get; set; }
    }


}
