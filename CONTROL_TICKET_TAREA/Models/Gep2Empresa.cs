using System;
using System.Collections.Generic;

namespace CONTROL_TICKET_TAREA.Models;

public partial class Gep2Empresa
{
    public int IdEmpresa { get; set; }

    public int? IdTipo { get; set; }

    public string? IdDistrito { get; set; }

    public int? IdGe { get; set; }

    public int? IdEstado { get; set; }

    public string? Sigla { get; set; }

    public string? NDoc { get; set; }

    public string? RazonSocial { get; set; }

    public string? Direccion { get; set; }

    public string? Logo { get; set; }

    public int? Orden { get; set; }

    public string? Slogan { get; set; }

    public string? Icono { get; set; }

    public string? Saenet { get; set; }

    public string? Web { get; set; }

    public int? Defecto { get; set; }

    public int? Flag { get; set; }

    public int? IdUsuario { get; set; }

    public int? UsuReg { get; set; }

    public DateTime? FecReg { get; set; }

    public int? UsuAct { get; set; }

    public DateTime? FecAct { get; set; }

    public int? IdDocumento { get; set; }

    public int? IdPersoneria { get; set; }

    public int? IdTratamiento { get; set; }

    public string? CodPais { get; set; }

    public string? CodDepartamento { get; set; }

    public string? CodProvincia { get; set; }

    public string? CodDistrito { get; set; }

    public int? IdColor { get; set; }

    public int? IndShow { get; set; }

    public string? CorrelConcatExterno { get; set; }

    public string? CorrelGe { get; set; }

    public string? NomAbrv { get; set; }

    public string? CodAbrv { get; set; }

    public virtual ICollection<Gep3Proyecto> Gep3Proyectos { get; set; } = new List<Gep3Proyecto>();

    public virtual ICollection<Gep4Subproyecto> Gep4Subproyectos { get; set; } = new List<Gep4Subproyecto>();

    public virtual General? IdDocumentoNavigation { get; set; }

    public virtual General? IdPersoneriaNavigation { get; set; }

    public virtual General? IdTratamientoNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }

    public virtual ICollection<ItemCenter> ItemCenters { get; set; } = new List<ItemCenter>();

    public virtual Usuario? UsuActNavigation { get; set; }

    public virtual Usuario? UsuRegNavigation { get; set; }
}
