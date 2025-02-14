using AlpineMode.Models;
using TodoList;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlpineMode.Controllers
{
    public class TourEditController : Controller
    {
        private readonly TodoListContext _context;

        public TourEditController(TodoListContext context)
        {
            _context = context;
        }

        // GET: Edit Tour
        public async Task<IActionResult> Edit(int id)
        {
            var tour = await _context.Tours
                .Include(t => t.City)
                .Include(t => t.Hotel)
                .Include(t => t.FlyCompany)
                .Include(t => t.FoodSystem)
                .Include(t => t.Category)
                .FirstOrDefaultAsync(t => t.ID == id);

            if (tour == null)
            {
                return NotFound();
            }

            var model = new EditTourViewModel
            {
                ID = tour.ID,
                Name = tour.Name,
                CityID = tour.CityID,
                HotelID = tour.HotelID,
                FlyCompanyID = tour.FlyCompanyID,
                FoodSystemID = tour.FoodSystemID,
                CategoryID = tour.CategoryID,
                Price = tour.Price,
                StartTime = tour.StartTime,
                EndTime = tour.EndTime,
                Description = tour.Description,
                Cities = await _context.Cities.ToListAsync(),
                Hotels = await _context.Hotels.ToListAsync(),
                FlyCompanies = await _context.FlyCompanies.ToListAsync(),
                FoodSystems = await _context.FoodSystems.ToListAsync(),
                Categories = await _context.Categories.ToListAsync()
            };

            return View("~/Views/Management/Edit/Edit.cshtml", model);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditTourViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Cities = await _context.Cities.ToListAsync();
                model.Hotels = await _context.Hotels.ToListAsync();
                model.FlyCompanies = await _context.FlyCompanies.ToListAsync();
                model.FoodSystems = await _context.FoodSystems.ToListAsync();
                model.Categories = await _context.Categories.ToListAsync();
                return View("~/Views/Management/Edit/Edit.cshtml", model);
            }

            var existingTour = await _context.Tours.FirstOrDefaultAsync(t => t.ID == model.ID);

            if (existingTour == null)
            {
                return NotFound();
            }

            existingTour.Name = model.Name;
            existingTour.CityID = model.CityID;
            existingTour.HotelID = model.HotelID;
            existingTour.FlyCompanyID = model.FlyCompanyID;
            existingTour.FoodSystemID = model.FoodSystemID;
            existingTour.CategoryID = model.CategoryID;
            existingTour.Price = model.Price;
            existingTour.StartTime = model.StartTime;
            existingTour.EndTime = model.EndTime;
            existingTour.Description = model.Description;

            _context.Update(existingTour);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Edit");
        }

    }
}
