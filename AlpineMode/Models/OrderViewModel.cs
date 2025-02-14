using TodoList.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AlpineMode.Models
{
    public class OrderViewModel
    {
        public int ID { get; set; }
        public int ClientID { get; set; }
        public int TourID { get; set; }
        public DateTime Data { get; set; }
        public List<Client> Clients { get; set; } = new();
        public List<Tour> Tours { get; set; } = new();
    }

}
