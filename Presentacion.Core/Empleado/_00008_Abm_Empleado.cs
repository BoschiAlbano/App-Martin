using IServicio.Departamento;
using IServicio.Localidad;
using IServicio.Persona;
using IServicio.Provincia;
using PresentacionBase.Formularios;
using StructureMap;
using System;
using static Aplicacion.Constantes.Clases.ValidacionDatosEntrada;
using System.Windows.Forms;
using static Aplicacion.Constantes.Imagen;
using IServicio.Persona.DTOs;
using System.Drawing;
using Presentacion.Core.Provincia;
using Presentacion.Core.Departamento;
using Presentacion.Core.Localidad;

namespace Presentacion.Core.Empleado
{
    public partial class _00008_Abm_Empleado : FormAbm
    {

        private readonly IEmpleadoServicio _EmpleadoServicio;
        private readonly IProvinciaServicio _ProvinciaServicio;
        private readonly IDepartamentoServicio _DepartamentoServicio;
        private readonly ILocalidadServicio _LocalidadServicio;


        public _00008_Abm_Empleado(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            //===============   Eliminar Parte de arriba del formulario   =======================
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            _EmpleadoServicio = ObjectFactory.GetInstance<IEmpleadoServicio>();
            _ProvinciaServicio = ObjectFactory.GetInstance<IProvinciaServicio>();
            _DepartamentoServicio = ObjectFactory.GetInstance<IDepartamentoServicio>();
            _LocalidadServicio = ObjectFactory.GetInstance<ILocalidadServicio>();

            imgFoto.Image = ImagenEmpleadoPorDefecto;

            txtLegajo.Enabled = false;

            AsignarEvento_EnterLeave(this);

            ValidarDatos();

        }
        // metodo privado
        private void ValidarDatos()
        {
            txtApellido.KeyPress += delegate (object sender, KeyPressEventArgs args)
            {
                NoInyeccion(sender, args);
                NoSimbolos(sender, args);
                NoNumeros(sender, args);
            };
            txtNombre.KeyPress += delegate (object sender, KeyPressEventArgs args)
            {
                NoInyeccion(sender, args);
                NoSimbolos(sender, args);
                NoNumeros(sender, args);
            };
            txtDni.KeyPress += delegate (object sender, KeyPressEventArgs args)
            {
                NoInyeccion(sender, args);
                NoSimbolos(sender, args);
                NoLetras(sender, args);
            };
            txtDomicilio.KeyPress += delegate (object sender, KeyPressEventArgs args)
            {
                NoInyeccion(sender, args);
                NoSimbolos(sender, args);
            };
            //txtMail.KeyPress += delegate (object sender, KeyPressEventArgs args)
            //{
            //    NoInyeccion(sender, args);
            //    var Mail = ValidarEmail(txtMail.Text, null, txtMail);
            //};

        }

        // Cargar Datos
        public override void CargarDatos(long? entidadId)
        {
            base.CargarDatos(entidadId);

            

            if (entidadId.HasValue) // modificar o Eliminar
            {
                var empleado = (EmpleadoDto)_EmpleadoServicio.Obtener(typeof(EmpleadoDto), entidadId.Value);

                txtLegajo.Text = empleado.Legajo.ToString();
                txtApellido.Text = empleado.Apellido;
                txtNombre.Text = empleado.Nombre;
                txtDni.Text = empleado.Dni;
                txtTelefono.Text = empleado.Telefono;
                txtDomicilio.Text = empleado.Direccion;
                txtMail.Text = empleado.Mail;
                imgFoto.Image = ConvertirImagen(empleado.Foto);

                if (TipoOperacion == TipoOperacion.Eliminar)
                    DesactivarControles(this);

                // Provincias
                var Provincias = _ProvinciaServicio.Obtener(string.Empty, false);
                PoblarComboBox(cmbProvincia, Provincias, "Descripcion", "Id");
                cmbProvincia.SelectedValue = empleado.ProvinciaId;

                // Departamentos
                var Departamentos = _DepartamentoServicio.ObtenerPorProvincia((long)cmbProvincia.SelectedValue);
                PoblarComboBox(cmbDepartamento, Departamentos, "Descripcion", "Id");
                cmbDepartamento.SelectedValue = empleado.DepartamentoId;

                // Localidades
                var Localidades = _LocalidadServicio.ObtenerPorDepartamento((long)cmbDepartamento.SelectedValue);
                PoblarComboBox(cmbLocalidad, Localidades, "Descripcion", "Id");
                cmbLocalidad.SelectedValue = empleado.LocalidadId;

            }
            else // nuevo
            {
                // Provincias
                var Provincias = _ProvinciaServicio.Obtener(string.Empty, false);
                if (Provincias == null)
                    cmbProvincia.Text = "No Existen Provincias";
                PoblarComboBox(cmbProvincia, Provincias, "Descripcion", "Id");

                // Departamentos
                var Departamentos = _DepartamentoServicio.ObtenerPorProvincia((long)cmbProvincia.SelectedValue);
                if (Departamentos == null)
                    cmbProvincia.Text = "No Existen Departamentos";
                PoblarComboBox(cmbDepartamento, Departamentos, "Descripcion", "Id");

                // Localidades
                var Localidades = _LocalidadServicio.ObtenerPorDepartamento((long)cmbDepartamento.SelectedValue);
                if (Localidades == null)
                    cmbProvincia.Text = "No Existen Localidades";
                PoblarComboBox(cmbLocalidad, Localidades, "Descripcion", "Id");

                LimpiarControles(this);
                // buscamos el siguiente numero de legajo
                txtLegajo.Text = _EmpleadoServicio.ObtenerSiguienteLegajo().ToString();
                txtApellido.Focus();
            }

        }

