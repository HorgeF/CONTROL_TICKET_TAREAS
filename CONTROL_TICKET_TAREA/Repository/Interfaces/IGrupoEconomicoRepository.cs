using CONTROL_TICKET_TAREA.Dtos.Combos;

namespace CONTROL_TICKET_TAREA.Repository.Interfaces
{
    public interface IGrupoEconomicoRepository
    {
        Task<List<CboGrupoEconomico>> ListarGruposEconomicos();

        Task<List<CboGrupoEconomico>> BuscarGE(string nombre);
    }
}
