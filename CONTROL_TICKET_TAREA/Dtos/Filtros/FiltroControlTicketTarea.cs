namespace CONTROL_TICKET_TAREA.Dtos.Filtros
{
    public class FiltroControlTicketTarea
    {
        public List<int> Prioridad { get; set; } = [];
        public List<int> Nivel { get; set; } = [];
        public int IdReceptor { get; set; }
        public string? Receptor { get; set; }
        public int IdEstado { get; set; } = 1268;
        public int? PrioridadInd { get; set; }
        public int? NivelInd { get; set; }
    }
}
