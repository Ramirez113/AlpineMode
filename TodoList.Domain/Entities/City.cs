using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Entities
{
    public class City
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }


        [ForeignKey(nameof(Country))]
        public int CountryID { get; set; }
        public Country Country { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
        public virtual ICollection<Tour> Tours { get; set; }

    }
}
