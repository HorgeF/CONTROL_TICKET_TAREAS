namespace CONTROL_TICKET_TAREA.Models;

public partial class ItemCenter
{
    public int IdItemCenter { get; set; }

    public int? IdTipo { get; set; }

    public int? IdClase { get; set; }

    public int? IdEstado { get; set; }

    public int? IdEmpresa { get; set; }

    public int? IdCt { get; set; }

    public int? IdMarca { get; set; }

    public int? IdModelo { get; set; }

    public string? Sigla { get; set; }

    public string? Subtipo { get; set; }

    public int? Defecto { get; set; }

    public int? Orden { get; set; }

    public int? UsuReg { get; set; }

    public DateTime? FecReg { get; set; }

    public DateTime? FecAct { get; set; }

    public int? UsuAct { get; set; }

    public int? Flag { get; set; }

    public string? NParte { get; set; }

    public string? NSerie { get; set; }

    public string? Descripcion { get; set; }

    public int? IdCategoria { get; set; }

    public int? IdSubCategoria { get; set; }

    public string? CorrelEmp { get; set; }

    public string? CorrelSup { get; set; }

    public string? CorrelConcatExterno { get; set; }

    public string? IdRds { get; set; }

    public string? IdRdsItem { get; set; }

    public string? Modelo { get; set; }

    public int? IndInventario { get; set; }

    public int? IdTipoCliente { get; set; }

    public decimal? CostoBase { get; set; }

    public decimal? CostoAdicional1 { get; set; }

    public decimal? CostoAdicional2 { get; set; }

    public decimal? CostoAdicional3 { get; set; }

    public decimal? CostoAdicional4 { get; set; }

    public decimal? CostoAdicional5 { get; set; }

    public decimal? CostoTotal { get; set; }

    public decimal? Mub { get; set; }

    public decimal? Igv { get; set; }

    public decimal? PrecioVenta { get; set; }

    public string? CodLog { get; set; }

    public string? GrupoCompra { get; set; }

    public string? CodDvc { get; set; }

    public string? SubTipo1 { get; set; }

    public string? Rank { get; set; }

    public int? Canpartnumber { get; set; }

    public int? Cantidad { get; set; }

    public string? Requerimiento { get; set; }

    public int? IdPadre { get; set; }

    public string? TipoConector { get; set; }

    public string? TipoEnchufe { get; set; }

    public string? Necesidad { get; set; }

    public string? CodProductoSae { get; set; }

    public decimal? CostoInicio { get; set; }

    public decimal? Costo { get; set; }

    public decimal? CostoOtros1 { get; set; }

    public decimal? CostoOtros2 { get; set; }

    public string? DescripcionCorta { get; set; }

    public int? CantidadVdtSaenet { get; set; }

    public int? TipoItem { get; set; }

    public virtual Gep2Empresa? IdEmpresaNavigation { get; set; }

    public virtual Usuario? UsuActNavigation { get; set; }

    public virtual Usuario? UsuRegNavigation { get; set; }
}
