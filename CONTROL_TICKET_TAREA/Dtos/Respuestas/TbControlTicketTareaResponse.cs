namespace CONTROL_TICKET_TAREA.Dtos.Respuestas
{
    public class TbControlTicketTareaResponse
    {
        public int IdTarea { get; set; }
        public int IdGE { get; set; }
        public string GE { get; set; } = string.Empty;
        public string? SiglaGE { get; set; } = string.Empty;
        public int IdEmpresa { get; set; }
        public string? Empresa { get; set; } = string.Empty;
        public DateTime FechaTicketTarea { get; set; }
        public string? SiglaEmpresa { get; set; } = string.Empty;
        public int IdReceptor { get; set; }
        public string? Receptor { get; set; } = string.Empty;
        public int IdMedio { get; set; }
        public string? Medio { get; set; } = string.Empty;
        public int IdPrioridad { get; set; }
        public int IdItemCenter { get; set; }
        public string? IdItemCenterDesc { get; set; }
        public int CantidadItems { get; set; }
        public string? Prioridad { get; set; } = string.Empty;
        public string? Contacto { get; set; } = string.Empty;
        public string? NSerie { get; set; } = string.Empty;
        public int IdTipo { get; set; }
        public string? Tipo { get; set;} = string.Empty;
        public string? Descripcion { get; set; } = string.Empty;
        public string? CodTicket { get; set; } = string.Empty;
        public int IdEstado { get; set; }
        public string? Estado { get; set; } = string.Empty;
        public int? IdNivel { get; set; }
        public string? Nivel { get; set; } = string.Empty;
        public string? Correo { get; set; } = string.Empty;
        public string? Whatsapp { get; set; } = string.Empty;
        public string? Dni { get; set; } = string.Empty;
        public DateTime? FecReg { get; set; }
        public DateTime? FecCierre { get; set; }
    }
}
