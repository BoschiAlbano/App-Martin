using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Transactions;
using Dominio.UnidadDeTrabajo;
using Infraestructura;
using IServicio.BaseDto;
using IServicio.ListaPrecio;
using IServicio.ListaPrecio.DTOs;
using Servicios.Base;

namespace Servicios.ListaPrecio
{
    public class ListaPrecioServicio : IListaPrecioServicio
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;

        public ListaPrecioServicio(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public void Eliminar(long id)
        {
            _unidadDeTrabajo.ListaPrecioRepositorio.Eliminar(id);
            _unidadDeTrabajo.Commit();

            var entidad = _unidadDeTrabajo.ListaPrecioRepositorio.Obtener(id);

            if (entidad.EstaEliminado == true)
            {
                // Elimino todos los precios
                foreach (var precio in _unidadDeTrabajo.PrecioRepositorio.Obtener()){
                    
                    if (precio.ListaPrecioId == id)
                    {
                        _unidadDeTrabajo.PrecioRepositorio.Remover(precio.Id);
                    }
                }

                _unidadDeTrabajo.Commit();
            }
            else {
                // genero todos los precios de esa lista para todos los articulos
                // aqui.

                var fechaActual = DateTime.Now;

                foreach (var articulo in _unidadDeTrabajo.ArticuloRepositorio.Obtener())
                {
                    _unidadDeTrabajo.PrecioRepositorio.Insertar(new Dominio.Entidades.Precio
                    {
                        ArticuloId = articulo.Id,
                        ListaPrecioId = entidad.Id,
                        FechaActualizacion = fechaActual,
                        PrecioCosto = articulo.PrecioCosto,
                        PrecioPublico = articulo.PrecioCosto + ((entidad.PorcentajeGanancia * articulo.PrecioCosto) / 100),
                        EstaEliminado = false
                    });
                }

                _unidadDeTrabajo.Commit();

            }

        }// si elimino una lista, elimino todos los precios de esa lista, si no la elimino genero los procios de nuevo para todos los articulos de esa lista

        public void Insertar(DtoBase dtoEntidad) // si creo una nueva lista de precio, genero un nuevo precio para cada articulo
        {
            using (var tran = new TransactionScope()) 
            {
                try
                {
                    var dto = (ListaPrecioDto)dtoEntidad;

                    var entidad = new Dominio.Entidades.ListaPrecio
                    {
                        Descripcion = dto.Descripcion,
                        NecesitaAutorizacion = dto.NecesitaAutorizacion,
                        PorcentajeGanancia = dto.PorcentajeGanancia,
                        EstaEliminado = false
                    };

                    _unidadDeTrabajo.ListaPrecioRepositorio.Insertar(entidad);

                    var fechaActual = DateTime.Now;

                    foreach (var articulo in _unidadDeTrabajo.ArticuloRepositorio.Obtener())
                    {
                        if (articulo.EstaEliminado == false)
                        {
                            _unidadDeTrabajo.PrecioRepositorio.Insertar(new Dominio.Entidades.Precio
                            {
                                ArticuloId = articulo.Id,
                                ListaPrecioId = entidad.Id,
                                FechaActualizacion = fechaActual,
                                PrecioCosto = articulo.PrecioCosto,
                                PrecioPublico = articulo.PrecioCosto + ((dto.PorcentajeGanancia * articulo.PrecioCosto) / 100),
                                EstaEliminado = false
                            });
                        }
                        
                    }

                    _unidadDeTrabajo.Commit();

                    tran.Complete();

                }
                catch (Exception e)
                {
                    tran.Dispose();
                    throw new Exception(e.Message);
                }
            }
        }

        public void Modificar(DtoBase dtoEntidad) // si actualizo la lista de precio, Genero un nuevo precio para cada articulo
        {
            using (var tran = new TransactionScope()) {

                try
                {
                    var dto = (ListaPrecioDto)dtoEntidad;

                    // Buscamos la lista
                    var entidad = _unidadDeTrabajo.ListaPrecioRepositorio.Obtener(dto.Id);

                    if (entidad == null) throw new Exception("Ocurrio un Error al Obtener la ListaPrecio");

                    // Actualizamos la lista
                    entidad.Descripcion = dto.Descripcion;
                    entidad.PorcentajeGanancia = dto.PorcentajeGanancia;
                    entidad.NecesitaAutorizacion = dto.NecesitaAutorizacion;
                    _unidadDeTrabajo.ListaPrecioRepositorio.Modificar(entidad);

                    // Actualizamos los precios de todos los articulos

                    var fechaActual = DateTime.Now;

                    foreach (var articulo in _unidadDeTrabajo.ArticuloRepositorio.Obtener())
                    {
                        if (articulo.EstaEliminado == false) 
                        {
                            _unidadDeTrabajo.PrecioRepositorio.Insertar(new Dominio.Entidades.Precio
                            {
                                ArticuloId = articulo.Id,
                                ListaPrecioId = entidad.Id,
                                FechaActualizacion = fechaActual,
                                PrecioCosto = articulo.PrecioCosto,
                                PrecioPublico = articulo.PrecioCosto + ((dto.PorcentajeGanancia * articulo.PrecioCosto) / 100),
                                EstaEliminado = false
                            });
                        }
                        
                    }


                    _unidadDeTrabajo.Commit();

                    tran.Complete();

                }
                catch (Exception e)
                {
                    tran.Dispose();
                    throw new Exception(e.Message);
                }

            }
        
        }

        public DtoBase Obtener(long id)
        {
            var entidad = _unidadDeTrabajo.ListaPrecioRepositorio.Obtener(id);

            return new ListaPrecioDto
            {
                Id = entidad.Id,
                Descripcion = entidad.Descripcion,
                NecesitaAutorizacion = entidad.NecesitaAutorizacion,
                PorcentajeGanancia = entidad.PorcentajeGanancia,
                Eliminado = entidad.EstaEliminado
            };
        }

        public IEnumerable<DtoBase> Obtener(string cadenaBuscar, bool mostrarTodos = true)
        {

            Expression<Func<Dominio.Entidades.ListaPrecio, bool>> filtro = x => x.Descripcion.Contains(cadenaBuscar);

            if (!mostrarTodos)
            {
                filtro = filtro.And(x => !x.EstaEliminado);
            }

            return _unidadDeTrabajo.ListaPrecioRepositorio.Obtener(filtro)
                .Select(x => new ListaPrecioDto
                {
                    Id = x.Id,
                    Descripcion = x.Descripcion,
                    NecesitaAutorizacion = x.NecesitaAutorizacion,
                    PorcentajeGanancia = x.PorcentajeGanancia,
                    Eliminado = x.EstaEliminado
                })
                .OrderBy(x => x.Descripcion)
                .ToList();
        }

        public bool VerificarSiExiste(string datoVerificar, long? entidadId = null)
        {
            return entidadId.HasValue
                ? _unidadDeTrabajo.ListaPrecioRepositorio.Obtener(x => !x.EstaEliminado
                                                                        && x.Id != entidadId.Value
                                                                        && x.Descripcion.Equals(datoVerificar,
                                                                            StringComparison.CurrentCultureIgnoreCase))
                    .Any()
                : _unidadDeTrabajo.ListaPrecioRepositorio.Obtener(x => !x.EstaEliminado
                                                                        && x.Descripcion.Equals(datoVerificar,
                                                                            StringComparison.CurrentCultureIgnoreCase))
                    .Any();
        }


        public void Probar() {

            /*using (var contexto = new DataContext()) {

                var _ListaPrecio = new Dominio.Entidades.ListaPrecio();

                _ListaPrecio.PorcentajeGanancia = 20;
                _ListaPrecio.Descripcion = "Probar";
                _ListaPrecio.NecesitaAutorizacion = false;

                contexto.ListaPrecios.Add(_ListaPrecio);

                contexto.SaveChanges();
            }
            */

            long id = 5;

            _unidadDeTrabajo.ListaPrecioRepositorio.Remover(id);

            _unidadDeTrabajo.Commit();

        }
    }
}
