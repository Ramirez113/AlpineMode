using AlpineMode.Models;
using TodoList;
using TodoList.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class TourController : Controller
{
    private readonly TodoListContext _context;

    public TourController(TodoListContext context)
    {
        _context = context;
    }


    // GET: Edit Tour
    public async Task<IActionResult> Edit(int id)
    {

        var tour = await _context.Tours
            .FirstOrDefaultAsync(t => t.ID == id);


        if (tour == null)
        {
            return NotFound();
        }


        var model = new TourCreateViewModel
        {
            Tour = tour,
            Cities = await _context.Cities.ToListAsync() ?? new List<City>(),
            Hotels = await _context.Hotels.ToListAsync() ?? new List<Hotel>(),
            Companies = await _context.FlyCompanies.ToListAsync() ?? new List<FlyCompany>(),
            MealPlans = await _context.FoodSystems.ToListAsync() ?? new List<FoodSystem>(),
            Categories = await _context.Categories.ToListAsync() ?? new List<Category>()
        };

        return View(model);
    }



    // POST: Edit Tour
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, TourCreateViewModel model)
    {
        if (id != model.Tour.ID)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(model.Tour);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Tours.Any(e => e.ID == model.Tour.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index)); 
        }

        model.Cities = await _context.Cities.ToListAsync();
        model.Hotels = await _context.Hotels.ToListAsync();
        model.Companies = await _context.FlyCompanies.ToListAsync();
        model.MealPlans = await _context.FoodSystems.ToListAsync();
        model.Categories = await _context.Categories.ToListAsync();

        return View(model);
    }
}
