using Hospital.Data;
using Hospital.Data.Enums;
using Hospital.Dtos;
using Hospital.Repository;
using Hospital.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis;
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

        public IActionResult List(string keyvalue)
        {
            if (string.IsNullOrEmpty(keyvalue))
            {
                var list = _departmanService.GetActive().OrderBy(x=>x.Name).ToList();
                
                return View(list);
            }
            else
            {
                var result = _departmanService.Search(x => x.IsDeleted == true && x.Name.ToLower().Contains(keyvalue.ToLower())).ToList();
                return View(result);
            }

            

        }
        public IActionResult AllList()
        {
            var AllList = _departmanService.GetAll().OrderBy(x => x.Name).ToList();
            return View(AllList);
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
                TempData["Message"] = EnumMessage.GetMessageEn(ValidationStatus.Success);
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
             
                _departmanService.Update(departmanDto, id);
                TempData["Update"] = EnumMessage.GetMessageEn(ValidationStatus.Update);
                    return RedirectToAction("List");
            
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
                TempData["Message"] = EnumMessage.GetMessageEn(ValidationStatus.Delete);
                return RedirectToAction("List");
            }
            TempData["Attached"] = EnumMessage.GetMessageEn(ValidationStatus.AttachedDepartman);
            return RedirectToAction("List");

        }

        public IActionResult Remove(string id)
        {
          bool result =  _departmanService.IsItAttached(id);

            if (result==false)
            {
                _departmanService.Remove(id);
                TempData["Message"] = EnumMessage.GetMessageEn(ValidationStatus.PermanentMessage);
                return RedirectToAction("List");
            }
            return View();
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
