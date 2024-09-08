using Hospital.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hospital.Models
{
    public class PrescriptionVM
    {
        public string PrescriptionId { get; set; }
        public string MedicineId { get; set; }
        public string DoctorId { get; set; }
        public string PatientId { get; set; }
        public string Description { get; set; }
        public Prescription prescription {  get; set; }
        public SelectList Medicine { get; set; }
    }
}
