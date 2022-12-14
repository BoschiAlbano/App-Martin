using IServicios.Tarjeta;
using PresentacionBase.Formularios;
using StructureMap;
using static Aplicacion.Constantes.Clases.ValidacionDatosEntrada;
using System.Windows.Forms;
using IServicios.Tarjeta.DTOs;

namespace Presentacion.Core.FormaPago
{
    public partial class _00046_Abm_tarjeta : FormAbm
    {

        private readonly ITarjetaServicio _TarjetaServicio;

        public _00046_Abm_tarjeta(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            _TarjetaServicio = ObjectFactory.GetInstance<ITarjetaServicio>();

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
                var entidad = (TarjetaDto)_TarjetaServicio.Obtener(entidadId.Value);

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
            return _TarjetaServicio.VerificarSiExiste(txtDescripcion.Text, id);
        }

        public override void EjecutarComandoEliminar()
        {
            _TarjetaServicio.Eliminar(EntidadId.Value);
        }
        public override void EjecutarComandoModificar()
        {
            _TarjetaServicio.Insertar(new TarjetaDto
            {
                Id = EntidadId.Value,
                Descripcion = txtDescripcion.Text
            });
        }
        public override void EjecutarComandoNuevo()
        {
            _TarjetaServicio.Insertar(new TarjetaDto
            {
                Descripcion = txtDescripcion.Text
            });
        }

    }
}
