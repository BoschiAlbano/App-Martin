using Aplicacion.Constantes;
using IServicio.Configuracion;
using IServicios.Caja;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Core.Caja
{
    public partial class _00039_AperturaCaja : Form
    {
        private readonly ICajaServicio _CajaServicio;
        private readonly IConfiguracionServicio _ConfiguracionServicio;

        private bool _ConfirmarApertura;
        public bool CajaAbierta => _ConfirmarApertura;
        public _00039_AperturaCaja(ICajaServicio cajaServicio, IConfiguracionServicio configuracionServicio)
        {
            InitializeComponent();

            _CajaServicio = cajaServicio;
            _ConfiguracionServicio = configuracionServicio;

            _ConfirmarApertura = false;
            DoubleBuffered = true;
        }

        private void _00039_AperturaCaja_Load(object sender, EventArgs e)
        {
            var config = _ConfiguracionServicio.Obtener();

            if (config.IngresoManualCajaInicial)
            {
                nudMonto.Value = 0;
                nudMonto.Select(0, nudMonto.Value.ToString().Length);
                nudMonto.Focus();
            }
            else
            {
                var ultimoValor = _CajaServicio.ObtenerMontoAnterio(Identidad.UsuarioId);

                nudMonto.Value = ultimoValor;
                nudMonto.Select(0, nudMonto.Value.ToString().Length);
                nudMonto.Focus();
            }

        }

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            try
            {
                _CajaServicio.AbrirCaja(Identidad.UsuarioId, nudMonto.Value, DateTime.Now);
                MessageBox.Show("Los Datos se Grabaron");
                _ConfirmarApertura = true;
                this.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show($"{ex.Message}, Error");
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            nudMonto.Value = 0;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
