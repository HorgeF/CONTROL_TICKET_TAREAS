using CONTROL_TICKET_TAREA.Dtos;
using CONTROL_TICKET_TAREA.Dtos.Filtros;
using CONTROL_TICKET_TAREA.Models;

namespace CONTROL_TICKET_TAREA.Repository
{
    public interface IControlTicketTareaRepository
    {
        Task<List<TbControlTicketTareaResponse>> SPListarTicketTarea(FiltroControlTicketTarea filtro);
        Task<TbControlTicketTareaResponse?> ObtenerTicketTarea(int idTarea);
        Task Insertar(TbControlTicketTarea entidad);
        Task Actualizar(TbControlTicketTarea entidad);
    }
}
