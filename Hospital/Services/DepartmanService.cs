using Hospital.Data.Entities;
using Hospital.Dtos;
using Hospital.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Hospital.Services
{
    //Departman eklemek için gerekli servisler
    
    public class DepartmanService : IDepartman
    {
        protected readonly DbContext _db;
        
        public DepartmanService(DbContext db)
        {
            _db = db;
        }

        public void Add(DepartmanDto departmanDto)
        {
           Departman departman = new Departman();
           departman.Id = departmanDto.Id;
            departman.Name = departmanDto.Name;
            departman.Description = departmanDto.Description;

            _db.Set<Departman>().Add(departman);
            _db.SaveChanges();
        }


        public void Delete(string Id)
        {
            throw new NotImplementedException();
        }

        public List<DepartmanDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public DepartmanDto GetById(string Id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Departman> Serach(Expression<Func<Departman, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<DepartmanDto> Serach(Expression<Func<DepartmanDto, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(Departman entity, string Id)
        {
            throw new NotImplementedException();
        }

        public void Update(DepartmanDto entity, string Id)
        {
            throw new NotImplementedException();
        }
    }

       
