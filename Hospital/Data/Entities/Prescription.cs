using Hospital.Data.Base;
using System.Diagnostics.CodeAnalysis;

namespace Hospital.Data.Entities
{
    public class Prescription: BaseEntity
    {
     
        public string PatientId { get; set; }
        public string? PersonellId { get; set; }
        public string Description { get; set; }
        
        public PrescriptionItems PrescriptionItems { get; set; }      
        public Personell? Personell { get; set; }
        public Patient?   Patient { get; set; }

    }
}
