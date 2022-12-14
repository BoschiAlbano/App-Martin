using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Core.Reportes.Datos
{
    public partial class FormularioArticulo : Form
    {
        public FormularioArticulo()
        {
            InitializeComponent();
        }

        private void FormularioArticulo_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'BaseDatos.Articulo' Puede moverla o quitarla según sea necesario.
            this.ArticuloTableAdapter.Fill(this.BaseDatos.Articulo);

            this.reportViewer1.RefreshReport();
        }
    }
}
