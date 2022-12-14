using IServicio.Articulo;
using IServicio.Articulo.DTOs;
using IServicios.Articulo.DTOs;
using PresentacionBase.Formularios;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentacion.Core.Articulo
{
    public partial class ArticuloLookUp : FormLookUp
    {

        private readonly IArticuloServicio _ArticuloServicio;
        public ArticuloDto ArticuloSeleccionado => (ArticuloDto)EntidadSeleccionada;

        public ArticuloLookUp()
        {
            InitializeComponent();

            //===============   Eliminar Parte de arriba del formulario   =======================
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            _ArticuloServicio = ObjectFactory.GetInstance<IArticuloServicio>();
        }

        public override void ActualizarDatos(DataGridView dgv, string cadenaBuscar)
        {
            dgv.DataSource = _ArticuloServicio.ObtenerLooUp(cadenaBuscar);
            base.ActualizarDatos(dgv, cadenaBuscar);
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            dgv.Columns["Codigo"].Visible = true;
            dgv.Columns["Codigo"].Width = 100;

            dgv.Columns["CodigoBarra"].Visible = true;
            dgv.Columns["CodigoBarra"].Width = 100;
            dgv.Columns["CodigoBarra"].HeaderText = "Codigo Barra";

            dgv.Columns["Descripcion"].Visible = true;
            dgv.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["Descripcion"].HeaderText = @"Descripción";

            //dgv.Columns["EliminadoStr"].Visible = true;
            //dgv.Columns["EliminadoStr"].Width = 100;
            //dgv.Columns["EliminadoStr"].HeaderText = "Eliminado";
            //dgv.Columns["EliminadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public override void dgvGrilla_KeyPress(object sender, KeyPressEventArgs e)
        {
            var letra = e.KeyChar.ToString();
            var mayuscula = letra.ToUpper();

            if (e.KeyChar == (char)Keys.Enter)
            {
                return;
            }

            if (e.KeyChar == (char)Keys.Space)
            {
                e.Handled = true;
                this.Close();
            }
            else
            {


                var li = (List<ArticuloVentaDto>)dgvGrilla.DataSource;


                //var INDEX = li.FindIndex(x => x.Apellido.Contains(e.KeyChar) || x.Apellido.Contains(mayuscula));

                // buscar la fila con la letra e.keychar
                // bucle
                var INDEX = li.FindIndex(x => x.Descripcion[0] == e.KeyChar || x.Descripcion[0] == mayuscula[0]);

                // Darle foco
                if (INDEX < 0)
                {
                    MessageBox.Show("Apellido no encontrado");
                    return;
                }
                dgvGrilla.Rows[INDEX].Selected = true;
            }
        }

    }

}
