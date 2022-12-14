using System.Linq;
using Dominio.UnidadDeTrabajo;
using IServicio.Persona;

namespace Servicios.Persona
{
    public class EmpleadoServicio : PersonaServicio, IEmpleadoServicio
    {
        public EmpleadoServicio(IUnidadDeTrabajo unidadDeTrabajo) 
            : base(unidadDeTrabajo)
        {
        }

        public void CambiarFoto(long idEmpleado, byte[] foto)
        {
            var _Empleado = _unidadDeTrabajo.EmpleadoRepositorio.Obtener(idEmpleado);

            _Empleado.Foto = foto;

            _unidadDeTrabajo.EmpleadoRepositorio.Modificar(_Empleado);

            _unidadDeTrabajo.Commit();
        }

        public int ObtenerSiguienteLegajo()
        {
            var empleados = _unidadDeTrabajo.EmpleadoRepositorio.Obtener();

            return empleados.Any()
                ? empleados.Max(x => x.Legajo) + 1
                : 1;
        }
    }
}
