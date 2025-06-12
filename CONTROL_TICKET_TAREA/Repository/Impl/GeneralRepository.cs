using CONTROL_TICKET_TAREA.Data;
using CONTROL_TICKET_TAREA.Dtos.Combos;
using CONTROL_TICKET_TAREA.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CONTROL_TICKET_TAREA.Repository.Impl
{
    public class GeneralRepository(AppDbContext context) : IGeneralRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<List<CboGeneral>> ListarGeneralesPorSeccionAsync(string idSecundaria, bool ordenarPorNombre = true, bool descendente = false)
        {
            var query = _context.Generals
                .Where(ge => ge.IdSecundaria == idSecundaria);

            query = ordenarPorNombre
                ? (descendente ? query.OrderByDescending(ge => ge.Nombre) : query.OrderBy(ge => ge.Nombre))
                : (descendente ? query.OrderByDescending(ge => ge.IdGeneral) : query.OrderBy(ge => ge.IdGeneral));

            return await query
                .Select(ge => new CboGeneral
                {
                    IdGeneral = ge.IdGeneral,
                    Nombre = ge.Nombre
                })
                .ToListAsync();
        }


        //public async Task<List<CboGeneral>> ListarPrioridades()
        //    => await _context.Generals
        //        .Where(ge => ge.IdSecundaria == "S1103")
        //        .OrderByDescending(ge => ge.IdGeneral)
        //        .Select(ge => new CboGeneral
        //        {
        //            IdGeneral = ge.IdGeneral,
        //            Nombre = ge.Nombre
        //        })
        //        .ToListAsync();

        //public async Task<List<CboGeneral>> ListarEstados()
        //    => await _context.Generals
        //        .Where(ge => ge.IdSecundaria == "S1128")
        //        .OrderBy(ge => ge.Nombre)
        //        .Select(ge => new CboGeneral
        //        {
        //            IdGeneral = ge.IdGeneral,
        //            Nombre = ge.Nombre
        //        })
        //        .ToListAsync();

        //public async Task<List<CboGeneral>> ListarMedios()
        //    => await _context.Generals
        //        .Where(ge => ge.IdSecundaria == "S1102")
        //        .OrderBy(ge => ge.Nombre)
        //        .Select(ge => new CboGeneral
        //        {
        //            IdGeneral = ge.IdGeneral,
        //            Nombre = ge.Nombre
        //        })
        //        .ToListAsync();

        //public async Task<List<CboGeneral>> ListarTipos()
        //    => await _context.Generals
        //        .Where(ge => ge.IdSecundaria == "S1053")
        //        .OrderBy(ge => ge.Nombre)
        //        .Select(ge => new CboGeneral
        //        {
        //            IdGeneral = ge.IdGeneral,
        //            Nombre = ge.Nombre
        //        })
        //        .ToListAsync();

        //public async Task<List<CboGeneral>> ListarNiveles()
        //    => await _context.Generals
        //        .Where(ge => ge.IdSecundaria == "S1127")
        //        .OrderByDescending(n => n.IdGeneral)
        //        .Select(ge => new CboGeneral
        //        {
        //            IdGeneral = ge.IdGeneral,
        //            Nombre = ge.Nombre
        //        })
        //        .ToListAsync();
    }
}
