using CONTROL_TICKET_TAREA.Data;
using CONTROL_TICKET_TAREA.Dtos.Combos;
using Microsoft.EntityFrameworkCore;

namespace CONTROL_TICKET_TAREA.Repository
{
    public class ItemCenterRepository(AppDbContext context) : IItemCenterRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<List<CboItem>> ListarItemsParaSelect()
            => await _context.ItemCenters
                .Where(ic => ic.IndInventario == 1 && ic.IdItemCenter != 0 && ic.IdEmpresa != 0)
                .Select(u => new CboItem
                {
                    IdItemCenter = u.IdItemCenter,
                    Nombre = u.Descripcion!
                })
                .OrderBy(u => u.Nombre)
                .ToListAsync();

        public async Task<string?> ObtenerNombrePorIdItemCenter(int idItemCenter)
            => await _context.ItemCenters
                .Where(ic => ic.IdItemCenter == idItemCenter)
                .Select(u => u.Descripcion)
                .FirstOrDefaultAsync();
    }
}
