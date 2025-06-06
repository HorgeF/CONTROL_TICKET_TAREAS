using CONTROL_TICKET_TAREA.Models;
using CONTROL_TICKET_TAREA.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace CONTROL_TICKET_TAREA.Controllers
{
    public class HomeController(
        IControlTicketTareaRepository controlTicketTareaRepository,
        IGrupoEconomicoRepository grupoEconomicoRepository,
        IEmpresaRepository empresaRepository,
        IUsuarioRepository usuarioRepository,
        IGeneralRepository generalRepository,
        IItemCenterRepository itemCenterRepository) : Controller
    {

        private readonly IControlTicketTareaRepository _controlTicketTareaRepository = controlTicketTareaRepository;
        private readonly IGrupoEconomicoRepository _grupoEconomicoRepository = grupoEconomicoRepository;
        private readonly IEmpresaRepository _empresaRepository = empresaRepository;
        private readonly IUsuarioRepository _usuarioRepository = usuarioRepository;
        private readonly IGeneralRepository _generalRepository = generalRepository;
        private readonly IItemCenterRepository _itemCenterRepository = itemCenterRepository;

        public async Task<IActionResult> Index()
        {
            var ticketTareas = await _controlTicketTareaRepository.SPListarTicketTarea();

            var selectGrupoEconomico = await _grupoEconomicoRepository.ListarGruposEconomicosParaSelect();
            var selectResponsable = await _usuarioRepository.ListarUsuariosParaSelect();
            var selectPrioridad = await _generalRepository.ListarPrioridadesParaSelect();
            var selectEstados = await _generalRepository.ListarEstadosParaSelect();
            var selectItems = await _itemCenterRepository.ListarItemsParaSelect();

            ViewBag.GruposEconomicos = new SelectList(selectGrupoEconomico, "IdGe", "Nombre");
            ViewBag.Responsables = new SelectList(selectResponsable, "IdUsuario", "NombreReducido");
            ViewBag.Prioridades = new SelectList(selectPrioridad, "IdGeneral", "Nombre");
            ViewBag.Estados = new SelectList(selectEstados, "IdGeneral", "Nombre");
            ViewBag.Items = new SelectList(selectItems, "IdItemCenter", "Nombre");

            return View(ticketTareas);
        }

        [HttpGet]
        public async Task<IActionResult> ListarEmpresasParaSelect(int grupoId)
        {
            var empresas = await _empresaRepository.ListarEmpresasParaSelect(grupoId);

            var resultado = empresas.Select(e => new {
                value = e.IdEmpresa,
                text = e.RazonSocial
            });

            return Json(resultado);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
