namespace Hospital.Data.Base
{
    public abstract class BaseEntity
    {
        public string Id { get; set; }
        public bool ActivePasive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public BaseEntity()
        {
            Id = Guid.NewGuid().ToString();
            CreatedAt = DateTime.Now;
            ActivePasive = true;
        }

    }
}
