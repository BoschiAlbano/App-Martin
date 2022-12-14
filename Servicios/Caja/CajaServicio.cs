using Dominio.UnidadDeTrabajo;
using Infraestructura;
using IServicios.Caja;
using IServicios.Caja.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Servicios.Caja
{
    public class CajaServicio : ICajaServicio
    {
        private readonly IUnidadDeTrabajo _UnidadDeTrabajo;
        public CajaServicio(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _UnidadDeTrabajo = unidadDeTrabajo;
        }

        public void AbrirCaja(long usuarioId, decimal montoApertura, DateTime fecha)
        {
            
        }
        public void CerrarCaja(CajaDto Caja)
        {

        }

        public IEnumerable<CajaDto> Obtener(string cadenaBuscar, bool filtroFechas, DateTime fechaDesde, DateTime fechaHasta)
        {
            return new List<CajaDto>();
        }
        public CajaDto Obtener(long CajaId)
        {
            return new CajaDto();
        }
        
        public decimal ObtenerMontoAnterio(long usuarioId)
        {
            return 0;
        }
        public bool VerificarAbiertaOCerrada(long usuarioId)
        {
            return false;
        }





        public CajaDtoSimple Obtener(DateTime fecha)
        {
            // si existe la caja del dia de hoy la busco y si no la creo
            var _fechaInicio = new DateTime(fecha.Year, fecha.Month, fecha.Day, 0, 0, 0);
            var _fechaFin = new DateTime(fecha.Year, fecha.Month, fecha.Day, 23, 59, 59);


            var caja = _UnidadDeTrabajo.CajaRepositorio.Obtener().Where(x => x.Fecha >= _fechaInicio && x.Fecha <= _fechaFin).FirstOrDefault();

            if (caja == null)
            {// creo una caja
         
                _UnidadDeTrabajo.CajaRepositorio.Insertar(new Dominio.Entidades.Caja 
                {
                    Efectivo = 0,
                    CuentaCorriente = 0,
                    Fecha = DateTime.Today,
                    EstaEliminado = false,
                });
                _UnidadDeTrabajo.Commit();

                return new CajaDtoSimple
                {
                    Efectivo = 0,
                    CuentaCorriente = 0,
                    Fecha = DateTime.Today,
                    Eliminado = false,
                };

            }
            else
            {// la q tengo
                return new CajaDtoSimple
                {
                    Efectivo = caja.Efectivo,
                    CuentaCorriente = caja.CuentaCorriente,
                    Fecha = caja.Fecha,
                    Eliminado = caja.EstaEliminado,
                };
            }


            
        }

        public void EliminarCajas() 
        {
            var fecha = DateTime.Today;

            var _fechaInicio = new DateTime(fecha.Year, fecha.Month, fecha.Day, 0, 0, 0);

            using (var contexto = new DataContext())
            {
                var obtener = contexto.Cajas.Where(x => x.Fecha < _fechaInicio).ToList().Any() 
                    ? contexto.Cajas.Where(x => x.Fecha < _fechaInicio).ToList() 
                    : null;

                if (obtener == null)
                {
                    return;
                }

                foreach (var cajas in obtener)
                {
                    contexto.Cajas.Remove(cajas);
                    contexto.SaveChanges();
                }

            }

        }

        public void ActualizarCaja(decimal Efectivo, decimal CtaCte) 
        {
            var caja = _UnidadDeTrabajo.CajaRepositorio.Obtener().FirstOrDefault();

            caja.Efectivo += Efectivo;
            caja.CuentaCorriente += CtaCte;

            _UnidadDeTrabajo.CajaRepositorio.Modificar(caja);

            _UnidadDeTrabajo.Commit();
        }
    }


}
