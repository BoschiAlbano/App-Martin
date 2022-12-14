using IServicio.Persona;
using IServicio.Persona.DTOs;
using PresentacionBase.Formularios;
using System.Windows.Forms;

namespace Presentacion.Core.Cliente
{
    public partial class _00009_Cliente : FormConsulta
    {
        private readonly IClienteServicio _ClienteServicio;

        public _00009_Cliente(IClienteServicio clienteServicio)
        {
            InitializeComponent();

            //===============   Eliminar Parte de arriba del formulario   =======================
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            _ClienteServicio = clienteServicio;
        }

        public override void ActualizarDatos(DataGridView dgv, string cadenaBuscar)
        {
            dgv.DataSource = _ClienteServicio.Obtener(typeof(ClienteDto), cadenaBuscar);
            base.ActualizarDatos(dgv, cadenaBuscar);
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            dgv.Columns["ApyNom"].Visible = true;
            dgv.Columns["ApyNom"].HeaderText = "Apellido y Nombre";
            dgv.Columns["ApyNom"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["ApyNom"].DisplayIndex = 0;

            dgv.Columns["CtaCteStr"].Visible = true;
            dgv.Columns["CtaCteStr"].Width = 100;
            dgv.Columns["CtaCteStr"].HeaderText = "Cuenta Corriente";
            dgv.Columns["CtaCteStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["CtaCteStr"].DisplayIndex = 2;

            //dgv.Columns["LimiteCompraStr"].Visible = true;
            //dgv.Columns["LimiteCompraStr"].Width = 100;
            //dgv.Columns["LimiteCompraStr"].HeaderText = "Limite Compra";
            //dgv.Columns["LimiteCompraStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dgv.Columns["LimiteCompraStr"].DisplayIndex = 1;

            dgv.Columns["MontoMaximoCtaCteStr"].Visible = true;
            dgv.Columns["MontoMaximoCtaCteStr"].Width = 150;
            dgv.Columns["MontoMaximoCtaCteStr"].HeaderText = "Monto Maximo";
            dgv.Columns["MontoMaximoCtaCteStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["MontoMaximoCtaCteStr"].DisplayIndex = 3;

            dgv.Columns["EliminadoStr"].Visible = true;
            dgv.Columns["EliminadoStr"].Width = 100;
            dgv.Columns["EliminadoStr"].HeaderText = "Eliminado";
            dgv.Columns["EliminadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["EliminadoStr"].DisplayIndex = 4;
        }

        public override bool EjecutarComando(TipoOperacion tipoOperacion, long? id = null)
        {
            var formulario = new _00010_Abm_Cliente(tipoOperacion, id);
            formulario.ShowDialog();

            return formulario.RealizoAlgunaOperacion;

        }
    }
}
