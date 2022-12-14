using Aplicacion.Constantes;
using IServicio.BaseDto;
using IServicio.Persona.DTOs;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace IServicios.Comprobante.DTOs
{
    public class ComprobantePenPagoDto : DtoBase
    {
        public ComprobantePenPagoDto()
        {
            if (Items == null)
            {
                Items = new List<DetallePenDto>();
            }
        }
        public int Numero { get; set; }

        public ClienteDto Cliente { get; set; }

        public string ClienteApiNom { get; set; }

        public string Telefono { get; set; }

        public string Dni { get; set; }

        public string Direccion { get; set; }

        public TipoComprobante TipoComprobante { get; set; }

        public DateTime Fecha { get; set; }

        public decimal  Monto { get; set; }
        public string MontoStr => Monto.ToString("C", new CultureInfo("es-Ar"));

        public decimal Descuento { get; set; }


        public List<DetallePenDto> Items { get; set; }
    }
}

