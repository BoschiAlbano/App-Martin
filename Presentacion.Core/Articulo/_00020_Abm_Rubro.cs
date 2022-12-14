using IServicio.Rubro;
using IServicio.Rubro.DTOs;
using PresentacionBase.Formularios;
using StructureMap;
using static Aplicacion.Constantes.Clases.ValidacionDatosEntrada;
using System.Windows.Forms;

namespace Presentacion.Core.Articulo
{
    public partial class _00020_Abm_Rubro : FormAbm
    {

        private readonly IRubroServicio _RubroServicio;

        public _00020_Abm_Rubro(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            //===============   Eliminar Parte de arriba del formulario   =======================
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            _RubroServicio = ObjectFactory.GetInstance<IRubroServicio>();

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
                var entidad = (RubroDto)_RubroServicio.Obtener(entidadId.Value);

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
            return _RubroServicio.VerificarSiExiste(txtDescripcion.Text, id);
        }
        public override void EjecutarComandoNuevo()
        {
            _RubroServicio.Insertar(new RubroDto
            {
                Descripcion = txtDescripcion.Text
            });
        }
        public override void EjecutarComandoModificar()
        {
            _RubroServicio.Modificar(new RubroDto
            {
                Id = EntidadId.Value,
                Descripcion = txtDescripcion.Text
            });
        }
        public override void EjecutarComandoEliminar()
        {
            _RubroServicio.Eliminar(EntidadId.Value);
        }
    }
}
