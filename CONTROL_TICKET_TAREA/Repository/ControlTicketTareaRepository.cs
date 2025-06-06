using CONTROL_TICKET_TAREA.Data;
using CONTROL_TICKET_TAREA.Dtos;
using CONTROL_TICKET_TAREA.Models;
using Microsoft.EntityFrameworkCore;

namespace CONTROL_TICKET_TAREA.Repository
{
    public class ControlTicketTareaRepository(AppDbContext context) : IControlTicketTareaRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<List<TbControlTicketTareaResponseProv>> SPListarTicketTarea()
            => await _context.TbControlTicketTareaResponses
                .FromSqlInterpolated($"EXEC SP_LISTAR_TICKET_TAREA")
                .ToListAsync();

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
