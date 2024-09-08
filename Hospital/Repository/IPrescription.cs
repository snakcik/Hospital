
using Hospital.Dtos;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hospital.Repository
{
    public interface IPrescription : IBaseRepository<PrescriptionDto>
    {
        public List<SelectListItem> GetActivePersonell();
        public List<SelectListItem> GetActivePatient();
        public List<SelectList> GetMedicine();
        public List<PrescriptionDto> GetPrescriptionList(string Id);
        public string StringAdd(PrescriptionDto entity);
    }
}
