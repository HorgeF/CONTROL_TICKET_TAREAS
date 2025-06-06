using CONTROL_TICKET_TAREA.Dtos;
using CONTROL_TICKET_TAREA.Models;

namespace CONTROL_TICKET_TAREA.Mappers
{
    public static class TbControlTicketTareaMapper
    {
        public static TbControlTicketTarea ToEntity(this TbControlTicketTareaRequest request)
        {
            return new TbControlTicketTarea
            {
                IdTarea = request.IdTarea,
                IdGe = request.IdGe,
                IdEmpresa = request.IdEmpresa,
                FechaTicketTarea = DateTime.Now,
                IdReceptor = request.IdReceptor,
                IdMedio = request.IdMedio,
                IdPrioridad = request.IdPrioridad,
                IdItemCenter = request.IdItemCenter,
                IdItemCenterDesc = request.IdItemCenterDesc,
                CantidadItems = request.CantidadItems,
                NSerie = request.NSerie?.ToUpper(),
                IdTipo = request.IdTipo,
                Descripcion = request.DescripcionTrimmed.ToUpper(),
                CodTicket = request.CodTicket,
                Contacto = request.Contacto?.ToUpper(),
                IdEstado = request.IdEstado,
                Flag = request.Flag,
                UsuReg = request.UsuReg,
                FecReg = DateTime.Now
            };
        }
    }
}
