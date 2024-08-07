using Hospital.Data.Base;

namespace Hospital.Data.Entities
{
    public class AppRole:BaseEntity
    {
        public string Name { get; set; }

        public ICollection<AppUser> AppUser{ get; set; }
    }
}
