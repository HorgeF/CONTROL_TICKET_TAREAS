using System;
using System.Collections.Generic;

namespace CONTROL_TICKET_TAREA.Models;

public partial class Gep1Grupoe
{
    public int IdGe { get; set; }

    public int? IdTipo { get; set; }

    public int? IdEstado { get; set; }

    public string? Sigla { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public int? Orden { get; set; }

    public int? Defecto { get; set; }

    public int? Flag { get; set; }

    public int? IdPersoneria { get; set; }

    public int? IdTratamiento { get; set; }

    public int? IndShow { get; set; }

    public int? IdPais { get; set; }

    public string? NomAbrv { get; set; }

    public string? CodAbrv { get; set; }
}
