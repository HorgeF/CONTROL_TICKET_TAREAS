using CONTROL_TICKET_TAREA.Data;
using CONTROL_TICKET_TAREA.Dtos.Combos;
using Microsoft.EntityFrameworkCore;

namespace CONTROL_TICKET_TAREA.Repository
{
    public class GeneralRepository(AppDbContext context) : IGeneralRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<List<CboGeneral>> ListarPrioridadesParaSelect()
            => await _context.Generals
                .Where(ge => ge.IdSecundaria == "S1103")
                .Select(ge => new CboGeneral
                {
                    IdGeneral = ge.IdGeneral,
                    Nombre = ge.Nombre
                })
                .OrderBy(ge => ge.Nombre)
                .ToListAsync();

        public async Task<List<CboGeneral>> ListarEstadosParaSelect()
            => await _context.Generals
                .Where(ge => ge.IdSecundaria == "S1100")
                .Select(ge => new CboGeneral
                {
                    IdGeneral = ge.IdGeneral,
                    Nombre = ge.Nombre
                })
                .OrderBy(ge => ge.Nombre)
                .ToListAsync();
    }
}
