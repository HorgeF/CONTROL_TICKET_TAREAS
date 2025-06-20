using System;
using System.Collections.Generic;

namespace CONTROL_TICKET_TAREA.Models;

public partial class TbControlTicketTarea
{
    public int IdTarea { get; set; }

    public int IdGe { get; set; }

    public int IdEmpresa { get; set; }

    public DateTime FechaTicketTarea { get; set; }

    public int IdReceptor { get; set; }

    public int IdMedio { get; set; }

    public int IdPrioridad { get; set; }

    public int IdItemCenter { get; set; }

    public string? IdItemCenterDesc { get; set; }

    public int CantidadItems { get; set; }

    public string? NSerie { get; set; }

    public int IdTipo { get; set; }

    public string? Descripcion { get; set; }

    public string? CodTicket { get; set; }

    public string? Contacto { get; set; }

    public int IdEstado { get; set; }

    public int? Flag { get; set; }

    public int? UsuReg { get; set; }

    public DateTime? FecReg { get; set; }

    public int? UsuAct { get; set; }

    public DateTime? FecCierre { get; set; }

    public string? CorrelEmp { get; set; }

    public string? CorrelConcatExterno { get; set; }

    public string? CorrelSup { get; set; }

    public int? IdRef { get; set; }

    public int? IdNivel { get; set; }

    public string? Correo { get; set; }

    public string? Whatsapp { get; set; }

    public string? Dni { get; set; }
}
