using Microsoft.AspNetCore.Mvc;

namespace AlpineMode.Controllers
{
    public class MakeRequestController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Request/Make/Index.cshtml");
        }
    }
}
