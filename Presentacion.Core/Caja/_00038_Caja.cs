using Aplicacion.Constantes;
using IServicios.Caja;
using IServicios.Caja.DTOs;
using PresentacionBase.Formularios;
using StructureMap;
using System;
using System.Windows.Forms;

namespace Presentacion.Core.Caja
{
    public partial class _00038_Caja : FormBase
    {
        private readonly ICajaServicio _CajaServicio;
        private CajaDto _CajaSeleccionada;

        public _00038_Caja(ICajaServicio cajaServicio)
        {
            InitializeComponent();

            _CajaServicio = cajaServicio;
            _CajaSeleccionada = null;
        }

        private void _00038_Caja_Load(object sender, EventArgs e)
        {
            dtpFechaDesde.Value = DateTime.Now;
            dtpFechaHasta.Value = DateTime.Now;
            txtBuscar.Clear();

            ActualizarDatos(string.Empty, false, DateTime.Today, DateTime.Today);
        }

        private void btnAbrirCaja_Click(object sender, EventArgs e)
        {
            // Abrir caja
            if (!_CajaServicio.VerificarAbiertaOCerrada(Identidad.UsuarioId))
            {
                var fAbrirCaja = ObjectFactory.GetInstance<_00039_AperturaCaja>();
                fAbrirCaja.ShowDialog();

                ActualizarDatos(string.IsNullOrEmpty(txtBuscar.Text) ? txtBuscar.Text : string.Empty
               , chkFechas.Checked, dtpFechaDesde.Value, dtpFechaHasta.Value);
            }
            else
            {
                MessageBox.Show("La Caja Ya se encuentra Abierta Para este Usuario");
            }

        }

        private void ActualizarDatos(string cadenaBuscar,bool filtroFechas ,DateTime fechaDesde, DateTime fechaHasta)
        {
            var Cajas = _CajaServicio.Obtener(cadenaBuscar, filtroFechas, fechaDesde, fechaHasta);

            dgvGrillaApertura.DataSource = Cajas;
            dgvGrillaCierre.DataSource = Cajas;

            FormatearGrillaApertura(dgvGrillaApertura);
            FormatearGrillaCierre(dgvGrillaCierre);

            txtBuscar.Clear();
        }

