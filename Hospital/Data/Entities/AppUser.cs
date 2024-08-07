using Hospital.Data.Base;

namespace Hospital.Data.Entities
{
    public class AppUser:PersonBase
    {

        public string AppRoleId { get; set; }
        public AppRole AppRole { get; set; }
    }
}
