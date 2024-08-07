using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
    public class PatientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
