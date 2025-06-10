using CONTROL_TICKET_TAREA.Dtos;
using CONTROL_TICKET_TAREA.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace CONTROL_TICKET_TAREA.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<General> Generals { get; set; }

    public virtual DbSet<Gep1Grupoe> Gep1Grupoes { get; set; }

    public virtual DbSet<Gep2Empresa> Gep2Empresas { get; set; }

    public virtual DbSet<ItemCenter> ItemCenters { get; set; }

    public virtual DbSet<TbControlTicketTarea> TbControlTicketTareas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<TbControlTicketTareaResponse> TbControlTicketTareaResponses { get; set; }

    public virtual DbSet<TicketResponse> TicketResponses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<General>(entity =>
        {
            entity.HasKey(e => e.IdGeneral).HasName("PK__GENERAL__C1106EFEE07D0F8C");

            entity.ToTable("GENERAL");

            entity.Property(e => e.IdGeneral)
                .ValueGeneratedNever()
                .HasColumnName("ID_GENERAL");
            entity.Property(e => e.Cantidad).HasColumnName("CANTIDAD");
            entity.Property(e => e.Defecto).HasColumnName("DEFECTO");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.FecAct)
                .HasColumnType("datetime")
                .HasColumnName("FEC_ACT");
            entity.Property(e => e.FecReg)
                .HasColumnType("datetime")
                .HasColumnName("FEC_REG");
            entity.Property(e => e.Flag).HasColumnName("FLAG");
            entity.Property(e => e.Flag2).HasColumnName("FLAG_2");
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_EMPRESA");
            entity.Property(e => e.IdLista).HasColumnName("ID_LISTA");
            entity.Property(e => e.IdSecundaria)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ID_SECUNDARIA");
            entity.Property(e => e.Mostrar).HasColumnName("MOSTRAR");
            entity.Property(e => e.Nombre)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.Orden).HasColumnName("ORDEN");
            entity.Property(e => e.Sigla)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("SIGLA");
            entity.Property(e => e.UsuAct).HasColumnName("USU_ACT");
            entity.Property(e => e.UsuReg).HasColumnName("USU_REG");
        });

        modelBuilder.Entity<Gep1Grupoe>(entity =>
        {
            entity.HasKey(e => e.IdGe).HasName("PK__GEP_1_GR__8B62CF031B56F7A3");

            entity.ToTable("GEP_1_GRUPOE");

            entity.Property(e => e.IdGe)
                .ValueGeneratedNever()
                .HasColumnName("ID_GE");
            entity.Property(e => e.CodAbrv)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("COD_ABRV");
            entity.Property(e => e.Defecto).HasColumnName("DEFECTO");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.Flag).HasColumnName("FLAG");
            entity.Property(e => e.IdEstado).HasColumnName("ID_ESTADO");
            entity.Property(e => e.IdPais).HasColumnName("ID_PAIS");
            entity.Property(e => e.IdPersoneria).HasColumnName("ID_PERSONERIA");
            entity.Property(e => e.IdTipo).HasColumnName("ID_TIPO");
            entity.Property(e => e.IdTratamiento).HasColumnName("ID_TRATAMIENTO");
            entity.Property(e => e.IndShow).HasColumnName("IND_SHOW");
            entity.Property(e => e.NomAbrv)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("NOM_ABRV");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.Orden).HasColumnName("ORDEN");
            entity.Property(e => e.Sigla)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("SIGLA");
        });

        modelBuilder.Entity<Gep2Empresa>(entity =>
        {
            entity.HasKey(e => e.IdEmpresa).HasName("PK__GEP_2_EM__E30DF09C482F844C");

            entity.ToTable("GEP_2_EMPRESA");

            entity.Property(e => e.IdEmpresa)
                .ValueGeneratedNever()
                .HasColumnName("ID_EMPRESA");
            entity.Property(e => e.CodAbrv)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("COD_ABRV");
            entity.Property(e => e.CodDepartamento)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("COD_DEPARTAMENTO");
            entity.Property(e => e.CodDistrito)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("COD_DISTRITO");
            entity.Property(e => e.CodPais)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("COD_PAIS");
            entity.Property(e => e.CodProvincia)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("COD_PROVINCIA");
            entity.Property(e => e.CorrelConcatExterno)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("CORREL_CONCAT_EXTERNO");
            entity.Property(e => e.CorrelGe)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("CORREL_GE");
            entity.Property(e => e.Defecto).HasColumnName("DEFECTO");
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DIRECCION");
            entity.Property(e => e.FecAct)
                .HasColumnType("datetime")
                .HasColumnName("FEC_ACT");
            entity.Property(e => e.FecReg)
                .HasColumnType("datetime")
                .HasColumnName("FEC_REG");
            entity.Property(e => e.Flag).HasColumnName("FLAG");
            entity.Property(e => e.Icono)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("ICONO");
            entity.Property(e => e.IdColor).HasColumnName("ID_COLOR");
            entity.Property(e => e.IdDistrito)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("ID_DISTRITO");
            entity.Property(e => e.IdDocumento).HasColumnName("ID_DOCUMENTO");
            entity.Property(e => e.IdEstado).HasColumnName("ID_ESTADO");
            entity.Property(e => e.IdGe).HasColumnName("ID_GE");
            entity.Property(e => e.IdPersoneria).HasColumnName("ID_PERSONERIA");
            entity.Property(e => e.IdTipo).HasColumnName("ID_TIPO");
            entity.Property(e => e.IdTratamiento).HasColumnName("ID_TRATAMIENTO");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");
            entity.Property(e => e.IndShow).HasColumnName("IND_SHOW");
            entity.Property(e => e.Logo)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("LOGO");
            entity.Property(e => e.NDoc)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("N_DOC");
            entity.Property(e => e.NomAbrv)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("NOM_ABRV");
            entity.Property(e => e.Orden).HasColumnName("ORDEN");
            entity.Property(e => e.RazonSocial)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("RAZON_SOCIAL");
            entity.Property(e => e.Saenet)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("SAENET");
            entity.Property(e => e.Sigla)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("SIGLA");
            entity.Property(e => e.Slogan)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("SLOGAN");
            entity.Property(e => e.UsuAct).HasColumnName("USU_ACT");
            entity.Property(e => e.UsuReg).HasColumnName("USU_REG");
            entity.Property(e => e.Web)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("WEB");

            entity.HasOne(d => d.IdDocumentoNavigation).WithMany(p => p.Gep2EmpresaIdDocumentoNavigations)
                .HasForeignKey(d => d.IdDocumento)
                .HasConstraintName("FK_EMPRESA_GENERAL_DOCUMENTO");

            entity.HasOne(d => d.IdPersoneriaNavigation).WithMany(p => p.Gep2EmpresaIdPersoneriaNavigations)
                .HasForeignKey(d => d.IdPersoneria)
                .HasConstraintName("FK_EMPRESA_GENERAL_PERSONERIA");

            entity.HasOne(d => d.IdTratamientoNavigation).WithMany(p => p.Gep2EmpresaIdTratamientoNavigations)
                .HasForeignKey(d => d.IdTratamiento)
                .HasConstraintName("FK_EMPRESA_GENERAL_TRATAMIENTO");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Gep2EmpresaIdUsuarioNavigations)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK_EMPRESA_USUARIO");

            entity.HasOne(d => d.UsuActNavigation).WithMany(p => p.Gep2EmpresaUsuActNavigations)
                .HasForeignKey(d => d.UsuAct)
                .HasConstraintName("FK_EMPRESA_USUARIO_ACT");

            entity.HasOne(d => d.UsuRegNavigation).WithMany(p => p.Gep2EmpresaUsuRegNavigations)
                .HasForeignKey(d => d.UsuReg)
                .HasConstraintName("FK_EMPRESA_USUARIO_REG");
        });

        modelBuilder.Entity<ItemCenter>(entity =>
        {
            entity.HasKey(e => e.IdItemCenter).HasName("PK__ITEM_CEN__23CAA599E0FF6985");

            entity.ToTable("ITEM_CENTER");

            entity.Property(e => e.IdItemCenter)
                .ValueGeneratedNever()
                .HasColumnName("ID_ITEM_CENTER");
            entity.Property(e => e.Canpartnumber).HasColumnName("CANPARTNUMBER");
            entity.Property(e => e.Cantidad).HasColumnName("CANTIDAD");
            entity.Property(e => e.CantidadVdtSaenet).HasColumnName("CANTIDAD_VDT_SAENET");
            entity.Property(e => e.CodDvc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("COD_DVC");
            entity.Property(e => e.CodLog)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("COD_LOG");
            entity.Property(e => e.CodProductoSae)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("COD_PRODUCTO_SAE");
            entity.Property(e => e.CorrelConcatExterno)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("CORREL_CONCAT_EXTERNO");
            entity.Property(e => e.CorrelEmp)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("CORREL_EMP");
            entity.Property(e => e.CorrelSup)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("CORREL_SUP");
            entity.Property(e => e.Costo)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("COSTO");
            entity.Property(e => e.CostoAdicional1)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("COSTO_ADICIONAL1");
            entity.Property(e => e.CostoAdicional2)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("COSTO_ADICIONAL2");
            entity.Property(e => e.CostoAdicional3)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("COSTO_ADICIONAL3");
            entity.Property(e => e.CostoAdicional4)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("COSTO_ADICIONAL4");
            entity.Property(e => e.CostoAdicional5)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("COSTO_ADICIONAL5");
            entity.Property(e => e.CostoBase)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("COSTO_BASE");
            entity.Property(e => e.CostoInicio)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("COSTO_INICIO");
            entity.Property(e => e.CostoOtros1)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("COSTO_OTROS_1");
            entity.Property(e => e.CostoOtros2)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("COSTO_OTROS_2");
            entity.Property(e => e.CostoTotal)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("COSTO_TOTAL");
            entity.Property(e => e.Defecto).HasColumnName("DEFECTO");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(800)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.DescripcionCorta)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION_CORTA");
            entity.Property(e => e.FecAct)
                .HasColumnType("datetime")
                .HasColumnName("FEC_ACT");
            entity.Property(e => e.FecReg)
                .HasColumnType("datetime")
                .HasColumnName("FEC_REG");
            entity.Property(e => e.Flag).HasColumnName("FLAG");
            entity.Property(e => e.GrupoCompra)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("GRUPO_COMPRA");
            entity.Property(e => e.IdCategoria).HasColumnName("ID_CATEGORIA");
            entity.Property(e => e.IdClase).HasColumnName("ID_CLASE");
            entity.Property(e => e.IdCt).HasColumnName("ID_CT");
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_EMPRESA");
            entity.Property(e => e.IdEstado).HasColumnName("ID_ESTADO");
            entity.Property(e => e.IdMarca).HasColumnName("ID_MARCA");
            entity.Property(e => e.IdModelo).HasColumnName("ID_MODELO");
            entity.Property(e => e.IdPadre).HasColumnName("ID_PADRE");
            entity.Property(e => e.IdRds)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("ID_RDS");
            entity.Property(e => e.IdRdsItem)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("ID_RDS_ITEM");
            entity.Property(e => e.IdSubCategoria).HasColumnName("ID_SUB_CATEGORIA");
            entity.Property(e => e.IdTipo).HasColumnName("ID_TIPO");
            entity.Property(e => e.IdTipoCliente).HasColumnName("ID_TIPO_CLIENTE");
            entity.Property(e => e.Igv)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("IGV");
            entity.Property(e => e.IndInventario).HasColumnName("IND_INVENTARIO");
            entity.Property(e => e.Modelo)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("MODELO");
            entity.Property(e => e.Mub)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("MUB");
            entity.Property(e => e.NParte)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("N_PARTE");
            entity.Property(e => e.NSerie)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("N_SERIE");
            entity.Property(e => e.Necesidad)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NECESIDAD");
            entity.Property(e => e.Orden).HasColumnName("ORDEN");
            entity.Property(e => e.PrecioVenta)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("PRECIO_VENTA");
            entity.Property(e => e.Rank)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("RANK");
            entity.Property(e => e.Requerimiento)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("REQUERIMIENTO");
            entity.Property(e => e.Sigla)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("SIGLA");
            entity.Property(e => e.SubTipo1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SUB_TIPO");
            entity.Property(e => e.Subtipo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SUBTIPO");
            entity.Property(e => e.TipoConector)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TIPO_CONECTOR");
            entity.Property(e => e.TipoEnchufe)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TIPO_ENCHUFE");
            entity.Property(e => e.TipoItem).HasColumnName("TIPO_ITEM");
            entity.Property(e => e.UsuAct).HasColumnName("USU_ACT");
            entity.Property(e => e.UsuReg).HasColumnName("USU_REG");

            entity.HasOne(d => d.IdEmpresaNavigation).WithMany(p => p.ItemCenters)
                .HasForeignKey(d => d.IdEmpresa)
                .HasConstraintName("FK_ITEM_CENTER_EMPRESA");

            entity.HasOne(d => d.UsuActNavigation).WithMany(p => p.ItemCenterUsuActNavigations)
                .HasForeignKey(d => d.UsuAct)
                .HasConstraintName("FK__ITEM_CENT__USU_A__2141CF68");

            entity.HasOne(d => d.UsuRegNavigation).WithMany(p => p.ItemCenterUsuRegNavigations)
                .HasForeignKey(d => d.UsuReg)
                .HasConstraintName("FK__ITEM_CENT__USU_R__2235F3A1");
        });

        modelBuilder.Entity<TbControlTicketTarea>(entity =>
        {
            entity.HasKey(e => e.IdTarea).HasName("PK__TB_CONTR__3484F0F9C46D185E");

            entity.ToTable("TB_CONTROL_TICKET_TAREA");

            entity.Property(e => e.IdTarea).HasColumnName("ID_TAREA");
            entity.Property(e => e.CantidadItems).HasColumnName("CANTIDAD_ITEMS");
            entity.Property(e => e.CodTicket)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("COD_TICKET");
            entity.Property(e => e.Contacto)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("CONTACTO");
            entity.Property(e => e.CorrelConcatExterno)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("CORREL_CONCAT_EXTERNO");
            entity.Property(e => e.CorrelEmp)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("CORREL_EMP");
            entity.Property(e => e.CorrelSup)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CORREL_SUP");
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CORREO");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.Dni)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("DNI");
            entity.Property(e => e.FecAct)
                .HasColumnType("datetime")
                .HasColumnName("FEC_ACT");
            entity.Property(e => e.FecReg)
                .HasColumnType("datetime")
                .HasColumnName("FEC_REG");
            entity.Property(e => e.FechaTicketTarea)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_TICKET_TAREA");
            entity.Property(e => e.Flag).HasColumnName("FLAG");
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_EMPRESA");
            entity.Property(e => e.IdEstado).HasColumnName("ID_ESTADO");
            entity.Property(e => e.IdGe).HasColumnName("ID_GE");
            entity.Property(e => e.IdItemCenter).HasColumnName("ID_ITEM_CENTER");
            entity.Property(e => e.IdItemCenterDesc)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("ID_ITEM_CENTER_DESC");
            entity.Property(e => e.IdMedio).HasColumnName("ID_MEDIO");
            entity.Property(e => e.IdNivel).HasColumnName("ID_NIVEL");
            entity.Property(e => e.IdPrioridad).HasColumnName("ID_PRIORIDAD");
            entity.Property(e => e.IdReceptor).HasColumnName("ID_RECEPTOR");
            entity.Property(e => e.IdRef).HasColumnName("ID_REF");
            entity.Property(e => e.IdTipo).HasColumnName("ID_TIPO");
            entity.Property(e => e.NSerie)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("N_SERIE");
            entity.Property(e => e.UsuAct).HasColumnName("USU_ACT");
            entity.Property(e => e.UsuReg).HasColumnName("USU_REG");
            entity.Property(e => e.Whatsapp)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WHATSAPP");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__USUARIO__91136B904AEC533F");

            entity.ToTable("USUARIO");

            entity.Property(e => e.IdUsuario)
                .ValueGeneratedNever()
                .HasColumnName("ID_USUARIO");
            entity.Property(e => e.ApellidoM)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("APELLIDO_M");
            entity.Property(e => e.ApellidoP)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("APELLIDO_P");
            entity.Property(e => e.AreaDesc)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("AREA_DESC");
            entity.Property(e => e.CargoDesc)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("CARGO_DESC");
            entity.Property(e => e.Celular)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("CELULAR");
            entity.Property(e => e.Celular2)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("CELULAR_2");
            entity.Property(e => e.Clave)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CLAVE");
            entity.Property(e => e.ClaveEncode)
                .IsUnicode(false)
                .HasColumnName("CLAVE_ENCODE");
            entity.Property(e => e.CodConfirm)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("COD_CONFIRM");
            entity.Property(e => e.CodDepartamento)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("COD_DEPARTAMENTO");
            entity.Property(e => e.CodDistrito)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("COD_DISTRITO");
            entity.Property(e => e.CodPais)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("COD_PAIS");
            entity.Property(e => e.CodProvincia)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("COD_PROVINCIA");
            entity.Property(e => e.CodigoInterno)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("CODIGO_INTERNO");
            entity.Property(e => e.CorrelConcatExterno)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("CORREL_CONCAT_EXTERNO");
            entity.Property(e => e.CorrelEmp)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("CORREL_EMP");
            entity.Property(e => e.CorrelSup)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CORREL_SUP");
            entity.Property(e => e.Correo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CORREO");
            entity.Property(e => e.Defecto).HasColumnName("DEFECTO");
            entity.Property(e => e.Direccion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DIRECCION");
            entity.Property(e => e.Dpto)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("DPTO");
            entity.Property(e => e.Facebook)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("FACEBOOK");
            entity.Property(e => e.FecAct)
                .HasColumnType("datetime")
                .HasColumnName("FEC_ACT");
            entity.Property(e => e.FecReg)
                .HasColumnType("datetime")
                .HasColumnName("FEC_REG");
            entity.Property(e => e.FechaNac).HasColumnName("FECHA_NAC");
            entity.Property(e => e.Flag).HasColumnName("FLAG");
            entity.Property(e => e.Foto)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("FOTO");
            entity.Property(e => e.Fotousu)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("FOTOUSU");
            entity.Property(e => e.IdArea).HasColumnName("ID_AREA");
            entity.Property(e => e.IdArea2023).HasColumnName("ID_AREA_2023");
            entity.Property(e => e.IdCargo).HasColumnName("ID_CARGO");
            entity.Property(e => e.IdCargo2023).HasColumnName("ID_CARGO_2023");
            entity.Property(e => e.IdDistrito)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("ID_DISTRITO");
            entity.Property(e => e.IdDivision).HasColumnName("ID_DIVISION");
            entity.Property(e => e.IdDocumento).HasColumnName("ID_DOCUMENTO");
            entity.Property(e => e.IdEmpleado)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ID_EMPLEADO");
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_EMPRESA");
            entity.Property(e => e.IdEstado).HasColumnName("ID_ESTADO");
            entity.Property(e => e.IdGe).HasColumnName("ID_GE");
            entity.Property(e => e.IdGenero).HasColumnName("ID_GENERO");
            entity.Property(e => e.IdPersonal).HasColumnName("ID_PERSONAL");
            entity.Property(e => e.IdPersoneria).HasColumnName("ID_PERSONERIA");
            entity.Property(e => e.IdProyecto).HasColumnName("ID_PROYECTO");
            entity.Property(e => e.IdSiteActual).HasColumnName("ID_SITE_ACTUAL");
            entity.Property(e => e.IdSubProyectoActual).HasColumnName("ID_SUB_PROYECTO_ACTUAL");
            entity.Property(e => e.IdTipo).HasColumnName("ID_TIPO");
            entity.Property(e => e.IdTipoEmpleado).HasColumnName("ID_TIPO_EMPLEADO");
            entity.Property(e => e.IdTipoUser).HasColumnName("ID_TIPO_USER");
            entity.Property(e => e.IdTratamiento).HasColumnName("ID_TRATAMIENTO");
            entity.Property(e => e.IdUnidad).HasColumnName("ID_UNIDAD");
            entity.Property(e => e.ImgFirma).IsUnicode(false);
            entity.Property(e => e.IndSupremo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("IND_SUPREMO");
            entity.Property(e => e.Linkedin)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LINKEDIN");
            entity.Property(e => e.NDoc)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("N_DOC");
            entity.Property(e => e.NombreCorto)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_CORTO");
            entity.Property(e => e.Nombres)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("NOMBRES");
            entity.Property(e => e.Orden).HasColumnName("ORDEN");
            entity.Property(e => e.PasswordRecovery)
                .IsUnicode(false)
                .HasColumnName("PASSWORD_RECOVERY");
            entity.Property(e => e.PhoneGuid)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("PHONE_GUID");
            entity.Property(e => e.RazonSocial)
                .HasMaxLength(75)
                .IsUnicode(false)
                .HasColumnName("RAZON_SOCIAL");
            entity.Property(e => e.Referencia)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("REFERENCIA");
            entity.Property(e => e.Ruc)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("RUC");
            entity.Property(e => e.Saenet)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("SAENET");
            entity.Property(e => e.Sigla)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("SIGLA");
            entity.Property(e => e.Telefono)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("TELEFONO");
            entity.Property(e => e.Telefono2)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("TELEFONO_2");
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("USERNAME");
            entity.Property(e => e.UsuAct).HasColumnName("USU_ACT");
            entity.Property(e => e.UsuReg).HasColumnName("USU_REG");
        });

        modelBuilder.Entity<TbControlTicketTareaResponse>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.IdTarea).HasColumnName("ID_TAREA");
            entity.Property(e => e.IdGE).HasColumnName("ID_GE");
            entity.Property(e => e.GE).HasColumnName("GE");
            entity.Property(e => e.IdEmpresa).HasColumnName("ID_EMPRESA");
            entity.Property(e => e.Empresa).HasColumnName("EMPRESA");
            entity.Property(e => e.IdReceptor).HasColumnName("ID_RECEPTOR");
            entity.Property(e => e.Receptor).HasColumnName("RECEPTOR");
            entity.Property(e => e.IdMedio).HasColumnName("ID_MEDIO");
            entity.Property(e => e.Medio).HasColumnName("MEDIO");
            entity.Property(e => e.IdPrioridad).HasColumnName("ID_PRIORIDAD");
            entity.Property(e => e.Prioridad).HasColumnName("PRIORIDAD");

            entity.Property(e => e.NSerie).HasColumnName("N_SERIE");

            entity.Property(e => e.IdTipo).HasColumnName("ID_TIPO");
            entity.Property(e => e.Tipo).HasColumnName("TIPO");
            entity.Property(e => e.Descripcion).HasColumnName("DESCRIPCION");
            entity.Property(e => e.IdItemCenter).HasColumnName("ID_ITEM_CENTER");
            entity.Property(e => e.IdItemCenterDesc).HasColumnName("ID_ITEM_CENTER_DESC");
            entity.Property(e => e.CantidadItems).HasColumnName("CANTIDAD_ITEMS");

            entity.Property(e => e.IdNivel).HasColumnName("ID_NIVEL");
            entity.Property(e => e.Nivel).HasColumnName("NIVEL");

            entity.Property(e => e.CodTicket).HasColumnName("COD_TICKET");
            entity.Property(e => e.Correo).HasColumnName("CORREO");
            entity.Property(e => e.Whatsapp).HasColumnName("WHATSAPP");

            entity.Property(e => e.IdEstado).HasColumnName("ID_ESTADO");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.Contacto).HasColumnName("CONTACTO");
            entity.Property(e => e.Dni).HasColumnName("DNI");

            entity.Property(e => e.FecReg).HasColumnName("FEC_REG");
        });

        modelBuilder.Entity<TicketResponse>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.CORREL_SUP_EXTERNO).HasColumnName("CORREL_SUP_EXTERNO");
            entity.Property(e => e.ID).HasColumnName("ID");
        });

        modelBuilder.Entity<TbControlTicketTarea>()
            .ToTable("TB_CONTROL_TICKET_TAREA", t => t.HasTrigger("ENVIAR_TAREAS_V1"));

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
