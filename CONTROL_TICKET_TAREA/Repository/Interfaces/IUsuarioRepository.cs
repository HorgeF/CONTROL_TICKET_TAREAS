using CONTROL_TICKET_TAREA.Dtos.Combos;

namespace CONTROL_TICKET_TAREA.Repository.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<List<CboUsuario>> ListarUsuarios();
        Task<List<CboUsuario>> BuscarResponsables(string nombre);
    }
}
