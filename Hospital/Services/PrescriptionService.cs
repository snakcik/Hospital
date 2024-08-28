using Hospital.Data.Context;
using Hospital.Data.Entities;
using Hospital.Dtos;
using Hospital.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq.Expressions;

namespace Hospital.Services
{
    public class PrescriptionService : IPrescription
    {
        private readonly Context _db;

        public PrescriptionService(Context db)
        {
            _db = db;
        }

        public void Add(PrescriptionDto entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<PrescriptionDto> GetActive()
        {
            throw new NotImplementedException();
        }

        public List<SelectListItem> GetActivePatient()
        {
            throw new NotImplementedException();
        }

        public List<SelectListItem> GetActivePersonell()
        {
            return _db.Personells
           .Where(x => x.ActivePasive == true)
           .Where(x => x.Title.Name.ToLower().Contains("dok"))
           .Select(a => new SelectListItem
           {
               Text = a.Title.Name + " " + a.Name + " " + a.LastName,
               Value = a.Id
           })
           .ToList();
        }

        public List<PrescriptionDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public PrescriptionDto GetById(string id)
        {
            var prescription = _db.Set<Prescription>().Include(x=>x.Personell).Include(x=>x.Patient)
                .Where(x=>x.PatientId == id).FirstOrDefault();
            //var prescription = _db.Set<Prescription>().Find(PatientId);
                if (prescription != null)
                {

                     return new PrescriptionDto
                        {
                            Id = prescription.Id,
                            DoctorId = prescription.PersonellId,
                            PatientId = prescription.PatientId,
                            DoctorName = prescription.Personell.Name + " " + prescription.Personell.LastName,
                            PatientName = prescription.Patient.Name + " " + prescription.Patient.LastName,
                            PatientIdentity = prescription.Patient.IdentityNumber.ToString(),
                            CreteDate = prescription.CreatedAt,
                    
                        };
                }

            return null;

        }

        public void Remove(string Id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<PrescriptionDto> Search(Expression<Func<PrescriptionDto, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public string StringAdd(PrescriptionDto entity)
        {
            Prescription prescription = new Prescription
            {
                PatientId = entity.PatientId,
                PersonellId = entity.DoctorId,
                Description = entity.Description,

            };

            _db.Set<Prescription>().Add(prescription);
            _db.SaveChanges();
            var prescriptionId = prescription.Id;
            return prescriptionId;
        }

        public void Update(PrescriptionDto entity, string id)
        {
            throw new NotImplementedException();
        }

        public bool Validation(PrescriptionDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
