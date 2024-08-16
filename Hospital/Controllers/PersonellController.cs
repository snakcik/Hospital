using Hospital.Data.Context;
using Hospital.Data.Entities;
using Hospital.Dtos;
using Hospital.Repository;
using Hospital.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hospital.Controllers
{
    public class PersonellController : Controller
    {
        private readonly Context _db;
        private readonly IPersonell _personnel;
       

        public PersonellController(IPersonell personnel,Context context, ITitle title)
        {
            _db = context;
            _personnel = personnel;
          
        }


        public IActionResult List()
        {
            List<PersonellDto> pList = _personnel.GetActive();

            return View(pList);
        }

        public IActionResult AllList()
        { 
            var AllList = _personnel.GetAll();
            
            return View(AllList); 
        }

        public IActionResult Add() 
        {
            ViewBag.Titles = _personnel.GetActiveTitle();
            ViewBag.Departman = _personnel.GetActiveDepartman();

            return View();
        }

        [HttpPost]  
        public IActionResult Add(PersonellDto personellDto)
        {

           bool result = _personnel.AddBool(personellDto);
            
            if (result != false)
            {
                TempData["Message"] = "Kayıt İşlemi Başarılı";
                return RedirectToAction("List");
               
            }
            else
            {
                ViewBag.Personell = false;
                ViewBag.Message = "This Identity Number already used";
            }

            ViewBag.Titles = _personnel.GetActiveTitle();
            ViewBag.Departman = _personnel.GetActiveDepartman();
            return View(personellDto);


        }

        public IActionResult Update (string Id)
        {
            var Person = _personnel.GetById(Id);
            ViewData["Titles"] = new SelectList(_db.Titles, "Id", "Name");
            ViewData["Departman"] = new SelectList(_db.Departmens, "Id", "Name");

            return View(Person);
        }

        [HttpPost]
        public IActionResult Update(PersonellDto personellDto,string Id)
        {

            if (ModelState.IsValid)
            {
               bool result = _personnel.UpdateBool(personellDto, Id);
                if (result != false)
                {
                    TempData["Message"] = "Güncelleme İşlemi Başarılı";
                    return RedirectToAction("List");
                                        
                }
                ViewBag.Personell = false;
                ViewBag.Message = "This Identity Number alrady Used";
                
                 
            }
            ViewBag.Titles = _personnel.GetActiveTitle();
            ViewBag.Departman = _personnel.GetActiveDepartman();
            return View(personellDto);
        }

        public IActionResult Delete(string id)
        {
            var departman = _personnel.GetById(id);

            _personnel.Delete(id);
            return RedirectToAction("List");
        }
        public IActionResult Remove(string id)
        {
            _personnel.Remove(id);
            return RedirectToAction("List");
        }
    }
}


