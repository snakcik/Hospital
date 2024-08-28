using Hospital.Data.Base;

namespace Hospital.Data.Entities
{
    public class PrescriptionItems : BaseEntity
    {
        public string PrescriptionId { get; set; }
        public string InventoryId { get; set; }
        public int Piece { get; set; }

        public ICollection<Inventory>inventories {get; set;}
        public ICollection<Prescription>? Prescriptions { get; set; }

    }
}
