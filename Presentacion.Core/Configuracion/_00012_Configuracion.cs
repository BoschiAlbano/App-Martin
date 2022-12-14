using Aplicacion.Constantes;
using IServicio.Configuracion;
using IServicio.Configuracion.DTOs;
using IServicio.Departamento;
using IServicio.Deposito;
using IServicio.ListaPrecio;
using IServicio.Localidad;
using IServicio.Localidad.DTOs;
using IServicio.Provincia;
using static Aplicacion.Constantes.Imagen;
using Aplicacion.Constantes;
using Presentacion.Core.Articulo;
using Presentacion.Core.Departamento;
using Presentacion.Core.Deposito;
using Presentacion.Core.Localidad;
using Presentacion.Core.Provincia;
using PresentacionBase.Formularios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static Aplicacion.Constantes.Clases.ValidacionDatosEntrada;
using IServicios.Articulo.DTOs;
using IServicio.Articulo;

namespace Presentacion.Core.Configuracion
{
    public partial class _00012_Configuracion : FormBase
    {
        private readonly IProvinciaServicio _ProvinciaServicio;
        private readonly IDepartamentoServicio _DepartamentoServicio;
        private readonly ILocalidadServicio _LocalidadServicio;
        private readonly IConfiguracionServicio _ConfiguracionServicio;
        private readonly IListaPrecioServicio _ListaPrecioServicio;
        private readonly IArticuloServicio _articuloServicio;

        private ConfiguracionDto _Configuracion;

        public _00012_Configuracion(IProvinciaServicio provinciaServicio, IDepartamentoServicio departamentoServicio
            ,ILocalidadServicio localidadServicio, IConfiguracionServicio configuracionServicio
            , IListaPrecioServicio listaPrecioServicio, IArticuloServicio articuloServicio)
        {
            InitializeComponent();

            //===============   Eliminar Parte de arriba del formulario   =======================
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            _ProvinciaServicio = provinciaServicio;
            _DepartamentoServicio = departamentoServicio;
            _LocalidadServicio = localidadServicio;
            _ConfiguracionServicio = configuracionServicio;
            _ListaPrecioServicio = listaPrecioServicio;
            _articuloServicio = articuloServicio;

            // Metodo para colorear el foco del txtbox
            AsignarEvento_EnterLeave(this);

            ValidarDatosEntrada();

        }

        private void ValidarDatosEntrada()
        {
            // asignamos eventos a los txtbox

            txtCUIL.KeyPress += delegate (object sender, KeyPressEventArgs args)
            {
                NoInyeccion(sender, args);
                NoSimbolos(sender, args);
                NoLetras(sender, args);
            };

            txtTelefono.KeyPress += delegate (object sender, KeyPressEventArgs args)
            {
                NoInyeccion(sender, args);
                NoSimbolos(sender, args);
                NoLetras(sender, args);
            };

            txtCelular.KeyPress += delegate (object sender, KeyPressEventArgs args)
            {
                NoInyeccion(sender, args);
                NoSimbolos(sender, args);
                NoLetras(sender, args);
            };
        }

