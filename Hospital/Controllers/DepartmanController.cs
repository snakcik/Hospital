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
            var result = _departmanService.GetActive();
            return View(result);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(DepartmanDto departmanDto)
        {
            
                _departmanService.Add(departmanDto);
                return RedirectToAction("List");
            
            
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

            _departmanService.Delete(id);
            return RedirectToAction("List");
        }

        public IActionResult Remove(string id)
        {
            _departmanService.Remove(id);
            return RedirectToAction("List");
        }

        //[HttpPost, ActionName("Delete")]
        //public IActionResult DeleteConfirmed(string id)
        //{
        //    _departmanService.Delete(id);
        //    return RedirectToAction("Index");
        //}
        public IActionResult AllList()
        {
            var AllList = _departmanService.GetAll();
            return View(AllList);
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
