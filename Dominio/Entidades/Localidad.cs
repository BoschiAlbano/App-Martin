using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    [Table("Localidad")]
    public class Localidad : EntidadBase
    {
        // Propiedades
        public long DepartamentoId { get; set; }

        public string Descripcion { get; set; }


        // Propiedades de Navegacion
        public virtual Departamento Departamento { get; set; }

        public virtual ICollection<Persona> Personas { get; set; }

        public virtual ICollection<Configuracion> Configuraciones { get; set; }
    }
}
