﻿using Hospital.Data.Context;
using Hospital.Data.Entities;
using Hospital.Dtos;
using Hospital.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Hospital.Services
{
    public class PersonellService : IPersonell
    {
        private readonly Context _db;
        public PersonellService(Context db)
        {
            _db = db;
        }

        public void Add(PersonellDto entity)
        {
            Personell personell = new Personell
            {
                Name = entity.Name,
                LastName = entity.LastName,
                IdentityNumber = entity.IdentityNumber,
                Phone = entity.Phone,
                Email = entity.Email,
                TitleId = entity.Title,
                DepartmanId = entity.Departman,

            };

            _db.Set<Personell>().Add(personell);
            _db.SaveChanges();

            
        }
        public bool AddBool(PersonellDto entity)
        {
            bool duplicate = true;
            Personell personell = new Personell
            {
                Name = entity.Name,
                LastName = entity.LastName,
                IdentityNumber = entity.IdentityNumber,
                Phone = entity.Phone,
                Email = entity.Email,
                TitleId = entity.Title,
                DepartmanId = entity.Departman,

            };
            var isDublicated = _db.Set<Personell>().FirstOrDefault(x => x.IdentityNumber == personell.IdentityNumber);
            if(isDublicated == null)
            {
                _db.Set<Personell>().Add(personell);
                _db.SaveChanges();
            }
            else { duplicate = false; }
                 
            return duplicate;
        }

        public void Delete(string id)
        {
            var DeletedPersonnel = _db.Set<Personell>().Find(id);
            if (DeletedPersonnel != null)
            {
                DeletedPersonnel.DeletedAt = DateTime.Now;
                DeletedPersonnel.ActivePasive = false;
                _db.Set<Personell>().Update(DeletedPersonnel);
                _db.SaveChanges();
            }
        }

        public List<PersonellDto> GetActive()
        {
            var apList = _db.Set<Personell>().Where(x => x.ActivePasive == true)
                            .Include(x => x.Title)
                            .Include(x => x.Departman)
                            .Select(x => new PersonellDto
                             {
                                 Id = x.Id,
                                 Name = x.Name,
                                 LastName = x.LastName,
                                 IdentityNumber = x.IdentityNumber,
                                 Phone = x.Phone,
                                 Email = x.Email,
                                 Title = x.Title.Name,
                                 Departman = x.Departman.Name,
                                 }).ToList();
                             return apList;
        }

        public List<PersonellDto> GetAll()
        {
            var pList = _db.Set<Personell>()
                .Include(x=>x.Title)
                .Include(x=>x.Departman)
                .Select(x => new PersonellDto
            {
                Id = x.Id,
                Name = x.Name,
                LastName = x.LastName,
                IdentityNumber = x.IdentityNumber,
                Phone = x.Phone,
                Email = x.Email,
                Title = x.Title.Name,
                Departman = x.Departman.Name,
                IsDeleted = x.ActivePasive



                }).ToList();
            return pList;
        }

        public PersonellDto GetById(string id)
        {
            var PersonnelId = _db.Set<Personell>().Find(id);
            if (PersonnelId != null)
            {
                return new PersonellDto
                {
                    Id = PersonnelId.Id,
                    Name = PersonnelId.Name,
                    LastName = PersonnelId.LastName,
                    IdentityNumber = PersonnelId.IdentityNumber,
                    Phone = PersonnelId.Phone,
                    Email = PersonnelId.Email,
                    Title = PersonnelId.TitleId,
                    Departman = PersonnelId.DepartmanId
                   
                };
            }
            return null;
        }

        public void Remove(string Id)
        {
            var removeed = _db.Set<Personell>().Find(Id);
            _db.Set<Personell>().Remove(removeed);
            _db.SaveChanges();
        }

        public IQueryable<PersonellDto> Search(Expression<Func<PersonellDto, bool>> predicate)
        {
            return _db.Set<Personell>().Select(x=> new PersonellDto { 
                Id = x.Id, 
                Name = x.Name, 
                LastName = x.LastName, 
                IdentityNumber = x.IdentityNumber,
                Phone = x.Phone,
                Email = x.Email,
                Title = x.Title.Name,
                Departman= x.Departman.Name,
                IsDeleted=x.ActivePasive,
            }).Where(predicate).AsQueryable();
        }

        public void Update(PersonellDto entity, string id)
        {
           var ExistingPersonell = _db.Set<Personell>().Find(id);


            if ( ExistingPersonell != null)
            {
                ExistingPersonell.Name = entity.Name;
                ExistingPersonell.LastName = entity.LastName;
                ExistingPersonell.IdentityNumber = entity.IdentityNumber;
                ExistingPersonell.Phone = entity.Phone;
                ExistingPersonell.Email = entity.Email;
                ExistingPersonell.TitleId = entity.Title;
                ExistingPersonell.DepartmanId = entity.Departman;
                ExistingPersonell.UpdatedAt = DateTime.Now;


                _db.Update(ExistingPersonell);
                _db.SaveChanges();
                
            }


        }

        public bool UpdateBool(PersonellDto entity, string id)
        {
            bool duplicate = true;
            var ExistingPersonells = _db.Set<Personell>().Find(id);
            var isDublicated = _db.Set<Personell>().Where(x => x.IdentityNumber != ExistingPersonells.IdentityNumber).ToList();
            var filteredList = isDublicated.Any(x => x.IdentityNumber == entity.IdentityNumber);
            if (filteredList != false)
            {
                duplicate = false;
            }
            else
            {
                var ExistingPersonell = _db.Set<Personell>().Find(id);

                if (ExistingPersonell != null)
                {
                    ExistingPersonell.Name = entity.Name;
                    ExistingPersonell.LastName = entity.LastName;
                    ExistingPersonell.IdentityNumber = entity.IdentityNumber;
                    ExistingPersonell.Phone = entity.Phone;
                    ExistingPersonell.Email = entity.Email;
                    ExistingPersonell.TitleId = entity.Title;
                    ExistingPersonell.DepartmanId = entity.Departman;
                    ExistingPersonell.UpdatedAt = DateTime.Now;

                    duplicate = true;
                    _db.Update(ExistingPersonell);
                    _db.SaveChanges();

                }
            }
        
            return duplicate;
        }

        public List<SelectListItem> GetActiveTitle()
        {

            return _db.Titles
             .Where(x => x.ActivePasive == true)
             .Select(a => new SelectListItem
             {
                 Text = a.Name,
                 Value = a.Id
             })
             .ToList();

        }

        public List<SelectListItem> GetActiveDepartman()
        {

            return _db.Departmens
              .Where(x => x.ActivePasive == true)
              
              .Select(a => new SelectListItem
              {
                  Text = a.Name,
                  Value = a.Id
              })
              .ToList();

        }

        public bool Validation(PersonellDto entity)
        {
            bool Validation = true;
            if (entity.Name == null
                || entity.LastName == null
                || entity.IdentityNumber <= 0
                || entity.Phone == null
                || entity.Email == null
                || entity.Title == null
                || entity.Departman == null
               )
            {
                Validation = false;
            }

            return Validation;
        }

        public PersonellDto GetByIdName(string id)
        {
            var personellDto = _db.Set<Personell>().Include(x => x.Departman).Include(x => x.Title).First(x => x.Id == id);
            return new PersonellDto { 
                Id = id, 
                Name = personellDto.Name,
                LastName = personellDto.LastName,
                IdentityNumber = personellDto.IdentityNumber,
                Phone = personellDto.Phone,
                Email = personellDto.Email,
                Title=personellDto.Title.Name,
                Departman=personellDto.Departman.Name,
            };

        }
    }
}
