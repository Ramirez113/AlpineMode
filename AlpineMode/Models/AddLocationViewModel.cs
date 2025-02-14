using TodoList.Entities;
using System.Collections.Generic;

namespace AlpineMode.Models
{
    public class AddLocationViewModel
    {
        public List<Country> Countries { get; set; } = new List<Country>();
        public List<City> Cities { get; set; } = new List<City>();
        public Country NewCountry { get; set; } = new Country();
        public City NewCity { get; set; } = new City();
    }
}
