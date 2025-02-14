using TodoList;
using Microsoft.AspNetCore.Mvc;

namespace AlpineMode.Controllers
{
    public class RequestController : Controller
    {


        public IActionResult Index()
        {
            return View();
        }
    }
}
