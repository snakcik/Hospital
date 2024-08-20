using Hospital.Data.Enums;
using Hospital.Dtos;
using Hospital.Repository;
using Hospital.Services;
using Microsoft.AspNetCore.Mvc;
using static Hospital.Data.Enums.EnumMessage;

namespace Hospital.Controllers
{
    public class PoliclinicController : Controller
    {
        private readonly IPoliclinic _policlinic;

        public PoliclinicController(IPoliclinic policlinic)
        {
            _policlinic = policlinic;
        }

        public IActionResult List(string keyvalue)
        {
            if (string.IsNullOrEmpty(keyvalue))
            {
                var pList = _policlinic.GetActive().OrderBy(x => x.Name).ToList();
                return View(pList);
            }
          var result = _policlinic.Search(x=> x.IsDeleted == true && x.Name.ToLower().Contains(keyvalue.ToLower())).ToList();
            return View(result);
        }

        public IActionResult AllList()
        { 
            var AllList = _policlinic.GetAll().OrderBy(x => x.Name).ToList();

            return View(AllList);
        }

        public IActionResult Add()
        {

            return View();
        }

        [HttpPost] 
        public IActionResult Add(PoliclinicDto policlinicDto)
        {
            bool Validation = _policlinic.Validation(policlinicDto);
            if (Validation == true)
            {
                _policlinic.Add(policlinicDto);
                TempData["Message"] = GetMessageEn(ValidationStatus.Success);
                return RedirectToAction("List");
            }
            else ViewBag.Message = GetMessageEn(ValidationStatus.All);
            return View();

            
        }

        public IActionResult Update (string Id)
        {
            var result = _policlinic.GetById(Id);

            return View(result);

        }

        [HttpPost]
        public IActionResult Update (PoliclinicDto policlinicDto, string Id)
        {
            bool validation = _policlinic.Validation(policlinicDto);

            if (validation == true) {
                if (ModelState.IsValid)
                {
                    _policlinic.Update(policlinicDto, Id);
                    TempData["Message"] = GetMessageEn(ValidationStatus.Update);
                    return RedirectToAction("List");
                }
            }
            TempData["Message"] = GetMessageEn(ValidationStatus.All);

            return View(policlinicDto);  
        }


        public IActionResult Delete(string id)
        {
            var departman = _policlinic.GetById(id);
            TempData["Message"] = EnumMessage.GetMessageEn(ValidationStatus.Delete);
            _policlinic.Delete(id);
            return RedirectToAction("List");
        }
        public IActionResult Remove(string id)
        {
            _policlinic.Remove(id);
            TempData["Message"] = EnumMessage.GetMessageEn(ValidationStatus.PermanentMessage);
            return RedirectToAction("List");
        }
    }
}
