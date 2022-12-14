using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using IServicio.Persona.DTOs;
using IServicios.CuentaCorriente;
using IServicios.CuentaCorriente.DTOs;
using Presentacion.Core.Reportes;
using PresentacionBase.Formularios;
using StructureMap;

namespace Presentacion.Core.Cliente
{
    public partial class _00034_ClienteCtaCte : FormBase
    {
        private ClienteDto _clienteSeleccionado;
        private ICuentaCorrienteServicio _CuentaCorrienteServicio;
        public _00034_ClienteCtaCte(ICuentaCorrienteServicio cuentaCorrienteServicio)
        {
            InitializeComponent();

            _CuentaCorrienteServicio = cuentaCorrienteServicio;
            _clienteSeleccionado = null;


            dgvGrilla.DataSource = new List<CuentaCorrienteDto>();
            FormatearGrilla(dgvGrilla);

            //===============   Eliminar Parte de arriba del formulario   =======================
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            var PrimerDiaMes = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0);
            dtpFechaDesde.Value = PrimerDiaMes;

            txtTotal.Text = 0.ToString("C");

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

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            var fClienteLookUp = ObjectFactory.GetInstance<ClienteLookUp>();
            fClienteLookUp.ShowDialog();

            if (fClienteLookUp.EntidadSeleccionada != null)
            {
                _clienteSeleccionado = (ClienteDto)fClienteLookUp.EntidadSeleccionada;

                txtApyNom.Text = _clienteSeleccionado.ApyNom;
                txtCelular.Text = _clienteSeleccionado.Direccion;

                CargarDatos();
            }
            else
            {
                txtApyNom.Clear();
                txtCelular.Clear();

                _clienteSeleccionado = null;

                dgvGrilla.DataSource = new List<CuentaCorrienteDto>();
            }
        }

        private void CargarDatos()
        {
            var Deudas = _CuentaCorrienteServicio.Obtener(_clienteSeleccionado.Id, dtpFechaDesde.Value, dtpFechaHasta.Value, false);

            dgvGrilla.DataSource = Deudas;

           FormatearGrilla(dgvGrilla);

            // **
            var Resta = _CuentaCorrienteServicio.ObtenerDeudaCliente(_clienteSeleccionado.Id);
            

            txtTotal.Text = Resta.ToString("C");

            txtTotal.BackColor = Resta <= 0
                ? Color.FromArgb(192, 255, 192)
                : Color.FromArgb(255, 192, 192);

            txtTotal.ForeColor = Color.Black;
        }


        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);


            dgv.Columns["Descripcion"].Visible = true;
            dgv.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["Descripcion"].HeaderText = "Descripcion";
            dgv.Columns["Descripcion"].DisplayIndex = 1;

            dgv.Columns["FechaStr"].Visible = true;
            dgv.Columns["FechaStr"].Width = 100;
            dgv.Columns["FechaStr"].HeaderText = "Fecha";
            dgv.Columns["FechaStr"].DisplayIndex = 2;

            dgv.Columns["HoraStr"].Visible = true;
            dgv.Columns["HoraStr"].Width = 100;
            dgv.Columns["HoraStr"].HeaderText = "Hora";
            dgv.Columns["HoraStr"].DisplayIndex = 3;

            dgv.Columns["MontoStr"].Visible = true;
            dgv.Columns["MontoStr"].Width = 100;
            dgv.Columns["MontoStr"].HeaderText = "Cuenta Corriente";
            dgv.Columns["MontoStr"].DisplayIndex = 4;

            dgv.Columns["EfectivoStr"].Visible = true;
            dgv.Columns["EfectivoStr"].Width = 100;
            dgv.Columns["EfectivoStr"].HeaderText = "Efectivo";
            dgv.Columns["EfectivoStr"].DisplayIndex = 4;

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (_clienteSeleccionado == null)
            {
                return;
            }
            CargarDatos();
        }

        private void dtpFechaDesde_ValueChanged(object sender, EventArgs e)
        {
            if (_clienteSeleccionado == null)
            {
                return;
            }

            dtpFechaHasta.MinDate = dtpFechaDesde.Value;

            if (dtpFechaDesde.Value > dtpFechaHasta.Value)
            {
                dtpFechaHasta.Value = dtpFechaDesde.Value;
            }

            CargarDatos();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (_clienteSeleccionado == null)
            {
                return;
            }
            this.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (_clienteSeleccionado == null)
            {
                return;
            }
            CargarDatos();
        }

        private void btnRealizarPago_Click(object sender, EventArgs e)
        {
            if (_clienteSeleccionado != null)
            {
                var FPagarDeuda = new _00035_ClientePagoCtaCte(_clienteSeleccionado);
                FPagarDeuda.ShowDialog();

                if (FPagarDeuda.RealizoPagos)
                {
                    var PrimerDiaMes = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0);
                    dtpFechaDesde.Value = PrimerDiaMes;
                    dtpFechaHasta.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                    CargarDatos();
                }

            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

            var lista = (List<CuentaCorrienteDto>)dgvGrilla.DataSource;

            if (lista.Count == 0 )
            {
                MessageBox.Show("Error, La Grilla esta Vacia");
                return;
            }
            var Imprimir = new ReporteEstadoClienteCuentaCorriente(lista);
            Imprimir.ShowDialog();

        }
    }
}
