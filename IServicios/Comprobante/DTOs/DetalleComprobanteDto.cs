using IServicio.BaseDto;

namespace IServicios.Comprobante.DTOs
{
    public class DetalleComprobanteDto : DtoBase
    {
        public long ArticuloId { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public decimal Iva { get; set; }
        public decimal Precio { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Dto { get; set; }
    }

}
