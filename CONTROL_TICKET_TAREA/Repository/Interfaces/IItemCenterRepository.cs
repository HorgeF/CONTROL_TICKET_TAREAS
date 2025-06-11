using CONTROL_TICKET_TAREA.Dtos.Combos;

namespace CONTROL_TICKET_TAREA.Repository.Interfaces
{
    public interface IItemCenterRepository
    {
        Task<List<CboItem>> ListarItems();
        Task<string?> ObtenerNombrePorIdItemCenter(int idItemCenter);
        Task<List<CboItem>> BuscarItems(string nombre);
    }
}
