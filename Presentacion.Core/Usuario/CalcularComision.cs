using IServicio.Usuario;
using IServicios.Comprobante;
using IServicios.Comprobante.DTOs;
using PresentacionBase.Formularios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Core.Usuario
{
    public partial class CalcularComision : FormBase
    {

        private IComprobanteServicio _ComprobanteServicio;
        private IUsuarioServicio _UsuarioServicio;
        private decimal _Total = 0m;

        private ComprobanteReporteDto _ComprobanteSeleccionado;

        public CalcularComision(IComprobanteServicio comprobanteServicio, IUsuarioServicio usuarioServicio)
        {
            InitializeComponent();
            // Eliminar Parte de arriba del formulario
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;


            _ComprobanteServicio = comprobanteServicio;
            _UsuarioServicio = usuarioServicio;

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

        private void CalcularComision_Load(object sender, EventArgs e)
        {
            CargarUsuario();

            CagarGrilla();
        }

        private void CagarGrilla()
        {
            var idUsuario = (long)cmbUsuario.SelectedValue;

            var comprobantes = _ComprobanteServicio.ObtenerPorUsuario(dtpFecha.Value, idUsuario);

            dgvGrillaComprobantes.DataSource = comprobantes;

            FormatearGrilla(dgvGrillaComprobantes);

            if (comprobantes.Count() == 0)
            {
                dgvGrillaDetalle.DataSource = new List<DetallePenDto>();
                FormatearGrillaDetalleComprobante(dgvGrillaDetalle);
            }
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            dgv.Columns["Numero"].Visible = true;
            dgv.Columns["Numero"].Width = 75;
            dgv.Columns["Numero"].HeaderText = "Numero";
            dgv.Columns["Numero"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["Numero"].DisplayIndex = 0;

            dgv.Columns["NombreCliente"].Visible = true;
            dgv.Columns["NombreCliente"].HeaderText = @"Cliente";
            dgv.Columns["NombreCliente"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["NombreCliente"].DisplayIndex = 1;

            dgv.Columns["Fecha"].Visible = true;
            dgv.Columns["Fecha"].Width = 150;
            dgv.Columns["Fecha"].HeaderText = "Fecha";
            dgv.Columns["Fecha"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["Fecha"].DisplayIndex = 2;

            dgv.Columns["Total"].Visible = true;
            dgv.Columns["Total"].Width = 150;
            dgv.Columns["Total"].HeaderText = "Total";
            dgv.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["Total"].DisplayIndex = 3;

            
        }

        private void CargarUsuario() 
        {
            PoblarComboBox(cmbUsuario, _UsuarioServicio.Obtener(""), "ApyNomEmpleado", "Id");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CagarGrilla();
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            CagarGrilla();
        }

        private void cmbUsuario_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CagarGrilla();
        }

        private void dgvGrillaComprobantes_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvGrillaComprobantes.RowCount <= 0)
            {
                _ComprobanteSeleccionado = null;
                
                return;
            }

            _ComprobanteSeleccionado = (ComprobanteReporteDto)dgvGrillaComprobantes.Rows[e.RowIndex].DataBoundItem;

            if (_ComprobanteSeleccionado == null)
            {
                dgvGrillaDetalle.DataSource = _ComprobanteSeleccionado.Items.ToList();
                return;
            }

            dgvGrillaDetalle.DataSource = _ComprobanteSeleccionado.Items.ToList();

            FormatearGrillaDetalleComprobante(dgvGrillaDetalle);

        }

        private void FormatearGrillaDetalleComprobante(DataGridView dgv)
        {
            for (int i = 0; i < dgv.ColumnCount; i++)
            {
                dgv.Columns[i].Visible = false;
            }

            dgv.Columns["Descripcion"].Visible = true;
            dgv.Columns["Descripcion"].HeaderText = @"Descripcion";
            dgv.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["Descripcion"].DisplayIndex = 0;

            dgv.Columns["PrecioStr"].Visible = true;
            dgv.Columns["PrecioStr"].Width = 150;
            dgv.Columns["PrecioStr"].HeaderText = "Precio";
            dgv.Columns["PrecioStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["PrecioStr"].DisplayIndex = 1;

            dgv.Columns["Cantidad"].Visible = true;
            dgv.Columns["Cantidad"].Width = 150;
            dgv.Columns["Cantidad"].HeaderText = "Cantidad";
            dgv.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["Cantidad"].DisplayIndex = 2;

        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if ((long)cmbUsuario.SelectedValue == -1)
            {
                MessageBox.Show("Error, No hay usuarios");
                return;
            }

            if (dtpFecha.Value > DateTime.Now)
            {
                MessageBox.Show("Error, Ingrese una fecha menor a la de hoy");
                return;
            }

            _Total = _ComprobanteServicio.CalcularComision(dtpFecha.Value, (long)cmbUsuario.SelectedValue);
            txtTotal.Text = _Total.ToString("C");

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            txtTotalDescuento.Text = (_Total - (_Total * (numericUpDown1.Value / 100))).ToString("C");
        }
    }
}
