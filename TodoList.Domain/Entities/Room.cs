using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Entities
{
    public class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int CountOfPeople { get; set; }
        public int CountOfRooms { get; set; }

        [ForeignKey(nameof(Hotel))]
        public int HotelID { get; set; }
        public Hotel Hotel { get; set; }


        [ForeignKey(nameof(TypeOfRoom))]
        public int TypeOfRoomID { get; set; }
        public TypeOfRoom TypeOfRoom { get; set; }

        public string Description { get; set; }

        public virtual ICollection<PhotosRoom> PhotosRooms { get; set; }
    }
}
