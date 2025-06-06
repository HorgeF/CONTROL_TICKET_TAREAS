using CONTROL_TICKET_TAREA.Dtos.Combos;

namespace CONTROL_TICKET_TAREA.Repository
{
    public interface IUsuarioRepository
    {
        Task<List<CboUsuario>> ListarUsuariosParaSelect();
    }
}
