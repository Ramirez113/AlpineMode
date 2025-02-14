using Microsoft.AspNetCore.Mvc;

namespace AlpineMode.Controllers
{
    public class AccController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
