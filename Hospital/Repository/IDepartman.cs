using Hospital.Data.Entities;
using Hospital.Dtos;
using System.Linq.Expressions;

namespace Hospital.Repository
{
    public interface IDepartman:IBaseRepository<DepartmanDto>
    {
        void Remove(string Id);
    }
}
