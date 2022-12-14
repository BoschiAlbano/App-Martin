using IServicio.Configuracion.DTOs;
using IServicios.Configuracion.DTOs;

namespace IServicio.Configuracion
{
    public interface IConfiguracionServicio
    {
        void Grabar(ConfiguracionDto configuracionDto);

        ConfiguracionDto Obtener();

        DatosEmpresaDto ObtenerDatosEmpresa();
    }
}
