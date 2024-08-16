using Hospital.Dtos;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hospital.Repository
{
    public interface IPersonell : IBaseRepository<PersonellDto>
    {
       public bool AddBool (PersonellDto entity);
        public bool UpdateBool(PersonellDto entity, string id);
        public List<SelectListItem> GetActiveTitle();
        public List<SelectListItem> GetActiveDepartman();
    }
}
