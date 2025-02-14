using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using TodoList;
using TodoList.Entities;

namespace AlpineMode.Controllers
{
    public class ReportingLookController : Controller
    {
        private readonly TodoListContext _context;

        public ReportingLookController(TodoListContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var ordersPerMonth = _context.Orders
                .GroupBy(o => o.Data.Month)
                .ToDictionary(g => $"Month {g.Key}", g => g.Count());

            var popularCountries = _context.Orders
                .Where(o => o.Tour != null && o.Tour.City != null)
                .GroupBy(o => o.Tour.City.Name)
                .OrderByDescending(g => g.Count())
                .Take(5)
                .ToDictionary(g => g.Key, g => g.Count());

            var popularTours = _context.Orders
                .Where(o => o.Tour != null)
                .GroupBy(o => o.Tour.Name)
                .OrderByDescending(g => g.Count())
                .Take(5)
                .ToDictionary(g => g.Key, g => g.Count());

            ViewBag.OrdersPerMonth = ordersPerMonth;
            ViewBag.PopularCountries = popularCountries;
            ViewBag.PopularTours = popularTours;

            return View("Index");
        }
    }
}
