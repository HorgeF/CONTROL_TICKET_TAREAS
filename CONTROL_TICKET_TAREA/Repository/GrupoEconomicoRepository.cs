using CONTROL_TICKET_TAREA.Data;
using Microsoft.EntityFrameworkCore;
using CONTROL_TICKET_TAREA.Dtos.Combos;

namespace CONTROL_TICKET_TAREA.Repository
{
    public class GrupoEconomicoRepository(AppDbContext context) : IGrupoEconomicoRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<List<CboGrupoEconomico>> ListarGruposEconomicos()
            => await _context.Gep1Grupoes
                .Select(ge => new CboGrupoEconomico
                {
                    IdGe = ge.IdGe,
                    Nombre = ge.Nombre
                })
                .Where(ge => !string.IsNullOrWhiteSpace(ge.Nombre))
                .OrderBy(ge => ge.Nombre)
                .ToListAsync();
    }
}
