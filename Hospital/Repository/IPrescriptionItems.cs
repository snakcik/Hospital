using Hospital.Dtos;
using Hospital.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hospital.Repository
{
    public interface IPrescriptionItems:IBaseRepository<PrescriptionItemsDto>
    {
        public List<SelectListItem> GetInventory();
        public List<PrescriptionItemsDto> GetItems(string Id);
    }
}
