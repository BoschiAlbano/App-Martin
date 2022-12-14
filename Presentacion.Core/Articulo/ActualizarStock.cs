using IServicio.Articulo.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Core.Articulo
{
    public partial class ActualizarStock : Form
    {

        ArticuloDto _Articulo = new ArticuloDto();
        public decimal _Cantidad = 0;

        public ActualizarStock(object art)
        {
            InitializeComponent();

            _Articulo = (ArticuloDto)art;

            lblStockActual.Text = "El Articulo " + _Articulo.Descripcion + Environment.NewLine + " tiene un stock actual de "  + _Articulo.Stock +" Unidades ";

            //===============   Eliminar Parte de arriba del formulario   =======================
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            nudNuevoStock.Focus();
            nudNuevoStock.Select(0, nudNuevoStock.Value.ToString().Length);
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

        private void IconoSalir_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        private void IconoOcultar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        #endregion

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            Actualizar();

        }

        private void Actualizar()
        {
            // Actualizar
            if (nudNuevoStock.Value <= 0)
            {
                MessageBox.Show("Ingrese una candidad mayor a 0");
                return;
            }

            _Cantidad = Math.Round(nudNuevoStock.Value, 0);
            this.Close();
        }

        private void nudNuevoStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                Actualizar();
                
            }
        }
    }
}
