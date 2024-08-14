using Hospital.Dtos;
using Hospital.Repository;
using Hospital.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
    public class PoliclinicController : Controller
    {
        private readonly IPoliclinic _policlinic;

        public PoliclinicController(IPoliclinic policlinic)
        {
            _policlinic = policlinic;
        }

        public IActionResult List()
        {
           var pList = _policlinic.GetActive();
            return View(pList);
        }

        public IActionResult AllList()
        { 
            var AllList = _policlinic.GetAll();

            return View(AllList);
        }

        public IActionResult Add()
        {

            return View();
        }

        [HttpPost] 
        public IActionResult Add(PoliclinicDto policlinicDto)
        {
            _policlinic.Add(policlinicDto);
            return RedirectToAction("List");
        }

        public IActionResult Update (string Id)
        {
            var result = _policlinic.GetById(Id);

            return View(result);

        }

        [HttpPost]
        public IActionResult Update (PoliclinicDto policlinicDto, string Id)
        {
            if(ModelState.IsValid)
            {
                _policlinic.Update(policlinicDto,Id);
                return RedirectToAction("List");
            }

            return View(policlinicDto);  
        }


        public IActionResult Delete(string id)
        {
            var departman = _policlinic.GetById(id);

            _policlinic.Delete(id);
            return RedirectToAction("List");
        }
        public IActionResult Remove(string id)
        {
            _policlinic.Remove(id);
            return RedirectToAction("List");
        }
    }
}
