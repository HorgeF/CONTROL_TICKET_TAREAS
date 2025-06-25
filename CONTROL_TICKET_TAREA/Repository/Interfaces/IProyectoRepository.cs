using CONTROL_TICKET_TAREA.Dtos.Combos;

namespace CONTROL_TICKET_TAREA.Repository.Interfaces
{
    public interface IProyectoRepository
    {
        Task<List<CboProyecto>> ListarProyectos(int IdEmpresa);
    }
}