        private void _00012_Configuracion_Load(object sender, EventArgs e)
        {
            _Configuracion = _ConfiguracionServicio.Obtener();

            if (_Configuracion != null)
            {
                // Modificar
                _Configuracion.EsPrimeraVez = false;
                chkCargarPrimeraVEz.Enabled = false;
                // ----------   Datos de la empresa ----------

                txtRazonSocial.Text = _Configuracion.RazonSocial;
                txtNombreFantasia.Text = _Configuracion.NombreFantasia;
                txtCUIL.Text = _Configuracion.Cuit;
                txtTelefono.Text = _Configuracion.Telefono;
                txtCelular.Text = _Configuracion.Celular;
                txtDireccion.Text = _Configuracion.Direccion;

                // ----------   Configuracion del sistema ----------
                ChbPendientePago.Checked = _Configuracion.PuestoCajaSeparado;

                PoblarComboBox(cmbProvincia, _ProvinciaServicio.Obtener(string.Empty, false), "Descripcion", "Id");
                cmbProvincia.SelectedValue = _Configuracion.ProvinciaId;

                PoblarComboBox(cmbDepartamento, _DepartamentoServicio.ObtenerPorProvincia(_Configuracion.ProvinciaId), "Descripcion", "Id");
                cmbDepartamento.SelectedValue = _Configuracion.DepartamentoId;

                PoblarComboBox(cmbLocalidad, _LocalidadServicio.ObtenerPorDepartamento(_Configuracion.DepartamentoId), "Descripcion", "Id");
                cmbLocalidad.SelectedValue = _Configuracion.LocalidadId;

                txtEmail.Text = _Configuracion.Email;

            }
            else
            {
                chkCargarPrimeraVEz.Enabled = true;
                
                // Nuevo
                _Configuracion = new ConfiguracionDto();
                _Configuracion.EsPrimeraVez = true;

                LimpiarControles(this);

                var _provincias = _ProvinciaServicio.Obtener(string.Empty, false);
                PoblarComboBox(cmbProvincia, _provincias, "Descripcion", "Id");

                if (_provincias.Any())
                {
                    var _departamentos = _DepartamentoServicio.ObtenerPorProvincia((long)cmbProvincia.SelectedValue);
                    PoblarComboBox(cmbDepartamento, _departamentos, "Descripcion", "Id");

                    if (_departamentos.Any())
                    {
                        var _localidades = _LocalidadServicio.ObtenerPorDepartamento((long)cmbDepartamento.SelectedValue);
                        PoblarComboBox(cmbLocalidad, _localidades, "Descripcion", "Id");
                    }
                }

                txtRazonSocial.Focus();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro que desea limpiar los datos"
                ,"Atencion"
                ,MessageBoxButtons.OKCancel
                ,MessageBoxIcon.Question) == DialogResult.OK)
            {
                LimpiarControles(this);
            }
        }
        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            if (chkCargarPrimeraVEz.Checked == true)
            {
                CargarLista();
            }

