using IServicio.BaseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServicios.CuentaCorriente.DTOs
{
    public class ReporteClienteCuentaCorriente : DtoBase
    {

        public string ApiNom { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }

        public decimal Deuda { get; set; }




    }
}
