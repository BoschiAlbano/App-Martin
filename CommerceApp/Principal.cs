using System;
using System.Windows.Forms;
using Presentacion.Core.Articulo;
using Presentacion.Core.Cliente;
using Presentacion.Core.Comprobantes;
using Presentacion.Core.Configuracion;
using Presentacion.Core.Departamento;
using Presentacion.Core.Empleado;
using Presentacion.Core.Localidad;
using Presentacion.Core.Provincia;
using Presentacion.Core.Usuario;
using FontAwesome.Sharp;
using StructureMap;
using System.Drawing;
using System.Runtime.InteropServices;
using IServicio.Persona;
using IServicio.Usuario;
using IServicios.Caja;
using Presentacion.Core.FormaPago;
using Presentacion.Core.Reportes;
using IServicio.Configuracion;

namespace CommerceApp
{
    public partial class Principal : Form
    {
        // V Privadas
        private IconButton currentBtn;// Boton Actual
        private Panel leftBorderBtn;// Borde Izquierdo al boton
        private Form currentChildForm;// Para almacenar el formulario hijo actual

        private readonly IEmpleadoServicio _EmpleadoServicio;
        private readonly IUsuarioServicio _UsuarioServicio;
        private readonly ICajaServicio _CajaServicio;
        private readonly IConfiguracionServicio _ConfiguracionServicio;

        public Principal(IEmpleadoServicio empleadoServicio, IUsuarioServicio usuarioServicio, ICajaServicio cajaServicio, IConfiguracionServicio configuracionServicio)
        {
            InitializeComponent();

            _EmpleadoServicio = empleadoServicio;
            _UsuarioServicio = usuarioServicio;
            _CajaServicio = cajaServicio;

            _ConfiguracionServicio = configuracionServicio;

            //==================================   login   ==================================
            //ObjectFactory.GetInstance<Login>().ShowDialog();

            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);

            //===============   Eliminar Parte de arriba del formulario   =======================
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            //==================================   Cargamos los datos del usuario
            lblApyNom.Text = Aplicacion.Constantes.Identidad.ApyNom;
            //lblUsuario.Text = Aplicacion.Constantes.Identidad.Usuario;
            ptbFotoUsuario.Image = Aplicacion.Constantes.Imagen.ConvertirImagen(Aplicacion.Constantes.Identidad.Foto);

            //=============================   Caja   ============================

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
            if (MessageBox.Show("Esta seguro de salir de la Aplicacion", "Atencion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                == DialogResult.OK)
            {
                this.Close();
            }

        }
        private void IconoOcultar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        #endregion

        #region Menu de Arriba - NO TOCAR -
        private void provinciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFroms(ObjectFactory.GetInstance<_00001_Provincia>());
        }

        private void MenuDepartamento_Click(object sender, EventArgs e)
        {
            AbrirFroms(ObjectFactory.GetInstance<_00003_Departamento>());
        }

        private void MenuLocalidad_Click(object sender, EventArgs e)
        {
            AbrirFroms(ObjectFactory.GetInstance<_00005_Localidad>());
        }

        private void MenuArticulo_Click(object sender, EventArgs e)
        {
            AbrirFroms(ObjectFactory.GetInstance<_00017_Articulo>());
        }

        private void MenuRubro_Click(object sender, EventArgs e)
        {
            AbrirFroms(ObjectFactory.GetInstance<_00019_Rubro>());
        }

        private void MenuMarca_Click(object sender, EventArgs e)
        {
            AbrirFroms(ObjectFactory.GetInstance<_00021_Marca>());
        }

        private void MenuListaDePrecio_Click(object sender, EventArgs e)
        {
            AbrirFroms(ObjectFactory.GetInstance<_00032_ListaPrecio>());
        }

        private void MenuConfiguracion_Click(object sender, EventArgs e)
        {
            AbrirFroms(ObjectFactory.GetInstance<_00012_Configuracion>());
        }

        private void MenuRubro_Click_1(object sender, EventArgs e)
        {
            AbrirFroms(ObjectFactory.GetInstance<_00019_Rubro>());
        }

        private void MenuMarca_Click_1(object sender, EventArgs e)
        {
            AbrirFroms(ObjectFactory.GetInstance<_00021_Marca>());
        }

        private void MenuListaDePrecio_Click_1(object sender, EventArgs e)
        {
            AbrirFroms(ObjectFactory.GetInstance<_00032_ListaPrecio>());
        }

        private void MenuConfiguracion_Click_1(object sender, EventArgs e)
        {
            var _Abrir = ObjectFactory.GetInstance<_00012_Configuracion>();
            _Abrir.ShowDialog();
        }

        private void MenuEmpleado_Click(object sender, EventArgs e)
        {
            AbrirFroms(ObjectFactory.GetInstance<_00007_Empleado>());
        }

        private void MenuCliente_Click(object sender, EventArgs e)
        {
            AbrirFroms(ObjectFactory.GetInstance<_00009_Cliente>());
        }

