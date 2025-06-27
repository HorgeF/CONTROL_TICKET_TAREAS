using CONTROL_TICKET_TAREA.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CONTROL_TICKET_TAREA.Controllers
{
    public class GrupoEconomicoController(IGrupoEconomicoRepository grupoEconomicoRepository) : Controller
    {
        private readonly IGrupoEconomicoRepository _grupoEconomicoRepository = grupoEconomicoRepository;

        [HttpGet]
        public async Task<IActionResult> Buscar(string nombre)
        {
            var gruposEconomicos = await _grupoEconomicoRepository.BuscarGE(nombre);
            return Json(gruposEconomicos);
        }
    }
}
