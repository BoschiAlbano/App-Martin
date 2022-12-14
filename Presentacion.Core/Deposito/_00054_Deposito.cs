using IServicio.Deposito;
using PresentacionBase.Formularios;
using System.Windows.Forms;

namespace Presentacion.Core.Deposito
{
    public partial class _00054_Deposito : FormConsulta
    {
        private readonly IDepositoSevicio _DepositoSevicio;
        public _00054_Deposito(IDepositoSevicio depositoSevicio)
        {
            InitializeComponent();

            _DepositoSevicio = depositoSevicio;
        }

        public override void ActualizarDatos(DataGridView dgv, string cadenaBuscar)
        {
            dgv.DataSource = _DepositoSevicio.Obtener(cadenaBuscar);

            base.ActualizarDatos(dgv, cadenaBuscar);
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            dgv.Columns["Descripcion"].Visible = true;
            dgv.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["Descripcion"].HeaderText = "Departamento";
            dgv.Columns["Descripcion"].DisplayIndex = 0;

            dgv.Columns["Ubicacion"].Visible = true;
            dgv.Columns["Ubicacion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["Ubicacion"].HeaderText = "Ubicacion";
            dgv.Columns["Ubicacion"].DisplayIndex = 1;

            dgv.Columns["EliminadoStr"].Visible = true;
            dgv.Columns["EliminadoStr"].Width = 100;
            dgv.Columns["EliminadoStr"].HeaderText = "Eliminado";
            dgv.Columns["EliminadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["EliminadoStr"].DisplayIndex = 2;
        }

        public override bool EjecutarComando(TipoOperacion tipoOperacion, long? id = null)
        {
            var formulario = new _00055_Abm_Deposito(tipoOperacion, id);
            formulario.ShowDialog();
            return formulario.RealizoAlgunaOperacion;
        }
    }
}
