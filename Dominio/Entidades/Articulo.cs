using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    [Table("Articulo")]
    public class Articulo : EntidadBase
    {
        // Propiedades
        public long MarcaId { get; set; }
        public long RubroId { get; set; }

        public int Codigo { get; set; }
        public string CodigoBarra { get; set; }
        public string Abreviatura { get; set; }
        public string Descripcion { get; set; }
        public string Detalle { get; set; }
        public string Ubicacion { get; set; }

        public int Stock { get; set; }

        public decimal PrecioCosto { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal PorcentajeGanancia { get; set; }
        
        public byte[] Foto { get; set; }
        public decimal StockMinimo { get; set; }

        public bool PermiteStockNegativo { get; set; }

        //============  Propiedades de Navegacion ======================//
        public virtual Marca Marca { get; set; }
        public virtual Rubro Rubro { get; set; }
        //public virtual ICollection<Precio> Precios { get; set; }
        //public virtual ICollection<DetalleComprobante> DetalleComprobantes { get; set; }
    }
}