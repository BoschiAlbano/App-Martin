using Aplicacion.Constantes;
using Dominio.UnidadDeTrabajo;
using Infraestructura;
using IServicios.Comprobante.DTOs;
using IServicios.Factura;
using IServicios.Factura.DTOs;
using Servicios.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Transactions;

namespace Servicios.Comprobante
{
    public class FacturaServicio : ComprobanteServicio, IFacturaServicio
    {
        public FacturaServicio(IUnidadDeTrabajo unidadDeTrabajo)
        : base(unidadDeTrabajo)
        {
        }

        public IEnumerable<ComprobantePenPagoDto> ObtenerPendientesPago(string CadenaBuscar, int Codigo)
        {

            Expression<Func<Dominio.Entidades.Comprobante, bool>> filtro = x =>
             x.Cliente.Nombre.Contains(CadenaBuscar)
             || x.Cliente.Apellido.Contains(CadenaBuscar) 
             && !x.EstaEliminado;

            
            if (Codigo > 0)
            {
                filtro = filtro.And(x => x.Numero == Codigo);
            };
            

            var Comprobantes = _unidadDeTrabajo.ComprobanteRepositorio.Obtener(filtro, "Cliente, DetalleComprobantes").Where( e => e.Estado == Estado.Pendiente)
                .Select(x => new ComprobantePenPagoDto
                {
                    Id = x.Id,
                    Cliente = new IServicio.Persona.DTOs.ClienteDto
                    {
                        Id = x.Cliente.Id,
                        Eliminado = x.Cliente.EstaEliminado,

                        Nombre = x.Cliente.Nombre,
                        Apellido = x.Cliente.Apellido,
                        Telefono = x.Cliente.Telefono,
                        Direccion = x.Cliente.Direccion,
                        Dni = x.Cliente.Dni,

                        ActivarCtaCte = x.Cliente.ActivarCtaCte,
                        TieneLimiteCompra = x.Cliente.TieneLimiteCompra,
                        MontoMaximoCtaCte = x.Cliente.MontoMaximoCtaCte,

                    },
                    ClienteApiNom = $"{x.Cliente.Apellido} {x.Cliente.Nombre}",
                    Direccion = x.Cliente.Direccion,
                    Dni = x.Cliente.Dni,
                    Telefono = x.Cliente.Telefono,
                    Fecha = x.Fecha,
                    Monto = x.Total,
                    Numero = x.Numero,
                    TipoComprobante = x.TipoComprobante,
                    Descuento = x.Descuento,
                    Eliminado = x.EstaEliminado,
                    Items = x.DetalleComprobantes.Select(d => new DetallePenDto
                    {
                        Id = d.Id,
                        Descripcion = d.Descripcion,
                        Cantidad = d.Cantidad,
                        Precio = d.Precio,
                        SubTotal = d.SubTotal,
                        Eliminado = d.EstaEliminado,
                    }).ToList()

                }).OrderByDescending(x => x.Fecha).ToList();


            return Comprobantes;

        }

        public int ObtenerUltimaFactura()
        {
            int SigNumero = 0;

            using (var contexto = new DataContext())
            {
                SigNumero = contexto.Comprobantes.Where(x => !x.EstaEliminado).Max(m => m.Numero);
            }

            /*
            var SigNumero = _unidadDeTrabajo..Obtener()
                .Where(x => x.TipoComprobante == tipoComprobante && !x.EstaEliminado).Max(m => m.Numero);
            */
            return SigNumero;
        }


        public decimal Efectivo_Dia(DateTime fecha) 
        {
            // fecha y hora
            var _fechaInicio = new DateTime(fecha.Year, fecha.Month, fecha.Day, 0, 0, 0);
            var _fechaFin = new DateTime(fecha.Year, fecha.Month, fecha.Day, 23, 59, 59);
            
            return _unidadDeTrabajo.ComprobanteRepositorio.Obtener()
                .Where(x => x.Fecha >= _fechaInicio && x.Fecha <= _fechaFin && x.Estado == Estado.Pagada && !x.EstaEliminado)
                .Sum(s => s.Efectivo);
            

        }

        public decimal CtaCte_Dia(DateTime fecha)
        {
            // fecha y hora
            var _fechaInicio = new DateTime(fecha.Year, fecha.Month, fecha.Day, 0, 0, 0);
            var _fechaFin = new DateTime(fecha.Year, fecha.Month, fecha.Day, 23, 59, 59);


            return _unidadDeTrabajo.ComprobanteRepositorio.Obtener()
                .Where(x => x.Fecha >= _fechaInicio && x.Fecha <= _fechaFin && x.Estado == Estado.Pagada && !x.EstaEliminado && !x.PagoCuentaCorriente)
                .Sum(s => s.CuentaCorriente);
        }

        public bool Eliminar_Factura(long id) 
        {
            using (var tran = new TransactionScope())
            {
                try
                {
                    using (var _Contexto = new DataContext())
                    {
                        var _Comprobantes = _Contexto.Comprobantes.Where(x => x.Id == id).FirstOrDefault();

                        var _Detalle = _Contexto.DetalleComprobantes.Where(x => x.ComprobanteId == _Comprobantes.Id).ToList();

                        foreach (var detalle in _Detalle)
                        {
                            _Contexto.DetalleComprobantes.Remove(detalle);
                            _Contexto.SaveChanges();

                            //reponer stock
                            var _Articulo = _Contexto.Articulos.Where(a => a.Id == detalle.ArticuloId).FirstOrDefault();
                            _Articulo.Stock += detalle.Cantidad;
                            _Contexto.SaveChanges();
                        }

                        _Contexto.Comprobantes.Remove(_Comprobantes);
                        _Contexto.SaveChanges();
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


        public List<ReporteFacturaDto> ImprimirFactura(long Id_Factura) 
        {
            var config = _unidadDeTrabajo.ConfiguracionRepositorio.Obtener().FirstOrDefault();

            List<ReporteFacturaDto> Reporte = new List<ReporteFacturaDto>();

            var Comprobante = _unidadDeTrabajo.ComprobanteRepositorio.Obtener(Id_Factura, "Cliente, Empleado, DetalleComprobantes");

            foreach (var item in Comprobante.DetalleComprobantes)
            {
                var agregar = new ReporteFacturaDto() 
                {
                    Numero = Comprobante.Numero,
                    Fecha = Comprobante.Fecha,

                    NombreCliente = Comprobante.Cliente.Apellido + " " + Comprobante.Cliente.Nombre,
                    Direccion = Comprobante.Cliente.Direccion,
                    Telefono = Comprobante.Cliente.Telefono,

                    NombreVendedor = Comprobante.Empleado.Apellido + " " + Comprobante.Empleado.Nombre,
                    DireccionVendedor = Comprobante.Empleado.Direccion,
                    TelefonoVendedor = config.Telefono,
                    CelularVendedor = config.Celular,

                    FacturaSubtotal = Comprobante.SubTotal,
                    FacturaDescuento = Comprobante.Descuento,
                    FacturaTotal = Comprobante.Total,

                    Codigo = item.Codigo,
                    Descripcion = item.Descripcion,
                    Precio = item.Precio,
                    Cantidad = item.Cantidad,
                    Dto = item.Dto
                };

                Reporte.Add(agregar);
            }

            return Reporte;
        }
    }

}
