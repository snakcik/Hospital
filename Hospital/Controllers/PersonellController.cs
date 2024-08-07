using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
    public class PersonellController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
