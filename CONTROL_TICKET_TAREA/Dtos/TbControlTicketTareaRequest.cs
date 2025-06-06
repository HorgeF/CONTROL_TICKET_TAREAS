using System.ComponentModel.DataAnnotations;

namespace CONTROL_TICKET_TAREA.Dtos
{
    public class TbControlTicketTareaRequest
    {
        public int IdTarea { get; set; }

        //[Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un grupo económico.")]
        public int IdGe { get; set; }

        //[Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una empresa / entidad.")]
        public int IdEmpresa { get; set; }

        //[Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un receptor.")]
        public int IdReceptor { get; set; }

        //[Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un medio.")]
        public int IdMedio { get; set; }

        //[Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una prioridad")]
        public int IdPrioridad { get; set; }

        //[Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un item")]
        public int IdItemCenter { get; set; }

        public string? IdItemCenterDesc { get; set; }

        //[Range(1, int.MaxValue, ErrorMessage = "Ingrese una cantidad mayor a 0")]
        public int CantidadItems { get; set; }

        //[Required(ErrorMessage = "Ingrese un n° serie")]
        public string? NSerie { get; set; }

        //[Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un tipo")]
        public int IdTipo { get; set; }

        //[Required(ErrorMessage = "Ingrese una descripción")]
        public string? Descripcion { get; set; }

        public string DescripcionTrimmed => Descripcion?.Trim() ?? "";

        //[Required(ErrorMessage = "Ingrese un código ticket")]
        public string? CodTicket { get; set; }

        //[Required(ErrorMessage = "Ingrese un contacto")]
        public string? Contacto { get; set; }

        //[Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un estado")]
        public int IdEstado { get; set; }

        public int? Flag { get; set; } = 1;

        public int? UsuReg { get; set; } = 959;
    }
}
