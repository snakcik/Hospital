namespace Hospital.Data.Base

{
    public abstract class PersonBase:BaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int IdentityNumber { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }


    }
}
