using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TodoList;

namespace AlpineMode.Controllers
{
    public class HistoryController : Controller
    {
        private readonly TodoListContext _context;

        public HistoryController(TodoListContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var orders = _context.Orders
                                 .Include(o => o.Client) 
                                 .Include(o => o.Tour)    
                                 .OrderByDescending(o => o.Data) 
                                 .ToList();

            ViewBag.Orders = orders;
            return View();
        }
    }
}
