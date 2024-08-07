using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
    public class TitleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
