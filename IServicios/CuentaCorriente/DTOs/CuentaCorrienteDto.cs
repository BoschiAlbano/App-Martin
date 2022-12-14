using IServicio.BaseDto;
using System;
using System.Globalization;

namespace IServicios.CuentaCorriente.DTOs
{
    public class CuentaCorrienteDto : DtoBase
    {
        
        public string Descripcion { get; set; }

        public DateTime Fecha { get; set; }
        public string FechaStr => Fecha.ToShortDateString();
        public string HoraStr => Fecha.ToShortTimeString();

        public decimal Monto { get; set; }
        public decimal Efectivo { get; set; }
        public string MontoStr => Monto.ToString("C", new CultureInfo("es-Ar"));
        public string EfectivoStr => Efectivo.ToString("C", new CultureInfo("es-Ar"));
        public bool PagoCuentaCorriente { get; set; }


        //deuda total
        public decimal DeudaTotal { get; set; }


    }
}
