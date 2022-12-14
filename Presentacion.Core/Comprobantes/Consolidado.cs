using IServicio.Usuario;
using IServicios.Comprobante;
using IServicios.Comprobante.DTOs;
using PresentacionBase.Formularios;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Presentacion.Core.Comprobantes
{
    public partial class Consolidado : FormBase
    {
        private readonly IComprobanteServicio _ComprobanteServicio;
        private readonly IUsuarioServicio _UsuarioServicio;



        Hashtable Contador = new Hashtable();
        List<DetallePenDto> _Articulos = new List<DetallePenDto>();

        public Consolidado(IComprobanteServicio comprobanteServicio, IUsuarioServicio usuarioServicio)
        {
            InitializeComponent();

            _ComprobanteServicio = comprobanteServicio;
            _UsuarioServicio = usuarioServicio;

            //===============   Eliminar Parte de arriba del formulario   =======================
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

        }
        private void Consolidado_Load(object sender, EventArgs e)
        {
            CargarUsuario();

            CargarGrilla();

        }

        private void CargarGrilla()
        {
            var comp = _ComprobanteServicio.ObtenerPorUsuario(dtpFechaDesde.Value, (long)cmbUsuario.SelectedValue);

            Contador.Clear();
            _Articulos.Clear();

            foreach (var comprobantes in comp) // comprobates
            {

                foreach (var items in comprobantes.Items) // items
                {
                    if (Contador[items.Descripcion] == null)
                    {
                        Contador[items.Descripcion] = items.Cantidad;
                        _Articulos.Add(items);
                    }
                    else
                    {
                        var cantidad = Contador[items.Descripcion].ToString();

                        Contador[items.Descripcion] = decimal.Parse(cantidad) + items.Cantidad;
                    }

                }

            }
            
            if (_Articulos.Count != 0)
            {
                foreach (var art in _Articulos)
                {
                    var cantidad = Contador[art.Descripcion].ToString();
                    art.Cantidad = decimal.Parse(cantidad);
                    art.Cantidad = Math.Round(art.Cantidad);
                }
            }
            
            dgvGrilla.DataSource = _Articulos.ToList();
            

            FormatearGrilla(dgvGrilla);
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);


            dgv.Columns["Codigo"].Visible = true;
            dgv.Columns["Codigo"].Width = 100;
            dgv.Columns["Codigo"].HeaderText = "Codigo";
            dgv.Columns["Codigo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["Codigo"].DisplayIndex = 0;


            dgv.Columns["Descripcion"].Visible = true;
            dgv.Columns["Descripcion"].HeaderText = @"Descripcion";
            dgv.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["Descripcion"].DisplayIndex = 1;

         
            dgv.Columns["Cantidad"].Visible = true;
            dgv.Columns["Cantidad"].Width = 100;
            dgv.Columns["Cantidad"].HeaderText = "Cantidad";
            dgv.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["Cantidad"].Width = 150;
            dgv.Columns["Cantidad"].DisplayIndex = 2;
        }

        private void CargarUsuario()
        {
            PoblarComboBox(cmbUsuario, _UsuarioServicio.Obtener(""), "ApyNomEmpleado", "Id");
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void cmbUsuario_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void dtpFechaDesde_ValueChanged(object sender, EventArgs e)
        {
            CargarGrilla();
        }
    }
}
