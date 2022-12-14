using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PresentacionBase.Formularios
{
    public partial class FormLookUp : FormBase
    {
        private long? entidadId;
        public object EntidadSeleccionada = null;

        public FormLookUp()
        {
            InitializeComponent();

            //AsignarEvento_EnterLeave(this);
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

            EntidadSeleccionada = null;
            this.Close();
        }
        private void IconoOcultar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        #endregion
        private void FormLookUp_Load(object sender, System.EventArgs e)
        {
            ActualizarDatos(dgvGrilla, string.Empty);
        }

        public virtual void ActualizarDatos(DataGridView dgv, string cadenaBuscar)
        {
            FormatearGrilla(dgv);
        }

        private void btnBuscar_Click(object sender, System.EventArgs e)
        {
            ActualizarDatos(dgvGrilla, txtBuscar.Text);
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                ActualizarDatos(dgvGrilla, txtBuscar.Text);
                //dgvGrilla.Focus();
            }
        }

        private void dgvGrilla_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            
            if (dgvGrilla.RowCount <= 0) return;

            entidadId = (long)dgvGrilla["Id", e.RowIndex].Value;

            // Obtener el Objeto completo seleccionado
            EntidadSeleccionada = dgvGrilla.Rows[e.RowIndex].DataBoundItem;

            //MessageBox.Show("Entidad: "+ entidadId);
        }

        public virtual void btnSalir_Click(object sender, System.EventArgs e)
        {
            EntidadSeleccionada = null;
            this.Close();
        }

        private void btnActualizar_Click(object sender, System.EventArgs e)
        {
            ActualizarDatos(dgvGrilla, string.Empty);
        }

        private void dgvGrilla_DoubleClick(object sender, System.EventArgs e)
        {
            this.Close();
        }

        public virtual void btnSeleccionar_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        public virtual void dgvGrilla_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void dgvGrilla_SelectionChanged(object sender, EventArgs e)
        {
        }
    }
}
