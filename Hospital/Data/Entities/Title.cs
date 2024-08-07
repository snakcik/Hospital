using Hospital.Data.Base;

namespace Hospital.Data.Entities
{
    public class Title:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        
        public ICollection<Personell> Personells { get; set; }

    }
}
