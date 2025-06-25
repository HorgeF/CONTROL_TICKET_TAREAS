using System;
using System.Collections.Generic;

namespace CONTROL_TICKET_TAREA.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public int? IdTipo { get; set; }

    public int? IdEstado { get; set; }

    public string? IdDistrito { get; set; }

    public int? IdEmpresa { get; set; }

    public string? NDoc { get; set; }

    public string? Username { get; set; }

    public string? Nombres { get; set; }

    public string? ApellidoP { get; set; }

    public string? ApellidoM { get; set; }

    public string? Clave { get; set; }

    public string? Foto { get; set; }

    public DateOnly? FechaNac { get; set; }

    public string? CodigoInterno { get; set; }

    public string? Saenet { get; set; }

    public string? Direccion { get; set; }

    public string? Dpto { get; set; }

    public string? Referencia { get; set; }

    public int? Defecto { get; set; }

    public int? Orden { get; set; }

    public int? Flag { get; set; }

    public int? IdDivision { get; set; }

    public int? IdArea { get; set; }

    public int? IdUnidad { get; set; }

    public int? IdCargo { get; set; }

    public string? ClaveEncode { get; set; }

    public string? Correo { get; set; }

    public string? PasswordRecovery { get; set; }

    public string? RazonSocial { get; set; }

    public string? Ruc { get; set; }

    public int? UsuReg { get; set; }

    public DateTime? FecReg { get; set; }

    public int? UsuAct { get; set; }

    public DateTime? FecAct { get; set; }

    public int? IdProyecto { get; set; }

    public int? IdGe { get; set; }

    public string? NombreCorto { get; set; }

    public string? Sigla { get; set; }

    public string? Telefono { get; set; }

    public string? Telefono2 { get; set; }

    public string? Celular { get; set; }

    public string? Celular2 { get; set; }

    public string? Facebook { get; set; }

    public string? Linkedin { get; set; }

    public int? IdDocumento { get; set; }

    public int? IdPersoneria { get; set; }

    public int? IdTratamiento { get; set; }

    public int? IdGenero { get; set; }

    public string? CodDepartamento { get; set; }

    public string? CodProvincia { get; set; }

    public string? CodDistrito { get; set; }

    public string? CodPais { get; set; }

    public string? CodConfirm { get; set; }

    public string? IndSupremo { get; set; }

    public int? IdTipoUser { get; set; }

    public string? Fotousu { get; set; }

    public string? CorrelEmp { get; set; }

    public string? CorrelConcatExterno { get; set; }

    public string? CorrelSup { get; set; }

    public int? IdCargo2023 { get; set; }

    public int? IdArea2023 { get; set; }

    public int? IdPersonal { get; set; }

    public string? IdEmpleado { get; set; }

    public int? IdTipoEmpleado { get; set; }

    public string? ImgFirma { get; set; }

    public string? PhoneGuid { get; set; }

    public int? IdSubProyectoActual { get; set; }

    public int? IdSiteActual { get; set; }

    public string? CargoDesc { get; set; }

    public string? AreaDesc { get; set; }

    public virtual ICollection<CenterTicket> CenterTicketIdUsuarioNavigations { get; set; } = new List<CenterTicket>();

    public virtual ICollection<CenterTicket> CenterTicketUsuActNavigations { get; set; } = new List<CenterTicket>();

    public virtual ICollection<CenterTicket> CenterTicketUsuRegNavigations { get; set; } = new List<CenterTicket>();

    public virtual ICollection<Gep2Empresa> Gep2EmpresaIdUsuarioNavigations { get; set; } = new List<Gep2Empresa>();

    public virtual ICollection<Gep2Empresa> Gep2EmpresaUsuActNavigations { get; set; } = new List<Gep2Empresa>();

    public virtual ICollection<Gep2Empresa> Gep2EmpresaUsuRegNavigations { get; set; } = new List<Gep2Empresa>();

    public virtual ICollection<Gep3Proyecto> Gep3Proyectos { get; set; } = new List<Gep3Proyecto>();

    public virtual ICollection<Gep4Subproyecto> Gep4SubproyectoUsuActNavigations { get; set; } = new List<Gep4Subproyecto>();

    public virtual ICollection<Gep4Subproyecto> Gep4SubproyectoUsuRegNavigations { get; set; } = new List<Gep4Subproyecto>();

    public virtual ICollection<ItemCenter> ItemCenterUsuActNavigations { get; set; } = new List<ItemCenter>();

    public virtual ICollection<ItemCenter> ItemCenterUsuRegNavigations { get; set; } = new List<ItemCenter>();
}
