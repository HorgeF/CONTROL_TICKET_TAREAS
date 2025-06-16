using System.ComponentModel.DataAnnotations;

namespace CONTROL_TICKET_TAREA.Dtos.Peticiones
{
    public class TbControlTicketTareaRequest
    {
        public int IdTarea { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Seleccionar un grupo económico.")]
        public int IdGe { get; set; }

        public string? Ge { get; set; }

        [Required(ErrorMessage = "Seleccionar una empresa / entidad.")]
        [Range(1, int.MaxValue, ErrorMessage = "Seleccionar una empresa / entidad.")]
        public int IdEmpresa { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Seleccionar un receptor.")]
        public int IdReceptor { get; set; }

        public string? Receptor { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Seleccionar un medio.")]
        public int IdMedio { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Seleccionar una prioridad")]
        public int IdPrioridad { get; set; }

        public int IdItemCenter { get; set; }

        public string? ItemCenter { get; set; }

        [Required(ErrorMessage = "Ingrese un item")]
        public string? IdItemCenterDesc { get; set; }

        [Required(ErrorMessage = "Ingrese una cantidad mayor a 0")]
        [Range(1, int.MaxValue, ErrorMessage = "Ingrese una cantidad mayor a 0")]
        public int CantidadItems { get; set; }

        //[Required(ErrorMessage = "Ingrese un n° serie")]
        public string? NSerie { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Seleccionar un tipo")]
        public int IdTipo { get; set; }

        [Required(ErrorMessage = "Ingrese una descripción")]
        public string? Descripcion { get; set; }

        public string DescripcionTrimmed => Descripcion?.Trim() ?? "";

        public string? CodTicket { get; set; }

        [Required(ErrorMessage = "Ingrese un contacto")]
        public string? Contacto { get; set; }

        [RegularExpression(@"^\d{8}$", ErrorMessage = "El DNI debe contener exactamente 8 números.")]
        public string? Dni { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Seleccionar un estado")]
        public int IdEstado { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Seleccionar un nivel")]
        public int? IdNivel { get; set; }

        [RegularExpression(@"^[\w\.-]+@[\w\.-]+\.\w{2,4}$", ErrorMessage = "El formato del correo no es válido.")]
        public string? Correo { get; set; } = string.Empty;

        public string? Whatsapp { get; set; } = string.Empty;

        public int? Flag { get; set; } = 1;

        public int? UsuReg { get; set; } = 959;
    }
}
