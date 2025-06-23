using CONTROL_TICKET_TAREA.Data;
using CONTROL_TICKET_TAREA.Dtos.Combos;
using CONTROL_TICKET_TAREA.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CONTROL_TICKET_TAREA.Repository.Impl
{
    public class UsuarioRepository(AppDbContext context) : IUsuarioRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<List<CboUsuario>> ListarUsuarios()
            => await _context.Usuarios
                .Where(u => u.IdTipoEmpleado > 0 && u.Flag == 1)
                .Select(u => new CboUsuario
                {
                    IdUsuario = u.IdUsuario,
                    Nombre = u.Nombres + " " + u.ApellidoP
                })
                .OrderBy(u => u.Nombre)
                .ToListAsync();

        public async Task<List<CboUsuario>> BuscarResponsables(string nombre)
            => await _context.Usuarios
                .Where(u => 
                    (u.Nombres!.Trim() + " " + u.ApellidoP!.Trim()).Contains(nombre) && 
                    !string.IsNullOrWhiteSpace(u.Nombres) && 
                    u.IdTipoEmpleado > 0 && 
                    u.Flag == 1)
                .Take(10)
                .Select(u => new CboUsuario
                {
                    IdUsuario = u.IdUsuario,
                    Nombre = u.Nombres + " " + u.ApellidoP
                })
                .OrderBy(u => u.Nombre)
                .ToListAsync();

        public async Task<List<string>> ObtenerNombresPorIds(List<int> IdsReceptores)
        {
            if (IdsReceptores == null || !IdsReceptores.Any())
                return new List<string>();

            return await _context.Usuarios
                .Where(r => IdsReceptores.Contains(r.IdUsuario))
                .Select(r => r.Nombres + " " + r.ApellidoP)
                .ToListAsync();
        }
    }
}
