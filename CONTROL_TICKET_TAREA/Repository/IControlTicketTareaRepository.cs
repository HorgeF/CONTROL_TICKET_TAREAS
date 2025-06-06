using CONTROL_TICKET_TAREA.Dtos;
using CONTROL_TICKET_TAREA.Models;

namespace CONTROL_TICKET_TAREA.Repository
{
    public interface IControlTicketTareaRepository
    {
        Task<List<TbControlTicketTareaResponseProv>> SPListarTicketTarea();
        Task Insertar(TbControlTicketTarea entidad);
        Task Actualizar(TbControlTicketTarea entidad);
    }
}
