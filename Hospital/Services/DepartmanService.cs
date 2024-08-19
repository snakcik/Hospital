using Hospital.Data.Context;
using Hospital.Data.Entities;
using Hospital.Dtos;
using Hospital.Repository;
using Microsoft.CodeAnalysis.FlowAnalysis;
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

        public void Delete( string id)
        {

            var DeletedDepartman = _db.Set<Departman>().Find(id);
            if (DeletedDepartman != null)
            {
                DeletedDepartman.DeletedAt =  DateTime.Now;
                DeletedDepartman.ActivePasive =  false;
                _db.Set<Departman>().Update(DeletedDepartman);
                _db.SaveChanges();
            }
        }
    
        public void Remove (string Id)
        {
            var removeed = _db.Set<Departman>().Find(Id);
            _db.Set<Departman>().Remove(removeed);
            _db.SaveChanges() ;
        }

        public List<DepartmanDto> GetActive()
        {
           List<DepartmanDto> dActiveList = _db.Set<Departman>().Where(x=>x.ActivePasive == true).Select(x=> new DepartmanDto
           {
               Id = x.Id,
               Name = x.Name,
               Description= x.Description,
              
           }).ToList();

            return dActiveList;
        }

        public List<DepartmanDto> GetAll()
        {

            return _db.Set<Departman>()
                      .Select(d => new DepartmanDto
                      {
                          Id = d.Id,
                          Name = d.Name,
                          Description = d.Description,
                          IsDeleted = d.ActivePasive
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
                departman.UpdatedAt = DateTime.Now;
                
                _db.SaveChanges();
            }
        }

        public bool IsItAttached(string Id)
        {
            bool ItIs = true;
            bool result = _db.Personells.Any(x => x.DepartmanId == Id);
            if (result !=  false)
            {
                return ItIs;

            }
            return ItIs=false;
        }

        public bool Validation(DepartmanDto entity)
        {
            bool Validation = true;
            if (entity.Name == null || entity.Description == null)
            {
                Validation = false;
            }

            return Validation;
             
        }

        public string strValidation(DepartmanDto entity)
        {
            if (string.IsNullOrEmpty(entity.Name) && string.IsNullOrEmpty(entity.Description )) return "All";
            else if (string.IsNullOrEmpty(entity.Name)) return "Name";
            else if (string.IsNullOrEmpty(entity.Description)) return "Description";
            else return "Ok";

        }

     
    }
}
