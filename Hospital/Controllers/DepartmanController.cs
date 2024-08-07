using Hospital.Dtos;
using Hospital.Repository;
using Hospital.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Controllers
{
    public class DepartmanController : Controller
    {
        //burada dependency injection da Context i denemek için ekledim ama olması gerektiğini düşündüğüm şey departman
        
        protected IDepartman _departman;


        public DepartmanController( IDepartman departman )
        {
           
            _departman = departman;
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(DepartmanDto departmanDto)
        {
           _departman.Add(departmanDto);

           
            return View();
        }
    }
}
