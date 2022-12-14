using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PresentacionBase.Formularios
{
    public partial class FormAbm : FormBase
    {
        protected long? EntidadId;
        protected TipoOperacion TipoOperacion;

        private bool _realizoAlgunaOperacion;
        public bool RealizoAlgunaOperacion => _realizoAlgunaOperacion;

        // constructor por que da un error en la vista de los formularios
        public FormAbm()
        {
            InitializeComponent();

            _realizoAlgunaOperacion = false;
        }
        public FormAbm(TipoOperacion tipoOperacion, long? entidadId = null)
            : this()
        {
            TipoOperacion = tipoOperacion;
            EntidadId = entidadId;
        }

        // Load
        private void FormAbm_Load(object sender, EventArgs e)
        {
            CargarDatos(EntidadId);
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
            this.Close();

        }
        private void IconoOcultar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        #endregion

        // botones
        private void btnEjecutar_Click(object sender, System.EventArgs e)
        {
            switch (TipoOperacion)
            {
                case TipoOperacion.Nuevo:
                    if (VerificarDatosObligatorios())
                    {
                        if (!VerificarSiExiste())
                        {
                            try
                            {
                                EjecutarComandoNuevo(); // Grabar
                                MessageBox.Show("Los datos se grabaron Correctamente");
                                LimpiarControles(this);
                                _realizoAlgunaOperacion = true;
                            }
                            catch (Exception exception)
                            {
                                MessageBox.Show($"{exception.Message}", "Error", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Los datos ingresados ya Existen");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Por favor ingrese los datos Obligatorios");
                    }
                    break;
                case TipoOperacion.Modificar:
                    if (VerificarDatosObligatorios())
                    {
                        try
                        {
                            EjecutarComandoModificar(); // Modificar
                            MessageBox.Show("Los datos se Modificaron Correctamente");
                            _realizoAlgunaOperacion = true;
                            this.Close();
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show($"{exception.Message}", "Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }

                        /*if (VerificarSiExiste(EntidadId))
                        {
                            
                        }
                        else
                        {
                            MessageBox.Show("Los datos ingresados ya Existen");
                        }*/
                    }
                    else
                    {
                        MessageBox.Show("Por favor ingrese los datos Obligatorios");
                    }
                    break;
                case TipoOperacion.Eliminar:
                    if (VerificarDatosObligatorios())
                    {
                        try
                        {
                            EjecutarComandoEliminar(); // Eliminar
                            MessageBox.Show("Los datos se Eliminaron Correctamente");
                            _realizoAlgunaOperacion = true;
                            this.Close();
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show($"{exception.Message}", "Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                        
                        /*if (!VerificarSiExiste(EntidadId))
                        {
                            
                        }
                        else
                        {
                            MessageBox.Show("Los datos ingresados ya Existen");
                        }*/
                    }
                    else
                    {
                        MessageBox.Show("Por favor ingrese los datos Obligatorios");
                    }
                    break;
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro de salir", "Atencion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                == DialogResult.OK)
            {
                Close();
            }
        }
        public virtual void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarControles(this);
        }


        // metodos
        public virtual void EjecutarComandoNuevo()
        {
        }
        public virtual void EjecutarComandoEliminar()
        {
        }
        public virtual void EjecutarComandoModificar()
        {
        }

        public virtual bool VerificarSiExiste(long? id = null)
        {
            return false;
        }
        public virtual bool VerificarDatosObligatorios()
        {
            return false;
        }

        public virtual void CargarDatos(long? entidadId)
        {
            switch (TipoOperacion)
            {
                case TipoOperacion.Nuevo:
                    btnEjecutar.Text = "Guardar";
                    break;
                case TipoOperacion.Modificar:
                    btnEjecutar.Text = "Modificar";
                    break;
                case TipoOperacion.Eliminar:
                    btnEjecutar.Text = "Eliminar";
                    btnLimpiar.Enabled = false;
                    break;
            }
        }
    }
}
