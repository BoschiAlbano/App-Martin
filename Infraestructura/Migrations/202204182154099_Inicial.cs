namespace Infraestructura.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articulo",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        MarcaId = c.Long(nullable: false),
                        RubroId = c.Long(nullable: false),
                        Codigo = c.Int(nullable: false),
                        CodigoBarra = c.String(maxLength: 8000, unicode: false),
                        Abreviatura = c.String(maxLength: 8000, unicode: false),
                        Descripcion = c.String(maxLength: 8000, unicode: false),
                        Detalle = c.String(maxLength: 8000, unicode: false),
                        Ubicacion = c.String(maxLength: 8000, unicode: false),
                        Stock = c.Int(nullable: false),
                        PrecioCosto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PrecioVenta = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PorcentajeGanancia = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Foto = c.Binary(),
                        StockMinimo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EstaEliminado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Marca", t => t.MarcaId)
                .ForeignKey("dbo.Rubro", t => t.RubroId)
                .Index(t => t.MarcaId)
                .Index(t => t.RubroId);
            
            CreateTable(
                "dbo.Marca",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Descripcion = c.String(maxLength: 8000, unicode: false),
                        EstaEliminado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rubro",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Descripcion = c.String(maxLength: 8000, unicode: false),
                        EstaEliminado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Persona",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Apellido = c.String(maxLength: 8000, unicode: false),
                        Nombre = c.String(maxLength: 8000, unicode: false),
                        Dni = c.String(maxLength: 8000, unicode: false),
                        Direccion = c.String(maxLength: 8000, unicode: false),
                        Telefono = c.String(maxLength: 8000, unicode: false),
                        Mail = c.String(maxLength: 8000, unicode: false),
                        LocalidadId = c.Long(nullable: false),
                        EstaEliminado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Localidad", t => t.LocalidadId)
                .Index(t => t.LocalidadId);
            
            CreateTable(
                "dbo.Localidad",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        DepartamentoId = c.Long(nullable: false),
                        Descripcion = c.String(maxLength: 8000, unicode: false),
                        EstaEliminado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departamento", t => t.DepartamentoId)
                .Index(t => t.DepartamentoId);
            
            CreateTable(
                "dbo.Configuracion",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        RazonSocial = c.String(maxLength: 8000, unicode: false),
                        NombreFantasia = c.String(maxLength: 8000, unicode: false),
                        Cuit = c.String(maxLength: 8000, unicode: false),
                        Telefono = c.String(maxLength: 8000, unicode: false),
                        Celular = c.String(maxLength: 8000, unicode: false),
                        Direccion = c.String(maxLength: 8000, unicode: false),
                        Email = c.String(maxLength: 8000, unicode: false),
                        LocalidadId = c.Long(nullable: false),
                        PuestoCajaSeparado = c.Boolean(nullable: false),
                        EstaEliminado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Localidad", t => t.LocalidadId)
                .Index(t => t.LocalidadId);
            
            CreateTable(
                "dbo.Departamento",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ProvinciaId = c.Long(nullable: false),
                        Descripcion = c.String(maxLength: 8000, unicode: false),
                        EstaEliminado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Provincia", t => t.ProvinciaId)
                .Index(t => t.ProvinciaId);
            
            CreateTable(
                "dbo.Provincia",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Descripcion = c.String(maxLength: 8000, unicode: false),
                        EstaEliminado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        EmpleadoId = c.Long(nullable: false),
                        Nombre = c.String(maxLength: 8000, unicode: false),
                        Password = c.String(maxLength: 8000, unicode: false),
                        EstaBloqueado = c.Boolean(nullable: false),
                        EstaEliminado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Persona_Empleado", t => t.EmpleadoId)
                .Index(t => t.EmpleadoId);
            
            CreateTable(
                "dbo.Comprobante",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        EmpleadoId = c.Long(nullable: false),
                        UsuarioId = c.Long(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        Numero = c.Int(nullable: false),
                        SubTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Descuento = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TipoComprobante = c.Int(nullable: false),
                        Efectivo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CuentaCorriente = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Estado = c.Int(nullable: false),
                        ClienteId = c.Long(nullable: false),
                        PagoCuentaCorriente = c.Boolean(nullable: false),
                        EstaEliminado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Persona_Cliente", t => t.ClienteId)
                .ForeignKey("dbo.Persona_Empleado", t => t.EmpleadoId)
                .ForeignKey("dbo.Usuario", t => t.UsuarioId)
                .Index(t => t.EmpleadoId)
                .Index(t => t.UsuarioId)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.DetalleComprobante",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ComprobanteId = c.Long(nullable: false),
                        ArticuloId = c.Long(nullable: false),
                        Codigo = c.String(maxLength: 8000, unicode: false),
                        Descripcion = c.String(maxLength: 8000, unicode: false),
                        Cantidad = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SubTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EstaEliminado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Articulo", t => t.ArticuloId)
                .ForeignKey("dbo.Comprobante", t => t.ComprobanteId)
                .Index(t => t.ComprobanteId)
                .Index(t => t.ArticuloId);
            
            CreateTable(
                "dbo.Proveedor",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        RazonSocial = c.String(maxLength: 8000, unicode: false),
                        CUIT = c.String(maxLength: 8000, unicode: false),
                        Direccion = c.String(maxLength: 8000, unicode: false),
                        Telefono = c.String(maxLength: 8000, unicode: false),
                        Mail = c.String(maxLength: 8000, unicode: false),
                        LocalidadId = c.Long(nullable: false),
                        EstaEliminado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Localidad", t => t.LocalidadId)
                .Index(t => t.LocalidadId);
            
            CreateTable(
                "dbo.Persona_Cliente",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        ActivarCtaCte = c.Boolean(nullable: false),
                        TieneLimiteCompra = c.Boolean(nullable: false),
                        MontoMaximoCtaCte = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Persona", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Persona_Empleado",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        Legajo = c.Int(nullable: false),
                        Foto = c.Binary(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Persona", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Persona_Empleado", "Id", "dbo.Persona");
            DropForeignKey("dbo.Persona_Cliente", "Id", "dbo.Persona");
            DropForeignKey("dbo.Proveedor", "LocalidadId", "dbo.Localidad");
            DropForeignKey("dbo.Comprobante", "UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.Comprobante", "EmpleadoId", "dbo.Persona_Empleado");
            DropForeignKey("dbo.DetalleComprobante", "ComprobanteId", "dbo.Comprobante");
            DropForeignKey("dbo.DetalleComprobante", "ArticuloId", "dbo.Articulo");
            DropForeignKey("dbo.Comprobante", "ClienteId", "dbo.Persona_Cliente");
            DropForeignKey("dbo.Usuario", "EmpleadoId", "dbo.Persona_Empleado");
            DropForeignKey("dbo.Persona", "LocalidadId", "dbo.Localidad");
            DropForeignKey("dbo.Departamento", "ProvinciaId", "dbo.Provincia");
            DropForeignKey("dbo.Localidad", "DepartamentoId", "dbo.Departamento");
            DropForeignKey("dbo.Configuracion", "LocalidadId", "dbo.Localidad");
            DropForeignKey("dbo.Articulo", "RubroId", "dbo.Rubro");
            DropForeignKey("dbo.Articulo", "MarcaId", "dbo.Marca");
            DropIndex("dbo.Persona_Empleado", new[] { "Id" });
            DropIndex("dbo.Persona_Cliente", new[] { "Id" });
            DropIndex("dbo.Proveedor", new[] { "LocalidadId" });
            DropIndex("dbo.DetalleComprobante", new[] { "ArticuloId" });
            DropIndex("dbo.DetalleComprobante", new[] { "ComprobanteId" });
            DropIndex("dbo.Comprobante", new[] { "ClienteId" });
            DropIndex("dbo.Comprobante", new[] { "UsuarioId" });
            DropIndex("dbo.Comprobante", new[] { "EmpleadoId" });
            DropIndex("dbo.Usuario", new[] { "EmpleadoId" });
            DropIndex("dbo.Departamento", new[] { "ProvinciaId" });
            DropIndex("dbo.Configuracion", new[] { "LocalidadId" });
            DropIndex("dbo.Localidad", new[] { "DepartamentoId" });
            DropIndex("dbo.Persona", new[] { "LocalidadId" });
            DropIndex("dbo.Articulo", new[] { "RubroId" });
            DropIndex("dbo.Articulo", new[] { "MarcaId" });
            DropTable("dbo.Persona_Empleado");
            DropTable("dbo.Persona_Cliente");
            DropTable("dbo.Proveedor");
            DropTable("dbo.DetalleComprobante");
            DropTable("dbo.Comprobante");
            DropTable("dbo.Usuario");
            DropTable("dbo.Provincia");
            DropTable("dbo.Departamento");
            DropTable("dbo.Configuracion");
            DropTable("dbo.Localidad");
            DropTable("dbo.Persona");
            DropTable("dbo.Rubro");
            DropTable("dbo.Marca");
            DropTable("dbo.Articulo");
        }
    }
}
