using IServicio.BaseDto;

namespace IServicios.Configuracion.DTOs
{
    public class DatosEmpresaDto : DtoBase
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

        public string Localidad { get; set; }

        public string Departamento { get; set; }

        public string Provincia { get; set; }

        public string PieFactura { get; set; }

    }
}
