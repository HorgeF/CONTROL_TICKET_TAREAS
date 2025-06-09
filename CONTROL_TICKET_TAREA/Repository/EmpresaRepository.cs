using CONTROL_TICKET_TAREA.Data;
using CONTROL_TICKET_TAREA.Dtos.Combos;
using Microsoft.EntityFrameworkCore;

namespace CONTROL_TICKET_TAREA.Repository
{
    public class EmpresaRepository(AppDbContext context) : IEmpresaRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<List<CboEmpresa>> ListarEmpresas(int IdGe)
            => await _context.Gep2Empresas
                .Where(ge => ge.IdGe == IdGe)
                .Select(ge => new CboEmpresa
                {
                    IdEmpresa = ge.IdEmpresa,
                    RazonSocial = ge.RazonSocial
                })
                .OrderBy(ge => ge.RazonSocial)
                .ToListAsync();
    }
}
