using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
    public class InventoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
