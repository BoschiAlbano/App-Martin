using IServicios.Banco;
using IServicios.Banco.DTOs;
using PresentacionBase.Formularios;
using StructureMap;
using static Aplicacion.Constantes.Clases.ValidacionDatosEntrada;
using System.Windows.Forms;


namespace Presentacion.Core.FormaPago
{
    public partial class _00048_Abm_Banco : FormAbm
    {

        private readonly IBancoServicio _BancoServicio;

        public _00048_Abm_Banco(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            _BancoServicio = ObjectFactory.GetInstance<IBancoServicio>();

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
                var entidad = (BancoDto)_BancoServicio.Obtener(entidadId.Value);

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
            return _BancoServicio.VerificarSiExiste(txtDescripcion.Text, id);
        }

        public override void EjecutarComandoEliminar()
        {
            _BancoServicio.Eliminar(EntidadId.Value);
        }
        public override void EjecutarComandoModificar()
        {
            _BancoServicio.Insertar(new BancoDto
            {
                Id = EntidadId.Value,
                Descripcion = txtDescripcion.Text
            });
        }
        public override void EjecutarComandoNuevo()
        {
            _BancoServicio.Insertar(new BancoDto
            {
                Descripcion = txtDescripcion.Text
            });
        }

    }
}
