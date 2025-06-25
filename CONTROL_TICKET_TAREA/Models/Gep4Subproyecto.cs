using System;
using System.Collections.Generic;

namespace CONTROL_TICKET_TAREA.Models;

public partial class Gep4Subproyecto
{
    public int IdSubProyecto { get; set; }

    public int? IdProyecto { get; set; }

    public int? IdEmpresa { get; set; }

    public string? Sigla { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public int? Defecto { get; set; }

    public int? Flag { get; set; }

    public int? UsuReg { get; set; }

    public DateTime? FecReg { get; set; }

    public int? UsuAct { get; set; }

    public DateTime? FecAct { get; set; }

    public int? IdGe { get; set; }

    public string? NomAbrv { get; set; }

    public string? CodAbrv { get; set; }

    public virtual Gep2Empresa? IdEmpresaNavigation { get; set; }

    public virtual Gep3Proyecto? IdProyectoNavigation { get; set; }

    public virtual Usuario? UsuActNavigation { get; set; }

    public virtual Usuario? UsuRegNavigation { get; set; }
}
