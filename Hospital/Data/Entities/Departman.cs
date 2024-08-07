using Hospital.Data.Base;

namespace Hospital.Data.Entities
{
    public class Departman:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Personell> Personell { get; set; }

    }
}
