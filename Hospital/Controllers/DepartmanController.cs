using Hospital.Data;
using Hospital.Data.Enums;
using Hospital.Dtos;
using Hospital.Repository;
using Hospital.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using static Hospital.Data.Enums.EnumMessage;

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
            bool validation = _departmanService.Validation(departmanDto);
            if (validation == true)
            {
                _departmanService.Add(departmanDto);
                TempData["Success"] = EnumMessage.GetMessageEn(ValidationStatus.Success);
                return RedirectToAction("List");
            }
            else
                ViewBag.All = EnumMessage.GetMessageEn(ValidationStatus.All);
            return View();
            
        }

        public IActionResult Update(string id)
        {
            var departman = _departmanService.GetById(id);
            if (departman == null)
            {
                return NotFound();
            }

            return View(departman);
        }

        [HttpPost]
        public IActionResult Update(DepartmanDto departmanDto, string id)
        {
            bool validation = _departmanService.Validation(departmanDto);
            
            if (validation == true)
            {
                if (ModelState.IsValid)
            {
                _departmanService.Update(departmanDto, id);
                TempData["Update"] = EnumMessage.GetMessageEn(ValidationStatus.Update);
                    return RedirectToAction("List");
            }
            }
            else
                ViewBag.All = EnumMessage.GetMessageEn(ValidationStatus.All);
            
            return View(departmanDto);
        }

        public IActionResult Delete(string id)
        {
            bool result = _departmanService.IsItAttached(id);
            var departman = _departmanService.GetById(id);
            if (result!=true)
            {
                _departmanService.Delete(id);
                return RedirectToAction("List");
            }
            TempData["Attached"] = "Departmana Ekli Bir Personel Var";
            return RedirectToAction("List");

        }

        public IActionResult Remove(string id)
        {
          bool result =  _departmanService.IsItAttached(id);

            if (result==false)
            {
                _departmanService.Remove(id);
                return RedirectToAction("List");
            }
            return View();
        }

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
