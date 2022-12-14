using IServicio.Articulo.DTOs;
using IServicio.Base;
using IServicio.BaseDto;
using System.Collections.Generic;

namespace IServicios.Precio
{
    public interface IPrecioServicio : IServicioAbm
    {
        DtoBase Obtener(long id);

        IEnumerable<DtoBase> ObtenerPrecios(long articuloId);

        bool ActualizarPrecio(decimal porcentajeGanancia, bool Redondear, decimal valor, bool esPorcentaje
            , long? marcaId = null, long? rubroId = null
            , int? codigoDesde = null, int? codigoHasta = null);


        IEnumerable<ArticuloDto> BuscarArticulos(decimal valor, bool esPorcentaje, long? marcaId = null, long? rubroId = null,
            long? listaPrecioId = null, int? codigoDesde = null, int? codigoHasta = null);

    }
}
