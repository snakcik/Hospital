using Hospital.Dtos;
using Hospital.Repository;
using Hospital.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Controllers
{
    public class DepartmanController : Controller
    {
        private readonly IDepartman _departmanService;

        public DepartmanController(IDepartman departmanService)
        {
            _departmanService = departmanService;
        }

        public IActionResult List()
        {
            var departmanList = _departmanService.GetAll();
            return View(departmanList);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(DepartmanDto departmanDto)
        {
            
                _departmanService.Add(departmanDto);
                return RedirectToAction("Index");
            
            
        }

        public IActionResult Edit(string id)
        {
            var departman = _departmanService.GetById(id);
            if (departman == null)
            {
                return NotFound();
            }
            return View(departman);
        }

        [HttpPost]
        public IActionResult Edit(DepartmanDto departmanDto, string id)
        {
            if (ModelState.IsValid)
            {
                _departmanService.Update(departmanDto, id);
                return RedirectToAction("Index");
            }
            return View(departmanDto);
        }

        public IActionResult Delete(string id)
        {
            var departman = _departmanService.GetById(id);
            if (departman == null)
            {
                return NotFound();
            }
            return View(departman);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(string id)
        {
            _departmanService.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Details(string id)
        {
            var departman = _departmanService.GetById(id);
            if (departman == null)
            {
                return NotFound();
            }
            return View(departman);
        }
    }
}
