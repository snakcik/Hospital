using Hospital.Data.Base;
using Hospital.Data.Entities;
using Hospital.Dtos;
using System.Linq.Expressions;

namespace Hospital.Repository
{
    public interface IBaseRepository<TEntity> 
    {
        List<DepartmanDto> GetAll();
        void Add(TEntity entity);
        void Update(TEntity entity, string Id);
        void Delete(string Id);
        IQueryable<TEntity> Serach(Expression<Func<TEntity, bool>> predicate);
        DepartmanDto GetById(string Id);

    }
}
