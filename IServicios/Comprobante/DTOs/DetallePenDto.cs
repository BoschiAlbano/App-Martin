using IServicio.BaseDto;
using System.Globalization;

namespace IServicios.Comprobante.DTOs
{
    public class DetallePenDto : DtoBase
    {
        public string Descripcion { get; set; }

        public decimal Precio { get; set; }
        public string PrecioStr => Precio.ToString("C", new CultureInfo("es-Ar"));

        public decimal Cantidad { get; set; }

        public decimal SubTotal { get; set; }

        public string Codigo { get; set; }


    }
}
