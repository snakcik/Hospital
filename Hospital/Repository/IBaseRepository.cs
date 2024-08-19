using Hospital.Data.Base;
using Hospital.Data.Entities;
using Hospital.Dtos;
using System.Linq.Expressions;

namespace Hospital.Repository
{
    public interface IBaseRepository<TEntity> 
    {
        
            List<TEntity> GetAll();
            List<TEntity>GetActive();
            void Add(TEntity entity);
            void Update(TEntity entity, string id);
            void Delete( string id);
            void Remove(string Id);
            IQueryable<TEntity> Search(Expression<Func<TEntity, bool>> predicate);
            TEntity GetById(string id);
            bool Validation(TEntity entity);

        

    }
}
