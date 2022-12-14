using IServicio.Iva;
using IServicio.Iva.DTOs;
using PresentacionBase.Formularios;
using StructureMap;
using static Aplicacion.Constantes.Clases.ValidacionDatosEntrada;
using System.Windows.Forms;

namespace Presentacion.Core.Articulo
{
    public partial class _00026_Abm_Iva : FormAbm
    {
        private readonly IIvaServicio _IvaServicio;

        public _00026_Abm_Iva(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            _IvaServicio = ObjectFactory.GetInstance<IIvaServicio>();

            AsignarEvento_EnterLeave(this);

            txtDescripcion.KeyPress += delegate (object sender, KeyPressEventArgs args)
            {
                NoInyeccion(sender, args);
                NoSimbolos(sender, args);
            };

            nudPorcentaje.KeyPress += delegate (object sender, KeyPressEventArgs args)
            {
                NoInyeccion(sender, args);
                NoSimbolos(sender, args);
                NoLetras(sender, args);
            };
        }

        public override void CargarDatos(long? entidadId)
        {
            base.CargarDatos(entidadId);

            if (entidadId.HasValue)
            {
                var _Entidad = (IvaDto)_IvaServicio.Obtener(entidadId.Value);

                txtDescripcion.Text = _Entidad.Descripcion;
                nudPorcentaje.Value = _Entidad.Porcentaje;

                if (TipoOperacion == TipoOperacion.Eliminar)
                    DesactivarControles(this);
            }
            else// nuevo
            {
                txtDescripcion.Clear();
                txtDescripcion.Focus();
            }
        }

        public override bool VerificarDatosObligatorios()
        {
            if (string.IsNullOrEmpty(txtDescripcion.Text))
                return false;

            if (nudPorcentaje.Value <= 0)
                return false;

            return true;
        }

        public override bool VerificarSiExiste(long? id = null)
        {
            return _IvaServicio.VerificarSiExiste(txtDescripcion.Text, id);
        }
         // Botones
        public override void EjecutarComandoNuevo()
        {
            _IvaServicio.Insertar(new IvaDto
            {
                Descripcion = txtDescripcion.Text,
                Porcentaje = nudPorcentaje.Value
            });
        }
        public override void EjecutarComandoModificar()
        {
            _IvaServicio.Modificar(new IvaDto
            {
                Id = EntidadId.Value,
                Descripcion = txtDescripcion.Text,
                Porcentaje = nudPorcentaje.Value,
            });
        }
        public override void EjecutarComandoEliminar()
        {
            _IvaServicio.Eliminar(EntidadId.Value);
        }


    }
}
