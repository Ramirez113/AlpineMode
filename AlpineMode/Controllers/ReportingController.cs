using Microsoft.AspNetCore.Mvc;

namespace AlpineMode.Controllers
{
    public class ReportingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
