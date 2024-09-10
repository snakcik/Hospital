using Hospital.Dtos;
using Hospital.Repository;
using Microsoft.AspNetCore.Mvc;
using static Hospital.Data.Enums.EnumMessage;

namespace Hospital.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IPatient _patient;

        public DoctorController(IPatient patient)
        {
            _patient = patient;
        }

        public IActionResult List(string keyvalue)
        {
            if (string.IsNullOrEmpty(keyvalue))
            {
                List<PatientDto> dList = _patient.GetActive().OrderBy(x => x.Name).ToList();
                return View(dList);
            }

            var dResult = _patient.Search(x =>
            x.IsDeleted == true &&
            x.Name.ToLower().Contains(keyvalue.ToLower()) ||
            x.LastName.ToLower().Contains(keyvalue) ||
            x.IdentityNumber.ToString().Contains(keyvalue)).ToList();

            return View(dResult);

        }
        public IActionResult Edit(string Id)
        {
            var UpdatedPatient = _patient.GetById(Id);
            ViewBag.Personells = _patient.GetActiveAndDoctorPersonell();
            ViewBag.Policlinics = _patient.GetActivePoliclinics();

            return View(UpdatedPatient);
        }

        [HttpPost]
        public IActionResult Edit(PatientDto patientDto, string Id)
        {
            bool result = _patient.DoctorUpdateBool(patientDto, Id);
            TempData["Message"] = GetMessageEn(ValidationStatus.Update);
            return RedirectToAction("List");


        }
    }
}
