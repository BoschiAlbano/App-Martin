using Aplicacion.Constantes;
using IServicio.Articulo;
using IServicio.Configuracion;
using IServicio.Configuracion.DTOs;
using IServicio.ListaPrecio;
using IServicio.Persona;
using IServicio.Persona.DTOs;
using IServicios.Articulo.DTOs;
using IServicios.Contador;
using Presentacion.Core.Cliente;
using Presentacion.Core.Comprobantes.Clases;
using Presentacion.Core.Empleado;
using PresentacionBase.Formularios;
using StructureMap;
using System;
using static Aplicacion.Constantes.Clases.ValidacionDatosEntrada;
using System.Linq;
using System.Windows.Forms;
using Presentacion.Core.Articulo;
using Presentacion.Core.FormaPago;
using IServicios.Factura;
using IServicios.Comprobante.DTOs;
using System.Runtime.InteropServices;
using Presentacion.Core.Reportes;
using IServicios.Factura.DTOs;
using System.Collections.Generic;

namespace Presentacion.Core.Comprobantes
{
    public partial class _00050_Venta : FormBase
    {
        private readonly IConfiguracionServicio _ConfiguracionServicio;
        private readonly IClienteServicio _ClienteServicio;
        private readonly IEmpleadoServicio _EmpleadoServicio;
        private readonly IListaPrecioServicio _ListaPrecioServicio;
        private readonly IContadorServicio _ContadorServicio;
        private readonly IArticuloServicio _ArticuloServicio;
        private readonly IFacturaServicio _FacturaServicio;


        private ClienteDto _ClienteSeleccionado;
        private ConfiguracionDto _Configuracion;
        private EmpleadoDto _VendedorSeleccionado;
        private FacturaView _Factura;
        private ArticuloVentaDto _ArticuloSeleccionado;
        private bool _PermitirIngresarCantidad;
        private bool _AutorizaPermisoListaPrecio;
        private bool _IngresoArticuloAlternativo;
        private bool _IngresoArticuloBascula;
        private ItemView _ItemSeleccionado;
        private bool _DatoAsignado;


        // PROYECTO MARTIN
        private bool _UnificarRenglores = true;

        public _00050_Venta(IConfiguracionServicio configuracionServicio
            , IClienteServicio clienteServicio, IEmpleadoServicio empleadoServicio
            , IListaPrecioServicio listaPrecioServicio
            , IContadorServicio contadorServicio, IArticuloServicio articuloServicio
            , IFacturaServicio facturaServicio)
        {
            InitializeComponent();

            //===============   Eliminar Parte de arriba del formulario   =======================
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            _ConfiguracionServicio = configuracionServicio;
            _ClienteServicio = clienteServicio;
            _EmpleadoServicio = empleadoServicio;
            _ListaPrecioServicio = listaPrecioServicio;
            _ContadorServicio = contadorServicio;
            _ArticuloServicio = articuloServicio;
            _FacturaServicio = facturaServicio;

            _Factura = new FacturaView();
            _VendedorSeleccionado = null;
            _ClienteSeleccionado = null;
            _Configuracion = _ConfiguracionServicio.Obtener();
            if (_Configuracion == null)
            {
                MessageBox.Show("Primero Debe Cargar una Configuracion");
                Close();
            }
            _ArticuloSeleccionado = null;
            _PermitirIngresarCantidad = false;
            _AutorizaPermisoListaPrecio = false;
            _IngresoArticuloAlternativo = false;
            _IngresoArticuloBascula = false;
            _ItemSeleccionado = null;
            _DatoAsignado = false;

            //AsignarEvento_EnterLeave(this);

            txtCodigo.KeyPress += delegate (object sender, KeyPressEventArgs args)
            {
                NoInyeccion(sender, args);
                NoLetras(sender, args);
            };
        }

        // Evento Load
        private void _00050_Venta_Load(object sender, System.EventArgs e)
        {
            txtCodigo.Focus();

            _PermitirIngresarCantidad = !_PermitirIngresarCantidad;
            nudCantidad.Enabled = _PermitirIngresarCantidad;

            CargarCabezera();

            CargarCuerpo();

            CargarPie();
        }

