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
            ViewData["Titles"] = new SelectList(_db.Titles, "Id", "Name");
            ViewData["Departman"] = new SelectList(_db.Departmens, "Id", "Name");
            return View();
        }

        [HttpPost]  
        public IActionResult Add(PersonellDto personellDto)
        {

           bool result = _personnel.AddBool(personellDto);
            TempData["Message"] = "Kayıt İşlemi Başarılı";
            if (result == false)
            {
                ViewBag.Personell = false;
                ViewBag.Message = "This Identity Number already used";
            }
            return RedirectToAction("List");
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
                _personnel.Update(personellDto, Id);
                TempData["Message"] = "Güncelleme İşlemi Başarılı";
                return RedirectToAction("List");
            }
           

            return View();
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


