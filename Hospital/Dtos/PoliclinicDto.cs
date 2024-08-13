using Hospital.Data.Entities;

namespace Hospital.Dtos
{
    public class PoliclinicDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string PatientId { get; set; }
        public Patient Patient { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
