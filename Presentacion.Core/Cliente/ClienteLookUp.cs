using IServicio.Persona;
using IServicio.Persona.DTOs;
using PresentacionBase.Formularios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Presentacion.Core.Cliente
{
    public partial class ClienteLookUp : FormLookUp
    {
        private readonly IClienteServicio _ClienteServicio;

        private IEnumerable<PersonaDto> lista;
        public ClienteLookUp(IClienteServicio clienteServicio)
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
            lista = _ClienteServicio.Obtener(typeof(ClienteDto), cadenaBuscar);

            dgv.DataSource = lista;
            base.ActualizarDatos(dgv, cadenaBuscar);

            //dgv.DataSource = _ClienteServicio.Obtener(typeof(ClienteDto), cadenaBuscar);
            //base.ActualizarDatos(dgv, cadenaBuscar);
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

        public override void btnSeleccionar_Click(object sender, EventArgs e)
        {
            var FnuevoCliente = new _00010_Abm_Cliente(TipoOperacion.Nuevo);
            FnuevoCliente.ShowDialog();

            if (FnuevoCliente.RealizoAlgunaOperacion)
            {
                ActualizarDatos(dgvGrilla,string.Empty);
            }
        }

        public override void dgvGrilla_KeyPress(object sender, KeyPressEventArgs e)
        {
            var letra = e.KeyChar.ToString();
            var mayuscula = letra.ToUpper();

            if (e.KeyChar == (char)Keys.Enter)
            {
                return;
            }
            if (e.KeyChar == (char)Keys.Space)
            {
                e.Handled = true;
                this.Close();
            }
            else
            {


                var li = (List<ClienteDto>)dgvGrilla.DataSource;


                //var INDEX = li.FindIndex(x => x.Apellido.Contains(e.KeyChar) || x.Apellido.Contains(mayuscula));

                // buscar la fila con la letra e.keychar
                // bucle
                var INDEX = li.FindIndex(x => x.Apellido[0] == e.KeyChar || x.Apellido[0] == mayuscula[0]);

                // Darle foco
                if (INDEX < 0)
                {
                    MessageBox.Show("Apellido no encontrado");
                    return;
                }
                dgvGrilla.Rows[INDEX].Selected = true;
            }
        }
    }
}
