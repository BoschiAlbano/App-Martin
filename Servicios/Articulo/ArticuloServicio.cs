using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Transactions;
using Dominio.UnidadDeTrabajo;
using IServicio.Articulo;
using IServicio.Articulo.DTOs;
using IServicio.BaseDto;
using IServicios.Articulo.DTOs;
using Servicios.Base;

namespace Servicios.Articulo
{
    public class ArticuloServicio : IArticuloServicio
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;

        public ArticuloServicio(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public void Eliminar(long id)
        {
            // Elimano articulo
            _unidadDeTrabajo.ArticuloRepositorio.Eliminar(id);
            _unidadDeTrabajo.Commit();
        }

        public void Insertar(DtoBase dtoEntidad)
        {

            using (var tran = new TransactionScope()) 
            {
                try
                {
                    var dto = (ArticuloCrudDto)dtoEntidad;
                    
                    // ------------------------ Articulo -------------------------------------------

                    var entidad = new Dominio.Entidades.Articulo
                    {
                        MarcaId = dto.MarcaId,
                        RubroId = dto.RubroId,
                        Codigo = dto.Codigo,
                        CodigoBarra = dto.CodigoBarra,
                        Abreviatura = dto.Abreviatura,
                        Descripcion = dto.Descripcion,
                        Detalle = dto.Detalle,
                        Ubicacion = dto.Ubicacion,
                        Stock = dto.Stock,
                        StockMinimo = dto.StockMinimo,
                        Foto = dto.Foto,
                        EstaEliminado = false,
                        PrecioCosto = dto.PrecioCosto,
                        PrecioVenta = dto.PrecioVenta,
                        PorcentajeGanancia = dto.PorcentajeGanancia,
                        PermiteStockNegativo = dto.PermiteStockNegativo
                    };

                    if (VerificarSiExiste(entidad.Descripcion, entidad.Codigo))
                    {
                        return;
                    }

                    _unidadDeTrabajo.ArticuloRepositorio.Insertar(entidad);
                    _unidadDeTrabajo.Commit();

                    tran.Complete();
                }
                catch (Exception ex)
                {
                    tran.Dispose();
                    throw new Exception(ex.Message);
                }
            }

        }

        public void Modificar(DtoBase dtoEntidad)
        {
            var dto = (ArticuloCrudDto)dtoEntidad;

            var entidad = _unidadDeTrabajo.ArticuloRepositorio.Obtener(dto.Id);

            if (entidad == null) throw new Exception("Ocurrio un Error al Obtener el Artículo");

            entidad.MarcaId = dto.MarcaId;
            entidad.RubroId = dto.RubroId;
            entidad.Codigo = dto.Codigo;
            entidad.CodigoBarra = dto.CodigoBarra;
            entidad.Abreviatura = dto.Abreviatura;
            entidad.Descripcion = dto.Descripcion;
            entidad.Detalle = dto.Detalle;
            entidad.Ubicacion = dto.Ubicacion;
            entidad.Stock = dto.Stock;
            entidad.StockMinimo = dto.StockMinimo;
            entidad.Foto = dto.Foto;
            entidad.PrecioCosto = dto.PrecioCosto;
            entidad.PrecioVenta = dto.PrecioVenta;
            entidad.PorcentajeGanancia = dto.PorcentajeGanancia;
            entidad.PermiteStockNegativo = dto.PermiteStockNegativo;

            _unidadDeTrabajo.ArticuloRepositorio.Modificar(entidad);
            _unidadDeTrabajo.Commit();
        }

        public DtoBase Obtener(long id)
        {
            var entidad = _unidadDeTrabajo.ArticuloRepositorio.Obtener(id, "Rubro, Marca");

            return new ArticuloDto
            {
                Id = entidad.Id,
                MarcaId = entidad.MarcaId,
                Marca = entidad.Marca.Descripcion,
                RubroId = entidad.RubroId,
                Rubro = entidad.Rubro.Descripcion,
                Codigo = entidad.Codigo,
                CodigoBarra = entidad.CodigoBarra,
                Abreviatura = entidad.Abreviatura,
                Descripcion = entidad.Descripcion,
                Detalle = entidad.Detalle,
                Ubicacion = entidad.Ubicacion,
                StockMinimo = entidad.StockMinimo,
                Foto = entidad.Foto,
                Stock = entidad.Stock,
                Eliminado = entidad.EstaEliminado,
                PrecioCosto = entidad.PrecioCosto,
                PrecioVenta = entidad.PrecioVenta,
                PorcentajeGanancia = entidad.PorcentajeGanancia,
                PermiteStockNegativo = entidad.PermiteStockNegativo,
                
            };
        }

        public IEnumerable<DtoBase> Obtener(string cadenaBuscar, bool mostrarTodos = true)
        {
            Expression<Func<Dominio.Entidades.Articulo, bool>> filtro = x =>
                 x.Descripcion.Contains(cadenaBuscar)
                 || x.Marca.Descripcion.Contains(cadenaBuscar)
                 || x.Rubro.Descripcion.Contains(cadenaBuscar);

            if (!mostrarTodos)
            {
                filtro = filtro.And(x => x.EstaEliminado == false);
            };

            // Calcular el Capital Total => precio de costo * cantidad +=

            return _unidadDeTrabajo.ArticuloRepositorio.Obtener(filtro, "Rubro, Marca")
            .Select(x => new ArticuloDto
            {
                Id = x.Id,
                MarcaId = x.MarcaId,
                Marca = x.Marca.Descripcion,
                RubroId = x.RubroId,
                Rubro = x.Rubro.Descripcion,
                Codigo = x.Codigo,
                CodigoBarra = x.CodigoBarra,
                Abreviatura = x.Abreviatura,
                Descripcion = x.Descripcion,
                Detalle = x.Detalle,
                Ubicacion = x.Ubicacion,
                StockMinimo = x.StockMinimo,
                Foto = x.Foto,
                Stock = x.Stock,
                Eliminado = x.EstaEliminado,
                PrecioCosto = x.PrecioCosto,
                PrecioVenta = x.PrecioVenta,
                PorcentajeGanancia = x.PorcentajeGanancia,
                Capital = x.PrecioCosto * x.Stock,
                PermiteStockNegativo = x.PermiteStockNegativo,
             }).OrderBy(x => x.Descripcion).ToList();
        }

        public bool VerificarSiExiste(string datoVerificar, long? Codigo = null)
        {
            return Codigo.HasValue
                ? _unidadDeTrabajo.ArticuloRepositorio.Obtener(x => !x.EstaEliminado
                                                                        && x.Codigo == Codigo
                                                                        || x.Descripcion.Equals(datoVerificar,
                                                                            StringComparison.CurrentCultureIgnoreCase))
                    .Any()
                : _unidadDeTrabajo.ArticuloRepositorio.Obtener(x => !x.EstaEliminado
                                                                        && x.Descripcion.Equals(datoVerificar,
                                                                            StringComparison.CurrentCultureIgnoreCase))
                    .Any();
        }

        public int ObtenerSiguienteNroCodigo()
        {
            var articulos = _unidadDeTrabajo.ArticuloRepositorio.Obtener();
            return articulos.Any()
            ? articulos.Max(x => x.Codigo) + 1
            : 1;
        }

        // igual al obtener. En este si trae todos los stock de los depositos
        public IEnumerable<ArticuloVentaDto> ObtenerLooUp(string cadenaBuscar)
        {
            var fechaActual = DateTime.Now;
            int.TryParse(cadenaBuscar, out int codigoArticulo);
            Expression<Func<Dominio.Entidades.Articulo, bool>> filtro = x => x.EstaEliminado == false
            && x.CodigoBarra == cadenaBuscar
            || x.Descripcion.Contains(cadenaBuscar)
            || x.Marca.Descripcion.Contains(cadenaBuscar)
            || x.Rubro.Descripcion.Contains(cadenaBuscar)
            || x.Codigo == codigoArticulo;

            return _unidadDeTrabajo.ArticuloRepositorio.Obtener(filtro).Where(x => !x.EstaEliminado)
            .Select(x => new ArticuloVentaDto()
            {
                Id = x.Id,
                Codigo = x.Codigo,
                CodigoBarra = x.CodigoBarra,
                Descripcion = x.Descripcion,
                Stock = x.Stock,
                Precio = x.PrecioVenta,
                PrecioCosto = x.PrecioCosto,
                PorcentajeGanancia = x.PorcentajeGanancia,
                PermiteStockNegativo = x.PermiteStockNegativo
                
            }).OrderBy(o => o.Descripcion).ToList();
        } 

        public ArticuloVentaDto ObtenerPorCodigo(string codigo)
        {
            var fechaActual = DateTime.Now;
            int.TryParse(codigo, out int _codigo);

            return _unidadDeTrabajo.ArticuloRepositorio.Obtener(x => x.CodigoBarra == codigo || x.Codigo == _codigo, "Rubro, Marca")
            .Where(n => !n.EstaEliminado)
            .Select(x => new ArticuloVentaDto()
            {
                Id = x.Id,
                Codigo = x.Codigo,
                CodigoBarra = x.CodigoBarra,
                Descripcion = x.Descripcion,
                Stock = x.Stock,
                Precio = x.PrecioVenta,
                PrecioCosto = x.PrecioCosto,
                PorcentajeGanancia = x.PorcentajeGanancia,
                StockMinimo = x.StockMinimo,
                PermiteStockNegativo = x.PermiteStockNegativo,
            }).FirstOrDefault();
        }

        public int ActualizarStock(ArticuloDto art, decimal cantidad)
        {
            int StockActual = 0;

            var Articulo = _unidadDeTrabajo.ArticuloRepositorio.Obtener(art.Id);

            if (Articulo == null) throw new Exception("Ocurrio un Error al Obtener el Artículo");

            StockActual = (int)cantidad + Articulo.Stock;

            Articulo.Stock = StockActual;

            _unidadDeTrabajo.ArticuloRepositorio.Modificar(Articulo);
            _unidadDeTrabajo.Commit();

            return StockActual;
        }
    }
}
