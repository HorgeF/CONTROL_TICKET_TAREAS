using CONTROL_TICKET_TAREA.Data;
using Microsoft.EntityFrameworkCore;
using CONTROL_TICKET_TAREA.Dtos.Combos;
using CONTROL_TICKET_TAREA.Repository.Interfaces;

namespace CONTROL_TICKET_TAREA.Repository.Impl
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

        public async Task<List<CboGrupoEconomico>> BuscarGE(string nombre)
            => await _context.Gep1Grupoes
                .Where(ge => ge.Nombre!.Trim().Contains(nombre) && !string.IsNullOrWhiteSpace(ge.Nombre))
                .Select(ge => new CboGrupoEconomico
                {
                    IdGe = ge.IdGe,
                    Nombre = ge.Nombre
                })
                .OrderBy(ge => ge.Nombre)
                .Take(10)
                .ToListAsync();
    }
}
