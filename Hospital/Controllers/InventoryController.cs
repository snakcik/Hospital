using Hospital.Data.Entities;
using Hospital.Dtos;
using Hospital.Repository;
using Hospital.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
    public class InventoryController : Controller
    {
        private readonly IInventory _inventory;

        public InventoryController(IInventory inventory)
        {
            _inventory = inventory;
        }

        public IActionResult List()
        {
            var InventoryList = _inventory.GetActive();

            return View(InventoryList);
        }
        public IActionResult AllList()
        {
            var AllList = _inventory.GetAll();
            return View(AllList);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(InventoryDto inventoryDto)
        {

            _inventory.Add(inventoryDto);


            return RedirectToAction("List");
        }

        public IActionResult Delete(string id)
        {
            var departman = _inventory.GetById(id);

            _inventory.Delete(id);
            return RedirectToAction("List");
        }
        public IActionResult Remove(string id)
        {
            _inventory.Remove(id);
            return RedirectToAction("List");
        }

        public IActionResult Update(string Id)
        {
            var Inventory = _inventory.GetById(Id);

            return View(Inventory);
        }

        [HttpPost]
        public IActionResult Update(InventoryDto inventoryDto,string Id)
        {
            if (ModelState.IsValid)
            {
                _inventory.Update(inventoryDto, Id);
                return RedirectToAction("List");
            }
            

            return View();
        }
    }
}
