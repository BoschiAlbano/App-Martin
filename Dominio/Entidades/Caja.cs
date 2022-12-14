using System;

namespace Dominio.Entidades
{
    public class Caja : EntidadBase
    {
        public decimal Efectivo { get; set; }

        public decimal CuentaCorriente { get; set; }

        public DateTime Fecha { get; set; }
    
    }
}
