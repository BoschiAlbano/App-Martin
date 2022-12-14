using IServicios.Comprobante.DTOs;
using IServicios.CuentaCorriente.DTOs;
using System;
using System.Collections.Generic;

namespace IServicios.CuentaCorriente
{
    public interface ICuentaCorrienteServicio
    {

        decimal ObtenerDeudaCliente(long ClienteId);


        IEnumerable<CuentaCorrienteDto> Obtener(long ClienteId, DateTime fechaDesde, DateTime fechaHasta, bool Deuda);

        void Pagar(CtaCteComprobanteDto comprobanteDto);


        List<ReporteClienteCuentaCorriente> ClientesDeben();

    }
}
