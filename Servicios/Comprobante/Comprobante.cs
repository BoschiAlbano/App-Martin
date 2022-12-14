using Dominio.UnidadDeTrabajo;
using IServicios.Comprobante.DTOs;
using StructureMap;

namespace Servicios.Comprobante
{
    public class Comprobante
    {
        protected readonly IUnidadDeTrabajo _UnidadDeTrabajo;
        public Comprobante()
        {
            _UnidadDeTrabajo = ObjectFactory.GetInstance<IUnidadDeTrabajo>();
        }

        public virtual long Insertar(FacturaDto comprobanteDto) 
        {
            return 0;
        }

    }
}
