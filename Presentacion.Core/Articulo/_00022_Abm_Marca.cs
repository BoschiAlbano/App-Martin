using IServicio.Marca;
using IServicio.Marca.DTOs;
using PresentacionBase.Formularios;
using StructureMap;
using static Aplicacion.Constantes.Clases.ValidacionDatosEntrada;
using System.Windows.Forms;

namespace Presentacion.Core.Articulo
{
    public partial class _00022_Abm_Marca : FormAbm
    {

        private readonly IMarcaServicio _MarcaServicio;

        public _00022_Abm_Marca(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            //===============   Eliminar Parte de arriba del formulario   =======================
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;


            _MarcaServicio = ObjectFactory.GetInstance<IMarcaServicio>();

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
                var entidad = (MarcaDto)_MarcaServicio.Obtener(entidadId.Value);

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
            return _MarcaServicio.VerificarSiExiste(txtDescripcion.Text, id);
        }
        public override void EjecutarComandoNuevo()
        {
            _MarcaServicio.Insertar(new MarcaDto
            {
                Descripcion = txtDescripcion.Text
            });
        }
        public override void EjecutarComandoModificar()
        {
            _MarcaServicio.Insertar(new MarcaDto
            {
                Id = EntidadId.Value,
                Descripcion = txtDescripcion.Text
            });
        }
        public override void EjecutarComandoEliminar()
        {
            _MarcaServicio.Eliminar(EntidadId.Value);
        }

    }
}
