using TodoList.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlpineMode.Models
{
    public class EditTourViewModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please select a city")]
        public int CityID { get; set; }

        [Required(ErrorMessage = "Please select a hotel")]
        public int HotelID { get; set; }

        [Required(ErrorMessage = "Please select a flight company")]
        public int FlyCompanyID { get; set; }

        [Required(ErrorMessage = "Please select a food system")]
        public int FoodSystemID { get; set; }

        [Required(ErrorMessage = "Please select a category")]
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive value")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Start date is required")]
        public DateTime StartTime { get; set; }

        [Required(ErrorMessage = "End date is required")]
        public DateTime EndTime { get; set; }

        public string Description { get; set; }

        // Для випадаючих списків
        public List<City> Cities { get; set; }
        public List<Hotel> Hotels { get; set; }
        public List<FlyCompany> FlyCompanies { get; set; }
        public List<FoodSystem> FoodSystems { get; set; }
        public List<Category> Categories { get; set; }
    }
}
