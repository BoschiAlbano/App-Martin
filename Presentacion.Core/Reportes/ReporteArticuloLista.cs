using IServicio.Articulo.DTOs;
using IServicio.Configuracion;
using IServicio.Configuracion.DTOs;
using Microsoft.Reporting.WinForms;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Presentacion.Core.Reportes
{
    public partial class ReporteArticuloLista : Form
    {

        IEnumerable<IServicio.BaseDto.DtoBase> _Lista;

        private readonly IConfiguracionServicio _ConfiguracionServicio;

        public ReporteArticuloLista(IEnumerable<IServicio.BaseDto.DtoBase> Lista)
        {
            InitializeComponent();

            _ConfiguracionServicio = ObjectFactory.GetInstance<IConfiguracionServicio>();
            _Lista = Lista;

            //===============   Eliminar Parte de arriba del formulario   =======================
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

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

        private void ReporteArticuloLista_Load(object sender, EventArgs e)
        {
            ObtenerDatos();
            this.reportViewer1.RefreshReport();
        }


        public void ObtenerDatos()
        {
            List<ArticuloDto> Lista = new List<ArticuloDto>();
            Lista = (List<ArticuloDto>)_Lista;

            var ListaIzquierda = new List<ArticuloDto>();
            var ListaDerecha = new List<ArticuloDto>();

            int Mitad = Lista.Count / 2;
            if (Lista.Count % 2 == 1) { Mitad++; }

            var contador = 0;
            foreach (var item in Lista)
            {
                contador++;
                if (contador <= Mitad)
                {
                    ListaIzquierda.Add(item);
                }
                else
                {
                    ListaDerecha.Add(item);
                }
            }

            var Configuracion = _ConfiguracionServicio.Obtener();
            List<ConfiguracionDto> _ListaConfig = new List<ConfiguracionDto>();
            _ListaConfig.Add(Configuracion);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", ListaIzquierda));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet2", ListaDerecha));

            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Configuracion", _ListaConfig));
            //reportViewer1.LocalReport.DataSources.Clear();
            //reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", _Lista));
        }
    }
}