        // Verificar
        public override bool VerificarDatosObligatorios()
        {
            if (string.IsNullOrEmpty(txtLegajo.Text)) 
            {
                MessageBox.Show("Error, No Existe Legajo");
                return false;
            }

            if (string.IsNullOrEmpty(txtApellido.Text))
                return false;
            if (string.IsNullOrEmpty(txtNombre.Text))
                return false;
            if (string.IsNullOrEmpty(txtDni.Text))
                return false;
            if (string.IsNullOrEmpty(txtDomicilio.Text))
                return false;
            if (string.IsNullOrEmpty(txtTelefono.Text))
                return false;
            if (string.IsNullOrEmpty(txtMail.Text))
                return false;

            if (cmbProvincia.Items.Count <= 0)
                return false;
            if (cmbDepartamento.Items.Count <= 0)
                return false;
            if (cmbLocalidad.Items.Count <= 0)
                return false;

            return true;
        }
        public override bool VerificarSiExiste(long? id = null)
        {
            return false;
        }

        // Limpiar
        public override void LimpiarControles(object obj, bool tieneValorAsociado = false)
        {
            txtApellido.Clear();
            txtNombre.Clear();
            txtDni.Clear();
            txtDomicilio.Clear();
            txtTelefono.Clear();
            txtMail.Clear();
            imgFoto.Image = ImagenEmpleadoPorDefecto;
        }

        // Ejecutar comandos
        public override void EjecutarComandoNuevo()
        {
            _EmpleadoServicio.Insertar(new EmpleadoDto
            {
                Legajo = int.Parse(txtLegajo.Text),
                Apellido = txtApellido.Text,
                Nombre = txtNombre.Text,
                Dni = txtDni.Text,
                Telefono = txtTelefono.Text,
                Direccion = txtDomicilio.Text,
                Mail = txtMail.Text,

                ProvinciaId = (long)cmbProvincia.SelectedValue,
                DepartamentoId = (long)cmbDepartamento.SelectedValue,
                LocalidadId = (long)cmbLocalidad.SelectedValue,

                Foto = ConvertirImagen(imgFoto.Image),
            });

            txtLegajo.Text = _EmpleadoServicio.ObtenerSiguienteLegajo().ToString();
            txtApellido.Focus();
        }
        public override void EjecutarComandoModificar()
        {
            _EmpleadoServicio.Modificar(new EmpleadoDto
            {
                Id = EntidadId.Value,
                Legajo = int.Parse(txtLegajo.Text),
                Apellido = txtApellido.Text,
                Nombre = txtNombre.Text,
                Dni = txtDni.Text,
                Telefono = txtTelefono.Text,
                Direccion = txtDomicilio.Text,
                Mail = txtMail.Text,

                ProvinciaId = (long)cmbProvincia.SelectedValue,
                DepartamentoId = (long)cmbDepartamento.SelectedValue,
                LocalidadId = (long)cmbLocalidad.SelectedValue,

                Foto = ConvertirImagen(imgFoto.Image),
            });
        }
        public override void EjecutarComandoEliminar()
        {
            _EmpleadoServicio.Eliminar(typeof(EmpleadoDto),EntidadId.Value);
        }

        // Eventos
        private void cmbProvincia_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbProvincia.Items.Count > 0)
            {
                var Departamentos = _DepartamentoServicio.ObtenerPorProvincia((long)cmbProvincia.SelectedValue);
                PoblarComboBox(cmbDepartamento, Departamentos, "Descripcion", "Id");

                if (cmbDepartamento.Items.Count > 0)
                {
                    var Localidades = _LocalidadServicio.ObtenerPorDepartamento((long)cmbDepartamento.SelectedValue);
                    PoblarComboBox(cmbLocalidad, Localidades, "Descripcion", "Id");
                }

            }

        }
        private void cmbDepartamento_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbDepartamento.Items.Count > 0)
            {
                var Localidades = _LocalidadServicio.ObtenerPorDepartamento((long)cmbDepartamento.SelectedValue);
                PoblarComboBox(cmbLocalidad, Localidades, "Descripcion", "Id");
            }
        }

        // Botones
        private void btnImagen_Click(object sender, EventArgs e)
        {
            var openFile = new OpenFileDialog();
            openFile.ShowDialog();
            imgFoto.Image = string.IsNullOrEmpty(openFile.FileName)
            ? ImagenProductoPorDefecto
            : Image.FromFile(openFile.FileName);
        }
        private void btnNuevaProvincia_Click(object sender, EventArgs e)
        {
            var formulario = new _00002_Abm_Provincia(TipoOperacion.Nuevo);
            formulario.ShowDialog();

            if (formulario.RealizoAlgunaOperacion)
            {
                PoblarComboBox(cmbProvincia,_ProvinciaServicio.Obtener(string.Empty, false), "Descripcion","Id");

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
        private void btnNuevoDepartamento_Click(object sender, EventArgs e)
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
        private void btnNuevaLocalidad_Click(object sender, EventArgs e)
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
    }
}
