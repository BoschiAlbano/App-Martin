using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Aplicacion.Constantes;
using IServicios.Comprobante.DTOs;
using IServicios.Factura;
using IServicios.Factura.DTOs;
using Presentacion.Core.Reportes;
using PresentacionBase.Formularios;

namespace Presentacion.Core.FormaPago
{
    public partial class _00049_CobroDiferido : FormBase
    {

        private readonly IFacturaServicio _FacturaServicio;
        private ComprobantePenPagoDto _FacturaSeleccionada;
        private DateTime fecha = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 00, 00, 00);

        public _00049_CobroDiferido(IFacturaServicio facturaServicio)
        {
            InitializeComponent();

            //===============   Eliminar Parte de arriba del formulario   =======================
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            _FacturaServicio = facturaServicio;

            _FacturaSeleccionada = null;

            
            var resta = fecha.AddDays(-1);

            Buscar_Facturas_Pendientes_de_Pago("", 0);

            

            /*
            // Libreria para que refresque cada 60 seg la grilla
            // con las facturas que estan pendientes de pago.
            Observable.Interval(TimeSpan.FromSeconds(10))
                .ObserveOn(DispatcherScheduler.Current)
                .Subscribe(_ =>
                {
                    // Aqui se debe poner la consulta y asignarla a la grilla
                    //dgvGrillaPedientePago.DataSource = _FacturaServicio.ObtenerPendientesPago();
                    //FormatearGrilla(dgvGrillaPedientePago);

                    //Caluclar Efectivo y Cuenta Corriente

                });
            */

        }

        public void Buscar_Facturas_Pendientes_de_Pago(string Cadena_Buscar, int Codigo) 
        {
            dgvGrillaPedientePago.DataSource = _FacturaServicio.ObtenerPendientesPago(Cadena_Buscar, Codigo);
            FormatearGrilla(dgvGrillaPedientePago);

            if (dgvGrillaPedientePago.RowCount == 0)
            {
                var Detalle = new List<DetallePenDto>();
                dgvGrillaDetalleComprobante.DataSource = Detalle;
                FormatearGrillaDetalleComprobante(dgvGrillaDetalleComprobante);
                //nudDescuento.Value = 0m;
                //nudTotal.Value = 0m;
            }
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Quita Ruido molesto enter
                Buscar_Facturas_Pendientes_de_Pago(txtBuscar.Text, 0);
                //btnBuscar.PerformClick(); // Hago un Click por Codigo
            }
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            dgv.Columns["Numero"].Visible = true;
            dgv.Columns["Numero"].HeaderText = @"Nro Factura";
            dgv.Columns["Numero"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["Numero"].Width = 100;
            dgv.Columns["Numero"].DisplayIndex = 0;

            dgv.Columns["ClienteApiNom"].Visible = true;
            dgv.Columns["ClienteApiNom"].HeaderText = "Cliente";
            dgv.Columns["ClienteApiNom"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["ClienteApiNom"].DisplayIndex = 1;
            
            dgv.Columns["MontoStr"].Visible = true;
            dgv.Columns["MontoStr"].Width = 100;
            dgv.Columns["MontoStr"].HeaderText = "Monto";
            dgv.Columns["MontoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["MontoStr"].DisplayIndex = 2;

            dgv.Columns["Fecha"].Visible = true;
            dgv.Columns["Fecha"].Width = 150;
            dgv.Columns["Fecha"].HeaderText = "Fecha";
            dgv.Columns["Fecha"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["Fecha"].DisplayIndex = 3;
        }

        private void dgvGrillaPedientePago_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGrillaPedientePago.RowCount <= 0)
            {
                _FacturaSeleccionada = null;
                return;
            }

            _FacturaSeleccionada = (ComprobantePenPagoDto)dgvGrillaPedientePago.Rows[e.RowIndex].DataBoundItem;

            if (_FacturaSeleccionada == null)
            {
                return;
            }
            //nudTotal.Value = _FacturaSeleccionada.Monto;
            //nudDescuento.Value = _FacturaSeleccionada.Descuento;

            dgvGrillaDetalleComprobante.DataSource = _FacturaSeleccionada.Items.ToList();

            FormatearGrillaDetalleComprobante(dgvGrillaDetalleComprobante);
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
            dgv.Columns["PrecioStr"].Width = 100;
            dgv.Columns["PrecioStr"].HeaderText = "Precio";
            dgv.Columns["PrecioStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["PrecioStr"].DisplayIndex = 1;

            dgv.Columns["Cantidad"].Visible = true;
            dgv.Columns["Cantidad"].Width = 100;
            dgv.Columns["Cantidad"].HeaderText = "Cantidad";
            dgv.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["Cantidad"].DisplayIndex = 2;

        }

        private void dgvGrillaPedientePago_DoubleClick(object sender, EventArgs e)
        {
            if (dgvGrillaPedientePago.RowCount <= 0)
            {
                return;
            }
            // Forma de pago
            var fFacturar = new _00044_FormaPago(_FacturaSeleccionada);
            fFacturar.ShowDialog();

            if (fFacturar.RealizoVenta)
            {
                //MessageBox.Show("Los Datos Se Grabaron Correctamente");
                dgvGrillaDetalleComprobante.DataSource = new List<DetallePenDto>();
                FormatearGrillaDetalleComprobante(dgvGrillaDetalleComprobante);
                //nudDescuento.Value = 0;
                //nudTotal.Value = 0;
                _FacturaSeleccionada = null;
                Buscar_Facturas_Pendientes_de_Pago("", 0);
            }

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar_Facturas_Pendientes_de_Pago(txtBuscar.Text, 0);
        }

        private void NudCodigo_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
        }

        private void txtBuscar_Click(object sender, EventArgs e)
        {
            //NudCodigo.Value = 0;
        }

        private void dtpFechaDesde_ValueChanged(object sender, EventArgs e)
        {
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_FacturaSeleccionada == null)
            {
                MessageBox.Show("Seleccione una factura de la grilla");
                return;
            }
            else
            {
                if (MessageBox.Show("Esta seguro que quieres eliminar la Factura "+_FacturaSeleccionada.Numero, "Atencion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                == DialogResult.OK)
                {
                    if (_FacturaServicio.Eliminar_Factura(_FacturaSeleccionada.Id))
                    {
                        MessageBox.Show("Factura Eliminada y Stock Actualizado");
                        Buscar_Facturas_Pendientes_de_Pago(txtBuscar.Text, 0);
                    }
                    else
                    {
                        MessageBox.Show("Ocurrio un error.");
                    }
                }
            }

            
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (_FacturaSeleccionada == null)
            {
                MessageBox.Show("Seleccione una factura de la grilla");
                return;
            }
            else
            {
                if (MessageBox.Show("Esta seguro que quieres Imprimir la Factura " + _FacturaSeleccionada.Numero, "Atencion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                == DialogResult.OK)
                {

                    // Inprimir Factura Estado Pendiente de pago
                    new ReporteFactura(_FacturaServicio.ImprimirFactura(_FacturaSeleccionada.Id)).ShowDialog();
                }
            }
        }
    }
}
