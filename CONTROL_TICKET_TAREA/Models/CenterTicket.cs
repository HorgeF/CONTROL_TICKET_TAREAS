using System;
using System.Collections.Generic;

namespace CONTROL_TICKET_TAREA.Models;

public partial class CenterTicket
{
    public int IdTicket { get; set; }

    public int? IdUsuario { get; set; }

    public string? Descripcion { get; set; }

    public string? Img { get; set; }

    public int? Cantidad { get; set; }

    public short? Defecto { get; set; }

    public short? Habilitado { get; set; }

    public short? Autorizado { get; set; }

    public int? UsuReg { get; set; }

    public DateTime? FecReg { get; set; }

    public DateTime? FecAct { get; set; }

    public int? UsuAct { get; set; }

    public int? Flag { get; set; }

    public string? Nombre { get; set; }

    public string? Sigla { get; set; }

    public string? CorrelEmp { get; set; }

    public string? CorrelSupremoExterno { get; set; }

    public string? Formato { get; set; }

    public string? CorrelCompletoExterno { get; set; }

    public string? CorrelEmpFormato { get; set; }

    public string? OrdenEmp { get; set; }

    public string? Ubicacion { get; set; }

    public string? Correo { get; set; }

    public string? Telefono { get; set; }

    public string? Serie { get; set; }

    public int? EstadoTicket { get; set; }

    public string? NombreContacto { get; set; }

    public string? NumDoc { get; set; }

    public int? IdGe { get; set; }

    public int? IdEmpresa { get; set; }

    public int? IdMotivo { get; set; }

    public int? IdProyecto { get; set; }

    public int? IdSubProyecto { get; set; }

    public int? IdSite { get; set; }

    public string? CodRds { get; set; }

    public int? IdMedioContacto { get; set; }

    public int? IdPrioridad { get; set; }

    public int? IdNivel { get; set; }

    public DateTime? FechaTicket { get; set; }

    public int? IdCategoria { get; set; }

    public DateTime? FechaCierre { get; set; }

    public int? IdWebExt { get; set; }

    public int? FlagCorreo { get; set; }

    public DateTime? FechaCorreo { get; set; }

    public string? MensajeCorreo { get; set; }

    public string? MensajeCierre { get; set; }

    public DateTime? FechaSustentado { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }

    public virtual Usuario? UsuActNavigation { get; set; }

    public virtual Usuario? UsuRegNavigation { get; set; }
}
