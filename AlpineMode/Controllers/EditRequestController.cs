using Microsoft.AspNetCore.Mvc;

namespace AlpineMode.Controllers
{
    public class EditRequestController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Request/Edit/Index.cshtml");
        }
    }
}
