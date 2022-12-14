using Dominio.Entidades;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using Infraestructura.Migrations;
using static Aplicacion.CadenaConexion.CadenaConecion;

namespace Infraestructura
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base(ObtenerCadenaWin)
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataContext, Configuration>());

            ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = 600;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>()
                .Configure(x => x.HasColumnType("varchar"));

            base.OnModelCreating(modelBuilder);
        }

        // Mapeo
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }


        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<Rubro> Rubros { get; set; }
        public DbSet<Marca> Marcas { get; set; }

        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Localidad> Localidades { get; set; }
        public DbSet<Provincia> Provincias { get; set; }

        public DbSet<Configuracion> Configurationes { get; set; }


        public DbSet<Comprobante> Comprobantes { get; set; }
        public DbSet<DetalleComprobante> DetalleComprobantes { get; set; }
        
        public DbSet<Dominio.Entidades.Caja> Cajas { get; set; }
        
        //public DbSet<ListaPrecio> ListaPrecios { get; set; }
        //public DbSet<Dominio.Entidades.Precio> Precios { get; set; }
        
        
    }
}
