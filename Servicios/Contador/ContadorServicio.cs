using Aplicacion.Constantes;
using Dominio.UnidadDeTrabajo;
using Infraestructura;
using IServicios.Contador;
using System;
using System.Linq;

namespace Servicios.Contador
{
    public class ContadorServicio : IContadorServicio
    {
        private readonly IUnidadDeTrabajo _UnidadDeTrabajo;
        public ContadorServicio(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _UnidadDeTrabajo = unidadDeTrabajo;
        }
        public int ObtenerSiguienteNumero()
        {
            int SiguienteNumero = 1;

            using (var contexto = new DataContext())
            {
                var PrimerComprobante = contexto.Comprobantes.FirstOrDefault();
                
                if (PrimerComprobante != null)
                {
                    SiguienteNumero = (contexto.Comprobantes.Max(x => x.Numero) + 1);
                }
               
            }

            return SiguienteNumero;
        }


    }
}
