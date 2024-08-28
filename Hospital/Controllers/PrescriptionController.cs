using Hospital.Data.Entities;
using Hospital.Dtos;
using Hospital.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
    public class PrescriptionController : Controller
    {
        private readonly IPrescription _Prescription;
        private readonly IPrescriptionItems _Items;
        private readonly IPatient _patient;

        public PrescriptionController(IPrescription prescription, IPatient patient,IPrescriptionItems items)
        {
            _Prescription = prescription;
            _patient = patient;
            _Items = items;
        }

        public IActionResult Add(string patientId)
        {

            if (string.IsNullOrWhiteSpace(patientId))
            {
                return View();
            }
           ViewBag.ActivePersonell = _Prescription.GetActivePersonell();
           var patient =  _patient.GetById(patientId);
           var name = patient.Name +" "+patient.LastName;
            var Id = patient.Id;
            ViewBag.PatientId = Id;
            ViewBag.PatientName = name;

            return View();
        }
        [HttpPost]
        public IActionResult Add(PrescriptionDto prescription)
        {

           var prescriptionId = _Prescription.StringAdd(prescription);
            return RedirectToAction("AddMedicines", new { prescriptionId = prescriptionId }); ;
        }



        public IActionResult PrescriptionDetail (string patientId)
        {
            var prescription = _Prescription.GetById(patientId);

            return View(prescription);
        }

        public IActionResult AddMedicines(string prescriptionId)
        { 
            return View(); 
        }


    }
}
