using Microsoft.AspNetCore.Mvc;
using TodoList;
using TodoList.Entities;
using AlpineMode.Models;
using System.Linq;

namespace AlpineMode.Controllers
{
    public class AddLocationController : Controller
    {
        private readonly TodoListContext _context;

        public AddLocationController(TodoListContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = new AddLocationViewModel
            {
                Countries = _context.Countries.ToList(),
                Cities = _context.Cities.ToList()
            };

            return View("~/Views/Management/Add/Add Country/Index.cshtml", model);
        }

        [HttpPost]
        public IActionResult AddCountry(AddLocationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                TempData["Error"] = "Validation failed: " + string.Join(", ", errors);

                model.Countries = _context.Countries.ToList();
                model.Cities = _context.Cities.ToList();
                return View("~/Views/Management/Add/Add Country/Index.cshtml", model);
            }

            _context.Countries.Add(model.NewCountry);
            _context.SaveChanges();
            TempData["Success"] = "Country added successfully!";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AddCity(AddLocationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                TempData["Error"] = "Validation failed: " + string.Join(", ", errors);

                model.Countries = _context.Countries.ToList();
                model.Cities = _context.Cities.ToList();
                return View("~/Views/Management/Add/Add Country/Index.cshtml", model);
            }

            _context.Cities.Add(model.NewCity);
            _context.SaveChanges();
            TempData["Success"] = "City added successfully!";
            return RedirectToAction("Index");
        }
    }
}
