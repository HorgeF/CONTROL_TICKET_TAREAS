using CONTROL_TICKET_TAREA.Dtos.Filtros;
using CONTROL_TICKET_TAREA.Dtos.Peticiones;
using CONTROL_TICKET_TAREA.Dtos.Respuestas;
using CONTROL_TICKET_TAREA.Models;

namespace CONTROL_TICKET_TAREA.Repository.Interfaces
{
    public interface IControlTicketTareaRepository
    {
        Task<List<TbControlTicketTareaResponse>> SPListarTicketTarea(FiltroControlTicketTarea filtro);
        Task<List<GrupoCantidadResponse>> ListarGrupoConCantidadAsync(string idSecundaria, Func<TbControlTicketTarea, int?> groupBy);
        Task<TicketResponse?> RegistrarTicket(TicketRequest ticket);
        Task<TbControlTicketTareaResponse?> ObtenerTicketTarea(int idTarea);
        Task Insertar(TbControlTicketTarea entidad);
        Task Actualizar(TbControlTicketTarea entidad);
    }
}
