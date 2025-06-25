using CONTROL_TICKET_TAREA.Dtos.Combos;

namespace CONTROL_TICKET_TAREA.Repository.Interfaces
{
    public interface ISubProyectoRepository
    {
        Task<List<CboSubProyecto>> ListarSubProyectos(int? IdProyecto);
    }
}
