using IServicios.CuentaCorriente;
using Microsoft.Reporting.WinForms;
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

namespace Presentacion.Core.Reportes
{
    public partial class ReporteClienteCuentaCorriente : Form
    {
        private ICuentaCorrienteServicio _CuentaCorrienteServicio;
        public ReporteClienteCuentaCorriente(ICuentaCorrienteServicio cuentaCorrienteServicio)
        {
            InitializeComponent();

            _CuentaCorrienteServicio = cuentaCorrienteServicio;

            //===============   Eliminar Parte de arriba del formulario   =======================
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

        }

        private void ReporteClienteCuentaCorriente_Load(object sender, EventArgs e)
        {

            CargarDatos();

            this.reportViewer1.RefreshReport();
        }

        private void CargarDatos()
        {
            var Cuentas = _CuentaCorrienteServicio.ClientesDeben();

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", Cuentas));
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
    }
}