            if (VerificarDatosObligatorios())
            {
                // ----------   Datos de la empresa ----------

                _Configuracion.RazonSocial = txtRazonSocial.Text;
                _Configuracion.NombreFantasia = txtNombreFantasia.Text;
                _Configuracion.Cuit = txtCUIL.Text;
                _Configuracion.Telefono = txtTelefono.Text;
                _Configuracion.Celular = txtCelular.Text;
                _Configuracion.Direccion = txtDireccion.Text;
                _Configuracion.LocalidadId = (long)cmbLocalidad.SelectedValue;
                _Configuracion.Email = txtEmail.Text;

                _Configuracion.PuestoCajaSeparado = ChbPendientePago.Checked;

                _ConfiguracionServicio.Grabar(_Configuracion);

                MessageBox.Show("Los datos se grabaron Correctamente");
                Close();

            }
            else
            {
                MessageBox.Show("Por Favor, Ingrese los datos Obligatorios");
            }
        }

        private bool VerificarDatosObligatorios()
        {
            if (string.IsNullOrEmpty(txtRazonSocial.Text))
                return false;

            if (string.IsNullOrEmpty(txtCUIL.Text))
                return false;

            if (string.IsNullOrEmpty(txtDireccion.Text))
                return false;

            if (cmbLocalidad.Items.Count <= 0)
                return false;

            if (cmbDepartamento.Items.Count <= 0)
                return false;

            if (cmbProvincia.Items.Count <= 0)
                return false;

            return true;
        }

        private void cmbProvincia_SelectionChangeCommitted(object sender, EventArgs e)
        {

            // provincia
            if (cmbProvincia.Items.Count <= 0) return;
            PoblarComboBox(cmbDepartamento, _DepartamentoServicio.ObtenerPorProvincia((long)cmbProvincia.SelectedValue), "Descripcion", "Id");

            if (cmbDepartamento.Items.Count <= 0) 
            {
                cmbLocalidad.DataSource = new List<LocalidadDto>();
                return;
            }
                
            PoblarComboBox(cmbLocalidad, _LocalidadServicio.ObtenerPorDepartamento((long)cmbDepartamento.SelectedValue), "Descripcion", "Id");


        }
        private void cmbDepartamento_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // Departamento
            if (cmbDepartamento.Items.Count <= 0) return;
            PoblarComboBox(cmbLocalidad, _LocalidadServicio.ObtenerPorDepartamento((long)cmbDepartamento.SelectedValue), "Descripcion", "Id");


        }

        private void btnAddProvincia_Click(object sender, EventArgs e)
        {
            var formulario = new _00002_Abm_Provincia(TipoOperacion.Nuevo);
            formulario.ShowDialog();

            if (formulario.RealizoAlgunaOperacion)
            {
                PoblarComboBox(cmbProvincia, _ProvinciaServicio.Obtener(string.Empty, false), "Descripcion", "Id");

                if (cmbProvincia.Items.Count > 0)
                {
                    PoblarComboBox(cmbDepartamento, _DepartamentoServicio.ObtenerPorProvincia((long)cmbProvincia.SelectedValue), "Descripcion", "Id");

                    if (cmbDepartamento.Items.Count > 0)
                    {
                        PoblarComboBox(cmbLocalidad, _LocalidadServicio.ObtenerPorDepartamento((long)cmbDepartamento.SelectedValue), "Descripcion", "Id");
                    }
                }
            }
        }
        private void btnAddDepartamento_Click(object sender, EventArgs e)
        {
            var formulario = new _00004_Abm_Departamento(TipoOperacion.Nuevo);
            formulario.ShowDialog();

            if (formulario.RealizoAlgunaOperacion)
            {
                if (cmbProvincia.Items.Count > 0)
                {
                    PoblarComboBox(cmbDepartamento, _DepartamentoServicio.ObtenerPorProvincia((long)cmbProvincia.SelectedValue), "Descripcion", "Id");

                    if (cmbDepartamento.Items.Count > 0)
                    {
                        PoblarComboBox(cmbLocalidad, _LocalidadServicio.ObtenerPorDepartamento((long)cmbDepartamento.SelectedValue), "Descripcion", "Id");
                    }
                }
            }
        }
        private void btnAddLocalidad_Click(object sender, EventArgs e)
        {
            var formulario = new _00006_AbmLocalidad(TipoOperacion.Nuevo);
            formulario.ShowDialog();

            if (formulario.RealizoAlgunaOperacion)
            {
                if (cmbDepartamento.Items.Count > 0)
                {
                    PoblarComboBox(cmbLocalidad, _LocalidadServicio.ObtenerPorDepartamento((long)cmbDepartamento.SelectedValue), "Descripcion", "Id");
                }
            }
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


        // **********  Cargar Articulos  ***********

        private void CargarLista()
        {
            // LISTA DE 149 PRODUCTOS
            string[] Productos = {
                "",// Cigarrillos
                "PIER ROJO",
                "PIER VERDE",
                "RED POINT",
                "MASTER",
                "MELBOURNE",
                "DOLCHESTER",
                "BOXER",
                "BOXER VERDE",
                "LIVERPOOL",
                "MILENIO",
                "MILENIO CLIK",
                "BAISHA",
                "PARLMT",
                "LyM",
                "M 20",
                "M BOX",
                "M 10",
                "M FUSION",
                "PM 20",
                "PM 10",
                "PM BOX",
                "PM CAPS BOX",
                "PM CAPS 10",
                "CH 20",
                "CH 10",
                "CH FRESH 20",
                "CH FRESH 10",
                "CH UVA",
                "LUCKY 20",
                "LUCKY 10",
                "PARISS",
                "",// Medicamentos
                "ACTRON 400 X 10",
                "ACTRON 600 X 10",
                "ACTRON MUJER X 10",
                "ACTRON PLUS X 8",
                "ALICAL X UNIDAD",
                "ALMAXIMO 50 GR",
                "AMOX + CLAVUL X 7",
                "AMOXICILIDA 500 X 7",
                "AMOXICILINA JARABE",
                "AMOXIDAL 500 X 8",
                "ASPIRINETA X 14",
                "AZITROMICINA X 3",
                "BAGO HEPAT X 10",
                "BAYASPIRINA C X 24",
                "BAYASPIRINA FORTE X 10",
                "BAYASPIRINA X 10",
                "BILETAN ENZIMATICO X 10",
                "BILETAN FORTE X 10",
                "BUSCAPINA COMP. X 10",
                "BUSCAPINA FEM. X 6",
                "BUSCAPINA PERLA X 10",
                "BYASPIRINA C CALIENTE",
                "CAFIASPIRINA PLUS X 10",
                "CAFIASPIRINA X 10",
                "CARAMELO TOS",
                "CARAMELO X 9",
                "CARBON ACTIVADO X 10",
                "CEFALEXINA 500 X 8",
                "CHICLE LAY X 6",
                "CINTAS ADECIVAS",
                "CIPROFLOXACINA X 10",
                "CLARITOMICINA",
                "CURA PLUS",
                "CURINFLAN 500 X 15",
                "CURITAS X 10",
                "DEXALERGIN X 20",
                "DEXAMETAZONA 05 X 10",
                "DICLOFENAC 75 X 15",
                "DICLORELAX",
                "DIPIRONA",
                "DORIXINA X 10",
                "DRISTAN X 10",
                "ENCENDEDOR CAND X 25",
                "FOCO LED 12 W",
                "FOCO LED 9 W",
                "FRASCO ESTERILIZADO",
                "GASAS X 10 UNID.",
                "GENIOL X 10",
                "IBU JRABE",
                "IBUEVANOL FORTE X 8",
                "IBUEVANOL MAX X 10",
                "IBUEVANOL PLUS X 10",
                "IBUEVANOL R. ACCION X 10",
                "IBUPROFENO 400 X 10",
                "IBUPROFENO 600 X 10",
                "JERINGA 5 O 10 ML",
                "KETEROLAC X 10",
                "ISU 600 CB",
                "PANTOPRAZOL",
                "TEST EMBARAZO",
                "ENALAPRIL",
                "NORFLAXACINA",
                "DIA DESPUES X 1",
                "ANTICONCEPTIVO X 21",
                "IBUPIRAC 600",
                "LOPERAMIDA X 10",
                "LORATADINA X 10",
                "MEJORAL P. NIÑO X 10",
                "MIGRAL COMP. X 10",
                "MILANTA X 8",
                "NEX X 10",
                "NOVALGINA X 10",
                "OMEPRAZOL X 15",
                "PANCLO B12 X 10",
                "PARACETAMOL",
                "PENICILINA 1 MILLON X 6",
                "PONSTIL X 5",
                "PRESERV. PRIME",
                "REFRIANEX X 10",
                "SERTAL COMP. X 10",
                "SERTAL PERLA X 10",
                "SINDOL",
                "TAFIROL 1 GR X 8",
                "TAFIROL 500 MG. X 10",
                "TAFIROL FORTE X 10",
                "TAFIROL MIGRA",
                "TAFIROL PLUS X 8",
                "TAFIROLITO",
                "TE VICK",
                "TETRALGIN X 10",
                "UVASAL",
                "",// Descartables
                "ROLLO 15 X 20",
                "ROLLO 15 X 25",
                "ROLLO 20 X 30",
                "ROLLO 25 X 35",
                "FOLEX 20 X 30",
                "FOLEX 20 X 25",
                "FOLEX 25 X 37",
                "MANIJA 30 X 40",
                "MANIJA 40 X 50",
                "MANIJA REFORZADA",
                "BLOCK 15 X 25",
                "BLOCK 20 X 30",
                "BLOCK 25 X 35",
                "BLOCK 30 X 40",
                "PAPEL GDE",
                "SORBETES",
                "BOLSAS CONDIMENTO",
                "B CONSORCIO",
                "B RESIDUO",
                "VASO 120 CC X 25",
                "VASO 180 CC X 50",
                "MANIJA 40 X 50",
                
            };

            int rubro = 1;

            for (int i = 1; i < Productos.Length + 1; i++)
            {
                if (Productos[i - 1] != "")
                {
                    var nuevoRegistro = new ArticuloCrudDto
                    {
                        Codigo = i,
                        CodigoBarra = i.ToString(),
                        Descripcion = Productos[i - 1],
                        Abreviatura = Productos[i - 1],
                        Detalle = "Sin Descripcion",
                        Ubicacion = "Sin Ubicacion",
                        MarcaId = 1,
                        RubroId = rubro,
                        StockMinimo = 0,

                        PrecioCosto = 0,
                        Stock = 0,
                        PrecioVenta = 0,
                        PorcentajeGanancia = 0,

                        //------------------------------------------------//
                        StockActual = 0,
                        //------------------------------------------------//
                        //Foto = Imagen.ConvertirImagen(imgFoto.Image),
                        Foto = Imagen.ConvertirImagen(ImagenProductoPorDefecto),
                        Eliminado = false


                    };
                    _articuloServicio.Insertar(nuevoRegistro);
                }
                else
                {
                    rubro += 1;
                }
                
            }
        }


    }
}
