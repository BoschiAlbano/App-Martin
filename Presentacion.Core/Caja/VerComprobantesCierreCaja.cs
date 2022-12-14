using IServicios.Caja.DTOs;
using PresentacionBase.Formularios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Core.Caja
{
    public partial class VerComprobantesCierreCaja : FormBase
    {
        public VerComprobantesCierreCaja(List<CajaComprobanteDto> Comprobantes)
        {
            InitializeComponent();

            CargarDatosGrilla(dgvGrilla, Comprobantes);
            
        }

        private void CargarDatosGrilla(DataGridView dgvGrilla, List<CajaComprobanteDto> comprobantes)
        {
            dgvGrilla.DataSource = comprobantes.ToList();

            FormatearGrilla(dgvGrilla);
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            dgv.Columns["Numero"].Visible = true;
            dgv.Columns["Numero"].Width = 50;
            dgv.Columns["Numero"].HeaderText = "Nro";
            dgv.Columns["Numero"].DisplayIndex = 1;

            dgv.Columns["Fecha"].Visible = true;
            dgv.Columns["Fecha"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["Fecha"].HeaderText = "Fecha";
            dgv.Columns["Fecha"].DisplayIndex = 2;

            dgv.Columns["Total"].Visible = true;
            dgv.Columns["Total"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["Total"].HeaderText = "Total";
            dgv.Columns["Total"].DisplayIndex = 3;

            dgv.Columns["Vendedor"].Visible = true;
            dgv.Columns["Total"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["Vendedor"].HeaderText = "Vendedor";
            dgv.Columns["Vendedor"].DisplayIndex = 4;

        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
