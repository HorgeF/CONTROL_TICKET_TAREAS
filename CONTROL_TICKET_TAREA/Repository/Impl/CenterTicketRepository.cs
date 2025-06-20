using CONTROL_TICKET_TAREA.Data;
using CONTROL_TICKET_TAREA.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CONTROL_TICKET_TAREA.Repository.Impl
{
    public class CenterTicketRepository(AppDbContext context) : ICenterTicketRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<bool> ExisteTicket(string codTicket)
            => await _context.CenterTickets.AnyAsync(ct => ct.CorrelSupremoExterno == codTicket);
    }
}
