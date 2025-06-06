using System;
using System.Collections.Generic;

namespace CONTROL_TICKET_TAREA.Models;

public partial class General
{
    public int IdGeneral { get; set; }

    public string? IdSecundaria { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public string? Sigla { get; set; }

    public int? Orden { get; set; }

    public int? Defecto { get; set; }

    public int? Flag { get; set; }

    public int? UsuReg { get; set; }

    public DateTime? FecReg { get; set; }

    public int? UsuAct { get; set; }

    public DateTime? FecAct { get; set; }

    public int? Mostrar { get; set; }

    public int? Flag2 { get; set; }

    public int? Cantidad { get; set; }

    public int? IdLista { get; set; }

    public int? IdEmpresa { get; set; }

    public virtual ICollection<Gep2Empresa> Gep2EmpresaIdDocumentoNavigations { get; set; } = new List<Gep2Empresa>();

    public virtual ICollection<Gep2Empresa> Gep2EmpresaIdPersoneriaNavigations { get; set; } = new List<Gep2Empresa>();

    public virtual ICollection<Gep2Empresa> Gep2EmpresaIdTratamientoNavigations { get; set; } = new List<Gep2Empresa>();
}
