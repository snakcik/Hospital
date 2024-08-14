using Hospital.Data.Context;
using Hospital.Dtos;
using Hospital.Repository;
using Hospital.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hospital.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatient _patient;
        private readonly Context _db;

        public PatientController(IPatient patient, Context context)
        {
            _patient = patient;
            _db = context;
        }

        public IActionResult List()
        {
            List<PatientDto> pList = _patient.GetActive();

            return View(pList);
        }
        public IActionResult AllList()
        {
            var AllPatient = _patient.GetAll();
            return View(AllPatient);

        }


        public IActionResult Add()
        {
            ViewData["Personells"] = new SelectList(_db.Personells, "Id", "Name");
            ViewData["Policlinics"] = new SelectList(_db.Policlinics, "Id", "Name");

            return View();
        }

        [HttpPost]
        public IActionResult Add(PatientDto patientDto) 
        {
            _patient.Add(patientDto);

            return RedirectToAction("List");
        }

        public IActionResult Update(string Id)
        {
            var UpdatedPatient = _patient.GetById(Id);
            ViewData["Personells"] = new SelectList(_db.Personells, "Id", "Name");
            ViewData["Policlinics"] = new SelectList(_db.Policlinics, "Id", "Name");

            

            return View(UpdatedPatient);
        }

        [HttpPost]
        public IActionResult Update(PatientDto patientDto  ,string Id)
        {
            if (ModelState.IsValid)
            {
                _patient.Update(patientDto, Id);
                return RedirectToAction("List");
            }

            return View();
        }

        public IActionResult Delete(string id)
        {
            var departman = _patient.GetById(id);

            _patient.Delete(id);
            return RedirectToAction("List");
        }
        public IActionResult Remove(string id)
        {
            _patient.Remove(id);
            return RedirectToAction("List");
        }
        public IActionResult Detail(string Id) 
        {
            var result = _patient.GetById(Id);
        
            return View(result);
        }
    }
}
