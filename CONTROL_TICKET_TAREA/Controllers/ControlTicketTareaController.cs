using CONTROL_TICKET_TAREA.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CONTROL_TICKET_TAREA.Controllers
{
    public class ControlTicketTareaController(IControlTicketTareaRepository controlTicketTareaRepository) : Controller
    {
        private readonly IControlTicketTareaRepository _controlTicketTareaRepository = controlTicketTareaRepository;

        [HttpGet]
        public async Task<IActionResult> SPListarTicketTarea()
        {
            var ticketTareas = await _controlTicketTareaRepository.SPListarTicketTarea();
            return View(ticketTareas);
        }
    }
}
