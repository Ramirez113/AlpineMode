using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Entities
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [ForeignKey(nameof(Client))]
        public int ClientID { get; set; }
        public Client Client { get; set; }

        [ForeignKey(nameof(Tour))]
        public int TourID { get; set; }
        public Tour Tour { get; set; }
        public DateTime Data { get; set; }

    }
}
