using Hospital.Data.Context;
using Hospital.Data.Entities;
using Hospital.Dtos;
using Hospital.Repository;
using System.Linq.Expressions;

namespace Hospital.Services
{
    public class TitleService : ITitle

    {
        private readonly Context _db;

        public TitleService(Context db)
        {
            _db = db;
        }

        public void Add(TitleDto entity)
        {
            Title title = new Title
            {
                Name = entity.Name,
                Description = entity.Description,

            };
            _db.Set<Title>().Add(title);
            _db.SaveChanges();
        }

        public void Delete(string id)
        {
            var DeletedTitle = _db.Set<Title>().Find(id);
            if (DeletedTitle != null)
            {
                DeletedTitle.DeletedAt = DateTime.Now;
                DeletedTitle.ActivePasive = false;
                _db.Set<Title>().Update(DeletedTitle);
                _db.SaveChanges();
            }
        }

        public List<TitleDto> GetActive()
        {
            List<TitleDto> tList = _db.Set<Title>().Where(x => x.ActivePasive == true).Select(x => new TitleDto
            {
                Name = x.Name,
                Description = x.Description,
              
            }).ToList();
            return tList;
        }

        public List<TitleDto> GetAll()
        {
            List<TitleDto> tList = _db.Set<Title>().Select(x=> new TitleDto 
            { Name = x.Name, 
              Description = x.Description,
              IsDeleted = x.ActivePasive
            }).ToList();
            return tList;
        }

        public TitleDto GetById(string id)
        {
            var TitleId = _db.Set<Title>().Find(id);
            if (TitleId != null)
            {
                return new TitleDto
                {
                    Id = TitleId.Id,
                    Name = TitleId.Name,
                    Description= TitleId.Description,
                };
            }
            return null;
        }

        public IQueryable<TitleDto> Search(Expression<Func<TitleDto, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(TitleDto entity, string id)
        {
            throw new NotImplementedException();
        }
    }
}
