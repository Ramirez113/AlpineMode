using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Entities
{
    public class Tour
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryID { get; set; }
        public Category Category { get; set; }

        [ForeignKey(nameof(City))]
        public int CityID { get; set; }
        public City City { get; set; }

        public decimal Price { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        [ForeignKey(nameof(Hotel))]
        public int HotelID { get; set; }
        public Hotel Hotel { get; set; }

        [ForeignKey(nameof(FlyCompany))]
        public int FlyCompanyID { get; set; }
        public FlyCompany FlyCompany { get; set; }

        [ForeignKey(nameof(FoodSystem))]
        public int FoodSystemID { get; set; }
        public FoodSystem FoodSystem { get; set; }

        public string Description { get; set; }

    }
}
    