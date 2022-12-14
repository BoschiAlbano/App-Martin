using IServicio.Articulo;
using IServicio.Articulo.DTOs;
using IServicio.Marca;
using IServicio.Rubro;
using IServicios.Precio;
using PresentacionBase.Formularios;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Presentacion.Core.Reportes
{
    public partial class ReporteArticuloCapital : FormBase
    {

        private List<ArticuloDto> Articulos;
        private IArticuloServicio _ArticuloServicio;
        private List<int> _Items = new List<int>();
        private bool _Listar;

        private readonly IRubroServicio _RubroServicio;
        private readonly IMarcaServicio _MarcaServicio;
        private readonly IPrecioServicio _PrecioServicio;

        public ReporteArticuloCapital()
        {
            InitializeComponent();

            _ArticuloServicio = ObjectFactory.GetInstance<IArticuloServicio>();
            _RubroServicio = ObjectFactory.GetInstance<IRubroServicio>();
            _MarcaServicio = ObjectFactory.GetInstance<IMarcaServicio>();
            _PrecioServicio = ObjectFactory.GetInstance<IPrecioServicio>();

            //_ArticuloServicio = articuloServicio;

            //===============   Eliminar Parte de arriba del formulario   =======================
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            CargarComboBox();
        }

        private void CargarComboBox()
        {
            PoblarComboBox(cmbRubro, _RubroServicio.Obtener(string.Empty, false), "Descripcion", "Id");
            PoblarComboBox(cmbMarca, _MarcaServicio.Obtener(string.Empty, false), "Descripcion", "Id");

            CargarArticulos();
        }

        public ReporteArticuloCapital(bool Lista)
        : this()
        {
            _Listar = Lista;
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


        private void ReporteArticuloCapital_Load(object sender, EventArgs e)
        {
            CargarArticulos();
            
        }

        private void CargarArticulos()
        {
            long? marcaId = null;
            long? rubroId = null;

            //marca
            if (chkMarca.Checked)
            {
                marcaId = (long)cmbMarca.SelectedValue;
            }

            // rubro
            if (chkRubro.Checked)
            {
                rubroId = (long)cmbRubro.SelectedValue;
            }

            //Articulos = (List<ArticuloDto>)_ArticuloServicio.Obtener("", false);
            Articulos = (List<ArticuloDto>)_PrecioServicio.BuscarArticulos(0, false, marcaId, rubroId);
            dgvGrilla.DataSource = Articulos.ToList();


            if (_Listar)
            {
                FormatearGrillaLista(dgvGrilla);
            }
            else
            {
                FormatearGrilla(dgvGrilla);
            }
            

            // marcar con rojo los art de la grilla con la lista de items

            if (_Items.Count <= 0) 
            {
                return;
            }

            foreach (var i in _Items)
            {

                var Index = ((List<ArticuloDto>)dgvGrilla.DataSource).FindIndex(x => x.Id == i);

                dgvGrilla.Rows[Index].DefaultCellStyle.BackColor = Color.FromArgb(255, 192, 192);
            }

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

            dgv.Columns["Stock"].Visible = true;
            dgv.Columns["Stock"].Width = 100;
            dgv.Columns["Stock"].HeaderText = "Cantidad";
            dgv.Columns["Stock"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["Stock"].DisplayIndex = 2;

            dgv.Columns["PrecioCosto"].Visible = true;
            dgv.Columns["PrecioCosto"].Width = 150;
            dgv.Columns["PrecioCosto"].HeaderText = "Precio Costo";
            dgv.Columns["PrecioCosto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["PrecioCosto"].DisplayIndex = 3;

            dgv.Columns["Eliminar"].Visible = true;
            dgv.Columns["Eliminar"].Width = 75;
            dgv.Columns["Eliminar"].HeaderText = "Eliminar";
            dgv.Columns["Eliminar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["Eliminar"].DisplayIndex = 4;

            dgv.Columns["Agregar"].Visible = true;
            dgv.Columns["Agregar"].Width = 75;
            dgv.Columns["Agregar"].HeaderText = "Agregar";
            dgv.Columns["Agregar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["Agregar"].DisplayIndex = 5;

        }
        public void FormatearGrillaLista(DataGridView dgv)
        {
            for (int i = 0; i < dgv.ColumnCount; i++)
            {
                dgv.Columns[i].Visible = false;
                dgv.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dgv.Columns["Descripcion"].Visible = true;
            dgv.Columns["Descripcion"].HeaderText = @"Descripcion";
            dgv.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["Descripcion"].DisplayIndex = 1;

            dgv.Columns["PrecioVenta"].Visible = true;
            dgv.Columns["PrecioVenta"].Width = 150;
            dgv.Columns["PrecioVenta"].HeaderText = "Precio";
            dgv.Columns["PrecioVenta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["PrecioVenta"].DisplayIndex = 3;

            dgv.Columns["Eliminar"].Visible = true;
            dgv.Columns["Eliminar"].Width = 75;
            dgv.Columns["Eliminar"].HeaderText = "Eliminar";
            dgv.Columns["Eliminar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["Eliminar"].DisplayIndex = 4;

            dgv.Columns["Agregar"].Visible = true;
            dgv.Columns["Agregar"].Width = 75;
            dgv.Columns["Agregar"].HeaderText = "Agregar";
            dgv.Columns["Agregar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["Agregar"].DisplayIndex = 5;

        }
        private void btnImprimir_Click(object sender, EventArgs e)
        {

            // Eliminar Articulos con los indices en _items
            foreach (var id in _Items)
            {

                Articulos.RemoveAll(x => x.Id == id);

            }


            // Voy a ReporteArticulos o ReporteArticuloLista ?
            if (_Listar)
            {
                var _Abrir = new ReporteArticuloLista(Articulos);
                _Abrir.ShowDialog();
            }
            else
            {
                var _Abrir = new ReporteArticulo(Articulos);
                _Abrir.ShowDialog();
            }
            

            CargarArticulos(); // Cargo de nuevo los articulos.

        }

        private void dgvGrilla_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvGrilla.Columns[e.ColumnIndex].Name == "Eliminar")
            {
                var Id = Convert.ToInt32(dgvGrilla.CurrentRow.Cells["Id"].Value);

                // Color en Grilla
                //var Index = ((List<ArticuloDto>)dgvGrilla.DataSource).FindIndex(x => x.Id == Id);
                //dgvGrilla.Rows[Index].DefaultCellStyle.BackColor = Color.FromArgb(255, 192, 192);

                // Eliminar de Artiulos
                dgvGrilla.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 192, 192);
                _Items.Add(Id);

            }
            else if (dgvGrilla.Columns[e.ColumnIndex].Name == "Agregar")
            {
                var Id = Convert.ToInt32(dgvGrilla.CurrentRow.Cells["Id"].Value);

                // Eliminar de Articulos - bloquear en la grilla
                //var Index = ((List<ArticuloDto>)dgvGrilla.DataSource).FindIndex(x => x.Id == Id);
                //dgvGrilla.Rows[Index].DefaultCellStyle.BackColor = Color.FromArgb(235, 243, 245);

                dgvGrilla.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(235, 243, 245);


                if (_Items.Count <= 0)
                {
                    return;
                }
                var buscar = _Items.FindIndex(x => x == Id);
                _Items.RemoveAt(buscar);
            }


        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            _Items = new List<int>();
            CargarArticulos();
            
        }
    }

}

