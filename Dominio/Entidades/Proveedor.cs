using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    [Table("Proveedor")]
    public class Proveedor : EntidadBase
    {
        public string RazonSocial { get; set; }

        public string CUIT { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }

        public string Mail { get; set; }

        public long LocalidadId { get; set; }


        // Propiedades de Navegacion

        public virtual Localidad Localidad { get; set; }
    }
}
