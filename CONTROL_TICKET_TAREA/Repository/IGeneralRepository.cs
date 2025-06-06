using CONTROL_TICKET_TAREA.Dtos.Combos;

namespace CONTROL_TICKET_TAREA.Repository
{
    public interface IGeneralRepository
    {
        Task<List<CboGeneral>> ListarPrioridadesParaSelect();
        Task<List<CboGeneral>> ListarEstadosParaSelect();
    }
}
