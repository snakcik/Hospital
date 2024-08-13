namespace Hospital.Dtos
{
    public class InventoryDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? DeletedTime{ get; set; }
    }
}
