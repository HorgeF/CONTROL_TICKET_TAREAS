using CONTROL_TICKET_TAREA.Data;
using CONTROL_TICKET_TAREA.Dtos.Combos;
using CONTROL_TICKET_TAREA.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CONTROL_TICKET_TAREA.Repository.Impl
{
    public class ProyectoRepository(AppDbContext context) : IProyectoRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<List<CboProyecto>> ListarProyectos(int IdEmpresa)
            => await _context.Gep3Proyectos
                .Where(ge => ge.IdEmpresa == IdEmpresa && ge.Flag == 1)
                .Select(ge => new CboProyecto
                {
                    IdProyecto = ge.IdProyecto,
                    Proyecto = ge.Nombre
                })
                .OrderBy(ge => ge.Proyecto)
                .ToListAsync();
    }
}
