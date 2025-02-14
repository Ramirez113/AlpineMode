using AlpineMode.Models;
using TodoList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AlpineMode.Controllers
{
    public class AccountController : Controller
    {

        private readonly TodoListContext _context;

        public AccountController(TodoListContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Nickname == username);
            
            if (user == null || user.Password != password)
            {
                ViewBag.Error = "Incorect password!";
                return View();
            }

            HttpContext.Session.SetString("Username", user.Nickname);

            return RedirectToAction("Index" , "Home");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
