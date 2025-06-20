namespace CONTROL_TICKET_TAREA.Repository.Interfaces
{
    public interface ICenterTicketRepository
    {
        Task<bool> ExisteTicket(string codTicket);
    }
}
