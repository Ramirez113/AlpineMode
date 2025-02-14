using Microsoft.AspNetCore.Mvc;

namespace AlpineMode.Controllers
{
    public class LookReportController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Reporting/Look/Index.cshtml");
        }
    }
}
