namespace CONTROL_TICKET_TAREA.Dtos
{
    public class TicketRequest
    {
        public string V_ID_TICKET { get; set; } = string.Empty;
        public string V_ID_USUARIO { get; set; } = string.Empty;
        public string V_NOMBRE { get; set; } = string.Empty;
        public string V_DESCRIPCION { get; set; } = string.Empty;
        public string V_SIGLA { get; set; } = string.Empty;
        public string V_IMG { get; set; } = string.Empty;
        public int V_CANTIDAD { get; set; }
        public short V_DEFECTO { get; set; }
        public short V_HABILITADO { get; set; }
        public short V_AUTORIZADO { get; set; }
        public short V_USUARIO { get; set; }
        public short V_FLAG { get; set; }
        public short V_ACCION { get; set; }
        public string V_ID_GE { get; set; } = string.Empty;
        public string V_ID_EMPRESA { get; set; } = string.Empty;
        public string V_UBICACION { get; set; } = string.Empty;
        public string? V_CORREO { get; set; } = string.Empty;
        public string? V_TELEFONO { get; set; } = string.Empty;
        public string? V_SERIE { get; set; } = string.Empty;
        public string? V_NOMBRE_CONTACTO { get; set; } = string.Empty;
        public string? V_NUM_DOC { get; set; } = string.Empty;
        public int V_ESTADO_TICKET { get; set; } = 0;
        public int V_ID_MOTIVO { get; set; } = 0;
        public int V_ID_PROYECTO { get; set; } = 0;
        public int V_ID_SUBPROYECTO { get; set; } = 0;
        public int V_ID_SITE { get; set; } = 0;
        public int V_ID_MEDIO_CONTACTO { get; set; } = 0;
        public int V_ID_PRIORIDAD { get; set; } = 0;
        public int V_ID_NIVEL { get; set; } = 0;
        public string? V_FECHA_TICKET { get; set; }
        public int V_ID_CATEGORIA { get; set; } = 0;
        public int V_ID_WEB_EXT { get; set; } = 0;
        public string V_MOTIVO_CIERRA { get; set; } = string.Empty;
    }

}
