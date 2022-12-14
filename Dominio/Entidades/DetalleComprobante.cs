using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    [Table("DetalleComprobante")]
    public class DetalleComprobante : EntidadBase
    {
        // Propiedades
        public long ComprobanteId { get; set; }

        public long ArticuloId { get; set; }

        public string Codigo { get; set; }

        public string Descripcion { get; set; }

        public int Cantidad { get; set; }

        public decimal Precio { get; set; }

        public decimal PrecioCosto { get; set; }

        public decimal SubTotal { get; set; }

        // Propiedades de Navegacion
        public virtual Comprobante Comprobante { get; set; }

        public virtual Articulo Articulos { get; set; }
    }
}