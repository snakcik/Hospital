using Hospital.Data.Context;
using Hospital.Data.Entities;
using Hospital.Dtos;
using Hospital.Repository;
using System.Linq.Expressions;

namespace Hospital.Services
{
    public class PoliclinicService : IPoliclinic
    {

        private readonly Context _db;

        public PoliclinicService(Context db)
        {
            _db = db;
        }

        public void Add(PoliclinicDto entity)
        {
            Policlinic policlinic = new Policlinic
            {
                Name = entity.Name,

            };
            _db.Set<Policlinic>().Add(policlinic);
            _db.SaveChanges();
        }

        public void Delete(string id)
        {
            var DeletedPoliclinic = _db.Set<Policlinic>().Find(id);
            if (DeletedPoliclinic != null)
            {
                DeletedPoliclinic.DeletedAt = DateTime.Now;
                DeletedPoliclinic.ActivePasive = false;
                _db.Set<Policlinic>().Update(DeletedPoliclinic);
                _db.SaveChanges();
            }
        }

        public List<PoliclinicDto> GetActive()
        {
            List<PoliclinicDto> ApList = _db.Set<Policlinic>()
                .Where(x=>x.ActivePasive == true)
                .Select(x => new PoliclinicDto
            {
                Name = x.Name,
               
            }).ToList();

            return ApList;
        }

        public List<PoliclinicDto> GetAll()
        {
            List<PoliclinicDto> pList = _db.Set<Policlinic>().Select(x => new PoliclinicDto
            {
                Name = x.Name,
                IsDeleted = x.ActivePasive
            }).ToList();

            return pList;
        }

        public PoliclinicDto GetById(string id)
        {
            var PoliclinicId = _db.Set<Policlinic>().Find(id);
            if (PoliclinicId != null)
            {
                return new PoliclinicDto
                {
                    Id = PoliclinicId.Id,
                    Name = PoliclinicId.Name
                };
            }
            return null;
        }

        public IQueryable<PoliclinicDto> Search(Expression<Func<PoliclinicDto, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(PoliclinicDto entity, string id)
        {
            throw new NotImplementedException();
        }
    }
}
