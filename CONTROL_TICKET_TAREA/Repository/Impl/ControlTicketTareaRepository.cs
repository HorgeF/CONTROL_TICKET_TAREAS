using CONTROL_TICKET_TAREA.Data;
using CONTROL_TICKET_TAREA.Dtos.Filtros;
using CONTROL_TICKET_TAREA.Dtos.Peticiones;
using CONTROL_TICKET_TAREA.Dtos.Respuestas;
using CONTROL_TICKET_TAREA.Models;
using CONTROL_TICKET_TAREA.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CONTROL_TICKET_TAREA.Repository.Impl
{
    public class ControlTicketTareaRepository(AppDbContext context, ILogger<ControlTicketTareaRepository> logger) : IControlTicketTareaRepository
    {
        private readonly AppDbContext _context = context;
        private readonly ILogger<ControlTicketTareaRepository> _logger = logger;

        public async Task<List<TbControlTicketTareaResponse>> SPListarTicketTarea(FiltroControlTicketTarea filtro)
        {
            string prioridadesCsv = "";
            string nivelesCsv = "";
            int IdReceptor = filtro.IdReceptor == 0 ? -1 : filtro.IdReceptor;
            int IdEstado = filtro.IdEstado == 0 ? -1 : filtro.IdEstado;

            if(filtro.PrioridadInd == null && filtro.NivelInd == null)
            {
                prioridadesCsv = filtro.Prioridad != null && filtro.Prioridad.Any()
                    ? string.Join(",", filtro.Prioridad)
                    : "%";

                nivelesCsv = filtro.Nivel != null && filtro.Nivel.Any()
                    ? string.Join(",", filtro.Nivel)
                    : "%";

                return await _context.TbControlTicketTareaResponses
                .FromSqlInterpolated($"EXEC SP_LISTAR_TICKET_TAREA @ID_PRIORIDAD={prioridadesCsv},@ID_NIVEL={nivelesCsv},@ID_RESPONSABLE={IdReceptor},@ID_ESTADO={IdEstado}")
                .ToListAsync();
            }

            return await _context.TbControlTicketTareaResponses
                .FromSqlInterpolated($"EXEC SP_LISTAR_TICKET_TAREA @ID_PRIORIDAD={filtro.PrioridadInd},@ID_NIVEL={filtro.NivelInd},@ID_RESPONSABLE={IdReceptor},@ID_ESTADO={IdEstado}")
                .ToListAsync();
        }

        public async Task<List<GrupoCantidadResponse>> ListarGrupoConCantidadAsync(string idSecundaria, Func<TbControlTicketTarea, int?> groupBy)
        {
            var grupos = await _context.Generals
                .Where(g => g.IdSecundaria == idSecundaria)
                .Select(g => new { g.IdGeneral, g.Descripcion })
                .ToListAsync();

            var conteos = _context.TbControlTicketTareas
                .GroupBy(groupBy)
                .Select(g => new
                {
                    Id = g.Key,
                    Cantidad = g.Count()
                })
                .ToList();

            var resultado = grupos
                .GroupJoin(conteos,
                    g => g.IdGeneral,
                    c => c.Id,
                    (g, c) => new GrupoCantidadResponse
                    {
                        Id = g.IdGeneral,
                        Nombre = g.Descripcion!,
                        Cantidad = c.FirstOrDefault()?.Cantidad ?? 0
                    })
                .OrderByDescending(x => x.Id)
                .ToList();

            foreach (var item in resultado)
            {
                Debug.WriteLine($"Id: {item.Id}, Nombre: {item.Nombre}, Cantidad: {item.Cantidad}");
            }

            return resultado;
        }

        public async Task<TicketResponse?> RegistrarTicket(TicketRequest ticket)
        {
            // Asegura que los campos opcionales no sean null (si el SP no los admite)
            ticket.V_CORREO ??= "";
            ticket.V_TELEFONO ??= "";
            ticket.V_SERIE ??= "";
            ticket.V_NOMBRE_CONTACTO ??= "";

            var result = await _context.TicketResponses
                .FromSqlInterpolated($@"
            EXEC [dbo].[SP_MANT_TICKET_V3] 
                @V_ID_TICKET = {ticket.V_ID_TICKET}, 
                @V_ID_USUARIO = {ticket.V_ID_USUARIO}, 
                @V_NOMBRE = {ticket.V_NOMBRE}, 
                @V_DESCRIPCION = {ticket.V_DESCRIPCION}, 
                @V_SIGLA = {ticket.V_SIGLA}, 
                @V_IMG = {ticket.V_IMG}, 
                @V_CANTIDAD = {ticket.V_CANTIDAD}, 
                @V_DEFECTO = {ticket.V_DEFECTO}, 
                @V_HABILITADO = {ticket.V_HABILITADO}, 
                @V_AUTORIZADO = {ticket.V_AUTORIZADO}, 
                @V_USUARIO = {ticket.V_USUARIO}, 
                @V_FLAG = {ticket.V_FLAG}, 
                @V_ACCION = {ticket.V_ACCION}, 
                @V_ID_GE = {ticket.V_ID_GE}, 
                @V_ID_EMPRESA = {ticket.V_ID_EMPRESA}, 
                @V_UBICACION = {ticket.V_UBICACION}, 
                @V_CORREO = {ticket.V_CORREO}, 
                @V_TELEFONO = {ticket.V_TELEFONO}, 
                @V_SERIE = {ticket.V_SERIE}, 
                @V_NOMBRE_CONTACTO = {ticket.V_NOMBRE_CONTACTO}, 
                @V_NUM_DOC = {ticket.V_NUM_DOC}, 
                @V_ESTADO_TICKET = {ticket.V_ESTADO_TICKET}, 
                @V_ID_MOTIVO = {ticket.V_ID_MOTIVO}, 
                @V_ID_PROYECTO = {ticket.V_ID_PROYECTO}, 
                @V_ID_SUBPROYECTO = {ticket.V_ID_SUBPROYECTO}, 
                @V_ID_SITE = {ticket.V_ID_SITE}, 
                @V_ID_MEDIO_CONTACTO = {ticket.V_ID_MEDIO_CONTACTO}, 
                @V_ID_PRIORIDAD = {ticket.V_ID_PRIORIDAD}, 
                @V_ID_NIVEL = {ticket.V_ID_NIVEL}, 
                @V_FECHA_TICKET = {ticket.V_FECHA_TICKET}, 
                @V_ID_CATEGORIA = {ticket.V_ID_CATEGORIA}, 
                @V_ID_WEB_EXT = {ticket.V_ID_WEB_EXT}, 
                @V_MOTIVO_CIERRA = {ticket.V_MOTIVO_CIERRA}
            ")
                .AsNoTracking()
                .ToListAsync();

            return result.FirstOrDefault();
        }


        public async Task<TbControlTicketTareaResponse?> ObtenerTicketTarea(int idTarea)
        {
            var result = await _context.TbControlTicketTareaResponses
                .FromSqlRaw("EXEC SP_OBTENER_TICKET_TAREA @p0", idTarea)
                .AsNoTracking()
                .ToListAsync();

            var ticket = result.FirstOrDefault();
            return ticket;
        }

        public async Task Insertar(TbControlTicketTarea entidad)
        {
            await _context.TbControlTicketTareas.AddAsync(entidad);
            await _context.SaveChangesAsync();
        }

        public async Task Actualizar(TbControlTicketTarea entidad)
        {
            entidad.FecAct = DateTime.Now;
            _context.TbControlTicketTareas.Update(entidad);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ActualizarEstado(string codTicket, int idNuevoEstado)
        {
            var entidad = await _context.TbControlTicketTareas
                .FirstOrDefaultAsync(t => t.CodTicket == codTicket);

            if(entidad == null)
            {
                _logger.LogWarning("No se encontro la tarea con el cod ticket: '{@codTicket}' - {Time}", codTicket,DateTime.Now);
                return false;
            }

            entidad.IdEstado = idNuevoEstado;
            entidad.FecAct = DateTime.Now;

            await _context.SaveChangesAsync();
            _logger.LogInformation("Se logro actualizar el estado de la tarea con el codTicket: '{@codTicket}' - {Time}", codTicket, DateTime.Now);
            return true;
        }
    }
}