        private void CargarPie()
        {
            txtSubTotal.Text = _Factura.SubTotalStr;
            nudDescuento.Value = _Factura.Descuento;
            txtTotal.Text = _Factura.TotalStr;
        }
        private void CargarCuerpo()
        {
            dgvGrilla.DataSource = _Factura.Items.ToList();
            FormatearGrilla(dgvGrilla);

            var ultimoItem = _Factura.Items.LastOrDefault();

            if (ultimoItem == null)
            {
                lblDescripcion.Text = string.Empty;
                //lblPrecioPorCantidad.Text = string.Empty;
            }
            else
            {
                //lblDescripcion.Text = ultimoItem.Descripcion;
                //lblPrecioPorCantidad.Text = $"{ultimoItem.Cantidad.ToString("N3")} X {ultimoItem.Precio.ToString("N2")} = {ultimoItem.SubTotal.ToString("N2")}";
            }
        }
        private void CargarCabezera()
        {
            // Fecha
            lblFechaActual.Text = DateTime.Today.ToShortDateString();

            // Consumidor Final de la BD
            _ClienteSeleccionado = ObtenerConsumidorFinal();
            AsignarDatosCliente(_ClienteSeleccionado);

            //Vendedor
            var Vendedor = ObtenerVendedorPorDefecto();
            AsignarDatosVendedor(Vendedor);

        }

        // =====================================   Empleado/Vendedor   ==========================================0
        // Empleado / Vendedor
        private EmpleadoDto ObtenerVendedorPorDefecto()
        {
            if (Identidad.EmpleadoId == 0)// admin
            {
                return (EmpleadoDto)_EmpleadoServicio.Obtener(typeof(EmpleadoDto), string.Empty).FirstOrDefault();
            }
            else// Empleado
            {
                return (EmpleadoDto)_EmpleadoServicio.Obtener(typeof(EmpleadoDto), Identidad.EmpleadoId);
            }

        }
        private void AsignarDatosVendedor(PersonaDto vendedor)
        {
            _VendedorSeleccionado = (EmpleadoDto)vendedor;
        }

        // Consumidor Final
        private ClienteDto ObtenerConsumidorFinal()
        {
            return (ClienteDto)_ClienteServicio.Obtener(typeof(ClienteDto), 1);
        }
        private void AsignarDatosCliente(ClienteDto clienteDto)
        {
            //txtDniCliente.Text = clienteDto.Dni;
            txtTelefono.Text = clienteDto.Telefono;
            txtDomicilioCliente.Text = clienteDto.Direccion;
            txtNombreCliente.Text = clienteDto.ApyNom;

        }

