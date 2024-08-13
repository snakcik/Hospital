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
            _personnel.Add(personellDto);
            return RedirectToAction("List");
        }

        public IActionResult Delete(string id)
        {
            var departman = _personnel.GetById(id);

            _personnel.Delete(id);
            return RedirectToAction("List");
        }
    }
}


