using Hospital.Data.Entities;

namespace Hospital.Dtos
{
    public class PrescriptionItemsDto
    {
        public string Id { get; set; }
        public string PrescriptionId { get; set; }
        public string InventoryId { get; set; }
        public List<string> InventoryNames { get; set; }
        public List<PrescriptionItemsDto> PrescriptionItems { get; set; }
        public Inventory inventory { get; set; }

    }
}
