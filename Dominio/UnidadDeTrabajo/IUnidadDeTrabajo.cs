using Dominio.Entidades;
using Dominio.Repositorio;

namespace Dominio.UnidadDeTrabajo
{
    public interface IUnidadDeTrabajo
    {
        // Metodos
        void Commit();

        void Disposed();

        // Propiedades

        IRepositorio<Provincia> ProvinciaRepositorio { get; }
        IRepositorio<Departamento> DepartamentoRepositorio { get; }
        IRepositorio<Localidad> LocalidadRepositorio { get; }
        IClienteRepositorio ClienteRepositorio { get; }
        IEmpleadoRepositorio EmpleadoRepositorio { get; }
        IRepositorio<Usuario> UsuarioRepositorio { get; }
        IRepositorio<Configuracion> ConfiguracionRepositorio { get; }
        IRepositorio<ListaPrecio> ListaPrecioRepositorio { get; }
        IRepositorio<Marca> MarcaRepositorio { get; }
        IRepositorio<Rubro> RubroRepositorio { get; }
        IRepositorio<Articulo> ArticuloRepositorio { get; }

        IRepositorio<Precio> PrecioRepositorio { get; }
        IRepositorio<Contador> ContadorRepositorio { get; }
        IRepositorio<Caja> CajaRepositorio { get; }

        IRepositorio<Comprobante> ComprobanteRepositorio { get; }

    }

}
