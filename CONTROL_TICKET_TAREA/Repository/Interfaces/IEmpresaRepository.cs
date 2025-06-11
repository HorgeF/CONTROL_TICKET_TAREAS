using CONTROL_TICKET_TAREA.Dtos.Combos;

namespace CONTROL_TICKET_TAREA.Repository.Interfaces
{
    public interface IEmpresaRepository
    {
        Task<List<CboEmpresa>> ListarEmpresas(int IdGe);
    }
}
