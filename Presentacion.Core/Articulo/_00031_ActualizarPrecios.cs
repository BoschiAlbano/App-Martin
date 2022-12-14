using IServicio.ListaPrecio;
using IServicio.Marca;
using IServicio.Rubro;
using IServicios.Precio;
using PresentacionBase.Formularios;
using System.Runtime.InteropServices;
using System;
using System.Windows.Forms;

namespace Presentacion.Core.Articulo
{
    public partial class _00031_ActualizarPrecios : FormBase
    {
        private readonly IRubroServicio _RubroServicio;
        private readonly IMarcaServicio _MarcaServicio;
        private readonly IListaPrecioServicio _ListaPrecioServicio;
        private readonly IPrecioServicio _PrecioServicio;
        public _00031_ActualizarPrecios(IRubroServicio rubroServicio, IMarcaServicio marcaServicio
            , IListaPrecioServicio listaPrecioServicio, IPrecioServicio precioServicio)
        {
            InitializeComponent();

            //===============   Eliminar Parte de arriba del formulario   =======================
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;


            _RubroServicio = rubroServicio;
            _MarcaServicio = marcaServicio;
            _ListaPrecioServicio = listaPrecioServicio;
            _PrecioServicio = precioServicio;

            AsignarEvento_EnterLeave(this);

            CargarComboBox();
        }

        private void CargarComboBox()
        {
            PoblarComboBox(cmbRubro, _RubroServicio.Obtener(string.Empty, false), "Descripcion", "Id");
            PoblarComboBox(cmbMarca, _MarcaServicio.Obtener(string.Empty, false), "Descripcion", "Id");

            BuscarArticulos();
        }

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            if (nudValor.Value > 0 && nudPorcentajeGanacia.Value > 0)
            {
                MessageBox.Show("Error, No es posible Actualizar ambas Cantidades a la vez, intente modificar el precio de compra y luego el porcentaje de ganacia");
                return;
            }

            Filtro();
        }
        private void Filtro()
        {
            decimal valor;
            bool esPorcentaje;
            long? marcaId = null;
            long? rubroId = null;
            long? listaPrecioId = null;
            int? codigoDesde = null;
            int? codigoHasta = null;

            /*
            if (nudValor.Value <= 0) 
            {
                MessageBox.Show("Ingrese un moto mayo a 0");
                return;
            }
            */
            // Porcentaje o no
            if (rdbPorcentaje.Checked)
            {
                esPorcentaje = true;
            }
            else
            {
                esPorcentaje = false;
            }

            //marca
            if (chkMarca.Checked)
            {
                marcaId = (long)cmbMarca.SelectedValue;
            }

            // rubro
            if (chkRubro.Checked)
            {
                rubroId = (long)cmbRubro.SelectedValue;
            }

            // Codigo Articulo desde hasta
            if (chkArticulo.Checked)
            {

                codigoDesde = (int)nudCodigoDesde.Value;
                codigoHasta = (int)nudCodigoHasta.Value;

                if (codigoDesde > codigoHasta)
                {
                    MessageBox.Show("Error, Ingrese un Intervalo Correcto");
                    return;
                }

            }

            valor = (decimal)nudValor.Value;

            listaPrecioId = null;

            if (_PrecioServicio.ActualizarPrecio(nudPorcentajeGanacia.Value ,chkRedondear.Checked, valor, esPorcentaje, marcaId, rubroId, codigoDesde, codigoHasta))
            {
                MessageBox.Show("Se Actualizaron Los Precios");

            }else
            {
                MessageBox.Show("Error. Primero, Busque y Carge la Grilla.");
            }
            
            LimpiarControles(this);
            nudValor.Value = 0m;
            nudCodigoDesde.Value = 0m;
            nudCodigoHasta.Value = 0m;
            nudPorcentajeGanacia.Value = 0m;
            chkRedondear.Checked = true;

            BuscarArticulos();
        }


        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            dgv.Columns["Codigo"].Visible = true;
            dgv.Columns["Codigo"].Width = 75;
            dgv.Columns["Codigo"].HeaderText = "Codigo";
            dgv.Columns["Codigo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["Codigo"].DisplayIndex = 0;

            dgv.Columns["Descripcion"].Visible = true;
            dgv.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["Descripcion"].HeaderText = @"Descripción";
            dgv.Columns["Descripcion"].DisplayIndex = 1;

            dgv.Columns["PrecioCosto"].Visible = true;
            dgv.Columns["PrecioCosto"].Width = 75;
            dgv.Columns["PrecioCosto"].HeaderText = @"P. C";
            dgv.Columns["PrecioCosto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["PrecioCosto"].DisplayIndex = 2;

            dgv.Columns["PorcentajeGanancia"].Visible = true;
            dgv.Columns["PorcentajeGanancia"].Width = 70;
            dgv.Columns["PorcentajeGanancia"].HeaderText = @"%";
            dgv.Columns["PorcentajeGanancia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["PorcentajeGanancia"].DisplayIndex = 3;

            dgv.Columns["PrecioVenta"].Visible = true;
            dgv.Columns["PrecioVenta"].Width = 75;
            dgv.Columns["PrecioVenta"].HeaderText = @"P. V";
            dgv.Columns["PrecioVenta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["PrecioVenta"].DisplayIndex = 4;
        }


        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarControles(this);
            nudValor.Value = 0m;
            nudCodigoDesde.Value = 0m;
            nudCodigoHasta.Value = 0m;
            nudPorcentajeGanacia.Value = 0m;
            chkRedondear.Checked = true;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarArticulos();
        }

        public void BuscarArticulos() {
            decimal valor;
            bool esPorcentaje;
            long? marcaId = null;
            long? rubroId = null;
            long? listaPrecioId = null;
            int? codigoDesde = null;
            int? codigoHasta = null;

            // Porcentaje o no
            if (rdbPorcentaje.Checked)
            {
                esPorcentaje = true;
            }
            else
            {
                esPorcentaje = false;
            }

            //marca
            if (chkMarca.Checked)
            {
                marcaId = (long)cmbMarca.SelectedValue;
            }

            // rubro
            if (chkRubro.Checked)
            {
                rubroId = (long)cmbRubro.SelectedValue;
            }

            // Codigo Articulo desde hasta
            if (chkArticulo.Checked)
            {
                codigoDesde = (int)nudCodigoDesde.Value;
                codigoHasta = (int)nudCodigoHasta.Value;

                if (codigoDesde > codigoHasta)
                {
                    MessageBox.Show("Error, Ingrese un Intervalo Correcto");
                    return;
                }


            }

            valor = (decimal)nudValor.Value;

            var ListArticulos = _PrecioServicio.BuscarArticulos(valor, esPorcentaje, marcaId, rubroId, listaPrecioId, codigoDesde, codigoHasta);

            dgvGrilla.DataSource = ListArticulos;

            FormatearGrilla(dgvGrilla);
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

        private void PanelGrilla_Paint(object sender, PaintEventArgs e)
        {

        }

        private void nudCodigoDesde_ValueChanged(object sender, EventArgs e)
        {
            nudCodigoHasta.Value = nudCodigoDesde.Value;
        }
        #endregion
        /*
        //Mover el Formulario con el evento
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void menuStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        */
    }
}
