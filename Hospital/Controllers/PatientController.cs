using Hospital.Data.Context;
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
    public class PatientController : Controller
    {
        private readonly IPatient _patient;
        private readonly IPrescription _prescription;
        private readonly IPrescriptionItems _prescriptionItems;
        private readonly Context _db;

        public PatientController(IPatient patient, Context context, IPrescriptionItems prescriptionItems, IPrescription prescription)
        {
            
            _prescription = prescription;
            _patient = patient;
            _db = context;
            _prescriptionItems = prescriptionItems;
        }

        public IActionResult List(string keyvalue)
        {
            if (string.IsNullOrEmpty(keyvalue))
            {
                List<PatientDto> pList = _patient.GetActive().OrderBy(x => x.Name).ToList();
                return View(pList);
            }
            
            var result = _patient.Search(x=>
            x.IsDeleted == true &&
            x.Name.ToLower().Contains(keyvalue.ToLower())||
            x.LastName.ToLower().Contains(keyvalue)|| 
            x.IdentityNumber.ToString().Contains(keyvalue)).ToList();
               
                

            return View(result);


        }
        public IActionResult AllList()
        {
            var AllPatient = _patient.GetAll().OrderBy(x => x.Name).ToList();
            return View(AllPatient);

        }
        public IActionResult Add()
        {
            ViewBag.Personells = _patient.GetActiveAndDoctorPersonell();
            ViewBag.Policlinics = _patient.GetActivePoliclinics(); 
           
            return View();
        }
        [HttpPost]
        public IActionResult Add(PatientDto patientDto) 
        {
           bool validation = _patient.Validation(patientDto);
            if (validation == true)
            {
                bool dublicate = _patient.AddBool(patientDto);
                if (dublicate == true)
                {
                    TempData["Message"] = GetMessageEn(ValidationStatus.Success);
                    
                }
                else
                {
                    ViewBag.Personells = _patient.GetActiveAndDoctorPersonell();
                    ViewBag.Policlinics = _patient.GetActivePoliclinics();
                    ViewBag.Message = GetMessageEn(ValidationStatus.Dublicate);
                    return View(patientDto);
                }

            }
            else
            {
                ViewBag.Personells = _patient.GetActiveAndDoctorPersonell();
                ViewBag.Policlinics = _patient.GetActivePoliclinics();
                ViewBag.Validation = GetMessageEn(ValidationStatus.All);
                return View(patientDto);
            }

            return RedirectToAction("List");
       

        }

        public IActionResult Update(string Id)
        {
            var UpdatedPatient = _patient.GetById(Id);
            ViewBag.Personells = _patient.GetActiveAndDoctorPersonell();
            ViewBag.Policlinics = _patient.GetActivePoliclinics();



            return View(UpdatedPatient);
        }
        [HttpPost]
        public IActionResult Update(PatientDto patientDto  ,string Id)
        {
            bool validation = _patient.Validation(patientDto);
            if(validation==true) 
            {
                if (ModelState.IsValid)
                {

                    bool result = _patient.UpdateBool(patientDto, Id);
                    if (result == true)
                    {
                        TempData["Message"] = GetMessageEn(ValidationStatus.Update);
                        return RedirectToAction("List");
                    }
                    else
                    {
                        ViewBag.Personell = false;
                        ViewBag.Message = GetMessageEn(ValidationStatus.Dublicate);
                    }

                }
                ViewBag.Personells = _patient.GetActiveAndDoctorPersonell();
                ViewBag.Policlinics = _patient.GetActivePoliclinics();
                return View(patientDto);
            }
            ViewBag.Message = GetMessageEn(ValidationStatus.All);
            ViewBag.Personells = _patient.GetActiveAndDoctorPersonell();
            ViewBag.Policlinics = _patient.GetActivePoliclinics();
            return View(patientDto);
        }
        public IActionResult Delete(string id)
        {
            var departman = _patient.GetById(id);
            TempData["Message"] = GetMessageEn(ValidationStatus.Delete);
            _patient.Delete(id);
            return RedirectToAction("List");
        }
        public IActionResult Remove(string id)
        {
            _patient.Remove(id);
            TempData["Message"] = GetMessageEn(ValidationStatus.PermanentMessage);
            return RedirectToAction("List");
        }
        public IActionResult Detail(string Id) 
        {
            var result = _patient.GetByIdName(Id);
        
            return View(result);
        }
    }
}
