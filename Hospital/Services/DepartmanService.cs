using Hospital.Data.Context;
using Hospital.Data.Entities;
using Hospital.Dtos;
using Hospital.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Hospital.Services
{
    public class DepartmanService : IDepartman
    {
        private readonly Context _db;

        public DepartmanService(Context db)
        {
            _db = db;
        }

        public void Add(DepartmanDto departmanDto)
        {
            Departman departman = new Departman
            {
                Name = departmanDto.Name,
                Description = departmanDto.Description
            };

            _db.Set<Departman>().Add(departman);
            _db.SaveChanges();
        }

        public void Delete(string id)
        {
            var departman = _db.Set<Departman>().Find(id);
            if (departman != null)
            {
                _db.Set<Departman>().Remove(departman);
                _db.SaveChanges();
            }
        }

        public List<DepartmanDto> GetAll()
        {
            return _db.Set<Departman>()
                      .Select(d => new DepartmanDto
                      {
                          Id = d.Id,
                          Name = d.Name,
                          Description = d.Description
                      }).ToList();
        }

        public DepartmanDto GetById(string id)
        {
            var departman = _db.Set<Departman>().Find(id);
            if (departman != null)
            {
                return new DepartmanDto
                {
                    Id = departman.Id,
                    Name = departman.Name,
                    Description = departman.Description
                };
            }
            return null;
        }

        public IQueryable<Departman> Search(Expression<Func<Departman, bool>> predicate)
        {
            return _db.Set<Departman>().Where(predicate);
        }

        public IQueryable<DepartmanDto> Search(Expression<Func<DepartmanDto, bool>> predicate)
        {
            return _db.Set<Departman>()
                      .Select(d => new DepartmanDto
                      {
                          Id = d.Id,
                          Name = d.Name,
                          Description = d.Description
                      }).AsQueryable().Where(predicate);
        }

        public IQueryable<DepartmanDto> Serach(Expression<Func<DepartmanDto, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(DepartmanDto entity, string id)
        {
            var departman = _db.Set<Departman>().Find(id);
            if (departman != null)
            {
                departman.Name = entity.Name;
                departman.Description = entity.Description;
                _db.SaveChanges();
            }
        }

        public void Update(Departman entity, string id)
        {
            var existingDepartman = _db.Set<Departman>().Find(id);
            if (existingDepartman != null)
            {
                existingDepartman.Name = entity.Name;
                existingDepartman.Description = entity.Description;
                _db.SaveChanges();
            }
        }
    }
}
