using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoList.Entities;
using System.Threading.Tasks;
using TodoList;
using AlpineMode.Models;

namespace AlpineMode.Controllers
{
    public class NextController : Controller
    {
        private readonly TodoListContext _context;

        public NextController(TodoListContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Countries = await _context.Countries.ToListAsync();
            ViewBag.Cities = await _context.Cities.ToListAsync();
            ViewBag.Categories = await _context.Categories.ToListAsync();

            return View("Next");
        }


        [HttpPost]
        public async Task<IActionResult> Filter(FilterViewModel model)
        {
            if (model.SelectedCountryId.HasValue)
            {
                var cities = await _context.Cities
                    .Where(c => c.CountryID == model.SelectedCountryId.Value)
                    .ToListAsync();
                model.Cities = cities;
            }

            return View("FilteredResults", model);
        }
    }
}
