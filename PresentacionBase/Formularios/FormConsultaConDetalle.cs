using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PresentacionBase.Formularios
{
    public partial class FormConsultaConDetalle : FormBase
    {
        private long? entidadId;
        protected object EntidadSeleccionada;

        public FormConsultaConDetalle()
        {
            InitializeComponent();

            entidadId = null;
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormConsulta_Load(object sender, EventArgs e)
        {
            ActualizarDatos(dgvGrilla, string.Empty);
        }

        public virtual void ActualizarDatos(DataGridView dgv, string cadenaBuscar)
        {
            FormatearGrilla(dgv);
        }

        public virtual void dgvGrilla_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGrilla.RowCount <= 0) return;

            entidadId = (long)dgvGrilla["Id", e.RowIndex].Value;

            // Obtener el Objeto completo seleccionado
            EntidadSeleccionada = dgvGrilla.Rows[e.RowIndex].DataBoundItem;


            btnModificar.Enabled = !(bool)dgvGrilla["Eliminado", e.RowIndex].Value;
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ActualizarDatos(dgvGrilla, txtBuscar.Text);
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Enter)
            {
                e.Handled = true; // Quita Ruido molesto enter
                ActualizarDatos(dgvGrilla, txtBuscar.Text);
                //btnBuscar.PerformClick(); // Hago un Click por Codigo
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarDatos(dgvGrilla,string.Empty);
            txtBuscar.Clear();
            txtBuscar.Focus();
        }

        public virtual bool EjecutarComando(TipoOperacion tipoOperacion, long? id = null)
        {
            return false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (EjecutarComando(TipoOperacion.Nuevo))
            {
                ActualizarDatos(dgvGrilla, string.Empty);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvGrilla.RowCount > 0)
            {
                if (entidadId.HasValue) // Pregunto si tiene un valor
                {
                    if (EjecutarComando(TipoOperacion.Modificar, entidadId))
                    {
                        ActualizarDatos(dgvGrilla, string.Empty);
                    }
                }
                else
                {
                    MessageBox.Show("Por favor seleccione un registro");
                }
            }
            else
            {
                MessageBox.Show("No hay registros Cargados");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvGrilla.RowCount > 0)
            {
                if (entidadId.HasValue) // Pregunto si tiene un valor
                {
                    if (EjecutarComando(TipoOperacion.Eliminar, entidadId))
                    {
                        ActualizarDatos(dgvGrilla, string.Empty);
                    }
                }
                else
                {
                    MessageBox.Show("Por favor seleccione un registro");
                }
            }
            else
            {
                MessageBox.Show("No hay registros Cargados");
            }
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

        public virtual void dgvGrilla_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
