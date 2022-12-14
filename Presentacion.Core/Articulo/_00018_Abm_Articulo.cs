using IServicio.Articulo;
using IServicio.Marca;
using IServicio.Rubro;
using PresentacionBase.Formularios;
using static Aplicacion.Constantes.Imagen;
using StructureMap;
using IServicio.Articulo.DTOs;
using System.Windows.Forms;
using Aplicacion.Constantes;
using IServicios.Articulo.DTOs;
using System;
using static Aplicacion.Constantes.Clases.ValidacionDatosEntrada;
using System.Drawing;

namespace Presentacion.Core.Articulo
{
    public partial class _00018_Abm_Articulo : FormAbm
    {
        private readonly IArticuloServicio _articuloServicio;
        private readonly IMarcaServicio _marcaServicio;
        private readonly IRubroServicio _rubroServicio;
        public _00018_Abm_Articulo(TipoOperacion tipoOperacion, long? entidadId = null)
        : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            //===============   Eliminar Parte de arriba del formulario   =======================
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            _articuloServicio = ObjectFactory.GetInstance<IArticuloServicio>();
            _marcaServicio = ObjectFactory.GetInstance<IMarcaServicio>();
            _rubroServicio = ObjectFactory.GetInstance<IRubroServicio>();

            imgFoto.Image = ImagenProductoPorDefecto;

            PoblarComboBox(cmbMarca, _marcaServicio.Obtener(string.Empty,false), "Descripcion", "Id");
            PoblarComboBox(cmbRubro, _rubroServicio.Obtener(string.Empty, false), "Descripcion", "Id");

            AsignarEvento_EnterLeave(this);

            ValidarDatos();
        }

        private void ValidarDatos()
        {
            txtCodigo.KeyPress += delegate (object sender, KeyPressEventArgs args)
            {
                NoInyeccion(sender, args);
                NoSimbolos(sender, args);
                NoLetras(sender, args);
            };
            txtDescripcion.KeyPress += delegate (object sender, KeyPressEventArgs args)
            {
                NoInyeccion(sender, args);
                NoSimbolos(sender, args);
            };
            txtAbreviatura.KeyPress += delegate (object sender, KeyPressEventArgs args)
            {
                NoInyeccion(sender, args);
                NoSimbolos(sender, args);
            };
            txtUbicacion.KeyPress += delegate (object sender, KeyPressEventArgs args)
            {
                NoInyeccion(sender, args);
                NoSimbolos(sender, args);
            }; 
        }

        public override void CargarDatos(long? entidadId)
        {
            base.CargarDatos(entidadId);

            if (entidadId.HasValue)
            {
                groupPrecio.Enabled = true;
                nudStock.Enabled = true;

                var resultado = (ArticuloDto)_articuloServicio.Obtener(entidadId.Value);
                if (resultado == null)
                {
                    MessageBox.Show("Ocurrio un error al obtener el registro seleccionado");
                    Close();
                }
                // ==================================================== //
                // =============== Datos del Articulo ========== //
                // ==================================================== //
                txtCodigo.Text = resultado.Codigo.ToString();
                txtDescripcion.Text = resultado.Descripcion;
                txtAbreviatura.Text = resultado.Abreviatura;
                txtDetalle.Text = resultado.Detalle;
                txtUbicacion.Text = resultado.Ubicacion;
                cmbMarca.SelectedValue = resultado.MarcaId;
                cmbRubro.SelectedValue = resultado.RubroId;
                nudPrecioCosto.Value = resultado.PrecioCosto;
                
                // ==================================================== //
                // =============== Foto del Articulo ========== //
                // ==================================================== //
                imgFoto.Image = Imagen.ConvertirImagen(resultado.Foto);
                if (TipoOperacion == TipoOperacion.Eliminar)
                    DesactivarControles(this);

                // ==================================================== //
                // =============== Calcular Stock Depositos  ========== //
                // ==================================================== //
                //nudStock.Value = resultado.Stocks;
                nudStockMinimo.Value = resultado.StockMinimo;
                nudStock.Value = resultado.Stock;
                nudPrecioCosto.Value = resultado.PrecioCosto;
                nudPrecioVenta.Value = resultado.PrecioVenta;
                nudPGanancia.Value = resultado.PorcentajeGanancia;

                chkStockNegativo.Checked = resultado.PermiteStockNegativo;
            }
            else // Nuevo
            {
                btnEjecutar.Text = "Grabar";
                LimpiarControles(this);
            }

        }

        public override bool VerificarDatosObligatorios()
        {

            if (string.IsNullOrEmpty(txtCodigo.Text)) 
                return false;

            if (string.IsNullOrEmpty(txtDescripcion.Text))
                return false;

            if (cmbMarca.Items.Count <= 0)
                return false;

            if (cmbRubro.Items.Count <= 0)
                return false;

            return true;
        }

