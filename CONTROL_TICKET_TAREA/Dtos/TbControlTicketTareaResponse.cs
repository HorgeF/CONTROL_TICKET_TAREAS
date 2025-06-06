namespace CONTROL_TICKET_TAREA.Dtos
{
    public class TbControlTicketTareaResponse
    {
        public int IdTarea { get; set; }

        public int IdGe { get; set; }

        public int IdEmpresa { get; set; }

        public DateTime FechaTicketTarea { get; set; }

        public int IdReceptor { get; set; }

        public int IdMedia { get; set; }

        public int IdPrioridad { get; set; }

        public int IdItemCenter { get; set; }

        public string? IdItemCenterDesc { get; set; }

        public string? NSerie { get; set; }

        public int IdTipo { get; set; }

        public string? Descripcion { get; set; }

        public string? CodTicket { get; set; }

        public string? Contacto { get; set; }

        public int IdEstado { get; set; }
    }
}
