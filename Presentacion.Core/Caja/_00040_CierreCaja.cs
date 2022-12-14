using Aplicacion.Constantes;
using IServicios.Caja;
using IServicios.Caja.DTOs;
using PresentacionBase.Formularios;
using StructureMap;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Presentacion.Core.Caja
{
    public partial class _00040_CierreCaja : FormBase
    {
        private readonly ICajaServicio _CajaServicio;

        private CajaDto _CajaActual;

        private long _cajaId;

        private decimal _Efectivo;
        public _00040_CierreCaja(long CajaId)
        {
            InitializeComponent();

            _CajaServicio = ObjectFactory.GetInstance<ICajaServicio>();
            _cajaId = CajaId;

            nudTotalEfectivoCaja.Value = 0m;
            CargarDatos(_cajaId);

            nudTotalEfectivoCaja.Focus();
        }

        private void CargarDatos(long cajaId)
        {
            _CajaActual = _CajaServicio.Obtener(cajaId);

            if (_CajaActual == null)
            {
                MessageBox.Show("Ocurrio Un Error Al Obtener La Caja del Usuario");
                this.Close();
            }

            txtCajaInicial.Text = _CajaActual.MontoAperturaStr;

            _Efectivo = _CajaActual.Detalles.Where(x => x.TipoPago == Aplicacion.Constantes.TipoPago.Efectivo)
                                                        .Sum(Suma => Suma.Monto);
            _CajaActual.TotalEntradaEfectivo = _Efectivo;

            var _Tarjeta = _CajaActual.Detalles.Where(x => x.TipoPago == Aplicacion.Constantes.TipoPago.Tarjeta)
                                                        .Sum(Suma => Suma.Monto);
            _CajaActual.TotalEntradaTarjeta = _Tarjeta;

            var _CtaCte = _CajaActual.Detalles.Where(x => x.TipoPago == Aplicacion.Constantes.TipoPago.CtaCte)
                                                        .Sum(Suma => Suma.Monto);
            _CajaActual.TotalEntradaCtaCte = _CtaCte;

            var _Cheque = _CajaActual.Detalles.Where(x => x.TipoPago == Aplicacion.Constantes.TipoPago.Cheque)
                                                        .Sum(Suma => Suma.Monto);
            _CajaActual.TotalEntradaCheque = _Cheque;

            txtTotalEfectivo.Text = _Efectivo.ToString("C");
            txtTarjeta.Text = _Tarjeta.ToString("C");
            txtCtaCte.Text = _CtaCte.ToString("C");
            txtCheque.Text = _Cheque.ToString("C");

            lblFechaApertura.Text = _CajaActual.FechaAperturaStr;

        }

        private void btnVerDetalleVenta_Click(object sender, EventArgs e)
        {
            var fVerComprobantes = new VerComprobantesCierreCaja(_CajaActual.Comprobantes);
            fVerComprobantes.ShowDialog();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            nudTotalEfectivoCaja.Value = 0;
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        // Finalizar CAja Cierre
        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            if (nudTotalEfectivoCaja.Value <= 0)
            {
                MessageBox.Show("Error, Ingrese el monto Total de la Caja");
                return;
            }
            if (nudTotalEfectivoCaja.Value >= _Efectivo)
            {
                _CajaActual.UsuarioCierreId = Identidad.UsuarioId;
                _CajaActual.MontoCierre = nudTotalEfectivoCaja.Value;
                _CajaActual.FechaCierre = DateTime.Now;

                _CajaServicio.CerrarCaja(_CajaActual);

                MessageBox.Show("La Caja se Cerro Correctamente.");
                var msj = "La Caja se Cerro Correctamente." + Environment.NewLine + "¿ Desea cerrar el Sistema ?";
                if (MessageBox.Show(msj,"Atencion",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.OK)
                {
                    Application.Exit();
                }
                else
                {
                    this.Close();
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Error, El monto Ingresado No supera El monto del Ingreso del Dia");
            }
            
        }


    }
}
