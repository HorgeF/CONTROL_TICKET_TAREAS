using CONTROL_TICKET_TAREA.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CONTROL_TICKET_TAREA.Controllers
{
    public class UsuarioController(IUsuarioRepository usuarioRepository) : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository = usuarioRepository;

        [HttpGet]
        public async Task<IActionResult> Buscar(string nombre)
        {
            var responsables = await _usuarioRepository.BuscarResponsables(nombre);
            return Json(responsables);
        }
    }
}
