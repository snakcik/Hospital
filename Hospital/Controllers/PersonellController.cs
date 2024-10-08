﻿using Hospital.Data.Context;
using Hospital.Data.Entities;
using Hospital.Data.Enums;
using Hospital.Dtos;
using Hospital.Repository;
using Hospital.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static Hospital.Data.Enums.EnumMessage;

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


        public IActionResult List(string keyvalue)
        {
            if (string.IsNullOrEmpty(keyvalue))
            {
                List<PersonellDto> pList = _personnel.GetActive().OrderBy(x => x.Name).ToList();

                return View(pList);
            }
            var result = _personnel.Search(x => 
         x.IsDeleted == true &&
         x.Name.ToLower().Contains(keyvalue.ToLower()) ||
         x.LastName.ToLower().Contains(keyvalue.ToLower()) ||
         x.Title.ToLower().Contains(keyvalue.ToLower())    ||
         x.IdentityNumber.ToString().Contains(keyvalue)).ToList();



            return View(result);
        }
        public IActionResult Details(string Id)
        {
            var result = _personnel.GetByIdName(Id);
            return View(result);
        }

        public IActionResult AllList()
        { 
            var AllList = _personnel.GetAll().OrderBy(x => x.Name).ToList();

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
           bool validation = _personnel.Validation(personellDto);
             if(validation ==true)
                {
                bool result = _personnel.AddBool(personellDto);

                if (result != false)
                {
                    TempData["Message"] =GetMessageEn(ValidationStatus.Success);
                    return RedirectToAction("List");

                }
                else
                {
                    ViewBag.Personell = false;
                    ViewBag.Message = GetMessageEn(ValidationStatus.Dublicate);
                }

                ViewBag.Titles = _personnel.GetActiveTitle();
                ViewBag.Departman = _personnel.GetActiveDepartman();
                return View(personellDto);
              }

            else
            {
                ViewBag.Validation = GetMessageEn(ValidationStatus.All);
                ViewBag.Titles = _personnel.GetActiveTitle();
                ViewBag.Departman = _personnel.GetActiveDepartman();
            }
            
             return View();
           


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

            bool validation = _personnel.Validation(personellDto);
            if(validation==true)
            {
                if (ModelState.IsValid)
                {
                    bool result = _personnel.UpdateBool(personellDto, Id);
                    if (result != false)
                    {
                        TempData["Message"] = GetMessageEn(ValidationStatus.Update);
                        return RedirectToAction("List");

                    }
                    ViewBag.Personell = false;
                    ViewBag.Message = GetMessageEn(ValidationStatus.Dublicate);


                }
                ViewBag.Titles = _personnel.GetActiveTitle();
                ViewBag.Departman = _personnel.GetActiveDepartman();
                return View(personellDto);
            }
            ViewBag.Message = GetMessageEn(ValidationStatus.All);
            ViewBag.Titles = _personnel.GetActiveTitle();
            ViewBag.Departman = _personnel.GetActiveDepartman();
            return View(personellDto);
        }

        public IActionResult Delete(string id)
        {
            
            var departman = _personnel.GetById(id);

            _personnel.Delete(id);
            TempData["Message"] = EnumMessage.GetMessageEn(ValidationStatus.Delete);
            return RedirectToAction("List");
        }
        public IActionResult Remove(string id)
        {
            _personnel.Remove(id);
            TempData["Message"] = EnumMessage.GetMessageEn(ValidationStatus.PermanentMessage);
            return RedirectToAction("List");
        }
    }
}


