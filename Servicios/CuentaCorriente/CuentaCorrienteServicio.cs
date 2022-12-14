using Aplicacion.Constantes;
using Dominio.Entidades;
using Dominio.UnidadDeTrabajo;
using Infraestructura;
using IServicios.Caja;
using IServicios.Comprobante;
using IServicios.Comprobante.DTOs;
using IServicios.Contador;
using IServicios.CuentaCorriente;
using IServicios.CuentaCorriente.DTOs;
using Servicios.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Servicios.CuentaCorriente
{
    public class CuentaCorrienteServicio : ICuentaCorrienteServicio
    {
        private readonly IUnidadDeTrabajo _UnidadTrabajo;

        private readonly IContadorServicio _ContadorServicio;

        private readonly ICajaServicio _CajaServicio;

        public CuentaCorrienteServicio(ICajaServicio cajaServicio, IUnidadDeTrabajo unidadDeTrabajo, IContadorServicio contadorServicio)
        {
            _UnidadTrabajo = unidadDeTrabajo;
            _ContadorServicio = contadorServicio;
            _CajaServicio = cajaServicio;
        }

        public IEnumerable<CuentaCorrienteDto> Obtener(long ClienteId, DateTime fechaDesde, DateTime fechaHasta, bool SoloDeuda)
        {

            //SoloDeuda = true;

            //var _fechaDesde = new DateTime(fechaDesde.Year, fechaDesde.Month, fechaDesde.Day, fechaDesde.Day, 0, 0, 0);
            //var _fechaHasta = new DateTime(fechaHasta.Year, fechaHasta.Month, fechaHasta.Day, fechaHasta.Day, 23, 59, 59);

            var _fechaDesde = new DateTime(fechaDesde.Year, fechaDesde.Month, fechaDesde.Day, 0, 0, 0);
            var _fechaHasta = new DateTime(fechaHasta.Year, fechaHasta.Month, fechaHasta.Day, 23, 59, 59);

            using (var contexto = new DataContext())
            {
                var deudatotal = ObtenerDeudaCliente(ClienteId);

                var DeudaCuentaCorriente = contexto.Comprobantes
                    .Where(x => x.ClienteId == ClienteId && !x.EstaEliminado 
                        && x.Estado == Aplicacion.Constantes.Estado.Pagada 
                        && x.Fecha > _fechaDesde && x.Fecha < _fechaHasta)
                    .Select(x => new CuentaCorrienteDto
                    {
                        Id = x.Id,
                        Eliminado = x.EstaEliminado,

                        Descripcion = x.PagoCuentaCorriente ? "Factura n"+x.Numero+" - PAGO CUENTA CORRIENTE" : "Factura n" + x.Numero + " - COMPRA REALIZADA",
                        Fecha = x.Fecha,
                        Monto = x.CuentaCorriente,

                        PagoCuentaCorriente = x.PagoCuentaCorriente,
                        Efectivo = x.Efectivo,

                        DeudaTotal = deudatotal
                    }).ToList();

                return DeudaCuentaCorriente;
            }

        }

        public decimal ObtenerDeudaCliente(long ClienteId)
        {

            using (var context = new DataContext())
            {
                var Cliente = context.Clientes.Where(x => x.Id == ClienteId).FirstOrDefault();

                return Cliente.Deuda;
            }
        }

        public void Pagar(CtaCteComprobanteDto comprobanteDto)
        {
            int numeroComprobante = 0;


            // Actualizar Caja
            _CajaServicio.ActualizarCaja(comprobanteDto.Efectivo, 0);

            try
            {
                // Grabar un comprobante nuevo sin detalle de comprobante y con algo q lo distinga del resto de comprobantes de ventas
                using (var contexto = new DataContext())
                {
                    // obtenermos el siguiente numero de comprobante
                    numeroComprobante = _ContadorServicio.ObtenerSiguienteNumero();
                    // Comprobante
                    contexto.Comprobantes.Add(new Dominio.Entidades.Comprobante
                    {
                        EstaEliminado = false,
                        EmpleadoId = comprobanteDto.EmpleadoId,
                        UsuarioId = comprobanteDto.UsuarioId,
                        ClienteId = comprobanteDto.ClienteId,
                        Fecha = comprobanteDto.Fecha,
                        Numero = numeroComprobante,
                        SubTotal = comprobanteDto.SubTotal,
                        Descuento = comprobanteDto.Descuento,
                        Total = comprobanteDto.Total,
                        TipoComprobante = comprobanteDto.TipoComprobante,// Eliminar de la entidad
                        Efectivo = comprobanteDto.Efectivo,
                        CuentaCorriente = comprobanteDto.CuentaCorriente,
                        Estado = Aplicacion.Constantes.Estado.Pagada,
                        PagoCuentaCorriente = true
                    });

                    // Restar deuda del cliente 
                    var clientee = contexto.Clientes.Where(x => x.Id == comprobanteDto.ClienteId).FirstOrDefault();
                    clientee.Deuda -= comprobanteDto.Efectivo;

                    contexto.Entry(clientee).State = System.Data.Entity.EntityState.Modified;
                    
                    contexto.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw new Exception("Ocurrio Un Error al Pagar");
            }
        }


        public List<ReporteClienteCuentaCorriente> ClientesDeben() 
        {
            List<ReporteClienteCuentaCorriente> Reporte = new List<ReporteClienteCuentaCorriente>();

            var Clientes = _UnidadTrabajo.ClienteRepositorio.Obtener();

            foreach (var cliente in Clientes)
            {
                var Deuda = ObtenerDeudaCliente(cliente.Id);

                if (Deuda != 0)
                {
                    Reporte.Add(new ReporteClienteCuentaCorriente
                    {
                        Id = cliente.Id,
                        ApiNom = cliente.Apellido + " " + cliente.Nombre,
                        Direccion = cliente.Direccion,
                        Telefono = cliente.Telefono,
                        Deuda = Deuda,
                    });
                }
            }

            return Reporte;

        }
    }
}
