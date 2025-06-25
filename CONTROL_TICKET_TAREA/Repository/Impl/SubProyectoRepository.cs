using CONTROL_TICKET_TAREA.Data;
using CONTROL_TICKET_TAREA.Dtos.Combos;
using CONTROL_TICKET_TAREA.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CONTROL_TICKET_TAREA.Repository.Impl
{
    public class SubProyectoRepository(AppDbContext context) : ISubProyectoRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<List<CboSubProyecto>> ListarSubProyectos(int? IdProyecto)
            => await _context.Gep4Subproyectos
                .Where(ge => ge.IdProyecto == IdProyecto && ge.Flag == 1)
                .Select(ge => new CboSubProyecto
                {
                    IdSubProyecto = ge.IdSubProyecto,
                    SubProyecto = ge.Nombre
                })
                .OrderBy(ge => ge.SubProyecto)
                .ToListAsync();
    }
}
