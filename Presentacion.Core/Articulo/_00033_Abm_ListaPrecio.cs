using IServicio.ListaPrecio;
using IServicio.ListaPrecio.DTOs;
using PresentacionBase.Formularios;
using StructureMap;
using System.Windows.Forms;
using static Aplicacion.Constantes.Clases.ValidacionDatosEntrada;

namespace Presentacion.Core.Articulo
{
    public partial class _00033_Abm_ListaPrecio : FormAbm
    {
        private readonly IListaPrecioServicio _ListaPreciosServico;

        public _00033_Abm_ListaPrecio(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            //===============   Eliminar Parte de arriba del formulario   =======================
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            _ListaPreciosServico =  ObjectFactory.GetInstance<IListaPrecioServicio>();

            AsignarEvento_EnterLeave(this);
            ValidarDatos();
        }

        private void ValidarDatos()
        {
            // descripcion
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

            if (entidadId.HasValue)// Eliminador o modificar
            {
                // cargamos los datos
                var _ListaPreciosBD = (ListaPrecioDto)_ListaPreciosServico.Obtener(entidadId.Value);

                txtDescripcion.Text = _ListaPreciosBD.Descripcion;
                nudPorcentaje.Value = _ListaPreciosBD.PorcentajeGanancia;
                if (_ListaPreciosBD.NecesitaAutorizacion)
                {
                    chkPedirAutorizacion.Checked = true;
                }
                else
                {
                    chkPedirAutorizacion.Checked = false;
                }

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

            if (nudPorcentaje.Value < 0)
            {
                MessageBox.Show("No se permiten Porcentajes Negativos");
                return false;
            }
            return true;
        }
        public override bool VerificarSiExiste(long? id = null)
        {
            return _ListaPreciosServico.VerificarSiExiste(txtDescripcion.Text, EntidadId);

        }

        // comandos
        public override void EjecutarComandoNuevo()
        {
            _ListaPreciosServico.Insertar(new ListaPrecioDto
            {
                Descripcion = txtDescripcion.Text,
                Eliminado = false,
                PorcentajeGanancia = nudPorcentaje.Value,
                NecesitaAutorizacion = chkPedirAutorizacion.Checked,
            });
        }
        public override void EjecutarComandoModificar()
        {
            _ListaPreciosServico.Modificar(new ListaPrecioDto
            {
                Id = EntidadId.Value,
                Descripcion = txtDescripcion.Text,
                PorcentajeGanancia = nudPorcentaje.Value,
                NecesitaAutorizacion = chkPedirAutorizacion.Checked,
            });
        }
        public override void EjecutarComandoEliminar()
        {
            _ListaPreciosServico.Eliminar(EntidadId.Value);
        }

        /* Probando el use context
        private void Prueba_Click(object sender, System.EventArgs e)
        {
            _ListaPreciosServico.Probar();

            MessageBox.Show("Dato Borrado");
        }
        */
    }
}
