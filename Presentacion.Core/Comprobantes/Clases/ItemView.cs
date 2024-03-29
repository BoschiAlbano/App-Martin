﻿using System.Globalization;

namespace Presentacion.Core.Comprobantes.Clases
{
    public class ItemView
    {
        public long  Id { get; set; }
        public long ArticuloId { get; set; }

        public long ListaPrecioId { get; set; }

        public bool EsArticuloAlternativo { get; set; } = false;

        public bool IngresoPorBascula { get; set; } = false;

        //------
         
        public string CodigoBarra { get; set; }

        public string Descripcion { get; set; }

        public decimal Iva { get; set; }
        public string IvaStr => Iva.ToString("N2");

        public decimal Precio { get; set; }
        public string PrecioStr => Precio.ToString("C", new CultureInfo("es-Ar"));
        public decimal Dto { get; set; }
        public string DtoStr => Dto.ToString() + " %";

        public int Cantidad { get; set; }

        public decimal SubTotal => Cantidad * Precio;
        public string SubTotalStr => SubTotal.ToString("C", new CultureInfo("es-Ar"));

    }
}// 21:00