using Dominio.Entidades;
using Dominio.Repositorio;
using Infraestructura.Repositorio;

namespace Infraestructura.UnidadDeTrabajo
{
    public partial class UnidadDeTrabajo
    {
        // ============================================================================================================ //

        private IRepositorio<Provincia> provinciaRepositorio;
        public IRepositorio<Provincia> ProvinciaRepositorio => provinciaRepositorio
                                                               ?? (provinciaRepositorio =
                                                                   new Repositorio<Provincia>(_context));

        // ============================================================================================================ //

        private IRepositorio<Departamento> departamentoRepositorio;

        public IRepositorio<Departamento> DepartamentoRepositorio => departamentoRepositorio
                                                                  ?? (departamentoRepositorio =
                                                                      new Repositorio<Departamento>(_context));

        // ============================================================================================================ //

        private IRepositorio<Localidad> localidadRepositorio;

        public IRepositorio<Localidad> LocalidadRepositorio => localidadRepositorio
                                                               ?? (localidadRepositorio =
                                                                   new Repositorio<Localidad>(_context));

        // ============================================================================================================ //

        private IRepositorio<Marca> marcaRepositorio;

        public IRepositorio<Marca> MarcaRepositorio => marcaRepositorio
                                                       ?? (marcaRepositorio =
                                                           new Repositorio<Marca>(_context));

        // ============================================================================================================ //

        private IRepositorio<Rubro> rubroRepositorio;

        public IRepositorio<Rubro> RubroRepositorio => rubroRepositorio
                                                       ?? (rubroRepositorio =
                                                           new Repositorio<Rubro>(_context));


        // ============================================================================================================ //


        // ============================================================================================================ //

        private IRepositorio<Precio> precioRepositorio;

        public IRepositorio<Precio> PrecioRepositorio => precioRepositorio
                                                             ?? (precioRepositorio =
                                                                 new Repositorio<Precio>(_context));

        // ============================================================================================================ //



        // ============================================================================================================ //

    }
}
