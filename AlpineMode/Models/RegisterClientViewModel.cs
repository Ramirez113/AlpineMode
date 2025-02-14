using TodoList.Entities;
using System.ComponentModel.DataAnnotations;

namespace AlpineMode.Models
{
    public class RegisterClientViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public int CityID { get; set; }

        public List<City> Cities { get; set; } = new();

        public RegisterClientViewModel()
        {
            Cities = new List<City>();
        }
    }

}
