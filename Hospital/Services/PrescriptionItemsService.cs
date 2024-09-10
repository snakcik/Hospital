using Hospital.Data.Context;
using Hospital.Data.Entities;
using Hospital.Dtos;
using Hospital.Models;
using Hospital.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Hospital.Services
{
    
    public class PrescriptionItemsService : IPrescriptionItems
    {
        private readonly Context _db;

        public PrescriptionItemsService(Context db)
        {
            _db = db;
        }

  

        public void Add(PrescriptionItemsDto entity)
        {
            PrescriptionItems prescriptionItems = new PrescriptionItems
            {
                PrescriptionId = entity.PrescriptionId,
                InventoryId = entity.InventoryId,
                CreatedAt = DateTime.UtcNow,

            };
            _db.Set<PrescriptionItems>().Add(prescriptionItems);
            _db.SaveChanges();
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

        public List<SelectListItem> GetInventory()
        {
            return _db.Inventorys.Select(x=> new SelectListItem
            {
                Text = x.Name,
                Value = x.Id
            }).ToList();
        }

        public List<PrescriptionItemsDto> GetItems(string Id)
        {



            var medicines = _db.Set<PrescriptionItems>()
                  .Include(x => x.inventories)
                  .Where(x => x.PrescriptionId == Id)
                  .Select(x => new PrescriptionItemsDto
                  {
                      Id = x.Id,
                      PrescriptionId = x.PrescriptionId,
                      InventoryId = x.InventoryId,
                      //InventoryNames =  x.inventories.Where(y=>y.Id == x.InventoryId)
                      //.Select(x => x.Name).ToList()
                      InventoryNames = _db.Set<Inventory>().Where(y => y.Id == x.InventoryId).Select(x => x.Name).ToList()

                  }).ToList();

            
            
            
            return medicines;
        }

        public void Remove(string Id)
        {
            var removed = _db.Set<PrescriptionItems>().Find(Id);
            _db.Set<PrescriptionItems>().Remove(removed);
            _db.SaveChanges();
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
