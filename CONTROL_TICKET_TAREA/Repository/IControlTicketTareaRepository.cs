using CONTROL_TICKET_TAREA.Dtos;

namespace CONTROL_TICKET_TAREA.Repository
{
    public interface IControlTicketTareaRepository
    {
        Task<List<TbControlTicketTareaResponseProv>> SPListarTicketTarea();
    }
}
