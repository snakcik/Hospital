using Hospital.Data.Enums;
using Hospital.Dtos;
using Hospital.Repository;
using Hospital.Services;
using Microsoft.AspNetCore.Mvc;
using static Hospital.Data.Enums.EnumMessage;

namespace Hospital.Controllers
{
    public class TitleController : Controller
    {
        private readonly ITitle _titleService;

        public TitleController(ITitle title)
        {
            _titleService = title;
        }

        public IActionResult List()
        {
            List<TitleDto> tList = _titleService.GetActive();
            return View(tList);
        }

        public IActionResult AllList()
        { 
            var ActiveList = _titleService.GetAll();

            return View(ActiveList);
        }

        public IActionResult Add()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Add(TitleDto titleDto)
        {
            bool validation = _titleService.Validation(titleDto);
            if(validation==true)
            {
                _titleService.Add(titleDto);
                TempData["Message"] = GetMessageEn(ValidationStatus.Success);
                return RedirectToAction("List");
            }
            else
            {
                ViewBag.Message = GetMessageEn(ValidationStatus.All);
            }
            return View();  
        }

        public IActionResult Update(string Id) 
        {
            var result = _titleService.GetById(Id);
            return View(result);
        }
        [HttpPost]
        public IActionResult Update(TitleDto titleDto,string Id)
        {
            if (ModelState.IsValid)
            {
                _titleService.Update(titleDto, Id);
                TempData["Message"] = GetMessageEn(ValidationStatus.Update);
                return RedirectToAction("List");
            }
            return View(titleDto);
        }

        public IActionResult Delete(string id)
        {
            var title = _titleService.GetById(id);

            _titleService.Delete(id);
            return RedirectToAction("List");
        }
        public IActionResult Remove(string id)
        {
            _titleService.Remove(id);
            return RedirectToAction("List");
        }



    }
}
