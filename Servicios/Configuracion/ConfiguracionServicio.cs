using System.Linq;
using Dominio.UnidadDeTrabajo;
using IServicio.Configuracion;
using IServicio.Configuracion.DTOs;
using IServicios.Configuracion.DTOs;

namespace Servicios.Configuracion
{
    public class ConfiguracionServicio : IConfiguracionServicio
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;

        public ConfiguracionServicio(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public void Grabar(ConfiguracionDto configuracionDto)
        {
            var config = configuracionDto.EsPrimeraVez
                ? new Dominio.Entidades.Configuracion()
                : _unidadDeTrabajo.ConfiguracionRepositorio.Obtener(configuracionDto.Id);


            config.Id = configuracionDto.Id;
            config.EstaEliminado = false;
            config.LocalidadId = configuracionDto.LocalidadId;
            config.NombreFantasia = configuracionDto.NombreFantasia;
            config.RazonSocial = configuracionDto.RazonSocial;
            config.Telefono = configuracionDto.Telefono;
            config.Celular = configuracionDto.Celular;
            config.Cuit = configuracionDto.Cuit;
            config.PuestoCajaSeparado = configuracionDto.PuestoCajaSeparado;
            config.Direccion = configuracionDto.Direccion;
            config.Email = configuracionDto.Email;
            
            if (configuracionDto.EsPrimeraVez)
            {
                _unidadDeTrabajo.ConfiguracionRepositorio.Insertar(config);
            }
            else
            {
                _unidadDeTrabajo.ConfiguracionRepositorio.Modificar(config);
            }

            _unidadDeTrabajo.Commit();
        }

        public ConfiguracionDto Obtener()
        {
            var config = _unidadDeTrabajo.ConfiguracionRepositorio.Obtener(null, "Localidad, Localidad.Departamento, Localidad.Departamento.Provincia")
                .FirstOrDefault();

            if (config == null) return null;

            return new ConfiguracionDto
            {
                Id = config.Id,
                Eliminado = false,
                RazonSocial = config.RazonSocial,
                NombreFantasia = config.NombreFantasia,
                Telefono = config.Telefono,
                LocalidadId = config.LocalidadId,
                DepartamentoId = config.Localidad.DepartamentoId,
                PuestoCajaSeparado = config.PuestoCajaSeparado,
                ProvinciaId = config.Localidad.Departamento.ProvinciaId,
                Celular = config.Celular,
                Cuit = config.Cuit,
                Direccion = config.Direccion,
                Email = config.Email,
            };
        }

        public DatosEmpresaDto ObtenerDatosEmpresa() 
        {
            var config = _unidadDeTrabajo.ConfiguracionRepositorio.Obtener(null, "Localidad, Localidad.Departamento, Localidad.Departamento.Provincia")
                .FirstOrDefault();

            if (config == null) return null;

            return new DatosEmpresaDto
            {
                Id = config.Id,
                Eliminado = false,

                NombreFantasia = config.NombreFantasia,
                RazonSocial = config.RazonSocial,
                Cuit = config.Cuit,

                Localidad = config.Localidad.Descripcion,
                Departamento = config.Localidad.Departamento.Descripcion,
                Provincia = config.Localidad.Departamento.Provincia.Descripcion,
                Direccion = config.Direccion,

                Telefono = config.Telefono,
                Email = config.Email,
            };
        }
    }
}
