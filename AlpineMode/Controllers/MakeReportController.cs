using Microsoft.AspNetCore.Mvc;

namespace AlpineMode.Controllers
{
    public class MakeReportController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Reporting/Make/Index.cshtml");
        }
    }
}
