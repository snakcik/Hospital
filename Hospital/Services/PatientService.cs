using Hospital.Data.Context;
using Hospital.Data.Entities;
using Hospital.Dtos;
using Hospital.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
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

        public bool AddBool(PatientDto entity)
        {
           bool duplicate = true;

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
            if (checkIdentity == null)
            {
                _db.Add(patient);
                _db.SaveChanges();
            }
            else
            { duplicate = false; }

            return duplicate;
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

            var patientDto = _db.Set<Patient>().Find(id);
                
            if (patientDto != null)
            {
                return new PatientDto
                {
                    Id = patientDto.Id,
                    Name = patientDto.Name,
                    LastName = patientDto.LastName,
                    IdentityNumber = patientDto.IdentityNumber,
                    Phone = patientDto.Phone,
                    Email = patientDto.Email,
                    Illness = patientDto.Illness,
                    Diagnosis = patientDto.Diagnosis,
                    Policlinic = patientDto.PoliclinicId,
                    Personell = patientDto.PersonellId
                };
                    
            }
               
            return null;
        }

        public void Remove(string Id)
        {
            var removeed = _db.Set<Patient>().Find(Id);
            _db.Set<Patient>().Remove(removeed);
            _db.SaveChanges();
        }

        public IQueryable<PatientDto> Search(Expression<Func<PatientDto, bool>> predicate)
        {
            return _db.Set<Patient>().Select(x=> new PatientDto { 
                Id = x.Id, Name = x.Name, 
                LastName = x.LastName, 
                IdentityNumber = x.IdentityNumber,
                Phone = x.Phone,
                Email = x.Email,
                Illness = x.Illness,
                Diagnosis = x.Diagnosis,
                Policlinic = x.Policlinic.Name,
                Personell = x.Personell.Name,
                IsDeleted=x.ActivePasive,
            }).Where(predicate).AsQueryable();
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
        public bool UpdateBool(PatientDto entity, string Id)
        {
            bool duplicate = true;
            var ExistingPatientId = _db.Set<Patient>().Find(Id);
            var isDublicated = _db.Set<Patient>().Where(x => x.IdentityNumber != ExistingPatientId.IdentityNumber).ToList();
            var filteredList = isDublicated.Any(x => x.IdentityNumber == entity.IdentityNumber);
            if (filteredList != false)
            {
                duplicate = false;
            }

            else
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
            return duplicate;
        }

        public List<SelectListItem> GetActivePoliclinics()
        {

            return _db.Policlinics
             .Where(x => x.ActivePasive == true)
             .Select(a => new SelectListItem
             {
                 Text = a.Name,
                 
                 Value = a.Id
             })
             .ToList();

        }

        public List<SelectListItem> GetActiveAndDoctorPersonell()
        {

            return _db.Personells
              .Where(x => x.ActivePasive == true)
              .Where(x=>x.Title.Name.ToLower().Contains("dok"))
              .Select(a => new SelectListItem
              {
                  Text =a.Title.Name+" "+ a.Name+" "+a.LastName,
                  Value = a.Id
              })
              .ToList();

        }

        public bool Validation(PatientDto entity)
        {
            bool Validation = true;
            if (entity.Name == null 
                || entity.LastName == null 
                || entity.IdentityNumber <=0
                || entity.Phone == null
                || entity.Email == null
                || entity.Illness == null
                || entity.Diagnosis == null
                || entity.Policlinic == null
                || entity.Personell == null
               )
            {
                Validation = false;
            }

            return Validation;
        }

        public PatientDto GetByIdName(string id)
        {

            var patientDto = _db.Set<Patient>().Include(x => x.Policlinic).Include(x => x.Personell).First(x => x.Id == id);
               

            if (patientDto != null)
            {
                string FullName = _db.Set<Personell>().Select(x =>x.Title.Name+" "+ x.Name+" "+x.LastName).FirstOrDefault();
                return new PatientDto
                {
                    Id = patientDto.Id,
                    Name = patientDto.Name,
                    LastName = patientDto.LastName,
                    IdentityNumber = patientDto.IdentityNumber,
                    Phone = patientDto.Phone,
                    Email = patientDto.Email,
                    Illness = patientDto.Illness,
                    Diagnosis = patientDto.Diagnosis,
                    Policlinic = patientDto.Policlinic.Name,
                    Personell = FullName
                    
                };

            }

            return null;
        }

        public bool DoctorUpdateBool(PatientDto entity,string Id)
        {
            bool duplicate = true;
            var ExistingPatient = _db.Set<Patient>().Find(Id);

            if (ExistingPatient != null) 
            {
                ExistingPatient.Diagnosis = entity.Diagnosis;
                _db.Update(ExistingPatient);
                _db.SaveChanges();
                
            }
                return duplicate;
        }
           
    }
}