        private void FormatearGrillaCierre(DataGridView dgv)
        {
            for (int i = 0; i < dgv.ColumnCount; i++)
            {
                dgv.Columns[i].Visible = false;
                dgv.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dgv.Columns["Id"].Visible = true;
            dgv.Columns["Id"].Width = 100;
            dgv.Columns["Id"].HeaderText = "Nro Caja";
            dgv.Columns["Id"].DisplayIndex = 1;

            dgv.Columns["UsuarioCierre"].Visible = true;
            dgv.Columns["UsuarioCierre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["UsuarioCierre"].HeaderText = "Us. Cierre";
            dgv.Columns["UsuarioCierre"].DisplayIndex = 2;


            dgv.Columns["FechaCierreStr"].Visible = true;
            dgv.Columns["FechaCierreStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["FechaCierreStr"].HeaderText = @"Fecha Cierre";
            dgv.Columns["FechaCierreStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["FechaCierreStr"].DisplayIndex = 3;


            dgv.Columns["MontoCierreStr"].Visible = true;
            dgv.Columns["MontoCierreStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["MontoCierreStr"].HeaderText = "Monto Cierre";
            dgv.Columns["MontoCierreStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["MontoCierreStr"].DisplayIndex = 4;

            //

            dgv.Columns["TotalSalidaEfectivoStr"].Visible = true;
            dgv.Columns["TotalSalidaEfectivoStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["TotalSalidaEfectivoStr"].HeaderText = @"Salida Efectivo";
            dgv.Columns["TotalSalidaEfectivoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["TotalSalidaEfectivoStr"].DisplayIndex = 5;

            dgv.Columns["TotalSalidaTarjetaStr"].Visible = true;
            dgv.Columns["TotalSalidaTarjetaStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["TotalSalidaTarjetaStr"].HeaderText = @"Salida Tarjeta";
            dgv.Columns["TotalSalidaTarjetaStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["TotalSalidaTarjetaStr"].DisplayIndex = 6;

            dgv.Columns["TotalSalidaChequeStr"].Visible = true;
            dgv.Columns["TotalSalidaChequeStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["TotalSalidaChequeStr"].HeaderText = @"Salida Cheque";
            dgv.Columns["TotalSalidaChequeStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["TotalSalidaChequeStr"].DisplayIndex = 7;

            dgv.Columns["TotalSalidaCtaCteStr"].Visible = true;
            dgv.Columns["TotalSalidaCtaCteStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["TotalSalidaCtaCteStr"].HeaderText = @"Salida CtaCte";
            dgv.Columns["TotalSalidaCtaCteStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["TotalSalidaCtaCteStr"].DisplayIndex = 8;

        }
        private void FormatearGrillaApertura(DataGridView dgv)
        {
            for (int i = 0; i < dgv.ColumnCount; i++)
            {
                dgv.Columns[i].Visible = false;
                dgv.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dgv.Columns["Id"].Visible = true;
            dgv.Columns["Id"].Width = 100;
            dgv.Columns["Id"].HeaderText = "Nro Caja";
            dgv.Columns["Id"].DisplayIndex = 1;

            dgv.Columns["UsuarioApertura"].Visible = true;
            dgv.Columns["UsuarioApertura"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["UsuarioApertura"].HeaderText = "Us. Apertura";
            dgv.Columns["UsuarioApertura"].DisplayIndex = 2;


            dgv.Columns["FechaAperturaStr"].Visible = true;
            dgv.Columns["FechaAperturaStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["FechaAperturaStr"].HeaderText = @" Fecha Apertura";
            dgv.Columns["MontoAperturaStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["FechaAperturaStr"].DisplayIndex = 3;


            dgv.Columns["MontoAperturaStr"].Visible = true;
            dgv.Columns["MontoAperturaStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["MontoAperturaStr"].HeaderText = "Monto Apertura";
            dgv.Columns["MontoAperturaStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["MontoAperturaStr"].DisplayIndex = 4;

            //


            dgv.Columns["TotalEntradaEfectivoStr"].Visible = true;
            dgv.Columns["TotalEntradaEfectivoStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["TotalEntradaEfectivoStr"].HeaderText = @"Entrada Efectivo";
            dgv.Columns["TotalEntradaEfectivoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["TotalEntradaEfectivoStr"].DisplayIndex = 5;

            dgv.Columns["TotalEntradaTarjetaStr"].Visible = true;
            dgv.Columns["TotalEntradaTarjetaStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["TotalEntradaTarjetaStr"].HeaderText = @"Entrada Tarjeta";
            dgv.Columns["TotalEntradaTarjetaStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["TotalEntradaTarjetaStr"].DisplayIndex = 6;

            dgv.Columns["TotalEntradaChequeStr"].Visible = true;
            dgv.Columns["TotalEntradaChequeStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["TotalEntradaChequeStr"].HeaderText = @"Entrada Cheque";
            dgv.Columns["TotalEntradaChequeStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["TotalEntradaChequeStr"].DisplayIndex = 7;

            dgv.Columns["TotalEntradaCtaCteStr"].Visible = true;
            dgv.Columns["TotalEntradaCtaCteStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["TotalEntradaCtaCteStr"].HeaderText = @"Entrada CtaCte";
            dgv.Columns["TotalEntradaCtaCteStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["TotalEntradaCtaCteStr"].DisplayIndex = 8;

        }


        private void chkFechas_CheckedChanged(object sender, EventArgs e)
        {
            dtpFechaDesde.Enabled = chkFechas.Checked;
            dtpFechaHasta.Enabled = chkFechas.Checked;

            if (chkFechas.Checked) return;

            dtpFechaDesde.Value = DateTime.Now;
            dtpFechaHasta.Value = DateTime.Now;
        }

        private void dtpFechaDesde_ValueChanged(object sender, EventArgs e)
        {
            dtpFechaHasta.MinDate = dtpFechaDesde.Value;
            dtpFechaHasta.MinDate = dtpFechaDesde.Value;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            ActualizarDatos(string.IsNullOrEmpty(txtBuscar.Text) ? txtBuscar.Text : string.Empty
               , chkFechas.Checked, dtpFechaDesde.Value, dtpFechaHasta.Value);

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarDatos(string.IsNullOrEmpty(txtBuscar.Text) ? txtBuscar.Text : string.Empty
               , chkFechas.Checked, dtpFechaDesde.Value, dtpFechaHasta.Value);
        }





        private void btnCierreCaja_Click(object sender, EventArgs e)
        {

            var fCierreCaja = new _00040_CierreCaja(_CajaSeleccionada.Id);
            fCierreCaja.ShowDialog();

            ActualizarDatos(string.Empty, chkFechas.Checked, dtpFechaDesde.Value, dtpFechaHasta.Value);

        }

        private void dgvGrillaApertura_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGrillaApertura.RowCount <= 0)
            {
                _CajaSeleccionada = null;
                return;
            }

            _CajaSeleccionada = (CajaDto)dgvGrillaApertura.Rows[e.RowIndex].DataBoundItem;

        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                ActualizarDatos(string.IsNullOrEmpty(txtBuscar.Text) ? txtBuscar.Text : string.Empty
               , chkFechas.Checked, dtpFechaDesde.Value, dtpFechaHasta.Value);
            }
        }
    }
}
