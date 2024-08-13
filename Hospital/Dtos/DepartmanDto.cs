namespace Hospital.Dtos
{
    public class DepartmanDto
    {
        public string? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool ? IsDeleted { get; set; }
        public DateTime? DeletedTime { get; set; }
    }
}
