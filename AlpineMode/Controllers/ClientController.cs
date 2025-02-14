using AlpineMode.Models;
using TodoList;
using TodoList.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace AlpineMode.Controllers
{
    public class ClientController : Controller
    {
        private readonly TodoListContext _context;

        public ClientController(TodoListContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            var model = new RegisterClientViewModel
            {
                Cities = await _context.Cities.ToListAsync() ?? new List<City>()
            };

            return View("~/Views/Request/Make/Index.cshtml", model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterClientViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Cities = await _context.Cities.ToListAsync();
                return View("~/Views/Request/Make/Index.cshtml", model);
            }

            var existingClient = await _context.Clients
                .FirstOrDefaultAsync(c => c.Name == model.Name && c.Surname == model.Surname);

            if (existingClient != null)
            {
                var existingClientModel = new ExistingClientViewModel
                {
                    Name = existingClient.Name,
                    Surname = existingClient.Surname,
                    Age = existingClient.Age,
                    Address = existingClient.Address,
                    City = await _context.Cities.FirstOrDefaultAsync(c => c.ID == existingClient.CityID)
                };

                return View("~/Views/Request/Make/Have/Index.cshtml", existingClientModel);
            }

            var client = new Client
            {
                Name = model.Name,
                Surname = model.Surname,
                Age = model.Age,
                Address = model.Address,
                CityID = model.CityID
            };

            _context.Clients.Add(client);
            await _context.SaveChangesAsync();

            HttpContext.Session.SetInt32("ClientID", client.ID);
            HttpContext.Session.SetString("ClientName", client.Name);
            HttpContext.Session.SetString("ClientSurname", client.Surname);

            return View("~/Views/Request/Make/Next/Index.cshtml");
        }
    }
}
