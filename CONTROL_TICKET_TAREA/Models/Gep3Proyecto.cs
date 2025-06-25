using System;
using System.Collections.Generic;

namespace CONTROL_TICKET_TAREA.Models;

public partial class Gep3Proyecto
{
    public int IdProyecto { get; set; }

    public int? IdEmpresa { get; set; }

    public int? IdEstado { get; set; }

    public int? IdTipo { get; set; }

    public string? Sigla { get; set; }

    public string? Nombre { get; set; }

    public string? Logo { get; set; }

    public string? Descripcion { get; set; }

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaFinal { get; set; }

    public int? IdUsuario { get; set; }

    public int? Orden { get; set; }

    public int? Defecto { get; set; }

    public int? Flag { get; set; }

    public DateTime? FecReg { get; set; }

    public int? UsuReg { get; set; }

    public DateTime? FecAct { get; set; }

    public int? UsuAct { get; set; }

    public int? IdGe { get; set; }

    public string? NomAbrv { get; set; }

    public string? CodAbrv { get; set; }

    public virtual ICollection<Gep4Subproyecto> Gep4Subproyectos { get; set; } = new List<Gep4Subproyecto>();

    public virtual Gep2Empresa? IdEmpresaNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
