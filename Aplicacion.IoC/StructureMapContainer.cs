﻿using System.Data.Entity;
using Dominio.Repositorio;
using Dominio.UnidadDeTrabajo;
using Infraestructura.Repositorio;
using Infraestructura.UnidadDeTrabajo;
using IServicio.Articulo;
using IServicio.Configuracion;
using IServicio.Departamento;
using IServicio.Deposito;
using IServicio.Iva;
using IServicio.ListaPrecio;
using IServicio.Localidad;
using IServicio.Marca;
using IServicio.Persona;
using IServicio.Provincia;
using IServicio.Rubro;
using IServicio.Seguridad;
using IServicio.UnidadMedida;
using IServicio.Usuario;
using IServicios.Banco;
using IServicios.Caja;
using IServicios.Comprobante;
using IServicios.Contador;
using IServicios.CuentaCorriente;
using IServicios.Factura;
using IServicios.Precio;
using IServicios.PuestoTrabajo;
using IServicios.Tarjeta;
using Servicios.Articulo;
using Servicios.Caja;
using Servicios.Comprobante;
using Servicios.Configuracion;
using Servicios.Contador;
using Servicios.CuentaCorriente;
using Servicios.Departamento;
using Servicios.ListaPrecio;
using Servicios.Localidad;
using Servicios.Marca;
using Servicios.Persona;
using Servicios.Precio;
using Servicios.Provincia;
using Servicios.Rubro;
using Servicios.Seguridad;
using Servicios.Usuario;
using StructureMap;

namespace Aplicacion.IoC
{
    public class StructureMapContainer
    {
        public void Configure()
        {
            ObjectFactory.Configure(x =>
            {
                x.For(typeof(IRepositorio<>)).Use(typeof(Repositorio<>));

                x.ForSingletonOf<DbContext>();

                x.For<IUnidadDeTrabajo>().Use<UnidadDeTrabajo>();

                // =================================================================== //

                x.For<IProvinciaServicio>().Use<ProvinciaServicio>();

                x.For<IDepartamentoServicio>().Use<DepartamentoServicio>();

                x.For<ILocalidadServicio>().Use<LocalidadServicio>();

                x.For<IPersonaServicio>().Use<PersonaServicio>();

                x.For<IClienteServicio>().Use<ClienteServicio>();

                x.For<IEmpleadoServicio>().Use<EmpleadoServicio>();

                x.For<IUsuarioServicio>().Use<UsuarioServicio>();

                x.For<ISeguridadServicio>().Use<SeguridadServicio>();

                x.For<IConfiguracionServicio>().Use<ConfiguracionServicio>();

                x.For<IListaPrecioServicio>().Use<ListaPrecioServicio>();

                x.For<IRubroServicio>().Use<RubroServicio>();

                x.For<IMarcaServicio>().Use<MarcaServicio>();

                x.For<IArticuloServicio>().Use<ArticuloServicio>();

                x.For<IContadorServicio>().Use<ContadorServicio>();

                x.For<IPrecioServicio>().Use<PrecioServicio>();

                x.For<ICajaServicio>().Use<CajaServicio>();

                x.For<IFacturaServicio>().Use<FacturaServicio>();

                x.For<ICuentaCorrienteServicio>().Use<CuentaCorrienteServicio>();

                x.For<ICtaCteComprobanteServicio>().Use<CtaCteComprobanteServicio>();

                x.For<IComprobanteServicio>().Use<ComprobanteServicio>();

            });
        }
    }
}