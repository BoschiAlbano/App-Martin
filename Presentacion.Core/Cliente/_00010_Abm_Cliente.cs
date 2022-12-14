using IServicio.Departamento;
using IServicio.Localidad;
using IServicio.Persona;
using IServicio.Provincia;
using PresentacionBase.Formularios;
using StructureMap;
using static Aplicacion.Constantes.Clases.ValidacionDatosEntrada;
using System;
using System.Windows.Forms;
using IServicio.Persona.DTOs;
using Presentacion.Core.Provincia;
using Presentacion.Core.Departamento;
using Presentacion.Core.Localidad;
using Presentacion.Core.CondicionIva;

namespace Presentacion.Core.Cliente
{
    public partial class _00010_Abm_Cliente : FormAbm
    {

        private readonly IClienteServicio _ClienteServicio;
        private readonly IProvinciaServicio _ProvinciaServicio;
        private readonly IDepartamentoServicio _DepartamentoServicio;
        private readonly ILocalidadServicio _LocalidadServicio;

        public _00010_Abm_Cliente(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            //===============   Eliminar Parte de arriba del formulario   =======================
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;


            _ClienteServicio = ObjectFactory.GetInstance<IClienteServicio>();
            _ProvinciaServicio = ObjectFactory.GetInstance<IProvinciaServicio>();
            _DepartamentoServicio = ObjectFactory.GetInstance<IDepartamentoServicio>();
            _LocalidadServicio = ObjectFactory.GetInstance<ILocalidadServicio>();

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
            txtDomicilio.KeyPress += delegate (object sender, KeyPressEventArgs args)
            {
                NoInyeccion(sender, args);
                NoSimbolos(sender, args);
            };
        }

        // Cargar Datos
        public override void CargarDatos(long? entidadId)
        {
            base.CargarDatos(entidadId);
            nudLimiteCompra.Enabled = false;

            if (entidadId.HasValue) // modificar o Eliminar
            {
                var Cliente = (ClienteDto)_ClienteServicio.Obtener(typeof(ClienteDto), entidadId.Value);

                txtApellido.Text = Cliente.Apellido;
                txtNombre.Text = Cliente.Nombre;
                txtTelefono.Text = Cliente.Telefono;
                txtDomicilio.Text = Cliente.Direccion;

                // Cuneta Corriente
                chkActivarCuentaCorriente.Checked = Cliente.ActivarCtaCte;
                if (Cliente.ActivarCtaCte)
                {
                    chkLimiteCompra.Enabled = true;
                }

                chkLimiteCompra.Checked = Cliente.TieneLimiteCompra;
                if (Cliente.TieneLimiteCompra)
                    nudLimiteCompra.Enabled = true;

                nudLimiteCompra.Value = Cliente.MontoMaximoCtaCte;

                if (TipoOperacion == TipoOperacion.Eliminar)
                    DesactivarControles(this);

                // Provincias
                var Provincias = _ProvinciaServicio.Obtener(string.Empty,false);
                PoblarComboBox(cmbProvincia, Provincias, "Descripcion", "Id");
                cmbProvincia.SelectedValue = Cliente.ProvinciaId;

                // Departamentos
                var Departamentos = _DepartamentoServicio.ObtenerPorProvincia((long)cmbProvincia.SelectedValue);
                PoblarComboBox(cmbDepartamento, Departamentos, "Descripcion", "Id");
                cmbDepartamento.SelectedValue = Cliente.DepartamentoId;

                // Localidades
                var Localidades = _LocalidadServicio.ObtenerPorDepartamento((long)cmbDepartamento.SelectedValue);
                PoblarComboBox(cmbLocalidad, Localidades, "Descripcion", "Id");
                cmbLocalidad.SelectedValue = Cliente.LocalidadId;

            }
            else // nuevo
            {
                chkActivarCuentaCorriente.Checked = true;
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

                //LimpiarControles(this);
                // buscamos el siguiente numero de legajo
                txtApellido.Focus();
            }
        }

        // Verificar
        public override bool VerificarDatosObligatorios()
        {
            if (string.IsNullOrEmpty(txtApellido.Text))
                return false;
            if (string.IsNullOrEmpty(txtNombre.Text))
                return false;
            if (string.IsNullOrEmpty(txtDomicilio.Text))
                return false;
            if (string.IsNullOrEmpty(txtTelefono.Text))
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
            base.LimpiarControles(obj, tieneValorAsociado);

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
        }
        // comandos
        public override void EjecutarComandoNuevo()
        {
            _ClienteServicio.Insertar(new ClienteDto
            {
                Apellido = txtApellido.Text,
                Nombre = txtNombre.Text,
                Telefono = txtTelefono.Text,
                Direccion = txtDomicilio.Text,

                ProvinciaId = (long)cmbProvincia.SelectedValue,
                DepartamentoId = (long)cmbDepartamento.SelectedValue,
                LocalidadId = (long)cmbLocalidad.SelectedValue,

                ActivarCtaCte = chkActivarCuentaCorriente.Checked,
                TieneLimiteCompra = chkLimiteCompra.Checked,
                MontoMaximoCtaCte = nudLimiteCompra.Value,

            });

            LimpiarControles(this);
        }
        public override void EjecutarComandoModificar()
        {
            _ClienteServicio.Modificar(new ClienteDto
            {
                Id = EntidadId.Value,
                Apellido = txtApellido.Text,
                Nombre = txtNombre.Text,
                Telefono = txtTelefono.Text,
                Direccion = txtDomicilio.Text,

                ProvinciaId = (long)cmbProvincia.SelectedValue,
                DepartamentoId = (long)cmbDepartamento.SelectedValue,
                LocalidadId = (long)cmbLocalidad.SelectedValue,

                ActivarCtaCte = chkActivarCuentaCorriente.Checked,
                TieneLimiteCompra = chkLimiteCompra.Checked,
                MontoMaximoCtaCte = nudLimiteCompra.Value,

            });
        }
        public override void EjecutarComandoEliminar()
        {
            _ClienteServicio.Eliminar(typeof(ClienteDto),EntidadId.Value);
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

        // botones
        private void btnNuevaProvincia_Click(object sender, EventArgs e)
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
        private void btnNuevaCondicionIva_Click(object sender, EventArgs e)
        {

        }

        private void chkLimiteCompra_CheckedChanged(object sender, EventArgs e)
        {
            nudLimiteCompra.Enabled = !nudLimiteCompra.Enabled;
            nudLimiteCompra.Value = 0m;
        }

        private void chkActivarCuentaCorriente_CheckedChanged(object sender, EventArgs e)
        {
            chkLimiteCompra.Enabled = !chkLimiteCompra.Enabled;
            chkLimiteCompra.Checked = false;
            nudLimiteCompra.Enabled = false;
            nudLimiteCompra.Value = 0m;
        }
    }

}
