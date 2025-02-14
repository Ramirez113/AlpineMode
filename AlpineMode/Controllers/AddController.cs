using AlpineMode.Models;
using TodoList;
using TodoList.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class AddController : Controller
{
    private readonly TodoListContext _context;

    public AddController(TodoListContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var model = new TourCreateViewModel
        {
            Cities = await _context.Cities.ToListAsync(),
            Hotels = await _context.Hotels.ToListAsync(),
            Companies = await _context.FlyCompanies.ToListAsync(),
            MealPlans = await _context.FoodSystems.ToListAsync(),
            Countries = await _context.Countries.ToListAsync(),
            Categories = await _context.Categories.ToListAsync()
        };

        return View("~/Views/Management/Add/Index.cshtml", model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(TourCreateViewModel model)
    {
        if (!ModelState.IsValid)
        {
            ModelState.AddModelError("", "Please fill in all the required fields.");
            return await LoadViewDataAndReturn(model);
        }

        var tour = new Tour
        {
            CityID = model.Tour.CityID,
            HotelID = model.Tour.HotelID,
            FlyCompanyID = model.Tour.FlyCompanyID,
            FoodSystemID = model.Tour.FoodSystemID,
            CategoryID = model.Tour.CategoryID,
            Price = model.Tour.Price,
            StartTime = model.Tour.StartTime,
            EndTime = model.Tour.EndTime,
            Description = model.Tour.Description
        };

        if (tour.CityID == 0 || tour.HotelID == 0 || tour.FlyCompanyID == 0 || tour.FoodSystemID == 0 || tour.CategoryID == 0)
        {
            ModelState.AddModelError("", "Please fill in all the required fields.");
            return await LoadViewDataAndReturn(model);
        }

        if (tour.StartTime >= tour.EndTime)
        {
            ModelState.AddModelError("", "Start date must be earlier than end date.");
            return await LoadViewDataAndReturn(model);
        }

        try
        {
            _context.Tours.Add(tour);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", $"Error while saving: {ex.Message}");
            return await LoadViewDataAndReturn(model);
        }
    }


    private async Task<IActionResult> LoadViewDataAndReturn(TourCreateViewModel model)
    {
        model.Cities = await _context.Cities.ToListAsync();
        model.Hotels = await _context.Hotels.ToListAsync();
        model.Companies = await _context.FlyCompanies.ToListAsync();
        model.MealPlans = await _context.FoodSystems.ToListAsync();
        model.Countries = await _context.Countries.ToListAsync();
        model.Categories = await _context.Categories.ToListAsync();

        return View("~/Views/Management/Add/Index.cshtml", model);
    }

}
