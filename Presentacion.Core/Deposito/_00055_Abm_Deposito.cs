using IServicio.Deposito;
using PresentacionBase.Formularios;
using StructureMap;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static Aplicacion.Constantes.Clases.ValidacionDatosEntrada;
using System.Windows.Forms;
using IServicio.Deposito.DTOs;

namespace Presentacion.Core.Deposito
{
    public partial class _00055_Abm_Deposito : FormAbm
    {
        private readonly IDepositoSevicio _DepositoSevicio;
        public _00055_Abm_Deposito(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            _DepositoSevicio = ObjectFactory.GetInstance<IDepositoSevicio>();

            AsignarEvento_EnterLeave(this);

            ValidarDatos();
        }

        private void ValidarDatos()
        {
            txtUbicacion.KeyPress += delegate (object sender, KeyPressEventArgs args)
            {
                NoInyeccion(sender, args);
                NoSimbolos(sender, args);
            };
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

            if (entidadId.HasValue)// Eliminar o Modificar
            {
                var Puesto = (DepositoDto)_DepositoSevicio.Obtener(entidadId.Value);

                if (Puesto == null)
                    MessageBox.Show("Ocurrio un Error, Al Traer El Puesto de trabajo Seleccionado");

                txtDescripcion.Text = Puesto.Descripcion;
                txtUbicacion.Text = Puesto.Ubicacion.ToString();

                if (TipoOperacion == TipoOperacion.Eliminar)
                    DesactivarControles(this);

            }
            else// nuevo
            {
                LimpiarControles(this);
                txtDescripcion.Focus();
            }
        }

        // Verificar Datos
        public override bool VerificarDatosObligatorios()
        {
            if (string.IsNullOrEmpty(txtDescripcion.Text))
                return false;
            if (string.IsNullOrEmpty(txtUbicacion.Text))
                return false;

            return true;
        }
        public override bool VerificarSiExiste(long? id = null)
        {
            return _DepositoSevicio.VerificarSiExiste(txtDescripcion.Text, id);
        }

        // Comandos
        public override void EjecutarComandoNuevo()
        {
            _DepositoSevicio.Insertar(new DepositoDto
            {
                Descripcion = txtDescripcion.Text,
                Ubicacion = txtUbicacion.Text,
                Eliminado = false,
            });
        }
        public override void EjecutarComandoModificar()
        {
            _DepositoSevicio.Modificar(new DepositoDto
            {
                Id = EntidadId.Value,
                Descripcion = txtDescripcion.Text,
                Ubicacion = txtUbicacion.Text,
                Eliminado = false,
            });
        }
        public override void EjecutarComandoEliminar()
        {
            _DepositoSevicio.Eliminar(EntidadId.Value);
        }
    }
}
