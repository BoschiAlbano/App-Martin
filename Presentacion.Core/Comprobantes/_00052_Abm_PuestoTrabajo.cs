using IServicios.PuestoTrabajo;
using IServicios.PuestoTrabajo.DTOs;
using PresentacionBase.Formularios;
using static Aplicacion.Constantes.Clases.ValidacionDatosEntrada;
using StructureMap;
using System;
using System.Windows.Forms;

namespace Presentacion.Core.Comprobantes
{
    public partial class _00052_Abm_PuestoTrabajo : FormAbm
    {

        private readonly IPuestoTrabajoServicio _PuestoTrabajoServicio;

        public _00052_Abm_PuestoTrabajo(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            _PuestoTrabajoServicio = ObjectFactory.GetInstance<IPuestoTrabajoServicio>();

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
        }

        public override void CargarDatos(long? entidadId)
        {
            base.CargarDatos(entidadId);

            if (entidadId.HasValue)// Eliminar o Modificar
            {
                var Puesto = (PuestoTrabajoDto)_PuestoTrabajoServicio.Obtener(entidadId.Value);

                if (Puesto == null)
                    MessageBox.Show("Ocurrio un Error, Al Traer El Puesto de trabajo Seleccionado");

                txtDescripcion.Text = Puesto.Descripcion;
                txtCodigo.Text = Puesto.Codigo.ToString();

                if (TipoOperacion == TipoOperacion.Eliminar)
                    DesactivarControles(this);

            }
            else// nuevo
            {
                LimpiarControles(this);
                txtCodigo.Focus();
            }
        }

        // Verificar Datos
        public override bool VerificarDatosObligatorios()
        {
            if (string.IsNullOrEmpty(txtDescripcion.Text))
                return false;
            if (string.IsNullOrEmpty(txtCodigo.Text))
                return false;

            return true;
        }
        public override bool VerificarSiExiste(long? id = null)
        {
            return _PuestoTrabajoServicio.VerificarSiExiste(txtDescripcion.Text, id);
        }

        // Comandos
        public override void EjecutarComandoNuevo()
        {
            _PuestoTrabajoServicio.Insertar(new PuestoTrabajoDto
            {
                Descripcion = txtDescripcion.Text,
                Codigo = int.Parse(txtCodigo.Text),
                Eliminado = false,
            });
        }
        public override void EjecutarComandoModificar()
        {
            _PuestoTrabajoServicio.Modificar(new PuestoTrabajoDto
            {
                Id = EntidadId.Value,
                Descripcion = txtDescripcion.Text,
                Codigo = int.Parse(txtCodigo.Text),
                Eliminado = false,
            });
        }
        public override void EjecutarComandoEliminar()
        {
            _PuestoTrabajoServicio.Eliminar(EntidadId.Value);
        }



    }
}
