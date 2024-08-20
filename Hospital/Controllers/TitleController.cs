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

        public IActionResult List(string keyvalue)
        {
            if (string.IsNullOrEmpty(keyvalue))
            {

                List<TitleDto> tList = _titleService.GetActive().OrderBy(x => x.Name).ToList();
                return View(tList);
            }
         
            var result = _titleService.Search(x=>x.IsDeleted==true&&
            x.Name.ToLower().Contains(keyvalue.ToLower())).ToList();
            return View(result);
        }

        public IActionResult AllList()
        { 
            var ActiveList = _titleService.GetAll().OrderBy(x => x.Name).ToList();

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
            bool validation = _titleService.Validation(titleDto);
            if(validation==true)
            {
                if (ModelState.IsValid)
                {
                    _titleService.Update(titleDto, Id);
                    TempData["Message"] = GetMessageEn(ValidationStatus.Update);
                    return RedirectToAction("List");
                }
            }
            TempData["Message"] = GetMessageEn(ValidationStatus.All);
            return View(titleDto);
        }

        public IActionResult Delete(string id)
        {
            var title = _titleService.GetById(id);

            _titleService.Delete(id);
            TempData["Message"] = EnumMessage.GetMessageEn(ValidationStatus.Delete);
            return RedirectToAction("List");
        }
        public IActionResult Remove(string id)
        {
            _titleService.Remove(id);
            TempData["Message"] = EnumMessage.GetMessageEn(ValidationStatus.PermanentMessage);
            return RedirectToAction("List");
        }



    }
}
