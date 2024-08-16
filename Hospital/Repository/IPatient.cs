using Hospital.Dtos;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hospital.Repository
{
    public interface IPatient : IBaseRepository<PatientDto>
    {
        bool AddBool(PatientDto entity);
        public List<SelectListItem> GetActivePoliclinics();
        public List<SelectListItem> GetActiveAndDoctorPersonell();
        
    }
}
