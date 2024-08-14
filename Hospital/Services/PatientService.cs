using Hospital.Data.Context;
using Hospital.Data.Entities;
using Hospital.Dtos;
using Hospital.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Hospital.Services
{
    public class PatientService : IPatient
    {
        private readonly Context _db;
        public PatientService(Context db)
        {
            _db = db;
        }

        public void Add(PatientDto entity)
        {
            

            Patient patient = new Patient
            {
                Name = entity.Name,
                LastName = entity.LastName,
                IdentityNumber = entity.IdentityNumber,
                Phone = entity.Phone,
                Email = entity.Email,
                Illness = entity.Illness,
                Diagnosis = entity.Diagnosis,
                PoliclinicId = entity.Policlinic,
                PersonellId = entity.Personell,
            };

            var checkIdentity = _db.Patients.FirstOrDefault(x=>x.IdentityNumber==patient.IdentityNumber);
            if (checkIdentity ==null)
            {
                _db.Add(patient);
                _db.SaveChanges();
            }
            else
            {
                
            }
                    
            
               
            
            
        }

        public void Delete(string id)
        {
            var DeletedPatient = _db.Set<Patient>().Find(id);
            if (DeletedPatient != null)
            {
                DeletedPatient.DeletedAt = DateTime.Now;
                DeletedPatient.ActivePasive = false;
                _db.Set<Patient>().Update(DeletedPatient);
                _db.SaveChanges();
            }
        }

        public List<PatientDto> GetActive()
        {
            var ApList = _db.Set<Patient>().Where(x=>x.ActivePasive==true).Select(x => new PatientDto
            {
                Id = x.Id,
                Name = x.Name,
                LastName = x.LastName,
                IdentityNumber = x.IdentityNumber,
                Phone = x.Phone,
                Email = x.Email,
                
            }).ToList();

            return ApList;
        }

        public List<PatientDto> GetAll()
        {


            var pList = _db.Set<Patient>().Select(x => new PatientDto
            {
                Id = x.Id,
                Name = x.Name,
                LastName = x.LastName,
                IdentityNumber = x.IdentityNumber,
                Phone = x.Phone,
                Email = x.Email,
                IsDeleted = x.ActivePasive


            }).ToList();

            return pList;
        }

        public PatientDto GetById(string id)
        {
            Patient patient = _db.Patients.Find(id);


            PatientDto? patientDto = _db.Set<Patient>()
                .Include(x=>x.Policlinic)
                .Include(x=>x.Personell)
                .Select(x => new PatientDto
            {
                Id = x.Id,
                Name = x.Name,
                LastName = x.LastName,
                IdentityNumber = x.IdentityNumber,
                Phone = x.Phone,
                Email = x.Email,
                Illness = x.Illness,
                Diagnosis = x.Diagnosis,
                Policlinic = x.PoliclinicId,
                Personell = x.PersonellId

            }).FirstOrDefault();

            return patientDto;
        }

        public void Remove(string Id)
        {
            var removeed = _db.Set<Patient>().Find(Id);
            _db.Set<Patient>().Remove(removeed);
            _db.SaveChanges();
        }

        public IQueryable<PatientDto> Search(Expression<Func<PatientDto, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(PatientDto entity, string Id)
        {
            var ExistingPatient = _db.Set<Patient>().Find(Id);

            if (ExistingPatient != null)
            {
                
                ExistingPatient.Name = entity.Name;
                ExistingPatient.LastName = entity.LastName;
                ExistingPatient.IdentityNumber = entity.IdentityNumber;
                ExistingPatient.Illness = entity.Illness;
                ExistingPatient.Diagnosis = entity.Diagnosis;
                ExistingPatient.Phone = entity.Phone;
                ExistingPatient.PoliclinicId = entity.Policlinic;
                ExistingPatient.PersonellId = entity.Personell;
                ExistingPatient.UpdatedAt = DateTime.Now;

                _db.Update(ExistingPatient);
                _db.SaveChanges();

            }
        }
    }
}
