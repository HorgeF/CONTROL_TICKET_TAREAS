﻿using CONTROL_TICKET_TAREA.Data;
using CONTROL_TICKET_TAREA.Dtos.Filtros;
using CONTROL_TICKET_TAREA.Dtos.Peticiones;
using CONTROL_TICKET_TAREA.Dtos.Respuestas;
using CONTROL_TICKET_TAREA.Models;
using CONTROL_TICKET_TAREA.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CONTROL_TICKET_TAREA.Repository.Impl
{
    public class ControlTicketTareaRepository(AppDbContext context) : IControlTicketTareaRepository
    {
        private readonly AppDbContext _context = context;

        private const int ESTADO_CERRADO = 1269;

        public async Task<List<TbControlTicketTareaResponse>> SPListarTicketTarea(FiltroControlTicketTarea filtro)
        {
            int IdEstado = filtro.IdEstado == 0 ? -1 : filtro.IdEstado;

            string receptoresCsv = filtro.IdsReceptores != null && filtro.IdsReceptores.Any()
                ? string.Join(",", filtro.IdsReceptores)
                : "%";

            // Prioridades
            string? prioridadesCsv = filtro.PrioridadInd != null
                ? filtro.PrioridadInd.ToString()
                : (filtro.Prioridad != null && filtro.Prioridad.Count != 0 ? string.Join(",", filtro.Prioridad) : "%");

            // Niveles
            string? nivelesCsv = filtro.NivelInd != null
                ? filtro.NivelInd.ToString()
                : (filtro.Nivel != null && filtro.Nivel.Count != 0 ? string.Join(",", filtro.Nivel) : "%");

            return await _context.TbControlTicketTareaResponses
                .FromSqlInterpolated($"EXEC SP_LISTAR_TICKET_TAREA @ID_PRIORIDAD={prioridadesCsv},@ID_NIVEL={nivelesCsv},@ID_RESPONSABLE={receptoresCsv},@ID_ESTADO={IdEstado}")
                .ToListAsync();
        }

        public async Task<List<TbControlTicketTareaResponse>> ListarReporteTareasSemanal(FiltroControlTicketTarea filtro)
        {
            int IdEstado = filtro.IdEstado == 0 ? -1 : filtro.IdEstado;

            string receptoresCsv = filtro.IdsReceptores != null && filtro.IdsReceptores.Any()
                ? string.Join(",", filtro.IdsReceptores)
                : "%";

            if (filtro.PrioridadInd == null && filtro.NivelInd == null)
            {
                string prioridadesCsv = filtro.Prioridad != null && filtro.Prioridad.Any()
                    ? string.Join(",", filtro.Prioridad)
                    : "%";

                string nivelesCsv = filtro.Nivel != null && filtro.Nivel.Any()
                    ? string.Join(",", filtro.Nivel)
                    : "%";

                return await _context.TbControlTicketTareaResponses
                .FromSqlInterpolated($"EXEC SP_REPORTAR_TICKET_TAREA @ID_PRIORIDAD={prioridadesCsv},@ID_NIVEL={nivelesCsv},@ID_RESPONSABLE={receptoresCsv},@ID_ESTADO={IdEstado}")
                .ToListAsync();
            }

            return await _context.TbControlTicketTareaResponses
                .FromSqlInterpolated($"EXEC SP_REPORTAR_TICKET_TAREA @ID_PRIORIDAD={filtro.PrioridadInd},@ID_NIVEL={filtro.NivelInd},@ID_RESPONSABLE={receptoresCsv},@ID_ESTADO={IdEstado}")
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

            return resultado;
        }

        public async Task<bool> EsCodTicketTomado(string codTicket, int idTarea = 0)
        {
            var query = _context.TbControlTicketTareas.AsQueryable();
            if (idTarea == 0)
                return await query.AnyAsync(t => t.CodTicket == codTicket);
            else
                return await query.AnyAsync(t => t.CodTicket == codTicket &&  t.IdTarea != idTarea);
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
                @V_ID_TIPO = {ticket.V_ID_TIPO},
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
                .FromSqlRaw("EXEC SP_LISTAR_TICKET_TAREA @p0", idTarea)
                .AsNoTracking()
                .ToListAsync();

            var ticket = result.FirstOrDefault();
            return ticket;
        }

        public async Task Insertar(TbControlTicketTarea entidad)
        {
            // Fecha de actualización será usado como fecha de cierre
            if (entidad.IdEstado == ESTADO_CERRADO)
                entidad.FecCierre = DateTime.Now;

            await _context.TbControlTicketTareas.AddAsync(entidad);
            await _context.SaveChangesAsync();
        }

        public async Task Actualizar(TbControlTicketTarea entidad)
        {
            // Fecha de actualización será usado como fecha de cierre
            if(entidad.FecCierre == null && entidad.IdEstado == ESTADO_CERRADO)
                entidad.FecCierre = DateTime.Now;

            _context.TbControlTicketTareas.Update(entidad);
            await _context.SaveChangesAsync();
        }

        public async Task<int> ObtenerEstado(int idTarea)
            => await _context.TbControlTicketTareas
                .Where(t => t.IdTarea == idTarea)
                .Select(t => t.IdEstado)
                .FirstOrDefaultAsync();

        public async Task<bool> ExisteTarea(int idTarea)
            => await _context.TbControlTicketTareas.AnyAsync(t => t.IdTarea == idTarea);
    }
}
