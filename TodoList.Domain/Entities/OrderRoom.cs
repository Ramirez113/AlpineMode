using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Entities
{
    public class OrderRoom
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [ForeignKey(nameof(Order))]
        public int OrderID { get; set; }
        public Order Order { get; set; }

        [ForeignKey(nameof(Room))]
        public int RoomID { get; set; }
        public Room Room { get; set; }
    }
}
