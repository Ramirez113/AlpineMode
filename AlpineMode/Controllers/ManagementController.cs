using Microsoft.AspNetCore.Mvc;

namespace AlpineMode.Controllers
{
    public class ManagementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
