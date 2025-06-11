using CONTROL_TICKET_TAREA.Data;
using CONTROL_TICKET_TAREA.Dtos.Combos;
using CONTROL_TICKET_TAREA.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CONTROL_TICKET_TAREA.Repository.Impl
{
    public class ItemCenterRepository(AppDbContext context) : IItemCenterRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<List<CboItem>> ListarItems()
            => await _context.ItemCenters
                .Where(ic => ic.IndInventario == 1 && ic.IdItemCenter != 0 && ic.IdEmpresa != 0)
                .OrderBy(u => u.Descripcion)
                .Select(u => new CboItem
                {
                    IdItemCenter = u.IdItemCenter,
                    Descripcion = u.Descripcion!
                })
                .ToListAsync();

        public async Task<string?> ObtenerNombrePorIdItemCenter(int idItemCenter)
            => await _context.ItemCenters
                .Where(ic => ic.IdItemCenter == idItemCenter)
                .Select(u => u.Descripcion)
                .FirstOrDefaultAsync();
    }
}
