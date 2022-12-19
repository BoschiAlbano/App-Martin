using Aplicacion.Constantes;
using IServicio.Configuracion;
using IServicio.Persona.DTOs;
using IServicios.Banco;
using IServicios.Comprobante.DTOs;
using IServicios.CuentaCorriente;
using IServicios.Factura;
using IServicios.Factura.DTOs;
using IServicios.Tarjeta;
using Presentacion.Core.Cliente;
using Presentacion.Core.Comprobantes.Clases;
using Presentacion.Core.FormaPago.Clases;
using Presentacion.Core.Reportes;
using PresentacionBase.Formularios;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Presentacion.Core.FormaPago
{
    public partial class _00044_FormaPago : FormBase
    {
        private FacturaView _factura;
        private bool _vieneDeVentas;
        //private readonly IBancoServicio _bancoServicio;
        //private readonly ITarjetaServicio _tarjetaServicio;
        private readonly IFacturaServicio _facturaServicio;
        private ComprobantePenPagoDto _FacturaPendiente;
        private readonly ICuentaCorrienteServicio _CuentaCorrienteServicio;
        private readonly IConfiguracionServicio _ConfiguracionServicio;

        public bool RealizoVenta { get; set; } = false;
        public _00044_FormaPago()
        {
            InitializeComponent();

            //===============   Eliminar Parte de arriba del formulario   =======================
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            
            _facturaServicio = ObjectFactory.GetInstance<IFacturaServicio>();
            _CuentaCorrienteServicio = ObjectFactory.GetInstance<ICuentaCorrienteServicio>();
            _ConfiguracionServicio = ObjectFactory.GetInstance<IConfiguracionServicio>();
        }

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

        public _00044_FormaPago(FacturaView factura)
        : this() // Constructor sin parametros
        {
            _factura = factura;
            _vieneDeVentas = true;
            CargarDatos(_factura);
        }

        public _00044_FormaPago(ComprobantePenPagoDto factura)
        : this() // Constructor sin parametros
        {
            _FacturaPendiente = factura;
            _vieneDeVentas = false;
            CargarDatos(factura);
        }

        private void _00044_FormaPago_Load(object sender, EventArgs e)
        {
            //InstalledPrintersCombo();

        }

        private void CargarDatos(ComprobantePenPagoDto factura) 
        {
            txtTotalAbonar.Text = factura.MontoStr;
            nudMontoEfectivo.Value = factura.Monto;

            nudMontoCtaCte.Value = 0;
            txtApellidoyNombre.Text = factura.Cliente.ApyNom;
            //txtDni.Text = factura.Cliente.Dni;
            txtTelefono.Text = factura.Cliente.Telefono;
            txtDireccion.Text = factura.Cliente.Direccion;

            if (factura.Cliente.Dni != "99999999")
            {
                txtMontoAdeudado.Text = _CuentaCorrienteServicio.ObtenerDeudaCliente(factura.Cliente.Id).ToString("C", new CultureInfo("es-Ar"));
            }
            else
            {
                txtMontoAdeudado.Text = 0.ToString("C", new CultureInfo("es-Ar"));
            }
        }
        private void CargarDatos(FacturaView factura)
        {
            txtTotalAbonar.Text = factura.TotalStr;
            nudMontoEfectivo.Value = factura.Total;

            nudMontoCtaCte.Value = 0;
            txtApellidoyNombre.Text = factura.Cliente.ApyNom;
            //txtDni.Text = factura.Cliente.Dni;
            txtTelefono.Text = factura.Cliente.Telefono;
            txtDireccion.Text = factura.Cliente.Direccion;

            if (factura.Cliente.Dni != "99999999")
            {
                txtMontoAdeudado.Text = _CuentaCorrienteServicio.ObtenerDeudaCliente(factura.Cliente.Id).ToString("C", new CultureInfo("es-Ar"));
            }
            else
            {
                txtMontoAdeudado.Text = 0.ToString("C", new CultureInfo("es-Ar"));
            }

        }

        private void nudMontoEfectivo_ValueChanged(object sender, EventArgs e)
        {
            nudTotalEfectivo.Value = nudMontoEfectivo.Value;

            if (_vieneDeVentas)
            {
                //_factura
                if (_factura.Total >= nudMontoEfectivo.Value)
                {
                    nudMontoCtaCte.Value = _factura.Total - nudMontoEfectivo.Value;
                }
                else
                {
                    nudMontoEfectivo.Value = _factura.Total;
                }
            }
            else
            {
                //_FacturaPendiente
                if (_FacturaPendiente.Monto >= nudMontoEfectivo.Value)
                {
                    nudMontoCtaCte.Value = _FacturaPendiente.Monto - nudMontoEfectivo.Value;
                }
                else
                {
                    nudMontoEfectivo.Value = _FacturaPendiente.Monto;
                }
            }
        }
        private void nudMontoTarjeta_ValueChanged(object sender, EventArgs e)
        {
        }
        private void nudMontoCheque_ValueChanged(object sender, EventArgs e)
        {
        }
        private void nudMontoCtaCte_ValueChanged(object sender, EventArgs e)
        {
            nudTotalCtaCte.Value = nudMontoCtaCte.Value;

            if (_vieneDeVentas)
            {
                //_factura
                if (_factura.Total >= nudMontoCtaCte.Value)
                {
                    nudMontoEfectivo.Value = _factura.Total - nudMontoCtaCte.Value;
                }
                else
                {
                    nudMontoCtaCte.Value = _factura.Total;
                }
            }
            else
            {
                //_FacturaPendiente
                if (_FacturaPendiente.Monto >= nudMontoCtaCte.Value)
                {
                    nudMontoEfectivo.Value = _FacturaPendiente.Monto - nudMontoCtaCte.Value;
                }
                else
                {
                    nudMontoCtaCte.Value = _FacturaPendiente.Monto;
                }
            }

        }
        private void nudTotalEfectivo_ValueChanged(object sender, EventArgs e)
        {
            nudTotal.Value = +nudTotalEfectivo.Value
           + nudTotalCtaCte.Value;
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            var fLookUpCliente = ObjectFactory.GetInstance<ClienteLookUp>();
            fLookUpCliente.ShowDialog();
            if (fLookUpCliente.EntidadSeleccionada != null)
            {
                var _cliente = (ClienteDto)fLookUpCliente.EntidadSeleccionada;
                if (_cliente.ActivarCtaCte)
                {
                    txtApellidoyNombre.Text = _cliente.ApyNom;
                    //txtDni.Text = _cliente.Dni;
                    txtTelefono.Text = _cliente.Telefono;
                    txtDireccion.Text = _cliente.Direccion;

                    if (_cliente.Dni != "99999999")
                    {
                        txtMontoAdeudado.Text = _CuentaCorrienteServicio.ObtenerDeudaCliente(_cliente.Id).ToString("C", new CultureInfo("es-Ar"));
                    }
                    else
                    {
                        txtMontoAdeudado.Text = 0.ToString("C", new CultureInfo("es-Ar"));
                    }

                    if (_vieneDeVentas)
                    {
                        _factura.Cliente = _cliente;
                    }
                    else
                    {
                        _FacturaPendiente.Cliente = _cliente;
                    }
                }
                else
                {
                    MessageBox.Show($"El cliente {_cliente.ApyNom} no tiene Activa la Cuenta Corriente", "Atención"
                        ,MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void nudPagaCon_ValueChanged(object sender, EventArgs e)
        {
            CalcularVuelto();
        }
        private void CalcularVuelto()
        {
        }
        private void nudTotal_ValueChanged(object sender, EventArgs e)
        {
            if (_vieneDeVentas)
            {
                nudTotal.BackColor = _factura.Total > nudTotal.Value
                    ? System.Drawing.Color.FromArgb(255, 192, 192)
                    : System.Drawing.Color.FromArgb(192, 255, 192);
            }
            else 
            {
                nudTotal.BackColor = _FacturaPendiente.Monto > nudTotal.Value
                    ? System.Drawing.Color.FromArgb(255, 192, 192)
                    : System.Drawing.Color.FromArgb(192, 255, 192);
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            RealizoVenta = false;
            Close();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            var DtosEmpresa = _ConfiguracionServicio.ObtenerDatosEmpresa();
            try
            {

                #region Logicas  de Negocio
                if (_vieneDeVentas)
                {
                    if (nudTotal.Value > _factura.Total)
                    {
                        if (MessageBox.Show("El total que esta por abonar es superior al monto a pagar. Desea continuar ? ",

                        "Atención", MessageBoxButtons.OKCancel,
                       MessageBoxIcon.Question)
                        == DialogResult.Cancel)
                        {
                            return;
                        }
                    }
                    else if (nudTotal.Value < _factura.Total)
                    {
                        MessageBox.Show("El total que esta por abonar es inferior al monto a pagar",

                        "Atención", MessageBoxButtons.OK,
                       MessageBoxIcon.Information);
                        return;
                    }
                }
                else
                {
                    if (nudTotal.Value > _FacturaPendiente.Monto)
                    {
                        if (MessageBox.Show("El total que esta por abonar es superior al monto a pagar. Desea continuar ? ",

                        "Atención", MessageBoxButtons.OKCancel,
                       MessageBoxIcon.Question)
                        == DialogResult.Cancel)
                        {
                            return;
                        }
                    }
                    else if (nudTotal.Value < _FacturaPendiente.Monto)
                    {
                        MessageBox.Show("El total que esta por abonar es inferior al monto a pagar",

                        "Atención", MessageBoxButtons.OK,
                       MessageBoxIcon.Information);
                        return;
                    }
                }
                
                #endregion

                #region Nueva Factura

                var _facturaNueva = new FacturaDto();

                if (_vieneDeVentas)
                {
                    _facturaNueva.EmpleadoId = _factura.Vendedor.Id;
                    _facturaNueva.ClienteId = _factura.Cliente.Id;
                    _facturaNueva.TipoComprobante = _factura.TipoComprobante;
                    _facturaNueva.Descuento = _factura.Descuento;
                    _facturaNueva.SubTotal = _factura.SubTotal;
                    _facturaNueva.Total = _factura.Total;
                    _facturaNueva.Estado = Estado.Pagada;
                    _facturaNueva.PuestoTrabajoId = _factura.PuntoVentaId;
                    _facturaNueva.Fecha = DateTime.Now;
                    _facturaNueva.Iva105 = 0;
                    _facturaNueva.Iva21 = 0;
                    _facturaNueva.UsuarioId = _factura.UsuarioId;
                    _facturaNueva.VieneVentas = true;// ------------------

                    foreach (var item in _factura.Items)
                    {
                        _facturaNueva.Items.Add(new DetalleComprobanteDto
                        {
                            Cantidad = item.Cantidad,
                            Iva = item.Iva,
                            Descripcion = item.Descripcion,
                            Precio = item.Precio,
                            ArticuloId = item.ArticuloId,
                            Codigo = item.CodigoBarra,
                            SubTotal = item.SubTotal,
                            Eliminado = false,
                            Dto = item.Dto
                        });
                    }
                }
                else
                {
                    _facturaNueva.Id = _FacturaPendiente.Id;
                    _facturaNueva.Estado = Estado.Pendiente;
                    _facturaNueva.VieneVentas = false;
                    _facturaNueva.TipoComprobante = _FacturaPendiente.TipoComprobante;
                    _facturaNueva.UsuarioId = Identidad.UsuarioId;
                    _facturaNueva.Fecha = DateTime.Now;
                    _facturaNueva.Total = _FacturaPendiente.Monto;
                    _facturaNueva.VieneVentas = false;// ------------------
                    _facturaNueva.ClienteId = _FacturaPendiente.Cliente.Id;
                }
                #endregion

                #region Formas de Pago de la Factura

                //  *** Efectivo ***
                if (nudTotalEfectivo.Value > 0)
                {
                    _facturaNueva.Efectivo = nudTotalEfectivo.Value;
                }
                //  *** Cuenta Corriente ***
                if (nudTotalCtaCte.Value > 0) 
                {

                    if (_vieneDeVentas) 
                    {
                        
                        if (_factura.Cliente.ActivarCtaCte)
                        {
                            // Deuda del Cliente
                            decimal Deuda;

                            if (_vieneDeVentas)
                            {
                                Deuda = _CuentaCorrienteServicio.ObtenerDeudaCliente(_factura.Cliente.Id);
                            }
                            else
                            {
                                Deuda = _CuentaCorrienteServicio.ObtenerDeudaCliente(_FacturaPendiente.Cliente.Id);
                            }

                            if (_factura.Cliente.TieneLimiteCompra && _factura.Cliente.MontoMaximoCtaCte < Deuda + nudTotalCtaCte.Value)
                            {
                                var menssajeCtaCte = $"El cliente {_factura.Cliente.ApyNom} esta por arriba del limite Permitido."
                                    + Environment.NewLine
                                    + $" El limite es { _factura.Cliente.MontoMaximoCtaCte.ToString("C", new CultureInfo("es-Ar"))}";

                                MessageBox.Show(menssajeCtaCte, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                return;
                            }
                            _facturaNueva.CuentaCorriente = nudTotalCtaCte.Value;

                        }
                        else 
                        {
                            var menssajeCtaCte = $"El cliente {_factura.Cliente.ApyNom} No tiene Activa la cuenta corriente."
                                    + Environment.NewLine
                                    + $"Por favor ingrese otro cliente o cambie su configuracion";

                            MessageBox.Show(menssajeCtaCte, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }

                    }
                    else // Si viene de Pendiente
                    {
                        if (_FacturaPendiente.Cliente.ActivarCtaCte)
                        {

                            // Deuda del Cliente
                            decimal Deuda;

                            if (_vieneDeVentas)
                            {
                                Deuda = _CuentaCorrienteServicio.ObtenerDeudaCliente(_factura.Cliente.Id);
                            }
                            else
                            {
                                Deuda = _CuentaCorrienteServicio.ObtenerDeudaCliente(_FacturaPendiente.Cliente.Id);
                            }

                            if (_FacturaPendiente.Cliente.TieneLimiteCompra && _FacturaPendiente.Cliente.MontoMaximoCtaCte < Deuda + nudTotalCtaCte.Value)
                            {
                                var menssajeCtaCte = $"El cliente {_FacturaPendiente.Cliente.ApyNom} esta por arriba del limite Permitido."
                                    + Environment.NewLine
                                    + $" El limite es { _FacturaPendiente.Cliente.MontoMaximoCtaCte.ToString("C", new CultureInfo("es-Ar"))}";

                                MessageBox.Show(menssajeCtaCte, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                return;
                            }

                            _facturaNueva.CuentaCorriente = nudMontoCtaCte.Value;

                        }
                        else
                        {
                            var menssajeCtaCte = $"El cliente {_FacturaPendiente.Cliente.ApyNom} No tiene Activa la cuenta corriente."
                                    + Environment.NewLine
                                    + $"Por favor ingrese otro cliente o cambie su configuracion";

                            MessageBox.Show(menssajeCtaCte, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                    }

                }

                #endregion

                
                

                
                _facturaNueva.Numero = (int)_facturaServicio.Insertar(_facturaNueva);
                //ImprimirTicket(_facturaNueva);

                // Imprimir
                if (_facturaNueva.VieneVentas)
                {
                    // nueva Factura

                    // Imprimir Factura
                    List<ReporteFacturaDto> Reporte = new List<ReporteFacturaDto>();

                    foreach (var item in _facturaNueva.Items)
                    {
                        Reporte.Add(new ReporteFacturaDto
                        {
                            Numero = _facturaNueva.Numero,
                            Fecha = _facturaNueva.Fecha,

                            Direccion = txtDireccion.Text,
                            Telefono = txtTelefono.Text,
                            NombreCliente = txtApellidoyNombre.Text,

                            NombreVendedor = Identidad.ApyNom,
                            DireccionVendedor = _factura.Vendedor.Direccion,
                            TelefonoVendedor = DtosEmpresa.Telefono,
                            CelularVendedor = DtosEmpresa.Celular,

                            FacturaSubtotal = Math.Round(_facturaNueva.SubTotal, 2),
                            FacturaDescuento = Math.Round(_facturaNueva.Descuento, 2),
                            FacturaTotal = Math.Round(_facturaNueva.Total, 2),

                            Codigo = item.Codigo,
                            Descripcion = item.Descripcion,
                            Precio = item.Precio,
                            Cantidad = item.Cantidad,
                            Dto = item.Dto
                        });
                    }

                    // Inprimir Factura Estado Pendiente de pago
                    this.Hide();
                    new ReporteFactura(Reporte).ShowDialog();
                    this.Visible = true;
                }
                else 
                {
                    //Actualiza factura prendiente
                    //MessageBox.Show("No imprimo factura");
                }

                MessageBox.Show("Los datos se grabaron correctamente");

                RealizoVenta = true;
                Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                RealizoVenta = false;
            }
        }


        // =========================================================

        private void ImprimirTicket(FacturaDto facturaNueva)
        {
            var DtosEmpresa = _ConfiguracionServicio.ObtenerDatosEmpresa();
            var UltimoNumFactura = _facturaServicio.ObtenerUltimaFactura();

            clsFunciones.CreaTicket Ticket1 = new clsFunciones.CreaTicket();

            //------------------------ Datos de la Empresa ------------------------
            Ticket1.TextoCentro($"--- {DtosEmpresa.NombreFantasia} ---"); // Datos del Negocio
            clsFunciones.CreaTicket.LineasGuion();
            Ticket1.TextoIzquierda($"CUIT: {DtosEmpresa.Cuit}");
            Ticket1.TextoIzquierda($"Dir: {DtosEmpresa.Direccion}");
            Ticket1.TextoIzquierda($"{DtosEmpresa.Localidad} -");
            Ticket1.TextoIzquierda($"{DtosEmpresa.Departamento} -");
            Ticket1.TextoIzquierda($"{DtosEmpresa.Provincia}");

            Ticket1.TextoIzquierda("");
            clsFunciones.CreaTicket.LineasGuion();
            Ticket1.TextoIzquierda($@"Factura Nº: {UltimoNumFactura}");
            Ticket1.TextoIzquierda("Fecha: " + DateTime.Now.ToShortDateString() + "-" + DateTime.Now.ToShortTimeString());
            Ticket1.TextoIzquierda($"Empleado: {Identidad.ApyNom}");
            Ticket1.TextoIzquierda($"Tipo Comprobante: {facturaNueva.TipoComprobante}");
            Ticket1.TextoIzquierda("");
            clsFunciones.CreaTicket.LineasGuion();
            clsFunciones.CreaTicket.EncabezadoVenta(); // Encabezado del Detalle de Factura
            clsFunciones.CreaTicket.LineasGuion();

            //------------------------ Detalle de la factura  ------------------------

            foreach (var Articulo in facturaNueva.Items)
            {
                // Articulo        //Precio             cantidad             Subtotal
                Ticket1.AgregaArticulo(Articulo.Descripcion, Articulo.Precio, Articulo.Cantidad, Articulo.SubTotal); //imprime una linea de descripcion
            }

            //------------------------  Totales  ------------------------

            clsFunciones.CreaTicket.LineasGuion();
            Ticket1.AgregaTotales($"Sub-Total: ", facturaNueva.SubTotal); // imprime linea con Subtotal
            Ticket1.AgregaTotalesPorcentaje($"Descuento: ", facturaNueva.Descuento); // imprime linea con decuento total
            Ticket1.AgregaTotales($"Total: ", facturaNueva.Total); // imprime linea con total
            clsFunciones.CreaTicket.LineasGuion();
            /*
            Ticket1.AgregaTotales($"Efectivo Entregado:", nudPagaCon.Value);
            Ticket1.AgregaTotales($"Efectivo Devuelto:", nudVuelto.Value);
            */
            // Frase de la Empresa en Configuracion

            Ticket1.TextoIzquierda(" ");
            clsFunciones.CreaTicket.LineasGuion();
            Ticket1.TextoCentro($"* {DtosEmpresa.PieFactura} *");
            clsFunciones.CreaTicket.LineasGuion();
            Ticket1.TextoIzquierda(" ");

            //------------------------ Imprimir Ticket  ------------------------
            
            //Ticket1.ImprimirTiket(cmbInstalledPrinters.Text); //Imprimir
        }
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void InstalledPrintersCombo()
        {
            // Add list of installed printers found to the combo box.
            // The pkInstalledPrinters string will be used to provide the display string.
            //String pkInstalledPrinters;
            //for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
            //{
            //    pkInstalledPrinters = PrinterSettings.InstalledPrinters[i];
            //    cmbInstalledPrinters.Items.Add(pkInstalledPrinters);
            //
            //}
            //cmbInstalledPrinters.Text = "PDFLite";
            //cmbInstalledPrinters.Text = "PDFLite";
            //cmbInstalledPrinters.SelectedIndex = 3;
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
            if (MessageBox.Show("Esta seguro de salir de la Aplicacion", "Atencion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                == DialogResult.OK)
            {
                this.Close();
            }

        }
        private void IconoOcultar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        #endregion
    }
}