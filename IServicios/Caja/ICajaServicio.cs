using IServicios.Caja.DTOs;
using System;
using System.Collections.Generic;

namespace IServicios.Caja
{
    public interface ICajaServicio
    {
        bool VerificarAbiertaOCerrada(long usuarioId);
        decimal ObtenerMontoAnterio(long usuarioId);


        IEnumerable<CajaDto> Obtener(string cadenaBuscar, bool filtroFechas, DateTime fechaDesde, DateTime fechaHasta);
        CajaDto Obtener(long CajaId);


        void AbrirCaja(long usuarioId, decimal montoApertura, DateTime fechaApertura);
        void CerrarCaja(CajaDto CerrarCaja);


        CajaDtoSimple Obtener(DateTime fecha);
        void EliminarCajas();

        void ActualizarCaja(decimal Efectivo, decimal CtaCte);

    }
}
