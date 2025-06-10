using CONTROL_TICKET_TAREA.Dtos;
using CONTROL_TICKET_TAREA.Models;
using CONTROL_TICKET_TAREA.Repository;
using CONTROL_TICKET_TAREA.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using Microsoft.Extensions.Caching.Memory;
using CONTROL_TICKET_TAREA.Dtos.Filtros;

namespace CONTROL_TICKET_TAREA.Controllers
{
    public class HomeController(
        IControlTicketTareaRepository controlTicketTareaRepository,
        IGrupoEconomicoRepository grupoEconomicoRepository,
        IEmpresaRepository empresaRepository,
        IUsuarioRepository usuarioRepository,
        IGeneralRepository generalRepository,
        IItemCenterRepository itemCenterRepository,
        IMemoryCache cache) : Controller
    {

        private readonly IControlTicketTareaRepository _controlTicketTareaRepository = controlTicketTareaRepository;
        private readonly IGrupoEconomicoRepository _grupoEconomicoRepository = grupoEconomicoRepository;
        private readonly IEmpresaRepository _empresaRepository = empresaRepository;
        private readonly IUsuarioRepository _usuarioRepository = usuarioRepository;
        private readonly IGeneralRepository _generalRepository = generalRepository;
        private readonly IItemCenterRepository _itemCenterRepository = itemCenterRepository;

        private readonly IMemoryCache _cache = cache;

        public async Task<IActionResult> Index(FiltroControlTicketTarea filtro)
        {
            var prioridades = await _generalRepository.ListarPrioridades();
            var niveles = await _generalRepository.ListarNiveles();
            var ticketTareas = await _controlTicketTareaRepository.SPListarTicketTarea(filtro);

            ViewBag.Prioridades = new SelectList(prioridades.OrderByDescending(p => p.IdGeneral), "IdGeneral", "Nombre");
            ViewBag.Niveles = new SelectList(niveles, "IdGeneral", "Nombre");
            ViewBag.FiltroPrioridad = filtro.Prioridad;
            ViewBag.FiltroNivel = filtro.Nivel;

            return View(ticketTareas);
        }

        [HttpGet]
        public async Task<IActionResult> ListarEmpresasParaSelect(int grupoId)
        {
            var empresas = await _empresaRepository.ListarEmpresas(grupoId);

            var resultado = empresas.Select(e => new
            {
                value = e.IdEmpresa,
                text = e.RazonSocial
            });

            return Json(resultado);
        }

        [HttpGet("/Home/FormTicketTarea/{idTarea}")]
        public async Task<IActionResult> FormTicketTarea(int idTarea)
        {
            var ticketTarea = new TbControlTicketTareaRequest();

            await CargarCombos();

            if (idTarea != 0)
            {
                var ticketObtenido = await _controlTicketTareaRepository.ObtenerTicketTarea(idTarea);
                var selectEmpresas = await _empresaRepository.ListarEmpresas(ticketObtenido!.IdGE);
                ViewBag.Empresas = new SelectList(selectEmpresas, "IdEmpresa", "RazonSocial");
                ticketTarea = ticketObtenido.ToRequest();
            }

            return PartialView("Create", ticketTarea);
        }

        [HttpPost]
        public async Task<IActionResult> Guardar(TbControlTicketTareaRequest peticion)
        {
            if (peticion.IdItemCenter != 0)
            {
                ModelState.Remove(nameof(peticion.IdItemCenterDesc));
                peticion.IdItemCenterDesc = await _itemCenterRepository.ObtenerNombrePorIdItemCenter(peticion.IdItemCenter);
            }

            if (string.IsNullOrWhiteSpace(peticion.Correo) && string.IsNullOrWhiteSpace(peticion.Whatsapp))
            {
                ModelState.AddModelError("Correo", "Debe ingresar al menos Correo o Teléfono.");
                ModelState.AddModelError("Whatsapp", "Debe ingresar al menos Correo o Teléfono.");
            }

            if (!ModelState.IsValid)
            {
                await CargarCombos();
                if(peticion.IdGe != 0)
                {
                    var selectEmpresas = await _empresaRepository.ListarEmpresas(peticion.IdGe);
                    ViewBag.Empresas = new SelectList(selectEmpresas, "IdEmpresa", "RazonSocial");
                }
                return PartialView("Create", peticion);
            }

            if (peticion.IdTarea == 0)
                await _controlTicketTareaRepository.Insertar(peticion.ToEntity());
            else
                await _controlTicketTareaRepository.Actualizar(peticion.ToEntity());

            return Json(peticion);
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarTicket(int idTarea)
        {
            var ticketTarea = await _controlTicketTareaRepository.ObtenerTicketTarea(idTarea);

            Debug.WriteLine(ticketTarea.ToRequest().ToTicketRequest());

            var ticketRespuesta = await _controlTicketTareaRepository.RegistrarTicket(ticketTarea!.ToRequest().ToTicketRequest());

            ticketTarea!.CodTicket = ticketRespuesta?.CORREL_SUP_EXTERNO;

            await _controlTicketTareaRepository.Actualizar(ticketTarea!.ToRequest().ToEntity());

            return Json(new { CodTicketTarea = ticketTarea?.CodTicket, IdTicket = ticketRespuesta?.ID });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private async Task CargarCombos()
        {
            var selectGrupoEconomico = await _grupoEconomicoRepository.ListarGruposEconomicos();
            var selectResponsable = await _usuarioRepository.ListarUsuarios();
            var selectNiveles = await _generalRepository.ListarNiveles();
            var selectPrioridad = await _generalRepository.ListarPrioridades();
            var selectEstados = await _generalRepository.ListarEstados();
            var selectItems = await _itemCenterRepository.ListarItems();
            var selectTipos = await _generalRepository.ListarTipos();
            var selectMedios = await _generalRepository.ListarMedios();

            ViewBag.GruposEconomicos = new SelectList(selectGrupoEconomico, "IdGe", "Nombre");
            ViewBag.Responsables = new SelectList(selectResponsable, "IdUsuario", "Nombre");
            ViewBag.Prioridades = new SelectList(selectPrioridad, "IdGeneral", "Nombre");
            ViewBag.Estados = new SelectList(selectEstados, "IdGeneral", "Nombre");
            ViewBag.Items = new SelectList(selectItems, "IdItemCenter", "Descripcion");
            ViewBag.Tipos = new SelectList(selectTipos, "IdGeneral", "Nombre");
            ViewBag.Niveles = new SelectList(selectNiveles, "IdGeneral", "Nombre");
            ViewBag.Medios = new SelectList(selectMedios, "IdGeneral", "Nombre");
        }
    }
}
