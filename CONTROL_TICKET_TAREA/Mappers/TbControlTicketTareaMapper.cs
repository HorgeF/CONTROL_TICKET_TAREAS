using CONTROL_TICKET_TAREA.Dtos.Peticiones;
using CONTROL_TICKET_TAREA.Dtos.Respuestas;
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
                IdProyecto = request.IdProyecto,
                IdSubProyecto = request.IdSubProyecto,
                IdReceptor = request.IdReceptor,
                FechaTicketTarea = request.FechaTicketTarea,
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
                Dni = request.Dni?.Trim(),
                IdEstado = request.IdEstado,
                IdNivel = request.IdNivel,
                Correo = request.Correo?.Trim().ToUpper(),
                Whatsapp = request.Whatsapp,
                Flag = request.Flag,
                UsuReg = request.UsuReg,
                FecReg = request.FecReg,
                FecCierre = request.FecCierre
            };
        }

        public static TicketRequest ToTicketRequest(this TbControlTicketTareaRequest request)
        {
            return new TicketRequest
            {
                V_ID_USUARIO = request.IdReceptor.ToString(),
                V_NOMBRE = request.DescripcionTrimmed,
                V_DESCRIPCION = request.DescripcionTrimmed,
                V_CANTIDAD = request.CantidadItems,
                V_USUARIO = 959,
                V_FLAG = 1,
                V_ACCION = 1,
                V_DEFECTO = 0,
                V_ID_GE = request.IdGe.ToString(),
                V_ID_EMPRESA = request.IdEmpresa.ToString(),
                V_ID_PROYECTO = request.IdProyecto!.Value,
                V_ID_SUBPROYECTO = request.IdSubProyecto!.Value,
                V_CORREO = request.Correo,
                V_TELEFONO = request.Whatsapp,
                V_NUM_DOC = request.Dni,
                V_SERIE = request.NSerie,
                V_NOMBRE_CONTACTO = request.Contacto,
                V_ESTADO_TICKET = 1057, // REGISTRADO
                V_ID_MEDIO_CONTACTO = request.IdMedio,
                V_ID_TIPO = request.IdTipo,
                V_ID_PRIORIDAD = request.IdPrioridad,
                V_FECHA_TICKET = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            };
        }

        public static TbControlTicketTareaRequest ToRequest(this TbControlTicketTareaResponse response)
        {
            return new TbControlTicketTareaRequest
            {
                IdTarea = response.IdTarea,
                IdGe = response.IdGE,
                Ge = response.GE,
                IdEmpresa = response.IdEmpresa,
                IdProyecto = response.IdProyecto,
                IdSubProyecto = response.IdSubProyecto,
                FechaTicketTarea = response.FechaTicketTarea,
                IdReceptor = response.IdReceptor,
                Receptor = response.Receptor,
                IdMedio = response.IdMedio,
                IdPrioridad = response.IdPrioridad,
                IdTipo = response.IdTipo,
                Descripcion = response.Descripcion,
                IdItemCenter = response.IdItemCenter,
                ItemCenter = response.IdItemCenter == 0 ? "" : response.IdItemCenterDesc,
                IdItemCenterDesc = response.IdItemCenter == 0 ? response.IdItemCenterDesc : "",
                CantidadItems = response.CantidadItems,
                NSerie = response.NSerie,
                CodTicket = response.CodTicket,
                Contacto = response.Contacto,
                IdEstado = response.IdEstado,
                IdNivel = response.IdNivel,
                Dni = response.Dni,
                Correo = response.Correo,
                Whatsapp = response.Whatsapp,
                FecReg = response.FecReg,
                FecCierre = response.FecCierre
            };
        }
    }
}
