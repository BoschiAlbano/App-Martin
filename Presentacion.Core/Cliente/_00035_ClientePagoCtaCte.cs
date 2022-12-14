using Aplicacion.Constantes;
using IServicio.Persona.DTOs;
using IServicios.Comprobante.DTOs;
using IServicios.CuentaCorriente;
using PresentacionBase.Formularios;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Presentacion.Core.Cliente
{
    public partial class _00035_ClientePagoCtaCte : FormBase
    {
        private readonly ClienteDto _Cliente;
        private readonly ICuentaCorrienteServicio _CuentaCorrienteServicio;
        public bool RealizoPagos { get; set; }


        public _00035_ClientePagoCtaCte(ClienteDto clienteDto)
        {
            InitializeComponent();

            //===============   Eliminar Parte de arriba del formulario   =======================
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            _Cliente = clienteDto;
            _CuentaCorrienteServicio = ObjectFactory.GetInstance<ICuentaCorrienteServicio>();

            RealizoPagos = false;

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

        private void _00035_ClientePagoCtaCte_Load(object sender, System.EventArgs e)
        {

            if (_Cliente != null)
            {
                var ValorDeuda = _CuentaCorrienteServicio.ObtenerDeudaCliente(_Cliente.Id);
                nudMontoDeuda.Value = ValorDeuda >= 0 ? ValorDeuda : (ValorDeuda * -1);

                nudMontoPagar.Select(0, nudMontoPagar.Value.ToString().Length);
                nudMontoPagar.Focus();

            }

        }

        private void btnSalir_Click(object sender, System.EventArgs e)
        {
            RealizoPagos = false;
            this.Close();
        }

        private void btnLimpiar_Click(object sender, System.EventArgs e)
        {
            nudMontoPagar.Value = 0;
            nudMontoPagar.Select(0, nudMontoPagar.Value.ToString().Length);
            nudMontoPagar.Focus();
        }

        private void btnPagar_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (nudMontoPagar.Value > 0)
                {
                    if (nudMontoPagar.Value > nudMontoDeuda.Value)
                    {
                        var msj = "El monto a Pagar es Mayor a la Deuda.";
                        MessageBox.Show(msj);
                        return;
                        /*
                        if (MessageBox.Show(msj, "Atencion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                        {
                            return;
                        }*/
                    }
                    Grabar();
                    this.Close();
                }
                else
                {
                    nudMontoPagar.Select(0, nudMontoPagar.Value.ToString().Length);
                    nudMontoPagar.Focus();
                    MessageBox.Show("Ingrese un Monto Mayor a 0");
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Ocurrio Un Error Al Pagar");

            }
        }

        private void Grabar()
        {
            // Creamos un Comprobante para el pago realizado por cuenta corriente -> tipo de comprobante 7
            var _ComprobanteNuevo = new CtaCteComprobanteDto
            {
                ClienteId = _Cliente.Id,
                Descuento = 0,
                SubTotal = nudMontoPagar.Value,
                Total = nudMontoPagar.Value,
                EmpleadoId = Identidad.EmpleadoId,
                UsuarioId = Identidad.UsuarioId,
                Fecha = DateTime.Now,
                Iva105 = 0,
                Iva21 = 0,
                TipoComprobante = TipoComprobante.CuentaCorriente, // 7
                FormasDePagos = new List<FormaPagoDto>(),
                Items = new List<DetalleComprobanteDto>(),
                Eliminado = false,
                Efectivo = nudMontoPagar.Value,
            };

            _CuentaCorrienteServicio.Pagar(_ComprobanteNuevo);

            MessageBox.Show("Los Datos Se Grabaron");

            RealizoPagos = true;
        }
    }
}
