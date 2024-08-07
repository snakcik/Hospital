using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
    public class PoliclinicController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
