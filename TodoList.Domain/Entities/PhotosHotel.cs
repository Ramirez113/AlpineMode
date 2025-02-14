using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Entities
{
    public class PhotosHotel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string FilePath { get; set; }

        [ForeignKey(nameof(Hotel))]
        public int HotelID { get; set; }
        public Hotel Hotel { get; set; }
    }
}
