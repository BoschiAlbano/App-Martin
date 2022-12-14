using IServicio.BaseDto;
using System;

namespace IServicios.Caja.DTOs
{
    public class CajaComprobanteDto : DtoBase
    {
        public string Vendedor { get; set; }
        public DateTime Fecha { get; set; }
        public int Numero { get; set; }
        public decimal Total { get; set; }

    }
}
