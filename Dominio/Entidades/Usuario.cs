﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    [Table("Usuario")]
    public class Usuario : EntidadBase
    {
        // Propiedades
        public long EmpleadoId { get; set; }

        public string Nombre { get; set; }

        public string Password { get; set; }

        public bool EstaBloqueado { get; set; }


        // Propiedades de Navegacion
        public virtual Empleado Empleado { get; set; }

        //public virtual ICollection<Comprobante> Comprobantes { get; set; }
    }
}