        public override bool VerificarSiExiste(long? id = null)
        {
            return _articuloServicio.VerificarSiExiste(txtDescripcion.Text);
        }

        
        public override void EjecutarComandoNuevo()
        {
            var nuevoRegistro = new ArticuloCrudDto
            {
                Codigo = int.Parse(txtCodigo.Text),
                CodigoBarra = txtCodigo.Text,
                Descripcion = txtDescripcion.Text,
                Abreviatura = txtAbreviatura.Text,
                Detalle = txtDetalle.Text,
                Ubicacion = txtUbicacion.Text,
                MarcaId = (long)cmbMarca.SelectedValue,
                RubroId = (long)cmbRubro.SelectedValue,
                StockMinimo = nudStockMinimo.Value,

                PrecioCosto = nudPrecioCosto.Value,
                Stock = (int)nudStock.Value,
                PrecioVenta = nudPrecioVenta.Value,
                PorcentajeGanancia = nudPGanancia.Value,
               
                //------------------------------------------------//
                StockActual = nudStock.Value,
                PermiteStockNegativo = chkStockNegativo.Checked,
                //------------------------------------------------//
                Foto = Imagen.ConvertirImagen(imgFoto.Image),
                Eliminado = false
                
                
            };
            _articuloServicio.Insertar(nuevoRegistro);
            
        }

        public override void EjecutarComandoModificar()
        {
            var modificarRegistro = new ArticuloCrudDto
            {
                Id = EntidadId.Value,
                Codigo = int.Parse(txtCodigo.Text),
                CodigoBarra = txtCodigo.Text,
                Descripcion = txtDescripcion.Text,
                Abreviatura = txtAbreviatura.Text,
                Detalle = txtDetalle.Text,
                Ubicacion = txtUbicacion.Text,
                MarcaId = (long)cmbMarca.SelectedValue,
                RubroId = (long)cmbRubro.SelectedValue,
                PrecioCosto = nudPrecioCosto.Value,
                Stock = (int)nudStock.Value,
                PrecioVenta = nudPrecioVenta.Value,
                PorcentajeGanancia = nudPGanancia.Value,
                //------------------------------------------------//
                StockActual = nudStock.Value,
                StockMinimo = nudStockMinimo.Value,
                PermiteStockNegativo = chkStockNegativo.Checked,
                //------------------------------------------------//
                Foto = Imagen.ConvertirImagen(imgFoto.Image),
                Eliminado = false
            };
            _articuloServicio.Modificar(modificarRegistro);
        }

        public override void EjecutarComandoEliminar()
        {
            _articuloServicio.Eliminar(EntidadId.Value);
        }

        public override void LimpiarControles(object obj, bool tieneValorAsociado = false)
        {
            base.LimpiarControles(obj, tieneValorAsociado);
            txtCodigo.Text = _articuloServicio.ObtenerSiguienteNroCodigo().ToString();
            txtDescripcion.Focus();
        }

        private void btnNuevaMarca_Click(object sender, EventArgs e)
        {
            var fNuevaMarca = new _00022_Abm_Marca(TipoOperacion.Nuevo);
            fNuevaMarca.ShowDialog();
            if (fNuevaMarca.RealizoAlgunaOperacion)
            {
                PoblarComboBox(cmbMarca, _marcaServicio.Obtener(string.Empty, false));
            }
        }

        private void btnNuevoRubro_Click(object sender, EventArgs e)
        {
            var fNuevoRubro = new _00020_Abm_Rubro(TipoOperacion.Nuevo);
            fNuevoRubro.ShowDialog();
            if (fNuevoRubro.RealizoAlgunaOperacion)
            {
                PoblarComboBox(cmbRubro, _rubroServicio.Obtener(string.Empty, false));
            }
        }

        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            var openFile = new OpenFileDialog();
            openFile.ShowDialog();
            imgFoto.Image = string.IsNullOrEmpty(openFile.FileName)
            ? ImagenProductoPorDefecto
            : Image.FromFile(openFile.FileName);
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void nudStock_ValueChanged(object sender, EventArgs e)
        {

        }

        private void CalcularPrecioVenta() 
        {
            //var PrecioVenta = nudPrecioCosto.Value + ((nudPGanancia.Value * 100) / nudPrecioCosto.Value);


            var PrecioVenta = nudPrecioCosto.Value + ((nudPGanancia.Value * nudPrecioCosto.Value) / 100);

            // Redodiar Valor
            if (chkRedondear.Checked)
            {
                nudPrecioVenta.Value = Math.Round(PrecioVenta);
            }
            else
            {
                nudPrecioVenta.Value = PrecioVenta;
            }
            
        }

        private void nudPGanancia_ValueChanged(object sender, EventArgs e)
        {
            CalcularPrecioVenta();
        }

        private void chkRedondear_CheckedChanged(object sender, EventArgs e)
        {
            CalcularPrecioVenta();
        }

        private void nudPrecioCosto_ValueChanged(object sender, EventArgs e)
        {
            CalcularPrecioVenta();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void chkStockNegativo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkStockNegativo.Checked)
            {
                nudStock.Value = 0;
                nudStock.Enabled = false;
            }
            else
            {
                nudStock.Enabled = true;
            }
        }
    }
}
