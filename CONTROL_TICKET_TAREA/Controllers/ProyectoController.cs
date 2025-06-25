using CONTROL_TICKET_TAREA.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CONTROL_TICKET_TAREA.Controllers
{
    public class ProyectoController(IProyectoRepository proyectoRepository) : Controller
    {
        private readonly IProyectoRepository _proyectoRepository = proyectoRepository;

        [HttpGet]
        public async Task<IActionResult> ObtenerProyectosPorEmpresa(int idEmpresa)
        {
            var empresas = await _proyectoRepository.ListarProyectos(idEmpresa);

            var resultado = empresas.Select(e => new
            {
                value = e.IdProyecto,
                text = e.Proyecto
            });

            return Json(resultado);
        }
    }
}
