using Aplicacion.Constantes;
using Dominio.Entidades;
using Infraestructura;
using IServicio.Configuracion;
using IServicios.Caja;
using IServicios.Comprobante.DTOs;
using IServicios.Contador;
using StructureMap;
using System;
using System.Linq;
using System.Transactions;

namespace Servicios.Comprobante
{
    public class Factura : Comprobante
    {
        private readonly IContadorServicio _contadorServicio;
        private readonly IConfiguracionServicio _configuracionServicio;
        private readonly ICajaServicio _CajaServicio;
        public Factura() : base()
        {
            _contadorServicio = ObjectFactory.GetInstance<IContadorServicio>();
            _configuracionServicio = ObjectFactory.GetInstance<IConfiguracionServicio>();
            _CajaServicio = ObjectFactory.GetInstance<ICajaServicio>();
        }
        public override long Insertar(FacturaDto comprobante)
        {
            int numeroComprobante = 0;
            int clienteid = (int)comprobante.ClienteId;


            // Actualizar Caja
            _CajaServicio.ActualizarCaja(comprobante.Efectivo, comprobante.CuentaCorriente);


            if (comprobante.VieneVentas)
            {
                // Ventas 2 => 1 creo la factura en estado pendiente // 2 y la otra creo la factura y la cobro pagada
                // se graga igual sea pendiente o no
                // Factura En estado Pendiente 0 no
                using (var tran = new TransactionScope())
                {
                    try
                    {
                        using (var contexto = new DataContext())
                        {
                            // obtenermos el siguiente numero de comprobante
                            numeroComprobante = _contadorServicio.ObtenerSiguienteNumero();
                            // Comprobante
                            contexto.Comprobantes.Add(new Dominio.Entidades.Comprobante
                            {
                                EstaEliminado = false,
                                EmpleadoId = comprobante.EmpleadoId,
                                UsuarioId = comprobante.UsuarioId,
                                ClienteId = clienteid,
                                Fecha = comprobante.Fecha,
                                Numero = numeroComprobante,
                                SubTotal = comprobante.SubTotal,
                                Descuento = comprobante.Descuento,
                                Total = comprobante.Total,
                                TipoComprobante = comprobante.TipoComprobante,// Eliminar de la entidad
                                Efectivo = comprobante.Efectivo,
                                CuentaCorriente = comprobante.CuentaCorriente,
                                Estado = comprobante.Estado,
                                PagoCuentaCorriente = false
                            });



                            contexto.SaveChanges();

                        }

                        using (var contexto = new DataContext())
                        {
                            // Detalle de Comprobante
                            foreach (var Detalle in comprobante.Items)
                            {
                                // descontar stock
                                var articulo = contexto.Articulos.Where(x => x.Id == Detalle.ArticuloId).FirstOrDefault();

                                if (articulo.Stock >= Detalle.Cantidad)
                                {
                                    articulo.Stock -= (int)Detalle.Cantidad;
                                }

                                contexto.Entry(articulo).State = System.Data.Entity.EntityState.Modified;

                                // generar el detalle del comprobante
                                var UltimoComprobante = contexto.Comprobantes.Max(x => x.Id);


                                contexto.DetalleComprobantes.Add(new DetalleComprobante
                                {
                                    ComprobanteId = UltimoComprobante,
                                    ArticuloId = Detalle.ArticuloId,
                                    Codigo = Detalle.Codigo,
                                    Descripcion = Detalle.Descripcion,
                                    Cantidad = Detalle.Cantidad,
                                    Precio = Detalle.Precio,
                                    PrecioCosto = articulo.PrecioCosto,
                                    SubTotal = Detalle.SubTotal,
                                    EstaEliminado = false,
                                    Dto = Detalle.Dto
                                });
                            }

                            contexto.SaveChanges();
                        }

                        using (var contexto = new DataContext()) 
                        {
                            // actualizar deuda del cliente
                            var Cliente = contexto.Clientes.Where(x => x.Id == clienteid).FirstOrDefault();
                            Cliente.Deuda += comprobante.CuentaCorriente;

                            contexto.Entry(Cliente).State = System.Data.Entity.EntityState.Modified;
                            contexto.SaveChanges();
                        }

                        tran.Complete();
                        return numeroComprobante;
                    }
                    catch
                    {
                        
                        tran.Dispose();
                        throw new Exception("Ocurrio un error grave al grabar la Factura");
                    }
                }

            }
            else {
                // Combro Diferido => cobrarla osea Actualizar un comprobante saldo efectivo y/o cuenta corriente y pendiente de pago

                using (var tran = new TransactionScope())
                {
                    try
                    {
                        var numero = 0;
                        using (var contexto = new DataContext()) 
                        {
                            var ActualizarComprobante = contexto.Comprobantes.Where(x => x.Id == comprobante.Id).FirstOrDefault();
                            numero = ActualizarComprobante.Numero;

                            ActualizarComprobante.Efectivo = comprobante.Efectivo;
                            ActualizarComprobante.CuentaCorriente = comprobante.CuentaCorriente;
                            ActualizarComprobante.Estado = Estado.Pagada;
                            ActualizarComprobante.ClienteId = comprobante.ClienteId;

                            contexto.Entry(ActualizarComprobante).State = System.Data.Entity.EntityState.Modified;

                            contexto.SaveChanges();
                        }
                        // deuda del cliente 
                        using (var contexto = new DataContext())
                        {
                            // actualizar deuda del cliente
                            var Cliente = contexto.Clientes.Where(x => x.Id == clienteid).FirstOrDefault();
                            Cliente.Deuda += comprobante.CuentaCorriente;

                            contexto.Entry(Cliente).State = System.Data.Entity.EntityState.Modified;
                            contexto.SaveChanges();
                        }

                        tran.Complete();
                        return numero;
                    }
                    catch (Exception)
                    {
                        tran.Dispose();
                        throw new Exception("Ocurrio un error grave al grabar la Factura");
                    }
                }

                
            }

        }


    }
}