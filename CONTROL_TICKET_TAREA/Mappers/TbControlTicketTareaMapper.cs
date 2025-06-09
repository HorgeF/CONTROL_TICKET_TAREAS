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
                IdItemCenterDesc = request.IdItemCenterDesc?.Trim().ToUpper(),
                CantidadItems = request.CantidadItems,
                NSerie = request.NSerie?.Trim().ToUpper(),
                IdTipo = request.IdTipo,
                Descripcion = request.DescripcionTrimmed.ToUpper(),
                CodTicket = request.CodTicket?.Trim().ToUpper(),
                Contacto = request.Contacto?.Trim().ToUpper(),
                IdEstado = request.IdEstado,
                IdNivel = request.IdNivel,
                Correo = request.Correo,
                Whatsapp = request.Whatsapp,
                Flag = request.Flag,
                UsuReg = request.UsuReg,
                FecReg = DateTime.Now
            };
        }

        public static TbControlTicketTareaRequest ToRequest(this TbControlTicketTareaResponse response)
        {
            return new TbControlTicketTareaRequest
            {
                IdTarea = response.IdTarea,
                IdGe = response.IdGE,
                IdEmpresa = response.IdEmpresa,
                IdReceptor = response.IdReceptor,
                IdMedio = response.IdMedio,
                IdPrioridad = response.IdPrioridad,
                IdTipo = response.IdTipo,
                Descripcion = response.Descripcion,
                IdItemCenter = response.IdItemCenter,
                IdItemCenterDesc = response.IdItemCenterDesc,
                CantidadItems = response.CantidadItems,
                NSerie = response.NSerie,
                CodTicket = response.CodTicket,
                Contacto = response.Contacto,
                IdEstado = response.IdEstado,
                IdNivel = response.IdNivel,
                Correo = response.Correo,
                Whatsapp = response.Whatsapp
            };
        }

        public static TbControlTicketTareaRequest ToRequest(this TbControlTicketTarea entity)
        {
            return new TbControlTicketTareaRequest
            {
                IdTarea = entity.IdTarea,
                IdGe = entity.IdGe,
                IdEmpresa = entity.IdEmpresa,
                IdReceptor = entity.IdReceptor,
                IdMedio = entity.IdMedio,
                IdPrioridad = entity.IdPrioridad,
                IdItemCenter = entity.IdItemCenter,
                IdItemCenterDesc = entity.IdItemCenterDesc,
                CantidadItems = entity.CantidadItems,
                NSerie = entity.NSerie,
                IdTipo = entity.IdTipo,
                Descripcion = entity.Descripcion,
                CodTicket = entity.CodTicket,
                Contacto = entity.Contacto,
                IdEstado = entity.IdEstado,
                IdNivel = entity.IdNivel,
                Correo = entity.Correo,
                Whatsapp = entity.Whatsapp,
                Flag = entity.Flag,
                UsuReg = entity.UsuReg
            };
        }
    }
}
