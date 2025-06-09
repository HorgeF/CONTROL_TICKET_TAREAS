using CONTROL_TICKET_TAREA.Dtos.Combos;

namespace CONTROL_TICKET_TAREA.Repository
{
    public interface IItemCenterRepository
    {
        Task<List<CboItem>> ListarItems();
        Task<string?> ObtenerNombrePorIdItemCenter(int idItemCenter);
    }
}
