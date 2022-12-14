using IServicio.Persona;
using IServicio.Persona.DTOs;
using IServicio.Usuario;
using IServicio.Usuario.DTOs;
using PresentacionBase.Formularios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Core.Usuario
{
    public partial class _00011_Usuario : FormBase
    {

        private readonly IUsuarioServicio _UsuarioServicio;

        private long? entidadId;
        protected UsuarioDto EntidadSeleccionada;
        public _00011_Usuario(IUsuarioServicio usuarioServicio)
        {
            InitializeComponent();

            //===============   Eliminar Parte de arriba del formulario   =======================
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            _UsuarioServicio = usuarioServicio;
        }
        // Load
        private void _00011_Usuario_Load(object sender, EventArgs e)
        {
            // cargar Grilla
            CargarGrilla(string.Empty);
        }


        // Cargar Grilla
        private void CargarGrilla(string CadenaBuscar)
        {
            dgvGrilla.DataSource = _UsuarioServicio.Obtener(CadenaBuscar);

            FormatearGrilla(dgvGrilla);
        }
        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            dgv.Columns["ApyNomEmpleado"].Visible = true;
            dgv.Columns["ApyNomEmpleado"].HeaderText = "Apellido y Nombre";
            dgv.Columns["ApyNomEmpleado"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["ApyNomEmpleado"].DisplayIndex = 0;

            dgv.Columns["NombreUsuario"].Visible = true;
            dgv.Columns["NombreUsuario"].HeaderText = "Usuario";
            dgv.Columns["NombreUsuario"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["NombreUsuario"].DisplayIndex = 1;

            dgv.Columns["EstaBloqueadoStr"].Visible = true;
            dgv.Columns["EstaBloqueadoStr"].HeaderText = @"Bloqueado";
            dgv.Columns["EstaBloqueadoStr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["EstaBloqueadoStr"].DisplayIndex = 2;

            dgv.Columns["EliminadoStr"].Visible = true;
            dgv.Columns["EliminadoStr"].HeaderText = @"Eliminado";
            dgv.Columns["EliminadoStr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["EliminadoStr"].DisplayIndex = 3;

        }


        // Evento Grilla
        private void dgvGrilla_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGrilla.RowCount <= 0) return;

            entidadId = (long)dgvGrilla["EmpleadoId", e.RowIndex].Value;

            // Obtener el Objeto completo seleccionado
            EntidadSeleccionada = (UsuarioDto)dgvGrilla.Rows[e.RowIndex].DataBoundItem;




            if (string.IsNullOrEmpty(EntidadSeleccionada.Password))
            {
                btnNuevo.Enabled = true;
                btnNuevo.IconColor = Color.FromArgb(192, 255, 255);

                btnBloquear.Enabled = false;
                btnBloquear.IconColor = Color.Gray;

                btnDesbloquear.Enabled = false;
                btnDesbloquear.IconColor = Color.Gray;

                btnReset.Enabled = false;
                btnReset.IconColor = Color.Gray;
            }
            else
            {
                btnNuevo.Enabled = false;
                btnNuevo.IconColor = Color.Gray;

                btnBloquear.Enabled = !(bool)dgvGrilla["EstaBloqueado", e.RowIndex].Value;
                if (btnBloquear.Enabled)
                {
                    btnBloquear.IconColor = Color.FromArgb(255, 192, 192);
                }
                else
                {
                    btnBloquear.IconColor = Color.Gray;
                }


                btnDesbloquear.Enabled = (bool)dgvGrilla["EstaBloqueado", e.RowIndex].Value;
                if (btnDesbloquear.Enabled)
                {
                    btnDesbloquear.IconColor = Color.FromArgb(192, 255, 192);
                }
                else
                {
                    btnDesbloquear.IconColor = Color.Gray;
                }


                if (EntidadSeleccionada.EstaBloqueado)
                {
                    btnReset.Enabled = false;
                    btnReset.IconColor = Color.Gray;
                }
                else
                {
                    btnReset.Enabled = true;
                    btnReset.IconColor = Color.Black;
                }
                
            }


        }
        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                CargarGrilla(txtBuscar.Text);
            }
        }

        // botones
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            // creamos el usuario
            if (entidadId.HasValue)
            {
                _UsuarioServicio.Crear(EntidadSeleccionada.EmpleadoId, EntidadSeleccionada.ApellidoEmpleado, EntidadSeleccionada.NombreEmpleado);
                MessageBox.Show("El Usuario se Creo Correctamente");
                CargarGrilla(string.Empty);
            }
            else
            {
                MessageBox.Show("Error, Seleccione un Empleado de la Lista");
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnBloquear_Click(object sender, EventArgs e)
        {
            if (EntidadSeleccionada.Id > 0)
            {
                _UsuarioServicio.Bloquear(EntidadSeleccionada.Id);
                MessageBox.Show("El Bloqueo/Desbloqueo del Usuario fue Exitoso");
                CargarGrilla(string.Empty);
            }
            else
            {
                MessageBox.Show("Este Empleado No Tiene Un Usuario Asigando");
            }
            
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            CargarGrilla(string.Empty);

        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            
            if (EntidadSeleccionada.Id > 0)
            {
                _UsuarioServicio.ResetPassword(EntidadSeleccionada.Id);
                MessageBox.Show("El Reset del Usuario fue Exitoso");
                CargarGrilla(string.Empty);
            }
            else
            {
                MessageBox.Show("Este Empleado No Tiene Un Usuario Asigando");
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarGrilla(txtBuscar.Text);
        }

        #region BOTONES (X,minimizar y maximizar)
        private void IconoMaximizar_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }

        private void IconoSalir_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        private void IconoOcultar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        #endregion

    }
}
