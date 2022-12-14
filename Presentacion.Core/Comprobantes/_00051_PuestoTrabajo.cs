using IServicios.PuestoTrabajo;
using PresentacionBase.Formularios;
using System.Windows.Forms;

namespace Presentacion.Core.Comprobantes
{
    public partial class _00051_PuestoTrabajo : FormConsulta
    {
        private readonly IPuestoTrabajoServicio _PuestoTrabajoServicio;

        public _00051_PuestoTrabajo(IPuestoTrabajoServicio puestoTrabajoServicio)
        {
            InitializeComponent();

            _PuestoTrabajoServicio = puestoTrabajoServicio;

        }

        public override void ActualizarDatos(DataGridView dgv, string cadenaBuscar)
        {
            dgv.DataSource = _PuestoTrabajoServicio.Obtener(cadenaBuscar);

            base.ActualizarDatos(dgv, cadenaBuscar);
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);


            dgv.Columns["Codigo"].Visible = true;
            dgv.Columns["Codigo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["Codigo"].Width = 100;
            dgv.Columns["Codigo"].HeaderText = "Codigo";
            dgv.Columns["Codigo"].DisplayIndex = 0;

            dgv.Columns["Descripcion"].Visible = true;
            dgv.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["Descripcion"].HeaderText = "Departamento";
            dgv.Columns["Descripcion"].DisplayIndex = 1;

            dgv.Columns["EliminadoStr"].Visible = true;
            dgv.Columns["EliminadoStr"].Width = 100;
            dgv.Columns["EliminadoStr"].HeaderText = "Eliminado";
            dgv.Columns["EliminadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["EliminadoStr"].DisplayIndex = 2;
        }

        public override bool EjecutarComando(TipoOperacion tipoOperacion, long? id = null)
        {
            var formulario = new _00052_Abm_PuestoTrabajo(tipoOperacion, id);
            formulario.ShowDialog();
            return formulario.RealizoAlgunaOperacion;
        }
    }
}
