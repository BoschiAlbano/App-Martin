using IServicio.ListaPrecio;
using PresentacionBase.Formularios;
using System.Windows.Forms;

namespace Presentacion.Core.Articulo
{
    public partial class _00032_ListaPrecio : FormConsulta
    {

        private readonly IListaPrecioServicio _ListaPrecioServicio;

        public _00032_ListaPrecio(IListaPrecioServicio listaPrecioServicio)
        {
            InitializeComponent();

            //===============   Eliminar Parte de arriba del formulario   =======================
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            _ListaPrecioServicio = listaPrecioServicio;

        }

        public override void ActualizarDatos(DataGridView dgv, string cadenaBuscar)
        {
            dgv.DataSource = _ListaPrecioServicio.Obtener(cadenaBuscar);

            base.ActualizarDatos(dgv, cadenaBuscar);
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            dgv.Columns["Descripcion"].Visible = true;
            dgv.Columns["Descripcion"].HeaderText = @"Descripción";
            dgv.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["Descripcion"].DisplayIndex = 0;

            dgv.Columns["PorcentajeGananciaStr"].Visible = true;
            dgv.Columns["PorcentajeGananciaStr"].HeaderText = "Porcentaje Ganancia";
            dgv.Columns["PorcentajeGananciaStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["PorcentajeGananciaStr"].Width = 250;
            dgv.Columns["PorcentajeGananciaStr"].DisplayIndex = 1;

            dgv.Columns["AutorizacionStr"].Visible = true;
            dgv.Columns["AutorizacionStr"].HeaderText = "Autorizacion";
            dgv.Columns["AutorizacionStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["AutorizacionStr"].Width = 150;
            dgv.Columns["AutorizacionStr"].DisplayIndex = 2;

            dgv.Columns["EliminadoStr"].Visible = true;
            dgv.Columns["EliminadoStr"].Width = 100;
            dgv.Columns["EliminadoStr"].HeaderText = "Eliminado";
            dgv.Columns["EliminadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["EliminadoStr"].DisplayIndex = 3;

        }

        public override bool EjecutarComando(TipoOperacion tipoOperacion, long? id = null)
        {
            var form = new _00033_Abm_ListaPrecio(tipoOperacion, id);
            form.ShowDialog();
            return form.RealizoAlgunaOperacion;
        }
    }
}
