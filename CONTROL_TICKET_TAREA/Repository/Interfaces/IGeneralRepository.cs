using CONTROL_TICKET_TAREA.Dtos.Combos;

namespace CONTROL_TICKET_TAREA.Repository.Interfaces
{
    public interface IGeneralRepository
    {
        Task<List<CboGeneral>> ListarGeneralesPorSeccionAsync(string idSecundaria, bool ordenarPorNombre = true, bool descendente = false);
        //Task<List<CboGeneral>> ListarPrioridades();
        //Task<List<CboGeneral>> ListarEstados();
        //Task<List<CboGeneral>> ListarMedios();
        //Task<List<CboGeneral>> ListarTipos();
        //Task<List<CboGeneral>> ListarNiveles();
    }
}
