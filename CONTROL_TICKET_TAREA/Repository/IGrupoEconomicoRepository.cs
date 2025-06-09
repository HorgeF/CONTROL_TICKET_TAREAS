using CONTROL_TICKET_TAREA.Dtos.Combos;

namespace CONTROL_TICKET_TAREA.Repository
{
    public interface IGrupoEconomicoRepository
    {
        Task<List<CboGrupoEconomico>> ListarGruposEconomicos();
    }
}
