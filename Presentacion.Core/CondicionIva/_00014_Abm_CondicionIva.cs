using IServicio.CondicionIva.DTOs;
using IServicio.Departamento;
using PresentacionBase.Formularios;
using static Aplicacion.Constantes.Clases.ValidacionDatosEntrada;
using StructureMap;
using System.Windows.Forms;

namespace Presentacion.Core.CondicionIva
{
    public partial class _00014_Abm_CondicionIva : FormAbm
    {
        private readonly ICondicionIvaServicio _CondicionIvaServicio;

        public _00014_Abm_CondicionIva(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            _CondicionIvaServicio = ObjectFactory.GetInstance<ICondicionIvaServicio>();

            AsignarEvento_EnterLeave(this);

            txtDescripcion.KeyPress += delegate (object sender, KeyPressEventArgs args)
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
                var entidad = (CondicionIvaDto)_CondicionIvaServicio.Obtener(entidadId.Value);

                txtDescripcion.Text = entidad.Descripcion;

                if (TipoOperacion == TipoOperacion.Eliminar)
                    DesactivarControles(this);

            }
            else // nuevo
            {
                txtDescripcion.Clear();
                txtDescripcion.Focus();
            }

        }

        public override bool VerificarDatosObligatorios()
        {
            if (string.IsNullOrEmpty(txtDescripcion.Text))
                return false;

            return true;
        }
        public override bool VerificarSiExiste(long? id = null)
        {
            return _CondicionIvaServicio.VerificarSiExiste(txtDescripcion.Text, id);
        }
        public override void EjecutarComandoNuevo()
        {
            _CondicionIvaServicio.Insertar(new CondicionIvaDto
            {
                Descripcion = txtDescripcion.Text
            });
        }

        public override void EjecutarComandoModificar()
        {
            _CondicionIvaServicio.Modificar(new CondicionIvaDto
            {
                Id = EntidadId.Value,
                Eliminado = false,
                Descripcion = txtDescripcion.Text,
            });
        }
        public override void EjecutarComandoEliminar()
        {
            _CondicionIvaServicio.Eliminar(EntidadId.Value);
        }

    }
}
