using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoList;

namespace AlpineMode.Controllers
{
    public class EditController : Controller
    {
        private readonly TodoListContext _context;

        public EditController(TodoListContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var tours = _context.Tours
                .Include(t => t.City)
                .Include(t => t.Hotel)
                .Include(t => t.FlyCompany)
                .Include(t => t.FoodSystem)
                .Include(t => t.Category)
                .ToList();

            return View("~/Views/Management/Edit/Index.cshtml", tours);
        }

        [HttpPost]
        public IActionResult SelectTour(int tourId)
        {
            return RedirectToAction("Edit", "TourEdit", new { id = tourId });
        }
    }
}
