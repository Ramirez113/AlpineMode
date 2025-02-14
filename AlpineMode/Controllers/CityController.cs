using TodoList;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlpineMode.Controllers
{
    public class CityController : Controller
    {
        private readonly TodoListContext _context;

        public CityController(TodoListContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetCitiesByCountry(int id)
        {
            var cities = await _context.Cities.Where(c => c.CountryID == id).Select(c => new { c.ID, c.Name }).ToListAsync();
            return Json(cities);
        }
    }

}