        private void MenuUsuario_Click(object sender, EventArgs e)
        {
            AbrirFroms(ObjectFactory.GetInstance<_00011_Usuario>());
        }

        private void MenuActualizarPrecio_Click(object sender, EventArgs e)
        {
            AbrirFroms(ObjectFactory.GetInstance<_00031_ActualizarPrecios>());
        }

        private void MenuFactura_Click(object sender, EventArgs e)
        {
            AbrirFroms(ObjectFactory.GetInstance<_00050_Venta>());
        }

        private void CobroDiferido_Click(object sender, EventArgs e)
        {
            AbrirFroms(ObjectFactory.GetInstance<_00049_CobroDiferido>());
        }

        private void MenuCuentaCorriente_Click(object sender, EventArgs e)
        {
            AbrirFroms(ObjectFactory.GetInstance<_00034_ClienteCtaCte>());
        }

        private void MenuReporteFactura_Click(object sender, EventArgs e)
        {
            var _Abrir = ObjectFactory.GetInstance<ReporteComprobantes>();
            _Abrir.ShowDialog();
        }

        private void MenuReporteArticloStock_Click(object sender, EventArgs e)
        {
            var _Abrir = new ReporteArticuloCapital(false);
            _Abrir.ShowDialog();
        }

        private void MenuReporteClientesCuentaCorriente_Click(object sender, EventArgs e)
        {
            var _Abrir = ObjectFactory.GetInstance<ReporteClienteCuentaCorriente>();
            _Abrir.ShowDialog();

            //AbrirFroms(ObjectFactory.GetInstance<ReporteClienteCuentaCorriente>());
        }

        private void MenuComprobantes_Click(object sender, EventArgs e)
        {
            AbrirFroms(ObjectFactory.GetInstance<CalcularComision>());
        }

        private void MenuBajaComprobantesViejos_Click(object sender, EventArgs e)
        {
            var ComprobantesViejos = ObjectFactory.GetInstance<EliminarComprobantesViejos>();
            ComprobantesViejos.ShowDialog();

        }

        private void menuConsolidado_Click(object sender, EventArgs e)
        {
            AbrirFroms(ObjectFactory.GetInstance<Consolidado>());
        }
        #endregion

        #region Metodos privados
        private void AbrirFroms(Form Formulario)
        {
            if (_ConfiguracionServicio.Obtener() == null)
            {
                var msj = "Primero debe cargar una Configuracion para el sistema"
                            + Environment.NewLine + " ¿ Desea Continual ?";

                if (MessageBox.Show(msj, "Atencion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                {
                    return;
                }
                else
                {
                    this.Hide();
                    ObjectFactory.GetInstance<_00012_Configuracion>().ShowDialog();
                    this.Visible = true;
                    return;
                }
            }

            this.Hide();
            Formulario.ShowDialog();
            this.Visible = true;


            var caja = _CajaServicio.Obtener(DateTime.Today);// crear o tomar la caja de hoy

            txtCuentaCorriente.Text = caja.CuentaCorrienteStr;
            txtEfectivo.Text = caja.EfectivoStr;

        }

        private void btnCambiarFoto_Click(object sender, EventArgs e)
        {

            if (Aplicacion.Constantes.Identidad.EmpleadoId != 0)
            {
                var openFile = new OpenFileDialog();
                openFile.ShowDialog();

                if (!string.IsNullOrEmpty(openFile.FileName))
                {
                    // Programa
                    ptbFotoUsuario.Image = Image.FromFile(openFile.FileName);
                    // Base de datos
                    // crear un metodo nuevo en el servicio - id + imagen
                    _EmpleadoServicio.CambiarFoto(Aplicacion.Constantes.Identidad.EmpleadoId
                        , Aplicacion.Constantes.Imagen.ConvertirImagen(Image.FromFile(openFile.FileName)));

                }
            }

        }





        #endregion

        private void Principal_Load(object sender, EventArgs e)
        {
            _CajaServicio.EliminarCajas();//Eliminar Cajs viejas
            var caja = _CajaServicio.Obtener(DateTime.Today);// crear o tomar la caja de hoy

            txtCuentaCorriente.Text = caja.CuentaCorrienteStr;
            txtEfectivo.Text = caja.EfectivoStr;

            if (Aplicacion.Constantes.Identidad.UsuarioId == 0)// es admin
            {
                comprobanteToolStripMenuItem.Enabled = false;
                btnVenta.Enabled = false;
                btnCobroDiferido.Enabled = false;
                button2.Enabled = false;
            }
            else 
            {
                comprobanteToolStripMenuItem.Enabled = true;
                btnVenta.Enabled = true;
                btnCobroDiferido.Enabled = true;
                button2.Enabled = true;
            }
        }

        private void listaDeProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Listar productos - Descripcion, Precio Venta, y Espacio para Cantidad.
            var _Abrir = new ReporteArticuloCapital(true);
            _Abrir.ShowDialog();
        }

        private void artToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}