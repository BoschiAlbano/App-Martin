namespace IServicio.Persona
{
    public interface IEmpleadoServicio : IPersonaServicio
    {
        int ObtenerSiguienteLegajo();

        void CambiarFoto(long idEmpleado, byte[] foto);
    }
}
