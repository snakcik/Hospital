using Hospital.Dtos;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hospital.Repository
{
    public interface IPatient : IBaseRepository<PatientDto>
    {
        bool AddBool(PatientDto entity);
        public bool UpdateBool(PatientDto entity, string id);
        public List<SelectListItem> GetActivePoliclinics();
        public List<SelectListItem> GetActiveAndDoctorPersonell();
        public PatientDto GetByIdName(string id);

    }
}
