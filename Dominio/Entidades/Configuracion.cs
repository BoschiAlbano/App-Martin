using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Aplicacion.Constantes;

namespace Dominio.Entidades
{
    [Table("Configuracion")]
    public class Configuracion : EntidadBase
    {
        // ====================================== //
        // ====    Datos de la Empresa     ====== //
        // ====================================== //
        public string RazonSocial { get; set; }

        public string NombreFantasia { get; set; }

        public string Cuit { get; set; }

        public string Telefono { get; set; }

        public string Celular { get; set; }

        public string Direccion { get; set; }

        public string Email { get; set; }

        public long LocalidadId { get; set; }

        public bool PuestoCajaSeparado { get; set; }

        public virtual Localidad Localidad { get; set; }

    }
}
