using Microsoft.EntityFrameworkCore.Metadata;

namespace Hospital.Dtos
{
    public class PatientDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int IdentityNumber { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Illness { get; set; }
        public string Diagnosis { get; set; }
        public string Policlinic { get; set; }
        public string Personell { get; set; }
        public bool? IsDeleted { get; set; }
        public string FullName { get; set; }

    }

}
