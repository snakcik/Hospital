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
            ViewBag.Personells = _patient.GetActiveAndDoctorPersonell();
            ViewBag.Policlinics = _patient.GetActivePoliclinics(); 
           
            return View();
        }
        [HttpPost]
        public IActionResult Add(PatientDto patientDto) 
        {
            //_patient.Add(patientDto);
           bool isDuplicate = _patient.AddBool(patientDto);
            TempData["Message"] = "Kayıt İşlemi Başarılı";
            if (isDuplicate==false)
            {
                ViewBag.Patient = false;
                ViewBag.Message = "This Identity Number already used";
                ViewBag.Personells = _patient.GetActiveAndDoctorPersonell();
                ViewBag.Policlinics = _patient.GetActivePoliclinics();
                return View("Add");
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
            if (ModelState.IsValid)
            {
                
               bool result =  _patient.UpdateBool(patientDto, Id);
                if (result == true)
                {
                    TempData["Message"] = "Güncelleme İşlemi Başarılı";
                    return RedirectToAction("List");
                }
                else
                {
                    ViewBag.Personell = false;
                    ViewBag.Message = "This Identity Number alrady Used";
                }
                
            }
            ViewBag.Personells = _patient.GetActiveAndDoctorPersonell();
            ViewBag.Policlinics = _patient.GetActivePoliclinics();
            return View(patientDto);
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
