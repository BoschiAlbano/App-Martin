using PresentacionBase.Formularios;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Presentacion.Core.Comprobantes.Clases
{
    public partial class CambiarCantidadItems : FormBase
    {
        private int NuevaCantidad;
        public int CantidadNueva => NuevaCantidad;
        public bool RealizoAlgunaOperacion;


        private string _Descripcion = "";
        private int _Cantidad = 0;

        public CambiarCantidadItems(string descripcion, int cantidad)
        {

            InitializeComponent();


            // Eliminar Parte de arriba del formulario
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            this._Descripcion = descripcion;
            this._Cantidad = cantidad;

            RealizoAlgunaOperacion = false;
        }

        private void CambiarCantidadItems_Load(object sender, EventArgs e)
        {

            lblNombreArticul.Text = _Descripcion;
            nudCantidad.Value = _Cantidad;

            nudCantidad.Focus();
            nudCantidad.Select(0, nudCantidad.Value.ToString().Length);

        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (nudCantidad.Value < 1)
            {
                MessageBox.Show("Error en la cantidad");
                return;
            }

            RealizoAlgunaOperacion = true;
            NuevaCantidad = (int)nudCantidad.Value;
            this.Close();
        }

        //Mover el Formulario con el evento
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void lblNombreArticul_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }


        #region BOTONES (X,minimizar y maximizar)
        private void IconoMaximizar_Click(object sender, EventArgs e)
        {

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
    }

}
