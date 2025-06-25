using CONTROL_TICKET_TAREA.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CONTROL_TICKET_TAREA.Controllers
{
    public class EmpresaController(IEmpresaRepository empresaRepository) : Controller
    {
        private readonly IEmpresaRepository _empresaRepository = empresaRepository;

        [HttpGet]
        public async Task<IActionResult> ObtenerEmpresasPorGE(int idGE)
        {
            var empresas = await _empresaRepository.ListarEmpresas(idGE);

            var resultado = empresas.Select(e => new
            {
                value = e.IdEmpresa,
                text = e.RazonSocial
            });

            return Json(resultado);
        }
    }
}
