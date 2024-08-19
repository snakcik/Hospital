using Hospital.Data.Entities;
using Hospital.Dtos;
using System.Linq.Expressions;

namespace Hospital.Repository
{
    public interface IDepartman:IBaseRepository<DepartmanDto>
    {
        public bool IsItAttached(string Id);
        public string strValidation(DepartmanDto entity);
        
        
    }
}
