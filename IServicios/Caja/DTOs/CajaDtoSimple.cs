using IServicio.BaseDto;
using System;
using System.Globalization;

namespace IServicios.Caja.DTOs
{
    public class CajaDtoSimple : DtoBase
    {

        public decimal Efectivo { get; set; }
        public string EfectivoStr => Efectivo.ToString("C", new CultureInfo("es-Ar"));
        public decimal CuentaCorriente { get; set; }
        public string CuentaCorrienteStr => CuentaCorriente.ToString("C", new CultureInfo("es-Ar"));
        public DateTime Fecha { get; set; }

    }
}
