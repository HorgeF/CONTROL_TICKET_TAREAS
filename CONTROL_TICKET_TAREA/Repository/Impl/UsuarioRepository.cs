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
    }
}
