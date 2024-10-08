﻿using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hospital.Dtos
{
    public class PrescriptionDto
    {
        public string Id { get; set; }
        public string DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string PatientId { get; set; }
        public string PatientIdentity{ get; set; }
        public string PatientName { get; set; } 
        public string Description { get; set; }
        public string MedicineId { get; set; }
        public string PrescriptionId { get; set; }  
        public SelectList MedicineList {  get; set; }
        public List<string> SelectedMedicineIds { get; set; }
        public int Pieces {  get; set; }    
        public DateTime CreteDate { get; set; }
    }
}
