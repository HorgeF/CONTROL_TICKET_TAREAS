using CONTROL_TICKET_TAREA.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CONTROL_TICKET_TAREA.Controllers
{
    public class ItemController(IItemCenterRepository itemCenterRepository) : Controller
    {
        private readonly IItemCenterRepository _itemCenterRepository = itemCenterRepository;

        [HttpGet]
        public async Task<IActionResult> Buscar(string nombre)
        {
            var items = await _itemCenterRepository.BuscarItems(nombre);
            return Json(items);
        }
    }
}
