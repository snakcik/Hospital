using Hospital.Dtos;
using Hospital.Repository;
using System.Linq.Expressions;

namespace Hospital.Services
{
    public class PrescriptionItemsService : IPrescriptionItems
    {
        public void Add(PrescriptionItemsDto entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<PrescriptionItemsDto> GetActive()
        {
            throw new NotImplementedException();
        }

        public List<PrescriptionItemsDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public PrescriptionItemsDto GetById(string id)
        {
            throw new NotImplementedException();
        }

        public void Remove(string Id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<PrescriptionItemsDto> Search(Expression<Func<PrescriptionItemsDto, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(PrescriptionItemsDto entity, string id)
        {
            throw new NotImplementedException();
        }

        public bool Validation(PrescriptionItemsDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
