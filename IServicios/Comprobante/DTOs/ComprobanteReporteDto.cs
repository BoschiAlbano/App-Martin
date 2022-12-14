using Aplicacion.Constantes;
using IServicio.BaseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServicios.Comprobante.DTOs
{
    public class ComprobanteReporteDto : DtoBase
    {
        public string NombreCliente { get; set; }

        public DateTime Fecha { get; set; }
        public int Numero { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Descuento { get; set; }
        public decimal Total { get; set; }
        public decimal Efectivo { get; set; }
        public decimal CuentaCorriente { get; set; }
        public Estado Estado { get; set; }
        public string Descripcion { get; set; }
        public string EstadoStr => Estado == Estado.Pagada ? "Pagada" : "Inpaga";

        public string FechaDesde { get; set; }
        public string FechaHasta { get; set; }

        public List<DetallePenDto> Items { get; set; }
    }
}
