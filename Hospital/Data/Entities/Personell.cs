using Hospital.Data.Base;

namespace Hospital.Data.Entities
{
    public class Personell:PersonBase
    {

        public string TitleId { get; set; }
        public string DepartmanId { get; set; }

        public Departman Departman { get; set; }
        public Title Title { get; set; }
        public ICollection<Patient> Patients { get; set; }
    }
}
