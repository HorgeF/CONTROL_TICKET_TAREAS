using CONTROL_TICKET_TAREA.Data;
using CONTROL_TICKET_TAREA.Dtos;
using CONTROL_TICKET_TAREA.Dtos.Filtros;
using CONTROL_TICKET_TAREA.Models;
using Microsoft.EntityFrameworkCore;

namespace CONTROL_TICKET_TAREA.Repository
{
    public class ControlTicketTareaRepository(Data.AppDbContext context) : IControlTicketTareaRepository
    {
        private readonly Data.AppDbContext _context = context;

        public async Task<List<TbControlTicketTareaResponse>> SPListarTicketTarea(FiltroControlTicketTarea filtro)
        {
            var prioridadesCsv = filtro.Prioridad != null && filtro.Prioridad.Any()
                ? string.Join(",", filtro.Prioridad)
                : "%";

            var nivelesCsv = filtro.Nivel != null && filtro.Nivel.Any()
                ? string.Join(",", filtro.Nivel)
                : "%";

            return await _context.TbControlTicketTareaResponses
                .FromSqlInterpolated($"EXEC SP_LISTAR_TICKET_TAREA @ID_PRIORIDAD={prioridadesCsv},@ID_NIVEL={nivelesCsv}")
                .ToListAsync();
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
            _context.TbControlTicketTareas.Update(entidad);
            await _context.SaveChangesAsync();
        }
    }
}