        // Formatear Grilla
        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            dgv.Columns["CodigoBarra"].Visible = true;
            dgv.Columns["CodigoBarra"].Width = 100;
            dgv.Columns["CodigoBarra"].HeaderText = "Codigo";
            dgv.Columns["CodigoBarra"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv.Columns["Descripcion"].Visible = true;
            dgv.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["Descripcion"].HeaderText = @"Descripción";

            dgv.Columns["Cantidad"].Visible = true;
            dgv.Columns["Cantidad"].Width = 100;
            dgv.Columns["Cantidad"].HeaderText = "Cantidad";
            dgv.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv.Columns["PrecioStr"].Visible = true;
            dgv.Columns["PrecioStr"].Width = 130;
            dgv.Columns["PrecioStr"].HeaderText = "Precio";
            dgv.Columns["PrecioStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgv.Columns["SubTotalStr"].Visible = true;
            dgv.Columns["SubTotalStr"].Width = 130;
            dgv.Columns["SubTotalStr"].HeaderText = "Sub-Total";
            dgv.Columns["SubTotalStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        // Botones
        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            var fLookUpCliente = ObjectFactory.GetInstance<ClienteLookUp>();
            fLookUpCliente.ShowDialog();

            if ((ClienteDto)fLookUpCliente.EntidadSeleccionada != null)
            {
                _ClienteSeleccionado = (ClienteDto)fLookUpCliente.EntidadSeleccionada;
                AsignarDatosCliente((ClienteDto)fLookUpCliente.EntidadSeleccionada);
            }
            else
            {
                AsignarDatosCliente(ObtenerConsumidorFinal());
                _ClienteSeleccionado = ObtenerConsumidorFinal();
            }

        }
        private void btnBuscarVendedor_Click(object sender, EventArgs e)
        {
            var fLookUpCliente = ObjectFactory.GetInstance<EmpleadoLookUp>();
            fLookUpCliente.ShowDialog();

            if ((EmpleadoDto)fLookUpCliente.EntidadSeleccionada != null)
            {
                _VendedorSeleccionado = (EmpleadoDto)fLookUpCliente.EntidadSeleccionada;
                AsignarDatosVendedor((EmpleadoDto)fLookUpCliente.EntidadSeleccionada);
            }
            else
            {
                AsignarDatosVendedor(ObtenerVendedorPorDefecto());
            }
        }

        // =====================================   Items   ==========================================0

        #region Eventos
        
        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodigo.Text))
                return;

            if (e.KeyChar == (char)Keys.Enter)
            {
                BuscarArticulo(txtCodigo.Text); // Obtengo el Articulo que busco (alternativo - normal)

                if (_ArticuloSeleccionado == null) 
                {
                    MessageBox.Show("Codigo del Articulo No Encontrado");
                    LimpiarParaNuevoItem();
                    return;
                }

                txtDescripcion.Text = _ArticuloSeleccionado.Descripcion;
                txtPrecioUnitario.Text = _ArticuloSeleccionado.PrecioStr;

                if (_PermitirIngresarCantidad)
                {
                    // Paso al nud Cantidad
                    nudCantidad.Focus();
                    nudCantidad.Select(0, nudCantidad.Value.ToString().Length);
                }
                else
                {
                    // Agrego el Articulo
                    btnAgregar.PerformClick();
                    LimpiarParaNuevoItem();
                }
                
            }

