using IServicio.UnidadMedida;
using IServicio.UnidadMedida.DTOs;
using PresentacionBase.Formularios;
using StructureMap;
using static Aplicacion.Constantes.Clases.ValidacionDatosEntrada;
using System.Windows.Forms;

namespace Presentacion.Core.Articulo
{
    public partial class _00024_Abm_UnidadDeMedida : FormAbm
    {

        private readonly IUnidadMedidaServicio _UnidadMedidaServicio;

        public _00024_Abm_UnidadDeMedida(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();
            _UnidadMedidaServicio = ObjectFactory.GetInstance<IUnidadMedidaServicio>();

            AsignarEvento_EnterLeave(this);

            txtDescripcion.KeyPress += delegate (object sender, KeyPressEventArgs args)
            {
                NoInyeccion(sender, args);
                NoSimbolos(sender, args);
                NoNumeros(sender, args);
            };
        }

        public override void CargarDatos(long? entidadId)
        {
            base.CargarDatos(entidadId);

            if (entidadId.HasValue)
            {
                var entidad = (UnidadMedidaDto)_UnidadMedidaServicio.Obtener(entidadId.Value);

                txtDescripcion.Text = entidad.Descripcion;

                if (TipoOperacion == TipoOperacion.Eliminar)
                    DesactivarControles(this);
            }
            else
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
            return _UnidadMedidaServicio.VerificarSiExiste(txtDescripcion.Text, id);
        }

        // Botnoes

        public override void EjecutarComandoNuevo()
        {
            _UnidadMedidaServicio.Insertar(new UnidadMedidaDto
            {
                Descripcion = txtDescripcion.Text
            });

        }
        public override void EjecutarComandoModificar()
        {
            _UnidadMedidaServicio.Modificar(new UnidadMedidaDto
            {
                Id = EntidadId.Value,
                Descripcion = txtDescripcion.Text,
            });
        }
        public override void EjecutarComandoEliminar()
        {
            _UnidadMedidaServicio.Eliminar(EntidadId.Value);
        }

    }
}
