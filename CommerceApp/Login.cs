using IServicio.Seguridad;
using System;
using System.Windows.Forms;
using Aplicacion.Constantes;
using System.Runtime.InteropServices;
using StructureMap;

namespace CommerceApp
{
    public partial class Login : Form
    {
        private readonly ISeguridadServicio _SeguridadServicio;
        public Login()
        {
            InitializeComponent();
            
            // Eliminar Parte de arriba del formulario
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            _SeguridadServicio = ObjectFactory.GetInstance<ISeguridadServicio>();

        }
        private void Login_Load(object sender, EventArgs e)
        {
            btnIngresar.Focus();
            //txtUsuario.Text = "admin";
            //txtContrasena.Text = "admin";

            txtUsuario.Text = "MMontenegro";
            txtPassword.Text = "P$assword123";

        }
        // Botones
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text.Equals(UsuarioAdmin.Usuario) && txtPassword.Text.Equals(UsuarioAdmin.Password))
            {
                // entramos
                Identidad.Apellido = "Admin";
                Identidad.Nombre = "Admin";
                Identidad.EmpleadoId = 0;
                Identidad.Foto = Imagen.ConvertirImagen(Imagen.ImagenEmpleadoPorDefecto);
                Identidad.Usuario = "Administrador";
                Identidad.UsuarioId = 0;

                //this.Close();
                //var Principal = new Principal();
                var Principal = ObjectFactory.GetInstance<Principal>();
                this.Hide();
                Principal.ShowDialog();
                this.Visible = true;
                txtPassword.Clear();
                txtUsuario.Clear();
            }
            else// verificamos el la base 
            {
                // Verificamos los campos
                if (!VerificamosCampos())
                    MessageBox.Show("Por Favor Ingrese Los Campos Obligatorios");

                if (_SeguridadServicio.VerificarAcceso(txtUsuario.Text, txtPassword.Text))
                {
                    // entra
                    var Usuario = _SeguridadServicio.ObtenerUsuarioLogin(txtUsuario.Text);

                    Identidad.EmpleadoId = Usuario.EmpleadoId;
                    Identidad.Apellido = Usuario.ApellidoEmpleado;
                    Identidad.Nombre = Usuario.NombreEmpleado;
                    Identidad.UsuarioId = Usuario.Id;
                    Identidad.Usuario = Usuario.NombreUsuario;
                    Identidad.Foto = Usuario.FotoEmpleado;

                    //this.Close();
                    var Principal = ObjectFactory.GetInstance<Principal>();
                    this.Hide();
                    Principal.ShowDialog();
                    this.Visible = true;
                    //txtContrasena.Clear();
                    //txtUsuario.Clear();
                }
                else
                {
                    // no Entra
                    MessageBox.Show("Error, Usuario y/o contraseña No Existen. O Bloqueado");
                    //txtContrasena.Clear();
                    //txtUsuario.Clear();
                }
            }

        }

        // metodos Privados
        private bool VerificamosCampos()
        {
            if (string.IsNullOrEmpty(txtUsuario.Text))
                return false;
            if (string.IsNullOrEmpty(txtPassword.Text))
                return false;

            return true;
        }



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

        // Iconos/Botones

        private void btnVerPassword_MouseDown(object sender, MouseEventArgs e)
        {
            txtPassword.PasswordChar = char.MinValue;
        }

        private void btnVerPassword_MouseUp(object sender, MouseEventArgs e)
        {
            txtPassword.PasswordChar = char.Parse("*");
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void iconPictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void iconPictureBox3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        
        // Evento Paint del Boton
        private void btnIngresar_Paint(object sender, PaintEventArgs e)
        {
        }

        #region BOTONES (X,minimizar y maximizar)
        private void IconoMaximizar_Click(object sender, EventArgs e)
        {

        }

        private void IconoSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro que desea salir de la Aplicacion", "Atencion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                == DialogResult.OK)
            {
                Application.Exit();
            }

        }
        private void IconoOcultar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        #endregion
    }
}
