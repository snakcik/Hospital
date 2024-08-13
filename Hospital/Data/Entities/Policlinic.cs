using Hospital.Data.Base;

namespace Hospital.Data.Entities
{
    public class Policlinic:BaseEntity
    {
        public string Name { get; set; }
       
        ICollection<Patient>? Patient { get; set; }
    }
}
