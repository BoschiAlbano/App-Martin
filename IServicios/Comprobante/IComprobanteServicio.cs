using IServicios.Comprobante.DTOs;
using System;
using System.Collections.Generic;

namespace IServicios.Comprobante
{
    public interface IComprobanteServicio
    {
        long Insertar(FacturaDto dto);

        IEnumerable<ComprobanteReporteDto> Obtener(DateTime fechaDesde, DateTime fechaHasta);
        IEnumerable<ComprobanteReporteDto> ObtenerPorUsuario(DateTime fecha, long idUsuario);
        bool Eliminar();

        decimal CalcularComision(DateTime fecha, long idUsuario);
    }

}
