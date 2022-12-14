using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Aplicacion.Constantes;

namespace Dominio.Entidades
{
    [Table("Contador")]
    public class Contador : EntidadBase
    {
        public TipoComprobante TipoComprobante { get; set; }

        public int Valor { get; set; }
    }
}
