using System.ComponentModel.DataAnnotations;

namespace CONTROL_TICKET_TAREA.Dtos.Peticiones
{
    public class TbControlTicketTareaRequest
    {
        public int IdTarea { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un grupo económico.")]
        public int IdGe { get; set; }

        [Required(ErrorMessage = "Debe seleccionar una empresa / entidad.")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una empresa / entidad.")]
        public int IdEmpresa { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un receptor.")]
        public int IdReceptor { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un medio.")]
        public int IdMedio { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una prioridad")]
        public int IdPrioridad { get; set; }

        public int IdItemCenter { get; set; }

        [Required(ErrorMessage = "Ingrese un item")]
        public string? IdItemCenterDesc { get; set; }

        [Required(ErrorMessage = "Ingrese una cantidad mayor a 0")]
        [Range(1, int.MaxValue, ErrorMessage = "Ingrese una cantidad mayor a 0")]
        public int CantidadItems { get; set; }

        //[Required(ErrorMessage = "Ingrese un n° serie")]
        public string? NSerie { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un tipo")]
        public int IdTipo { get; set; }

        [Required(ErrorMessage = "Ingrese una descripción")]
        public string? Descripcion { get; set; }

        public string DescripcionTrimmed => Descripcion?.Trim() ?? "";

        public string? CodTicket { get; set; }

        [Required(ErrorMessage = "Ingrese un contacto")]
        public string? Contacto { get; set; }

        [RegularExpression(@"^\d{8}$", ErrorMessage = "El DNI debe contener exactamente 8 números.")]
        public string? Dni { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un estado")]
        public int IdEstado { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un nivel")]
        public int? IdNivel { get; set; }

        public string? Correo { get; set; } = string.Empty;

        public string? Whatsapp { get; set; } = string.Empty;

        public int? Flag { get; set; } = 1;

        public int? UsuReg { get; set; } = 959;
    }
}
