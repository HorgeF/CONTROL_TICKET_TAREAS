using CONTROL_TICKET_TAREA.Data;
using CONTROL_TICKET_TAREA.Dtos.Combos;
using Microsoft.EntityFrameworkCore;

namespace CONTROL_TICKET_TAREA.Repository
{
    public class GeneralRepository(AppDbContext context) : IGeneralRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<List<CboGeneral>> ListarPrioridades()
            => await _context.Generals
                .Where(ge => ge.IdSecundaria == "S1103")
                .OrderBy(ge => ge.Nombre)
                .Select(ge => new CboGeneral
                {
                    IdGeneral = ge.IdGeneral,
                    Nombre = ge.Nombre
                })
                .ToListAsync();

        public async Task<List<CboGeneral>> ListarEstados()
            => await _context.Generals
                .Where(ge => ge.IdSecundaria == "S1100")
                .OrderBy(ge => ge.Nombre)
                .Select(ge => new CboGeneral
                {
                    IdGeneral = ge.IdGeneral,
                    Nombre = ge.Nombre
                })
                .ToListAsync();

        public async Task<List<CboGeneral>> ListarMedios()
            => await _context.Generals
                .Where(ge => ge.IdSecundaria == "S1102")
                .OrderBy(ge => ge.Nombre)
                .Select(ge => new CboGeneral
                {
                    IdGeneral = ge.IdGeneral,
                    Nombre = ge.Nombre
                })
                .ToListAsync();

        public async Task<List<CboGeneral>> ListarTipos()
            => await _context.Generals
                .Where(ge => ge.IdSecundaria == "S1053")
                .OrderBy(ge => ge.Nombre)
                .Select(ge => new CboGeneral
                {
                    IdGeneral = ge.IdGeneral,
                    Nombre = ge.Nombre
                })
                .ToListAsync();

        public async Task<List<CboGeneral>> ListarNiveles()
            => await _context.Generals
                .Where(ge => ge.IdSecundaria == "S1127")
                .OrderByDescending(n => n.IdGeneral)
                .Select(ge => new CboGeneral
                {
                    IdGeneral = ge.IdGeneral,
                    Nombre = ge.Nombre
                })
                .ToListAsync();
    }
}
