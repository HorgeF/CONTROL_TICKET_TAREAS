using CONTROL_TICKET_TAREA.Constants;
using CONTROL_TICKET_TAREA.Dtos.Filtros;
using CONTROL_TICKET_TAREA.Dtos.Peticiones;
using CONTROL_TICKET_TAREA.Dtos.Respuestas;
using CONTROL_TICKET_TAREA.Helpers;
using CONTROL_TICKET_TAREA.Helpers.Reportes.Excel;
using CONTROL_TICKET_TAREA.Helpers.Reportes.Pdf;
using CONTROL_TICKET_TAREA.Mappers;
using CONTROL_TICKET_TAREA.Models;
using CONTROL_TICKET_TAREA.Repository.Interfaces;
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
        IItemCenterRepository itemCenterRepository,
        ICenterTicketRepository centerTicketRepository,
        IExcelService<TbControlTicketTareaResponse> excelTarea,
        IPdfService<TbControlTicketTareaResponse> pdfTarea,
        ICacheHelper cache) : Controller
    {

        private readonly IControlTicketTareaRepository _controlTicketTareaRepository = controlTicketTareaRepository;
        private readonly IGrupoEconomicoRepository _grupoEconomicoRepository = grupoEconomicoRepository;
        private readonly IEmpresaRepository _empresaRepository = empresaRepository;
        private readonly IUsuarioRepository _usuarioRepository = usuarioRepository;
        private readonly IGeneralRepository _generalRepository = generalRepository;
        private readonly IItemCenterRepository _itemCenterRepository = itemCenterRepository;
        private readonly ICenterTicketRepository _centerTicketRepository = centerTicketRepository;
        private readonly IExcelService<TbControlTicketTareaResponse> _excelTarea = excelTarea;
        private readonly IPdfService<TbControlTicketTareaResponse> _pdfTarea = pdfTarea;

        private readonly ICacheHelper _cache = cache;

        public async Task<IActionResult> Index(FiltroControlTicketTarea filtro)
        {
            var ticketTareas = await _controlTicketTareaRepository.SPListarTicketTarea(filtro);

            var prioridades = await _cache.ObtenerListaAsync(
                "ComunPrioridades", 
                () => _generalRepository.ListarGeneralesPorSeccionAsync(IdSecundaria.Prioridad, ordenarPorNombre: false, descendente: true),
                TimeSpan.FromHours(12));

            var niveles = await _cache.ObtenerListaAsync(
                "ComunNiveles", 
                () => _generalRepository.ListarGeneralesPorSeccionAsync(IdSecundaria.Nivel, descendente: true), 
                TimeSpan.FromHours(12));

            var receptores = await _cache.ObtenerListaAsync(
                "IndexUsuarios",
                _usuarioRepository.ListarUsuarios,
                TimeSpan.FromHours(1));

            var estados = await _cache.ObtenerListaAsync(
                "IndexEstados",
                () => _generalRepository.ListarGeneralesPorSeccionAsync(IdSecundaria.Estado),
                TimeSpan.FromHours(2));


            if (filtro.PrioridadInd.HasValue || filtro.NivelInd.HasValue)
            {
                ViewBag.PrioridadInd = filtro.PrioridadInd;
                ViewBag.NivelInd = filtro.NivelInd;
            } else
            {
                ViewBag.FiltroPrioridad = filtro.Prioridad;
                ViewBag.FiltroNivel = filtro.Nivel;
                ViewBag.FiltroReceptor = filtro.IdsReceptores;
                ViewBag.FiltroEstado = filtro.IdEstado;
            }

            ViewBag.Receptores = new SelectList(receptores, "IdUsuario", "Nombre", filtro.IdsReceptores);
            ViewBag.Estados = new SelectList(estados, "IdGeneral", "Nombre",filtro.IdEstado);
            ViewBag.Prioridades = new SelectList(prioridades, "IdGeneral", "Nombre");
            ViewBag.Niveles = new SelectList(niveles, "IdGeneral", "Nombre");
            ViewBag.GrafPrioridades = await _controlTicketTareaRepository.ListarGrupoConCantidadAsync(IdSecundaria.Prioridad, g => g.IdPrioridad);
            ViewBag.GrafNiveles = await _controlTicketTareaRepository.ListarGrupoConCantidadAsync(IdSecundaria.Nivel, g => g.IdNivel);

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

        [HttpGet]
        public async Task<IActionResult> GenerarReporteSemanal(FiltroControlTicketTarea filtro)
        {
            var reporteTareas = await _controlTicketTareaRepository.ListarReporteTareasSemanal(filtro);
            var nombresReceptores = new List<string>();

            // Siempre sea Lunes a Viernes
            var hoy = DateTime.Today;
            var diaSemana = (int)hoy.DayOfWeek;
            if (diaSemana == 0) diaSemana = 7;
            var lunes = hoy.AddDays(1 - diaSemana);
            var viernes = lunes.AddDays(4);
            ViewBag.FecInicio = lunes;
            ViewBag.FecFinal = viernes;

            if(filtro.IdsReceptores.Count != 0)
                nombresReceptores = await _usuarioRepository.ObtenerNombresPorIds(filtro.IdsReceptores);

            ViewBag.filtroTecnicos = nombresReceptores;

            return PartialView("ReporteTareas", reporteTareas);
        }

        [HttpGet]
        public async Task<IActionResult> ExportarExcelReporteTarea(FiltroControlTicketTarea filtro)
        {
            var reporteTareas = await _controlTicketTareaRepository.ListarReporteTareasSemanal(filtro);
            var bytes = _excelTarea.GenerarExcel(reporteTareas);
            var fechaRegistro = $"{DateTime.Now:ddMMyyyy}";

            return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"Reporte tareas - {fechaRegistro}.xlsx");
        }

        [HttpGet]
        public async Task<IActionResult> ExportarPdfReporteTarea(FiltroControlTicketTarea filtro)
        {
            var reporteTareas = await _controlTicketTareaRepository.ListarReporteTareasSemanal(filtro);
            var nombresReceptores = new List<string>();

            if(filtro.IdsReceptores.Count != 0)
            {
                nombresReceptores = await _usuarioRepository.ObtenerNombresPorIds(filtro.IdsReceptores);
            }

            var bytes = _pdfTarea.GenerarPdf(reporteTareas, nombresReceptores);
            var fechaRegistro = $"{DateTime.Now:ddMMyyyy}";

            return File(bytes, "application/pdf", $"Reporte tareas - {fechaRegistro}.pdf");
        }

        [HttpGet]
        public async Task<IActionResult> BuscarResponsables(string nombre)
        {
            var responsables = await _usuarioRepository.BuscarResponsables(nombre);
            return Json(responsables);
        }

        [HttpGet]
        public async Task<IActionResult> BuscarGE(string nombre)
        {
            var gruposEconomicos = await _grupoEconomicoRepository.BuscarGE(nombre);
            return Json(gruposEconomicos);
        }

        [HttpGet]
        public async Task<IActionResult> BuscarItems(string nombre)
        {
            var items = await _itemCenterRepository.BuscarItems(nombre);
            return Json(items);
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
            } else
            {
                ticketTarea.IdEstado = 1268; // Estado "PENDIENTE" predeterminado
            }

            ticketTarea.PeticionId = Guid.NewGuid();

            return PartialView("Guardar", ticketTarea);
        }

        [HttpPost]
        public async Task<IActionResult> Guardar(TbControlTicketTareaRequest peticion)
        {
            if (peticion.IdTarea != 0)
            {
                bool existeTicketTarea = await _controlTicketTareaRepository.ExisteTarea(peticion.IdTarea);
                if (!existeTicketTarea)
                    return NotFound(new { exito = false, mensaje = "Tarea no encontrada" });

                int estadoTicketTarea = await _controlTicketTareaRepository.ObtenerEstado(peticion.IdTarea);
                if (estadoTicketTarea == 1269 || estadoTicketTarea == 1270)
                    return BadRequest(new { exito = false, mensaje = "El estado de esta tarea no puede modificada" });
            }

            if (!string.IsNullOrWhiteSpace(peticion.CodTicket))
            {
                bool existeTicket = await _centerTicketRepository.ExisteTicket(peticion.CodTicket);
                if (!existeTicket)
                    ModelState.AddModelError("CodTicket", "Ticket no válido");

                bool esCodTicketTomado = await _controlTicketTareaRepository.EsCodTicketTomado(peticion.CodTicket, peticion.IdTarea);
                if (esCodTicketTomado)
                    ModelState.AddModelError("CodTicket", "Ticket ya usado");
            }

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
                return PartialView("Guardar", peticion);
            }

            if (!_cache.IntentarGuardar(peticion.PeticionId.ToString(), TimeSpan.FromSeconds(40)))
                return Conflict(new { exito = false, mensaje = "Ya se esta procesando la solicitud, espere unos segundos para volver a enviar" });

            if (peticion.IdTarea == 0)
            {
                peticion.FechaTicketTarea = DateTime.Now;
                peticion.FecReg = DateTime.Now;
                await _controlTicketTareaRepository.Insertar(peticion.ToEntity());
            }
            else
            {
                await _controlTicketTareaRepository.Actualizar(peticion.ToEntity());
            }

            return Json(peticion);
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarTicket(int idTarea)
        {
            string cacheKey = $"ticket-tarea-{idTarea}";

            var ticketTarea = await _controlTicketTareaRepository.ObtenerTicketTarea(idTarea);

            if (ticketTarea == null)
                return NotFound(new { exito = false, mensaje = "Tarea no encontrada" });

            if (!string.IsNullOrWhiteSpace(ticketTarea.CodTicket))
                return Conflict(new { exito = false, mensaje = "Esta tarea ya tiene un ticket creado que es " + ticketTarea.CodTicket, ticketTarea.CodTicket });

            if(!_cache.IntentarGuardar(cacheKey, TimeSpan.FromSeconds(40)))
                return Conflict(new { exito = false, mensaje = "Ya se esta procesando la solicitud, espere unos segundos para volver a enviar" });

            var ticketRespuesta = await _controlTicketTareaRepository.RegistrarTicket(ticketTarea.ToRequest().ToTicketRequest());

            ticketTarea.CodTicket = ticketRespuesta?.CORREL_SUP_EXTERNO;

            await _controlTicketTareaRepository.Actualizar(ticketTarea.ToRequest().ToEntity());

            return Json(new { ticketTarea.CodTicket });
        }

        [HttpPatch("/api/ticket-tarea/actualizar-estado")]
        public async Task<IActionResult> ActualizarEstado([FromBody] TbControlTicketTareaEstadoRequest peticion)
        {
            bool estaActualizado = await _controlTicketTareaRepository.ActualizarEstado(peticion.CodTicket, peticion.IdEstado);
            if (!estaActualizado)
                return BadRequest(new { mensaje = "No se logro actualizar el ticket" });

            return Ok(new { mensaje = "Estado de la tarea ticket actualizado" });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private async Task CargarCombos()
        {
            var expiracionLarga = TimeSpan.FromHours(12);
            var expiracionMedia = TimeSpan.FromHours(2);
            var expiracionCorta = TimeSpan.FromHours(1);

            var selectPrioridad = await _cache.ObtenerListaAsync(
                "Prioridades", 
                () => _generalRepository.ListarGeneralesPorSeccionAsync(IdSecundaria.Prioridad, ordenarPorNombre: false, descendente: true), 
                expiracionLarga);

            var selectNiveles = await _cache.ObtenerListaAsync(
                "Niveles", 
                () => _generalRepository.ListarGeneralesPorSeccionAsync(IdSecundaria.Nivel, descendente: true), 
                expiracionLarga);

            var selectEstados = await _cache.ObtenerListaAsync(
                "Estados",
                () => _generalRepository.ListarGeneralesPorSeccionAsync(IdSecundaria.Estado),
                expiracionMedia);

            var selectTipos = await _cache.ObtenerListaAsync(
                "Tipos", 
                () => _generalRepository.ListarGeneralesPorSeccionAsync(IdSecundaria.Tipo), 
                expiracionCorta);

            var selectMedios = await _cache.ObtenerListaAsync(
                "Medios", 
                () => _generalRepository.ListarGeneralesPorSeccionAsync(IdSecundaria.Medio), 
                expiracionCorta);

            ViewBag.Prioridades = new SelectList(selectPrioridad, "IdGeneral", "Nombre");
            ViewBag.Estados = new SelectList(selectEstados, "IdGeneral", "Nombre");
            ViewBag.Tipos = new SelectList(selectTipos, "IdGeneral", "Nombre");
            ViewBag.Niveles = new SelectList(selectNiveles, "IdGeneral", "Nombre");
            ViewBag.Medios = new SelectList(selectMedios, "IdGeneral", "Nombre");
        }
    }
}
