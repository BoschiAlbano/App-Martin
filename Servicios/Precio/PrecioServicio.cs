using Dominio.UnidadDeTrabajo;
using IServicio.Articulo.DTOs;
using IServicio.BaseDto;
using IServicios.Precio;
using IServicios.Precio.DTOs;
using Servicios.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Transactions;

namespace Servicios.Precio
{
    public class PrecioServicio : IPrecioServicio
    {
        private readonly IUnidadDeTrabajo _UnidadDeTrabajo;
        public PrecioServicio(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _UnidadDeTrabajo = unidadDeTrabajo;
        }

        public void Eliminar(long id)
        {
            _UnidadDeTrabajo.PrecioRepositorio.Eliminar(id);
            _UnidadDeTrabajo.Commit();
        }

        public void Insertar(DtoBase dtoEntidad)
        {
            var Dto = (PrecioCrudDto)dtoEntidad;

            _UnidadDeTrabajo.PrecioRepositorio.Insertar(new Dominio.Entidades.Precio
            {
                ArticuloId = Dto.ArticuloId,
                ListaPrecioId = Dto.ListaPrecioId,
                FechaActualizacion = Dto.FechaActualizacion,
                PrecioCosto = Dto.PrecioCosto,
                PrecioPublico = Dto.PrecioPublico,
            });

            _UnidadDeTrabajo.Commit();
        }

        public void Modificar(DtoBase dtoEntidad)
        {
            var Dto = (PrecioCrudDto)dtoEntidad;

            var entidad = _UnidadDeTrabajo.PrecioRepositorio.Obtener(Dto.Id);

            if (entidad == null) throw new Exception("Ocurrio un Error al Obtener la ListaPrecio");

            entidad.ListaPrecioId = Dto.ListaPrecioId;
            entidad.ArticuloId = Dto.ArticuloId;
            entidad.PrecioCosto = Dto.PrecioCosto;
            entidad.PrecioPublico = Dto.PrecioPublico;
            entidad.FechaActualizacion = Dto.FechaActualizacion;

            _UnidadDeTrabajo.PrecioRepositorio.Modificar(entidad);
            _UnidadDeTrabajo.Commit();
        }

        public DtoBase Obtener(long id)
        {
            var entidad = _UnidadDeTrabajo.PrecioRepositorio.Obtener(id);

            return new PrecioCrudDto
            {
                ListaPrecioId = entidad.ListaPrecioId,
                ArticuloId = entidad.ArticuloId,
                PrecioCosto = entidad.PrecioCosto,
                PrecioPublico = entidad.PrecioPublico,
                FechaActualizacion = entidad.FechaActualizacion,
                // puede mas cosas falta cargar el Dto
            };
        }

        public IEnumerable<DtoBase> ObtenerPrecios(long articuloId)
        {
            return _UnidadDeTrabajo.PrecioRepositorio.Obtener(x => x.ArticuloId == articuloId)
                .Select(x => new PrecioCrudDto
                {
                    ListaPrecioId = x.ListaPrecioId,
                    ArticuloId = x.ArticuloId,
                    PrecioCosto = x.PrecioCosto,
                    PrecioPublico = x.PrecioPublico,
                    FechaActualizacion = x.FechaActualizacion,
                })
                .OrderBy(x => x.ArticuloId)
                .ToList();
        }

        public IEnumerable<ArticuloDto> BuscarArticulos(decimal valor, bool esPorcentaje, long? marcaId = null, long? rubroId = null,
            long? listaPrecioId = null, int? codigoDesde = null, int? codigoHasta = null)
        {
            // Creamos el Filtro
            Expression<Func<Dominio.Entidades.Articulo, bool>> _Filtro = x => !x.EstaEliminado;

            // Modificamos el Filtro
            if (marcaId.HasValue)
            {
                _Filtro = _Filtro.And(x => x.MarcaId == marcaId.Value);
            }

            if (rubroId.HasValue)
            {
                _Filtro = _Filtro.And(x => x.RubroId == rubroId.Value);
            }

            if (codigoDesde.HasValue && codigoHasta.HasValue)
            {
                _Filtro = _Filtro.And(x => x.Codigo >= codigoDesde && x.Codigo <= codigoHasta);
            }

            // Traemos todos los Articulos
            //var _Precios = _UnidadDeTrabajo.ArticuloRepositorio.Obtener(_Filtro);

            return _UnidadDeTrabajo.ArticuloRepositorio.Obtener(_Filtro)
                .Select(x => new ArticuloDto
                {
                    Id = x.Id,
                    Codigo = x.Codigo,
                    CodigoBarra = x.CodigoBarra,
                    Abreviatura = x.Abreviatura,
                    Descripcion = x.Descripcion,
                    Detalle = x.Detalle,
                    Ubicacion = x.Ubicacion,
                    StockMinimo = x.StockMinimo,
                    Foto = x.Foto,
                    PrecioCosto = x.PrecioCosto,
                    Capital = x.PrecioCosto * x.Stock,
                    PrecioVenta = x.PrecioVenta,
                    PorcentajeGanancia = x.PorcentajeGanancia,
                    RubroId = x.RubroId,
                    MarcaId = x.MarcaId,
                    Stock = x.Stock
                })
                .OrderBy(x => x.Descripcion)
                .ToList();
        }

        // actualizar precio de costo en articulo y generar nuevos precios para todas las listas
        public bool ActualizarPrecio(decimal porcentajeGanancia, bool Redondear, decimal valor, bool esPorcentaje, long? marcaId = null, long? rubroId = null,
            int? codigoDesde = null, int? codigoHasta = null)
        {
            // Creamos el Filtro
            Expression<Func<Dominio.Entidades.Articulo, bool>> _Filtro = x => !x.EstaEliminado;

            // Fecha Actual
            var fechaActual = DateTime.Now;

            // Modificamos el Filtro
            if (marcaId.HasValue)
            {
                _Filtro = _Filtro.And(x => x.MarcaId == marcaId.Value);
            }

            if (rubroId.HasValue)
            {
                _Filtro = _Filtro.And(x => x.RubroId == rubroId.Value);
            }

            if (codigoDesde.HasValue && codigoHasta.HasValue)
            {
                _Filtro = _Filtro.And(x => x.Codigo >= codigoDesde && x.Codigo <= codigoHasta);
            }

            // Traemos todos los Articulos
            var _Articulos = _UnidadDeTrabajo.ArticuloRepositorio.Obtener(_Filtro);

            if (_Articulos.Count() == 0)
            {
                return false;
            }

            using (var tran = new TransactionScope())
            {
                try
                {
                    foreach (var art in _Articulos)
                    {
                        if (porcentajeGanancia > 0)// modifico porcentaje
                        {
                            art.PorcentajeGanancia = porcentajeGanancia;

                        }
                        else 
                        {
                            // modificamos el precio de costo
                            art.PrecioCosto = esPorcentaje
                               ? Math.Round(art.PrecioCosto + (art.PrecioCosto * (valor / 100m)), 2)
                               : Math.Round(art.PrecioCosto + valor, 2);
                        }

                        // calcumaos el nuevo precio de venta
                        var PrecioVenta = art.PrecioCosto + ((art.PorcentajeGanancia * art.PrecioCosto) / 100);

                        // Redodiar Valor
                        if (Redondear)
                        {
                            art.PrecioVenta = Math.Round(PrecioVenta);
                        }
                        else
                        {
                            art.PrecioVenta = Math.Round(PrecioVenta, 2);
                        }

                        _UnidadDeTrabajo.ArticuloRepositorio.Modificar(art);
                    }

                    _UnidadDeTrabajo.Commit();

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

    }
}