            //e.Handled = true;

        }
        private void txtCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 116) // F5
            {
                //ArticuloNormal(txtCodigo.Text, _Configuracion.DepositoId, (long)cmbListaPrecio.SelectedValue);

                _PermitirIngresarCantidad = !_PermitirIngresarCantidad;
                nudCantidad.Enabled = _PermitirIngresarCantidad;
                
                //nudCantidad.Focus();
                //nudCantidad.Select(0, nudCantidad.Value.ToString().Length);
                return;
            }
            if (e.KeyValue == 119) // F8
            {
                var LookUpArticulo = new ArticuloLookUp();
                LookUpArticulo.ShowDialog();

                if (LookUpArticulo.EntidadSeleccionada != null)
                {
                    _ArticuloSeleccionado = (ArticuloVentaDto)LookUpArticulo.EntidadSeleccionada;

                    if (_PermitirIngresarCantidad)
                    {
                        txtCodigo.Text = _ArticuloSeleccionado.CodigoBarra;
                        txtDescripcion.Text = _ArticuloSeleccionado.Descripcion;
                        txtPrecioUnitario.Text = _ArticuloSeleccionado.PrecioStr;
                        nudCantidad.Focus();

                        nudCantidad.Select(0, nudCantidad.Value.ToString().Length);
                        return;
                    }
                    else
                    {
                        btnAgregar.PerformClick();
                        LimpiarParaNuevoItem();
                    }
                }
                else
                {
                    LimpiarParaNuevoItem();
                }
            }
            if (e.KeyValue == 120) //f9
            {
                var fLookUpCliente = ObjectFactory.GetInstance<ClienteLookUp>();
                fLookUpCliente.ShowDialog();

                if ((ClienteDto)fLookUpCliente.EntidadSeleccionada != null)
                {
                    _ClienteSeleccionado = (ClienteDto)fLookUpCliente.EntidadSeleccionada;
                    AsignarDatosCliente((ClienteDto)fLookUpCliente.EntidadSeleccionada);
                }
                else
                {
                    AsignarDatosCliente(ObtenerConsumidorFinal());
                    _ClienteSeleccionado = ObtenerConsumidorFinal();
                }
            }

        }
        private void nudCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnAgregar.PerformClick();
                LimpiarParaNuevoItem();
            }
        }
        private void nudDescuento_ValueChanged(object sender, EventArgs e)
        {
            _Factura.Descuento = nudDescuento.Value;
            CargarPie();
        }
        private void dgvGrilla_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGrilla.RowCount > 0)
            {
                _ItemSeleccionado = (ItemView)dgvGrilla.Rows[e.RowIndex].DataBoundItem;
            }
            else
            {
                _ItemSeleccionado = null;
            }

        }
        private void dgvGrilla_DoubleClick(object sender, EventArgs e)
        {
            if (dgvGrilla.RowCount <= 0) return;
            if (_ItemSeleccionado.IngresoPorBascula)
            {
                MessageBox.Show("Los Articulos Ingresados Por Basculas No Pueden Modificarse");
                return;
            }

            // Cantidad de articulo en  lista
            decimal Cantidad = _ItemSeleccionado.Cantidad;

            // Cusco el art original
            var ArticuloCambioCantidad = _ArticuloServicio.ObtenerPorCodigo(_ItemSeleccionado.CodigoBarra);
            // remplazo el precio por si es que es alternativo
            ArticuloCambioCantidad.Precio = _ItemSeleccionado.Precio;

            // abro el formulario cambiar cantidad
            var fCambiarCantidad = new CambiarCantidadItems(_ItemSeleccionado.Descripcion, _ItemSeleccionado.Cantidad);
            fCambiarCantidad.ShowDialog();


            if (!fCambiarCantidad.RealizoAlgunaOperacion)
            {
                return;
            }

            nudCantidad.Value = fCambiarCantidad.CantidadNueva;

            if (fCambiarCantidad.CantidadNueva > 0)
            {
                // si cambie la cantidad
                var CantidadTotalenLista = _Factura.Items.Where(x => x.ArticuloId == _ItemSeleccionado.ArticuloId && x.Precio != _ItemSeleccionado.Precio).Sum(x => x.Cantidad);

                if (!ArticuloCambioCantidad.PermiteStockNegativo)
                {
                    if (ArticuloCambioCantidad.Stock < (fCambiarCantidad.CantidadNueva + CantidadTotalenLista))//  8 >= 15
                    {
                        MessageBox.Show("No hay Stock");
                        return;
                    }
                }
                
                
                _Factura.Items.Remove(_ItemSeleccionado);

                // unifica mal Por eso las variables.
                _IngresoArticuloAlternativo = _ItemSeleccionado.EsArticuloAlternativo;
                _IngresoArticuloBascula = _ItemSeleccionado.IngresoPorBascula;

                AgregarItem(ArticuloCambioCantidad, fCambiarCantidad.CantidadNueva);
                /*
                if (!AgregarItem(ArticuloCambioCantidad, (long)cmbListaPrecio.SelectedValue, fCambiarCantidad.CantidadNueva))
                {
                    // respaldo
                    _ItemSeleccionado.Cantidad = Cantidad;
                    _Factura.Items.Add(_ItemSeleccionado);
                }
                */
            }

            CargarCuerpo();
            CargarPie();
            LimpiarParaNuevoItem();
        }
        #endregion

        #region Buscar Articulo (Bascula, Normal, Alternativo)

        // Metodos Privados (Busqueda del Articulo)
        private void BuscarArticulo(string codigo) 
        {
            // Codigo *
            if (txtCodigo.Text.Contains("*")) // ARTICULO CON PRECIO ALTERNATIVO => CODIGO * PRECIO
            {
                _IngresoArticuloAlternativo = ArticuloAlternativo(codigo);
                return;
            }else if (txtCodigo.Text.Contains("%")) // ARTICULO CON PRECIO ALTERNATIVO => CODIGO % PRECIO
            {
                _IngresoArticuloAlternativo = ArticuloAlternativoPortcentaje(codigo);
                return;
            }

            // Codigo Normal
            ArticuloNormal(txtCodigo.Text);

        }
        private void ArticuloNormal(string codigo)
        {
            _ArticuloSeleccionado = _ArticuloServicio.ObtenerPorCodigo(codigo);
        }
        private bool ArticuloAlternativo(string codigoArticulo)
        {

            if (codigoArticulo.Length < 3)
                return false;

            // sacamos el Codigo (Antes del *)
            var codigo = codigoArticulo.Substring(0, codigoArticulo.IndexOf('*'));
            // sacamos el PrecioAlternativo
            var precioAlternativo = codigoArticulo.Substring(codigoArticulo.IndexOf('*') + 1);

            if (!string.IsNullOrEmpty(codigo))
            {
                _ArticuloSeleccionado = _ArticuloServicio.ObtenerPorCodigo(codigo);

                if (_ArticuloSeleccionado != null)
                {
                    if (!string.IsNullOrEmpty(precioAlternativo))
                    {
                        if (decimal.TryParse(precioAlternativo, out decimal NuevoPrecio))
                        {
                            _ArticuloSeleccionado.Precio = NuevoPrecio;
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Error, Precio Alternativo no Asignado Correctamente.");
                            _ArticuloSeleccionado = null;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error, Precio Alternativo no Asignado Correctamente.");
                    }

                }
                else
                {
                    MessageBox.Show("Error, Articulo No encontrado");
                }

            }
            else
            {
                MessageBox.Show("Error, Falta Codigo del Producto");
            }

            return false;
        }
        private bool ArticuloAlternativoPortcentaje(string codigoArticulo)
        {

            if (codigoArticulo.Length < 3)
                return false;

            // sacamos el Codigo (Antes del %)
            var codigo = codigoArticulo.Substring(0, codigoArticulo.IndexOf('%'));
            // sacamos el PrecioAlternativo
            var precioAlternativo = codigoArticulo.Substring(codigoArticulo.IndexOf('%') + 1);

            if (!string.IsNullOrEmpty(codigo))
            {
                _ArticuloSeleccionado = _ArticuloServicio.ObtenerPorCodigo(codigo);

                if (_ArticuloSeleccionado != null)
                {
                    if (!string.IsNullOrEmpty(precioAlternativo))
                    {
                        if (decimal.TryParse(precioAlternativo, out decimal NuevoPrecio))
                        {
                            _ArticuloSeleccionado.Precio -= (_ArticuloSeleccionado.Precio * (NuevoPrecio / 100));
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Error, Precio Alternativo no Asignado Correctamente.");
                            _ArticuloSeleccionado = null;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error, Precio Alternativo no Asignado Correctamente.");
                    }

                }
                else
                {
                    MessageBox.Show("Error, Articulo No encontrado");
                }

            }
            else
            {
                MessageBox.Show("Error, Falta Codigo del Producto");
            }

            return false;
        }
        #endregion

        #region Botones

        // Botones
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show($"Desea Cancelar la Venta", "Atención"
                    , MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                _Factura = new FacturaView();

                CargarCabezera();
                CargarCuerpo();
                CargarPie();
                LimpiarParaNuevoItem();
            }
        }
        private void btnPresupuesto_Click(object sender, EventArgs e)
        {
            MessageBox.Show("El Presupuesto");
        }
        private void btnEliminarItem_Click(object sender, EventArgs e)
        {
            if (dgvGrilla.Rows.Count <= 0) return;

            if (MessageBox.Show($"Desea Eliminar el Item {_ItemSeleccionado.Descripcion}", "Atención"
                , MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                _Factura.Items.Remove(_ItemSeleccionado);
              
                CargarCuerpo();
                CargarPie();
                LimpiarParaNuevoItem();
            }
        }
        #endregion

        #region Agregar Items a La Factura

        //Boton
        private void btnAgregar_Click(object sender, EventArgs e)
        {

            if (_ArticuloSeleccionado == null) 
            {
                MessageBox.Show("Primero Busque un articulo");
                return;
            }

            AgregarItem(_ArticuloSeleccionado, (int)nudCantidad.Value);

        }
        
        // Metodo Privados (Agregar Datos a la Grilla)
        private bool AgregarItem(ArticuloVentaDto articulo, int cantidad)
        {
            //=======================    Logicas de Negocio   ==========================

            // Limite de venta
            if (articulo.TieneRestriccionPorCantidad)
            {
                var totalArticulosItems = _Factura.Items
                    .Where(c => c.ArticuloId == articulo.Id)
                    .Sum(x => x.Cantidad);

                if ((cantidad + totalArticulosItems) > articulo.Limite)
                {
                    var MensajeLimiteVenta = ($"El Articulo {articulo.Descripcion.ToUpper()} Tiene una Restriccion"
                        + Environment.NewLine
                        + $"de Venta por una cantidad Maxima de {articulo.Limite}");

                    MessageBox.Show(MensajeLimiteVenta, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }


            }

            // Horario
            if (articulo.TieneRestriccionHorario)
            {
                if (VerifivarLimiteHoraVenta(articulo.HoraDesde, articulo.HoraHasta)) 
                {
                    var MensajeLimiteHora = ($"El Articulo {articulo.Descripcion.ToUpper()} Tiene una Restriccion"
                        + Environment.NewLine
                        + $"de Venta por Horario entre {articulo.HoraDesde.ToShortTimeString()} hasta {articulo.HoraHasta.ToShortTimeString()}");

                    MessageBox.Show(MensajeLimiteHora, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }
            }

            // Stock
            
            if (!articulo.PermiteStockNegativo && !VerificarStock(articulo,nudCantidad.Value))
            {
                var MensajeStock = ($"No hay Stock suficiente para el Articulo {articulo.Descripcion.ToUpper()}"
                        + Environment.NewLine
                        + $"Stock actual Disponible: {articulo.Stock}.");

                MessageBox.Show(MensajeStock, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            if (articulo.PermiteStockNegativo)
            {
                lblDescripcion.BackColor = System.Drawing.Color.FromArgb(128, 255, 128);
                lblDescripcion.Text = articulo.Descripcion + " Permite Stock Negativo ";
            }
            // si unificamos los articulos o no
            if (_IngresoArticuloAlternativo || _IngresoArticuloBascula)
            {
                AsignarDatosItems(articulo,cantidad);
            }
            else
            {
                if (_UnificarRenglores)
                {
                    // Error: ingreso primero con bascula y depues normal se aumenta la cantidad
                    // Error: si cambio la cantidad 
                    var ItemDelCuerpo = _Factura.Items.FirstOrDefault(x => x.ArticuloId == articulo.Id && x.IngresoPorBascula == false && x.EsArticuloAlternativo == false);

                    if (ItemDelCuerpo == null)
                    {
                        AsignarDatosItems(articulo, cantidad);
                    }
                    else
                    {
                        ItemDelCuerpo.Cantidad += cantidad;

                        //lblDescripcion.Text = ItemDelCuerpo.Descripcion;
                        //lblPrecioPorCantidad.Text = $"{ItemDelCuerpo.Cantidad.ToString("N3")} X {ItemDelCuerpo.Precio.ToString("N2")} = {ItemDelCuerpo.SubTotal.ToString("N2")}";
                        
                        dgvGrilla.DataSource = _Factura.Items.ToList();
                        FormatearGrilla(dgvGrilla);
                        CargarPie();
                    }

                }
                else
                {
                    AsignarDatosItems(articulo, cantidad);
                }
            }

            return true;
        }
        private bool VerificarStock(ArticuloVentaDto articulo, decimal cantidad)
        {
            var totalArticulosItems = _Factura.Items
                    .Where(c => c.ArticuloId == articulo.Id)
                    .Sum(x => x.Cantidad);


            if ((totalArticulosItems + cantidad) <= articulo.Stock)// si hay stock
            {

                if ((articulo.Stock - (totalArticulosItems + cantidad)) < articulo.StockMinimo) // si es menor o no al stosk minimo
                {
                    lblDescripcion.BackColor = System.Drawing.Color.FromArgb(255, 128, 128);
                }
                else
                {
                    lblDescripcion.BackColor = System.Drawing.Color.FromArgb(128, 255, 128);
                }

                lblDescripcion.Text = articulo.Descripcion + " Tiene un Stock Minimo de " + Math.Round(articulo.StockMinimo,0) + " Unidades, Stock Actual " + (articulo.Stock - (totalArticulosItems + cantidad));
                return true;
            }
            else// no hay stock
            {

                return false;
            }

            

        }
        private bool VerifivarLimiteHoraVenta(DateTime horaDesde, DateTime horaHasta)
        {
            var _horaDesdeSistena = DateTime.Now.Hour;
            var _minutoDesdeSistema = DateTime.Now.Minute;

            if (horaDesde <= horaHasta) // Mismo Dia
            {
                if (_horaDesdeSistena >= horaDesde.Hour && _minutoDesdeSistema >= horaDesde.Minute)
                {
                    if (_horaDesdeSistena < horaHasta.Hour)
                    {
                        return true;
                    }
                    else if (_horaDesdeSistena == horaHasta.Hour && _minutoDesdeSistema <= horaHasta.Minute)
                    {
                        return true;
                    }
                }

            }
            else // Dias Diferentes -> Ej: 11:00 PM hasta 06:00 AM
            {
                if (_horaDesdeSistena >= horaDesde.Hour)
                {
                    // Rango 1 hasta fin del dia
                    return _horaDesdeSistena >= horaDesde.Hour
                           && _minutoDesdeSistema >= horaDesde.Minute
                           && _horaDesdeSistena <= 23
                           && _minutoDesdeSistema <= 59;
                }
                else
                {
                    // Rango 2 desde el inicio de dia

                    if (_horaDesdeSistena >= 0 && _minutoDesdeSistema >= 0)
                    {
                        if (_horaDesdeSistena < horaHasta.Hour)
                        {
                            return true;
                        }
                        else if (_horaDesdeSistena == horaHasta.Hour &&_minutoDesdeSistema <= horaHasta.Minute)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
        private void AsignarDatosItems(ArticuloVentaDto articulo, int cantidad)
        {
            _Factura.ContadorItems++;
            _Factura.Items.Add(new ItemView
            {
                Id = _Factura.ContadorItems,
                ArticuloId = articulo.Id,
                Cantidad = cantidad,
                Precio = articulo.Precio,
                Descripcion = articulo.Descripcion,
                CodigoBarra = articulo.CodigoBarra,
                Iva = articulo.Iva,
                EsArticuloAlternativo = _IngresoArticuloAlternativo,
                IngresoPorBascula = _IngresoArticuloBascula,
            });

            CargarCuerpo();
            CargarPie();
            LimpiarParaNuevoItem();
        }
        private void LimpiarParaNuevoItem()
        {
            txtCodigo.Clear();
            txtDescripcion.Clear();
            txtPrecioUnitario.Clear();

            nudCantidad.Value = 1;
            //nudCantidad.Enabled = true;
            //_PermitirIngresarCantidad = true;

            _IngresoArticuloAlternativo = false;
            _IngresoArticuloBascula = false;
            _ArticuloSeleccionado = null;

            _DatoAsignado = false;
            txtCodigo.Focus();

            
        }
        #endregion

        #region Facturar

        private void btnFacturar_Click(object sender, EventArgs e)
        {

            if (_Factura.Total == 0)
            {
                MessageBox.Show("Primero Cargue Items en la factura");
                return;
            }

            _Factura.Cliente = _ClienteSeleccionado;
            _Factura.Vendedor = _VendedorSeleccionado;
            _Factura.UsuarioId = Identidad.UsuarioId;
            
            if (_Configuracion.PuestoCajaSeparado)
            {
                // Factura en estado Pendiente
                try
                {
                    var NuevoComprobante = new FacturaDto
                    {
                        EmpleadoId = _Factura.Vendedor.Id,
                        TipoComprobante = _Factura.TipoComprobante,
                        Fecha = DateTime.Now,
                        Descuento = _Factura.Descuento,
                        SubTotal = _Factura.SubTotal,
                        Iva105 = 0,
                        Iva21 = 0,
                        Total = _Factura.Total,
                        UsuarioId = _Factura.UsuarioId,
                        ClienteId = _Factura.Cliente.Id,
                        Estado = Estado.Pendiente,
                        PuestoTrabajoId = _Factura.PuntoVentaId,
                        VieneVentas = true,
                        Eliminado = false,
                    };

                    foreach (var item in _Factura.Items)
                    {
                        NuevoComprobante.Items.Add(new DetalleComprobanteDto
                        {
                            Cantidad = item.Cantidad,
                            Precio = item.Precio,
                            Descripcion = item.Descripcion,
                            SubTotal = item.SubTotal,
                            Iva = item.Iva,
                            ArticuloId = item.ArticuloId,
                            Codigo = item.CodigoBarra,
                            Eliminado = false

                        });

                    }

                    NuevoComprobante.Numero = (int)_FacturaServicio.Insertar(NuevoComprobante);

                    // Imprimir Factura
                    List<ReporteFacturaDto> Reporte = new List<ReporteFacturaDto>();

                    foreach (var item in NuevoComprobante.Items)
                    {
                        Reporte.Add(new ReporteFacturaDto
                        {
                            Numero = NuevoComprobante.Numero,
                            Fecha = NuevoComprobante.Fecha,

                            NombreCliente = _ClienteSeleccionado.ApyNom,
                            Direccion = _ClienteSeleccionado.Direccion,
                            Telefono = _ClienteSeleccionado.Telefono,

                            NombreVendedor = _VendedorSeleccionado.ApyNom,
                            DireccionVendedor = _VendedorSeleccionado.Direccion,
                            TelefonoVendedor = _Configuracion.Telefono,
                            CelularVendedor = _Configuracion.Celular,


                            FacturaSubtotal = Math.Round(NuevoComprobante.SubTotal, 2),
                            FacturaDescuento = Math.Round(NuevoComprobante.Descuento, 2),
                            FacturaTotal = Math.Round(NuevoComprobante.Total, 2),

                            Codigo = item.Codigo,
                            Descripcion = item.Descripcion,
                            Precio = item.Precio,
                            Cantidad = item.Cantidad,
                        });
                    }

                    // Inprimir Factura Estado Pendiente de pago
                    new ReporteFactura(Reporte).ShowDialog();

                    MessageBox.Show("Los Datos se Grabaron Correctamente");

                    LimpiarParaNuevaFactura();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }

            }
            else
            {
                // Forma de pago
                var fFacturar = new _00044_FormaPago(_Factura);
                fFacturar.ShowDialog();

                if (fFacturar.RealizoVenta)
                {

                    // imprimo factura


                    LimpiarParaNuevaFactura();
                    txtCodigo.Focus();

                    

                }
            }


        }
        private void LimpiarParaNuevaFactura()
        {
            LimpiarParaNuevoItem();

            _Factura = new FacturaView();
            
            CargarCabezera();
            CargarCuerpo();
            CargarPie();
        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {

        }

        #endregion


        //Drag Form (Para sacar (x,minimizar y maximizar de windows))
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        // Evento Para Mover La pantalla 
        private void menuStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        #region BOTONES (X,minimizar y maximizar)
        private void IconoMaximizar_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }

        private void IconoSalir_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        private void IconoOcultar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        #endregion
    }
}