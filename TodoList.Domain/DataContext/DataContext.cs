using TodoList.Entities;
using Microsoft.EntityFrameworkCore;

namespace TodoList
{
    public class TodoListContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<FlyCompany> FlyCompanies { get; set; }
        public DbSet<FoodSystem> FoodSystems { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderRoom> OrderRooms { get; set; }
        public DbSet<PhotosHotel> PhotosHotels { get; set; }
        public DbSet<PhotosRoom> PhotosRooms { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<TypeOfRoom> TypeOfRooms { get; set; }
        public DbSet<User> Users { get; set; }

        public TodoListContext(DbContextOptions<TodoListContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Client)
                .WithMany()
                .HasForeignKey(o => o.ClientID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Tour)
                .WithMany()
                .HasForeignKey(o => o.TourID)
                .OnDelete(DeleteBehavior.Restrict);

            // Можна додати обмеження для інших зв’язків
        }
    }
}
