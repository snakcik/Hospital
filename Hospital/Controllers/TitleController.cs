using Hospital.Dtos;
using Hospital.Repository;
using Hospital.Services;
using Microsoft.AspNetCore.Mvc;

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
            _titleService.Add(titleDto);

            return RedirectToAction("List");
        }
        
        public IActionResult Delete(string id)
        {
            var title = _titleService.GetById(id);

            _titleService.Delete(id);
            return RedirectToAction("List");
        }



    }
}
