using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Aplicacion.Constantes;

namespace Dominio.Entidades
{
    [Table("Comprobante")]
    public class Comprobante : EntidadBase
    {
        public long EmpleadoId { get; set; }

        public long UsuarioId { get; set; }

        public DateTime Fecha { get; set; }

        public int Numero { get; set; }

        public decimal SubTotal { get; set; }

        public decimal Descuento { get; set; }

        public decimal Total { get; set; }

        public TipoComprobante TipoComprobante { get; set; }//eliminar

        // app martin

        public decimal Efectivo { get; set; }

        public decimal CuentaCorriente { get; set; }

        public Estado Estado { get; set; }

        public long ClienteId { get; set; }

        public bool PagoCuentaCorriente { get; set; }


        // Propiedades de Navegacion
        public virtual Cliente Cliente { get; set; }
        public virtual Empleado Empleado { get; set; }
        public virtual Usuario Usuario { get; set; }

        public virtual ICollection<DetalleComprobante> DetalleComprobantes { get; set; }

    }
}