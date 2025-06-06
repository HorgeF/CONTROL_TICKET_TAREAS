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
                .Select(u => new CboItem
                {
                    IdItemCenter = u.IdItemCenter,
                    Nombre =
                        u.Descripcion + " " +
                        (string.IsNullOrEmpty(u.NSerie) ? "" : u.NSerie) +
                        (string.IsNullOrEmpty(u.NParte) ? "" : u.NParte)
                })
                .OrderBy(u => u.Nombre)
                .ToListAsync();
    }
}
