using TodoList.Entities;

namespace AlpineMode.Models
{
    internal class ExistingClientViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public City City { get; set; }
    }
}