using IServicio.Seguridad;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Presentacion.Core.Comprobantes.Clases
{
    public partial class AutorizacionLitPrecio : Form
    {

        private readonly ISeguridadServicio _SeguridadServicio;
        public bool _PermisoAutorizado;


        public AutorizacionLitPrecio(ISeguridadServicio seguridadServicio)
        {
            InitializeComponent();

            // Eliminar Parte de arriba del formulario
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            _SeguridadServicio = seguridadServicio;
            _PermisoAutorizado = false;

        }

        //Mover el Formulario con el evento
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnVerPassword_MouseDown(object sender, MouseEventArgs e)
        {
            txtPassword.PasswordChar = char.MinValue;
        }

        private void btnVerPassword_MouseUp(object sender, MouseEventArgs e)
        {
            txtPassword.PasswordChar = char.Parse("*");
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (_SeguridadServicio.VerificarAcceso(txtUsuario.Text,txtPassword.Text))
            {
                _PermisoAutorizado = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("El Usuario/Contraseña son Incorrectos");
                txtPassword.Clear();
                txtUsuario.Clear();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            _PermisoAutorizado = false;
            this.Close();
        }


    }
}
