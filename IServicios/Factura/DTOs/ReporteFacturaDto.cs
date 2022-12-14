using System;
using System.Globalization;

namespace IServicios.Factura.DTOs
{
    public class ReporteFacturaDto
    {
        // Factura
        public int Numero { get; set; }
        public DateTime Fecha { get; set; }
        public string NombreCliente { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }

        public string NombreVendedor { get; set; }
        public string DireccionVendedor { get; set; }
        public string TelefonoVendedor { get; set; }
        public string CelularVendedor { get; set; }
        public string Contacto => TelefonoVendedor + " - " + CelularVendedor;


        public decimal FacturaTotal { get; set; }
        public decimal FacturaSubtotal { get; set; }
        public decimal FacturaDescuento { get; set; }
        public string FacturaDescuentoStr => FacturaDescuento.ToString() + " %";

        // items - Articulos
        public string Codigo { get; set; }

        public string Descripcion { get; set; }

        public decimal Precio { get; set; }
        public string PrecioStr => Precio.ToString("C", new CultureInfo("es-Ar"));

        public decimal Cantidad { get; set; }

        public decimal SubTotal => Cantidad * Precio;
        public string SubTotalStr => SubTotal.ToString("C", new CultureInfo("es-Ar"));
    }
}
