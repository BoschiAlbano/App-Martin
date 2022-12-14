using Dominio.UnidadDeTrabajo;
using Infraestructura;
using IServicios.Comprobante;
using IServicios.Comprobante.DTOs;
using Servicios.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Transactions;

namespace Servicios.Comprobante
{
    public class ComprobanteServicio : IComprobanteServicio
    {
        protected readonly IUnidadDeTrabajo _unidadDeTrabajo;
        private Dictionary<Type, string> _diccionario;
        public ComprobanteServicio(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
            _diccionario = new Dictionary<Type, string>();
            InicializadorDiccionario();
        }
        private void InicializadorDiccionario()
        {
            _diccionario.Add(typeof(FacturaDto), "Servicios.Comprobante.Factura");
            _diccionario.Add(typeof(CtaCteComprobanteDto), "Servicios.Comprobante.CuentaCorriente");
        }
        public void AgregarOpcionDiccionario(Type type, string value)
        {
            _diccionario.Add(type, value);
        }
        public virtual long Insertar(FacturaDto dto)
        {
            var comprobante = GenericInstance<Comprobante>.InstanciarEntidad(dto, _diccionario);
            return comprobante.Insertar(dto);
        }

        public IEnumerable<ComprobanteReporteDto> Obtener(DateTime fechaDesde, DateTime fechaHasta)
        {

            var _fechaDesde = new DateTime(fechaDesde.Year, fechaDesde.Month, fechaDesde.Day, 0, 0, 0);
            var _fechaHasta = new DateTime(fechaHasta.Year, fechaHasta.Month, fechaHasta.Day, 23, 59, 59);

            string Desde = _fechaDesde.ToShortDateString();
            string Hasta = _fechaHasta.ToShortDateString();
            using (var contexto = new DataContext())
            {
                var Comprobantes = contexto.Comprobantes
                    .Where(x => !x.EstaEliminado && x.Fecha >= _fechaDesde && x.Fecha <= _fechaHasta)
                    .Select(x => new ComprobanteReporteDto 
                    {
                        Id = x.Id,
                        Eliminado = x.EstaEliminado,

                        Numero = x.Numero,
                        Fecha = x.Fecha,

                        NombreCliente = x.Cliente.Nombre + " " + x.Cliente.Apellido,
                        SubTotal = x.SubTotal,
                        Descuento = x.Descuento,
                        Total = x.Total,
                        Efectivo = x.Efectivo,
                        CuentaCorriente = x.PagoCuentaCorriente ? (x.Efectivo * -1) : x.CuentaCorriente,
                        Estado = x.Estado,

                        Descripcion = x.PagoCuentaCorriente ? "Factura n" + x.Numero + " - PAGO CUENTA CORRIENTE" : "Factura n" + x.Numero + " - COMPRA REALIZADA",

                        FechaDesde = Desde,
                        FechaHasta = Hasta,
                    }).ToList();

                return Comprobantes;
            }
        }

        public bool Eliminar() 
        {
            var _fecha = DateTime.Today.AddMonths(-3);

            //List<Dominio.Entidades.Comprobante> comprobantes = new List<Dominio.Entidades.Comprobante>();

            using (var tran = new TransactionScope()) 
            {
                try
                {
                    using (var _Contexto = new DataContext())
                    {
                        var _Comprobantes = _Contexto.Comprobantes.Where(x => x.Fecha <= _fecha).ToList();

                        foreach (var comprobante in _Comprobantes)
                        {
                            var _Detalle = _Contexto.DetalleComprobantes.Where(x => x.ComprobanteId == comprobante.Id).ToList();

                            foreach (var detalle in _Detalle)
                            {
                                _Contexto.DetalleComprobantes.Remove(detalle);
                                _Contexto.SaveChanges();
                            }

                            _Contexto.Comprobantes.Remove(comprobante);
                            _Contexto.SaveChanges();
                        }
                    }
                    tran.Complete();
                    return true;
                }
                catch (Exception ex)
                {
                    tran.Dispose();
                    throw new Exception(ex.Message);
                }
            }
        }


        public IEnumerable<ComprobanteReporteDto> ObtenerPorUsuario(DateTime fecha, long idUsuario)
        {

            var _fecha = new DateTime(fecha.Year, fecha.Month, fecha.Day, 0, 0, 0);
            var _Hora = new DateTime(fecha.Year, fecha.Month, fecha.Day, 23, 59, 59);

            string fechacomprobante = _fecha.ToShortDateString();

            using (var contexto = new DataContext())
            {
                var Comprobantes = contexto.Comprobantes
                    .Where(x => !x.EstaEliminado && x.Fecha >= _fecha && x.Fecha <= _Hora && x.UsuarioId == idUsuario && x.PagoCuentaCorriente == false)
                    .Select(x => new ComprobanteReporteDto
                    {
                        Id = x.Id,
                        Eliminado = x.EstaEliminado,

                        Numero = x.Numero,
                        Fecha = x.Fecha,

                        NombreCliente = x.Cliente.Nombre + " " + x.Cliente.Apellido,
                        SubTotal = x.SubTotal,
                        Descuento = x.Descuento,
                        Total = x.Total,
                        Efectivo = x.Efectivo,
                        CuentaCorriente = x.PagoCuentaCorriente ? (x.Efectivo * -1) : x.CuentaCorriente,
                        Estado = x.Estado,

                        Descripcion = x.PagoCuentaCorriente ? "Factura n" + x.Numero + " - PAGO CUENTA CORRIENTE" : "Factura n" + x.Numero + " - COMPRA REALIZADA",

                        FechaDesde = fechacomprobante,
                        FechaHasta = fechacomprobante,

                        Items = x.DetalleComprobantes.Select(d => new DetallePenDto
                        {
                            Id = d.Id,
                            Descripcion = d.Descripcion,
                            Cantidad = d.Cantidad,
                            Precio = d.Precio,
                            SubTotal = d.SubTotal,
                            Eliminado = d.EstaEliminado,
                            Codigo = d.Codigo,
                        }).ToList()

                    }).OrderByDescending(x => x.Fecha).ToList();

                return Comprobantes;
            }
        }


        public decimal CalcularComision(DateTime fecha, long idUsuario) 
        {
            decimal Total = 0m;

            var _fechaInicio = new DateTime(fecha.Year, fecha.Month, fecha.Day, 0, 0, 0);
            var _fechaFin = new DateTime(fecha.Year, fecha.Month, fecha.Day, 23, 59, 59);

            using (var _Contexto = new DataContext())
            {
                var comprobantes = _Contexto.Comprobantes.Where(x => !x.EstaEliminado && x.UsuarioId == idUsuario
                && x.Fecha >= _fechaInicio && x.Fecha <= _fechaFin && x.PagoCuentaCorriente == false)
                    .Include(x => x.DetalleComprobantes).ToList();

                var articulos = _Contexto.Articulos.ToList();

                foreach (var com in comprobantes)
                {
                    foreach (var producto in com.DetalleComprobantes)
                    {
                        Total += (producto.Cantidad * (producto.Precio - producto.PrecioCosto));
                    }
                }

            }

            return Total;
        }
    }

}
