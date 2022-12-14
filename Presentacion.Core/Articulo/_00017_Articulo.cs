using Aplicacion.Constantes;
using IServicio.Articulo;
using IServicio.Articulo.DTOs;
using PresentacionBase.Formularios;
using System.Windows.Forms;
using System;

namespace Presentacion.Core.Articulo
{
    public partial class _00017_Articulo : FormConsultaConDetalle
    {
        private readonly IArticuloServicio _ArticuloServicio;

        public _00017_Articulo(IArticuloServicio articuloServicio)
        {
            InitializeComponent();

            //===============   Eliminar Parte de arriba del formulario   =======================
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            _ArticuloServicio = articuloServicio;

            DesactivarControles(this);

            txtBuscar.Enabled = true;
            //btnBuscar.Enabled = true;
        }

        public override void ActualizarDatos(DataGridView dgv, string cadenaBuscar)
        {
            dgv.DataSource = _ArticuloServicio.Obtener(cadenaBuscar);
            base.ActualizarDatos(dgv, cadenaBuscar);
        }
        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            dgv.Columns["Codigo"].Visible = true;
            dgv.Columns["Codigo"].Width = 100;
            dgv.Columns["Codigo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv.Columns["Descripcion"].Visible = true;
            dgv.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["Descripcion"].HeaderText = @"Descripción";

            dgv.Columns["EliminadoStr"].Visible = true;
            dgv.Columns["EliminadoStr"].Width = 100;
            dgv.Columns["EliminadoStr"].HeaderText = "Eliminado";
            dgv.Columns["EliminadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public override bool EjecutarComando(TipoOperacion tipoOperacion, long? id = null)
        {
            var formulario = new _00018_Abm_Articulo(tipoOperacion, id);
            formulario.ShowDialog();

            return formulario.RealizoAlgunaOperacion;
        }

        // de mas
        public override void dgvGrilla_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            base.dgvGrilla_CellContentDoubleClick(sender, e);

            var ActualizarStock = new ActualizarStock(EntidadSeleccionada);
            ActualizarStock.ShowDialog();

            if (ActualizarStock._Cantidad > 0)
            {
                var StockActual = _ArticuloServicio.ActualizarStock((ArticuloDto)EntidadSeleccionada, ActualizarStock._Cantidad);

                MessageBox.Show("Stock Actualizado. " + Environment.NewLine + " Stock Actual: " + StockActual);

                ActualizarDatos(dgvGrilla, txtBuscar.Text);
            }

        }
        public override void dgvGrilla_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            base.dgvGrilla_RowEnter(sender, e);
            if (EntidadSeleccionada == null)
            {
                txtMarca.Clear();
                txtRubro.Clear();
                FotoArticulo.Image = null;
                return;
            }

            panelResultado.BackgroundImage = Aplicacion.Constantes.Imagen.ImagenProductoPorDefecto;

            var articulo = (ArticuloDto)EntidadSeleccionada;
            txtMarca.Text = articulo.Marca;
            txtRubro.Text = articulo.Rubro;
            txtPrecioVenta.Text = articulo.PrecioVenta.ToString();
            txtStock.Text = articulo.Stock.ToString();

            ImagenProducto.Image = Imagen.ConvertirImagen(articulo.Foto);
            // ================================================== //

            if (articulo.DescuentaStock)
            {
                rbTrue.Checked = true;
            }
            else {
                rbFalse.Checked = true;
            }
        }
        private void label5_Click(object sender, System.EventArgs e)
        {

        }

        
    }
}
