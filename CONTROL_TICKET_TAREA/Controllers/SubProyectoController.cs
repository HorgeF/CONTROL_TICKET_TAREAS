using CONTROL_TICKET_TAREA.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CONTROL_TICKET_TAREA.Controllers
{
    public class SubProyectoController(ISubProyectoRepository subProyectoRepository) : Controller
    {
        private readonly ISubProyectoRepository _subProyectoRepository = subProyectoRepository;

        [HttpGet]
        public async Task<IActionResult> ObtenerSubProyectosPorProyecto(int idProyecto)
        {
            var empresas = await _subProyectoRepository.ListarSubProyectos(idProyecto);

            var resultado = empresas.Select(e => new
            {
                value = e.IdSubProyecto,
                text = e.SubProyecto
            });

            return Json(resultado);
        }
    }
}
