using Hospital.Data.Context;
using Hospital.Data.Entities;
using Hospital.Dtos;
using Hospital.Repository;
using System.Linq.Expressions;

namespace Hospital.Services
{
    public class InventoryService : IInventory
    {
        private readonly Context _db;

        public InventoryService(Context db)
        {
            _db = db;
        }
        public void Add(InventoryDto entity)
        {
            Inventory inventory = new Inventory
            {
                Name = entity.Name,
                Description = entity.Description,
                Stock = entity.Stock
            };
            _db.Add(inventory);
            _db.SaveChanges();
        }

        public void Delete(string id)
        {
            var DeletedInventory = _db.Set<Inventory>().Find(id);
            if (DeletedInventory != null)
            {
                DeletedInventory.DeletedAt =DateTime.Now;
                DeletedInventory.ActivePasive = false;
                _db.Set<Inventory>().Update(DeletedInventory);
                _db.SaveChanges();
            }
        }

        public List<InventoryDto> GetActive()
        {
            var AIList = _db.Set<Inventory>().Where(x => x.ActivePasive == true).Select(x => new InventoryDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Stock = x.Stock,
               
            }).ToList();
            return AIList;
        }

        public List<InventoryDto> GetAll()
        {
            var IList = _db.Set<Inventory>().Select(x => new InventoryDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Stock = x.Stock,
                IsDeleted = x.ActivePasive
            }).ToList();
            return IList;
        }

        public InventoryDto GetById(string id)
        {
            var InventoryId = _db.Set<Inventory>().Find(id);
            if (InventoryId != null)
            {
                return new InventoryDto
                {
                    Id = InventoryId.Id,
                    Name = InventoryId.Name,
                    Stock = InventoryId.Stock,
                    Description = InventoryId.Description
                };
            }
            return null;
        }

        public void Remove(string Id)
        {
            var removeed = _db.Set<Inventory>().Find(Id);
            _db.Set<Inventory>().Remove(removeed);
            _db.SaveChanges();
        }

        public IQueryable<InventoryDto> Search(Expression<Func<InventoryDto, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(InventoryDto entity, string id)
        {
            var ExistingInventory = _db.Set<Inventory>().Find(id);

            if (ExistingInventory != null)
            {
                ExistingInventory.Name = entity.Name;
                ExistingInventory.Stock = entity.Stock;
                ExistingInventory.Description = entity.Description;
                ExistingInventory.UpdatedAt = DateTime.Now;
                 
                _db.Update(ExistingInventory);
                _db.SaveChanges();
            }
        }

        public bool Validation(InventoryDto entity)
        {
            bool Validation = true;
            if (entity.Name == null || entity.Description == null || entity.Stock <= 0 )
            {
                Validation = false;
            }

            return Validation;
        }
    }
}
