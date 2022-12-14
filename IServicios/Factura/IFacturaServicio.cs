using Aplicacion.Constantes;
using IServicios.Comprobante;
using IServicios.Comprobante.DTOs;
using IServicios.Factura.DTOs;
using System;
using System.Collections.Generic;

namespace IServicios.Factura
{
    public interface IFacturaServicio : IComprobanteServicio
    {
        IEnumerable<ComprobantePenPagoDto> ObtenerPendientesPago(string CadenaBuscar, int Codigo);

        int ObtenerUltimaFactura();

        decimal Efectivo_Dia(DateTime fecha);

        decimal CtaCte_Dia(DateTime fecha);

        bool Eliminar_Factura(long id);

        List<ReporteFacturaDto> ImprimirFactura(long Id_Factura);


    }
}
