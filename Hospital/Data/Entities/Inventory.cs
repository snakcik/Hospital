using Hospital.Data.Base;

namespace Hospital.Data.Entities
{
    public class Inventory:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }

    }
}
