using Hospital.Data.Context;
using Hospital.Data.Entities;
using Hospital.Dtos;
using Hospital.Models;
using Hospital.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hospital.Controllers
{
    public class PrescriptionController : Controller
    {
        private readonly IPrescription _Prescription;
        private readonly IPrescriptionItems _Items;
        private readonly IPatient _patient;
        private readonly IInventory _inventory;
        private readonly Context _db;

        public PrescriptionController(IPrescription prescription, IPatient patient,IPrescriptionItems items,IInventory inventory,Context db)
        {
            _Prescription = prescription;
            _patient = patient;
            _Items = items;
            _inventory = inventory;
            _db = db;
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
            _Prescription.GetMedicine();
            _Prescription.Add(prescription);
            return RedirectToAction("DoctorList", "Patient");
        }



        public IActionResult PrescriptionDetail (string patientId)
        {
            var prescription = _Prescription.GetPrescriptionList(patientId);

            
            return View(prescription);
        }

        public IActionResult AddMedicines(string prescriptionId)
        {
           
            
            ViewBag.Inventory = _Items.GetInventory();

            ViewBag.PrescriptionId = prescriptionId;
            
          ViewBag.medicines = _Items.GetItems(prescriptionId);

            return View();
        }
        
        [HttpPost]
        public IActionResult AddMedicines(PrescriptionItemsDto prescription,string prescriptionId) 
        {
            _Items.Add(prescription);
            ViewBag.Inventory = _Items.GetInventory();
            ViewBag.PrescriptionId = prescriptionId;
            ViewBag.medicines = _Items.GetItems(prescriptionId);
            return View();
        }

        public IActionResult RemoveMedicine(string Id)
        {
            _Items.Remove(Id);
            string previousUrl = Request.Headers["Referer"].ToString();

            return Redirect(previousUrl);
            

            
        }

        public IActionResult PrescriptionReceptionDetail(string patientId)
        {
            var prescription = _Prescription.GetPrescriptionList(patientId);

            return View(prescription);
        }

        public IActionResult ShowMedicines(string prescriptionId)
        {
            ViewBag.Inventory = _Items.GetInventory();

            ViewBag.PrescriptionId = prescriptionId;

            ViewBag.medicines = _Items.GetItems(prescriptionId);

            return View();
        }

    }
}
