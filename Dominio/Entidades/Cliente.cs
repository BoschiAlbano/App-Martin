using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    [Table("Persona_Cliente")]
    public class Cliente : Persona
    {
        // Propiedades 
        public bool ActivarCtaCte { get; set; }
        
        public bool TieneLimiteCompra { get; set; }
        
        public decimal MontoMaximoCtaCte { get; set; }

        public decimal Deuda { get; set; }

    }
}
