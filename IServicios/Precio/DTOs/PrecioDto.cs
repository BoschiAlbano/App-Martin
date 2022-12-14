using IServicio.BaseDto;
using System;
using System.Globalization;

namespace IServicios.Precio.DTOs
{
    public class PrecioDto : DtoBase
    {   
        public string ListaPrecio { get; set; }

        public decimal Precio { get; set; }
        public string PrecioStr => Precio.ToString("C", new CultureInfo("es-AR"));

        public DateTime Fecha { get; set; }
        public string FechaStr => Fecha.ToShortDateString();
    }
}
