using System;
using System.Windows.Forms;

namespace PresentacionBase.Formularios
{
    public partial class FormBase : Form
    {
        public FormBase()
        {
            InitializeComponent();

            
        }

        protected void Control_Leave(object sender, EventArgs e)
        {
            switch (sender)
            {
                case NumericUpDown down:
                    down.BackColor = Aplicacion.Constantes.Color.ControlSinFoco;
                    break;
                case TextBox box:
                    box.BackColor = Aplicacion.Constantes.Color.ControlSinFoco;
                    break;
                case RichTextBox down:
                    down.BackColor = Aplicacion.Constantes.Color.ControlSinFoco;
                    break;
                case ComboBox down:
                    down.BackColor = Aplicacion.Constantes.Color.ControlSinFoco;
                    break;
            }
        }

        protected void Control_Enter(object sender, EventArgs e)
        {
            switch (sender)
            {
                case NumericUpDown down:
                    down.BackColor = Aplicacion.Constantes.Color.ControlConFoco;
                    break;
                case TextBox box:
                    box.BackColor = Aplicacion.Constantes.Color.ControlConFoco;
                    break;
                case RichTextBox down:
                    down.BackColor = Aplicacion.Constantes.Color.ControlConFoco;
                    break;
                case ComboBox down:
                    down.BackColor = Aplicacion.Constantes.Color.ControlConFoco;
                    break;
            }
        }

        protected void DesactivarControles(object obj)
        {
            if (obj is Form)
            {
                foreach (var controlForm in ((Form)obj).Controls)
                {
                    if (controlForm is TextBox)
                    {
                        ((TextBox)controlForm).Enabled = false;
                        continue;
                    }

                    if (controlForm is ComboBox)
                    {
                        ((ComboBox)controlForm).Enabled = false;
                        continue;
                    }

                    if (controlForm is NumericUpDown)
                    {
                        ((NumericUpDown)controlForm).Enabled = false;
                        continue;
                    }

                    if (controlForm is Button)
                    {
                        ((Button)controlForm).Enabled = false;
                        continue;
                    }

                    if (controlForm is DateTimePicker)
                    {
                        ((DateTimePicker)controlForm).Enabled = false;
                        continue;
                    }

                    if (controlForm is CheckBox)
                    {
                        ((CheckBox)controlForm).Enabled = false;
                        continue;
                    }

                    if (controlForm is Panel)
                    {
                        DesactivarControles(controlForm);
                        continue;
                    }

                    if (controlForm is GroupBox)
                    {
                        DesactivarControles(controlForm);
                    }

                    if (controlForm is TabControl)
                    {
                        DesactivarControles(controlForm);
                    }
                }
            }
            else if (obj is Panel)
            {
                foreach (var ControlPanel in ((Panel)obj).Controls)
                {
                    if (ControlPanel is TextBox)
                    {
                        ((TextBox)ControlPanel).Enabled = false;
                        continue;
                    }

                    if (ControlPanel is ComboBox)
                    {
                        ((ComboBox)ControlPanel).Enabled = false;
                        continue;
                    }

                    if (ControlPanel is NumericUpDown)
                    {
                        ((NumericUpDown)ControlPanel).Enabled = false;
                        continue;
                    }

                    if (ControlPanel is Button)
                    {
                        ((Button)ControlPanel).Enabled = false;
                        continue;
                    }

                    if (ControlPanel is DateTimePicker)
                    {
                        ((DateTimePicker)ControlPanel).Enabled = false;
                        continue;
                    }

                    if (ControlPanel is CheckBox)
                    {
                        ((CheckBox)ControlPanel).Enabled = false;
                        continue;
                    }

                    if (ControlPanel is Panel)
                    {
                        DesactivarControles(ControlPanel);
                        continue;
                    }

                    if (ControlPanel is GroupBox)
                    {
                        DesactivarControles(ControlPanel);
                    }

                    if (ControlPanel is TabControl)
                    {
                        DesactivarControles(ControlPanel);
                    }
                }
            }
            else if (obj is GroupBox)
            {
                foreach (var ControlGroupBox in ((GroupBox)obj).Controls)
                {
                    if (ControlGroupBox is TextBox)
                    {
                        ((TextBox)ControlGroupBox).Enabled = false;
                        continue;
                    }

                    if (ControlGroupBox is ComboBox)
                    {
                        ((ComboBox)ControlGroupBox).Enabled = false;
                        continue;
                    }

                    if (ControlGroupBox is NumericUpDown)
                    {
                        ((NumericUpDown)ControlGroupBox).Enabled = false;
                        continue;
                    }

                    if (ControlGroupBox is Button)
                    {
                        ((Button)ControlGroupBox).Enabled = false;
                        continue;
                    }

                    if (ControlGroupBox is DateTimePicker)
                    {
                        ((DateTimePicker)ControlGroupBox).Enabled = false;
                        continue;
                    }

                    if (ControlGroupBox is CheckBox)
                    {
                        ((CheckBox)ControlGroupBox).Enabled = false;
                        continue;
                    }

                    if (ControlGroupBox is Panel)
                    {
                        DesactivarControles(ControlGroupBox);
                        continue;
                    }

                    if (ControlGroupBox is GroupBox)
                    {
                        DesactivarControles(ControlGroupBox);
                    }

                    if (ControlGroupBox is TabControl)
                    {
                        DesactivarControles(ControlGroupBox);
                    }
                }
            }
            else if (obj is TabControl)
            {
                foreach (var ControlTabControl in ((TabControl)obj).Controls)
                {
                    if (ControlTabControl is TextBox)
                    {
                        ((TextBox)ControlTabControl).Enabled = false;
                        continue;
                    }

                    if (ControlTabControl is ComboBox)
                    {
                        ((ComboBox)ControlTabControl).Enabled = false;
                        continue;
                    }

                    if (ControlTabControl is NumericUpDown)
                    {
                        ((NumericUpDown)ControlTabControl).Enabled = false;
                        continue;
                    }

                    if (ControlTabControl is Button)
                    {
                        ((Button)ControlTabControl).Enabled = false;
                        continue;
                    }

                    if (ControlTabControl is DateTimePicker)
                    {
                        ((DateTimePicker)ControlTabControl).Enabled = false;
                        continue;
                    }

                    if (ControlTabControl is CheckBox)
                    {
                        ((CheckBox)ControlTabControl).Enabled = false;
                        continue;
                    }

                    if (ControlTabControl is Panel)
                    {
                        DesactivarControles(ControlTabControl);
                        continue;
                    }

                    if (ControlTabControl is GroupBox)
                    {
                        DesactivarControles(ControlTabControl);
                    }

                    if (ControlTabControl is TabControl)
                    {
                        DesactivarControles(ControlTabControl);
                    }
                }
            }
        }

        public virtual void LimpiarControles(object obj, bool tieneValorAsociado = false)

        {
            if (obj is Form)// form
            {
                foreach (var controlForm in ((Form)obj).Controls)
                {
                    if (controlForm is TextBox)
                    {
                        ((TextBox)controlForm).Clear();
                        continue;
                    }

                    if (controlForm is ComboBox)
                    {
                        if (((ComboBox)controlForm).Items.Count > 0)
                        {
                            if (!tieneValorAsociado)
                            {
                                ((ComboBox)controlForm).SelectedIndex = 0;
                                continue;
                            }
                        }
                    }

                    if (controlForm is DateTimePicker)
                    {
                        ((DateTimePicker)controlForm).Value = DateTime.Now;
                        continue;
                    }

                    if (controlForm is NumericUpDown)
                    {
                        ((NumericUpDown)controlForm).Value = ((NumericUpDown)controlForm).Minimum;
                        continue;
                    }

                    if (controlForm is RichTextBox)
                    {
                        ((RichTextBox)controlForm).Clear();
                        continue;
                    }

                    if (controlForm is CheckBox) 
                    {
                        ((CheckBox)controlForm).Checked = false;
                        continue;
                    }

                    if (controlForm is Panel)
                    {
                        LimpiarControles(controlForm);
                    }

                    if (controlForm is TabControl)
                    {
                        LimpiarControles(controlForm);
                    }
                }
            }else if (obj is Panel)// Panel
            {
                foreach (var ControlPanel in ((Panel)obj).Controls)
                {
                    if (ControlPanel is TextBox)
                    {
                        ((TextBox)ControlPanel).Clear();
                        continue;
                    }

                    if (ControlPanel is ComboBox)
                    {
                        if (((ComboBox)ControlPanel).Items.Count > 0)
                        {
                            ((ComboBox)ControlPanel).SelectedIndex = 0;
                            continue;
                        }

                    }

                    if (ControlPanel is NumericUpDown)
                    {
                        ((NumericUpDown)ControlPanel).Value = ((NumericUpDown)ControlPanel).Minimum;
                        continue;
                    }

                    if (ControlPanel is DateTimePicker)
                    {
                        ((DateTimePicker)ControlPanel).Value = DateTime.Now;
                        continue;
                    }

                    if (ControlPanel is RichTextBox)
                    {
                        ((RichTextBox)ControlPanel).Clear();
                        continue;
                    }

                    if (ControlPanel is CheckBox)
                    {
                        ((CheckBox)ControlPanel).Checked = false;
                        continue;
                    }

                    if (ControlPanel is Panel)
                    {
                        LimpiarControles(ControlPanel);
                    }

                    if (ControlPanel is TabControl)
                    {
                        LimpiarControles(ControlPanel);
                    }
                }
            }
            else if (obj is TabControl)// Tab Control
            {
                foreach (var ControlTabControl in ((TabControl)obj).Controls)
                {
                    if (ControlTabControl is TextBox)
                    {
                        ((TextBox)ControlTabControl).Clear();
                        continue;
                    }

                    if (ControlTabControl is ComboBox)
                    {
                        if (((ComboBox)ControlTabControl).Items.Count > 0)
                        {
                            ((ComboBox)ControlTabControl).SelectedIndex = 0;
                            continue;
                        }

                    }

                    if (ControlTabControl is NumericUpDown)
                    {
                        ((NumericUpDown)ControlTabControl).Value = ((NumericUpDown)ControlTabControl).Minimum;
                        continue;
                    }

                    if (ControlTabControl is DateTimePicker)
                    {
                        ((DateTimePicker)ControlTabControl).Value = DateTime.Now;
                        continue;
                    }

                    if (ControlTabControl is CheckBox)
                    {
                        ((CheckBox)ControlTabControl).Checked = false;
                        continue;
                    }

                    if (ControlTabControl is RichTextBox)
                    {
                        ((RichTextBox)ControlTabControl).Clear();
                        continue;
                    }

                    if (ControlTabControl is Panel)
                    {
                        LimpiarControles(ControlTabControl);
                    }

                    if (ControlTabControl is TabPage)
                    {
                        LimpiarControles(ControlTabControl);
                    }
                }
            }
            
        }
        protected void AsignarEvento_EnterLeave(object obj)
        {
            if (obj is Form)
            {
                foreach (var controlForm in ((Form)obj).Controls)
                {
                    if (controlForm is TextBox)
                    {
                        ((TextBox)controlForm).Enter += Control_Enter;
                        ((TextBox)controlForm).Leave += Control_Leave;
                        continue;
                    }

                    if (controlForm is RichTextBox)
                    {
                        ((RichTextBox)controlForm).Enter += Control_Enter;
                        ((RichTextBox)controlForm).Leave += Control_Leave;
                        continue;
                    }

                    //if (controlForm is NumericUpDown)
                    //{
                    //    ((NumericUpDown)controlForm).Enter += Control_Enter;
                    //    ((NumericUpDown)controlForm).Leave += Control_Leave;
                    //    continue;
                    //}

                    //

                    if (controlForm is Panel)
                    {
                        AsignarEvento_EnterLeave(controlForm);
                    }

                    if (controlForm is TabControl)
                    {
                        AsignarEvento_EnterLeave(controlForm);
                    }

                    if (controlForm is GroupBox)
                    {
                        AsignarEvento_EnterLeave(controlForm);
                    }
                }
            }else if (obj is Panel)
            {
                foreach (var ControlPanel in ((Panel)obj).Controls)
                {
                    if (ControlPanel is TextBox)
                    {
                        ((TextBox)ControlPanel).Enter += Control_Enter;
                        ((TextBox)ControlPanel).Leave += Control_Leave;
                        continue;
                    }

                    if (ControlPanel is RichTextBox)
                    {
                        ((RichTextBox)ControlPanel).Enter += Control_Enter;
                        ((RichTextBox)ControlPanel).Leave += Control_Leave;
                        continue;
                    }

//
                    //if (controlForm is ComboBox)
                    //{
                    //    ((ComboBox)controlForm).Enter += Control_Enter;
                    //    ((ComboBox)controlForm).Leave += Control_Leave;
                    //    continue;
                    //}

                    if (ControlPanel is Panel)
                    {
                        AsignarEvento_EnterLeave(ControlPanel);
                    }

                    if (ControlPanel is TabControl)
                    {
                        AsignarEvento_EnterLeave(ControlPanel);
                    }

                    if (ControlPanel is GroupBox)
                    {
                        AsignarEvento_EnterLeave(ControlPanel);
                    }
                }
            }else if (obj is TabControl)
            {
                foreach (var ControlTabControl in ((TabControl)obj).Controls)
                {
                    if (ControlTabControl is TextBox)
                    {
                        ((TextBox)ControlTabControl).Enter += Control_Enter;
                        ((TextBox)ControlTabControl).Leave += Control_Leave;
                        continue;
                    }

//

                    if (ControlTabControl is RichTextBox)
                    {
                        ((RichTextBox)ControlTabControl).Enter += Control_Enter;
                        ((RichTextBox)ControlTabControl).Leave += Control_Leave;
                        continue;
                    }
                    //

                    if (ControlTabControl is Panel)
                    {
                        AsignarEvento_EnterLeave(ControlTabControl);
                    }

                    if (ControlTabControl is TabPage)
                    {
                        AsignarEvento_EnterLeave(ControlTabControl);
                    }

                    if (ControlTabControl is GroupBox)
                    {
                        AsignarEvento_EnterLeave(ControlTabControl);
                    }

                }
            }else if (obj is GroupBox)
            {
                foreach (var ControlGroupBox in ((GroupBox)obj).Controls)
                {
                    if (ControlGroupBox is TextBox)
                    {
                        ((TextBox)ControlGroupBox).Enter += Control_Enter;
                        ((TextBox)ControlGroupBox).Leave += Control_Leave;
                        continue;
                    }

//

                    if (ControlGroupBox is RichTextBox)
                    {
                        ((RichTextBox)ControlGroupBox).Enter += Control_Enter;
                        ((RichTextBox)ControlGroupBox).Leave += Control_Leave;
                        continue;
                    }
                    //

                    if (ControlGroupBox is Panel)
                    {
                        AsignarEvento_EnterLeave(ControlGroupBox);
                    }

                    if (ControlGroupBox is TabPage)
                    {
                        AsignarEvento_EnterLeave(ControlGroupBox);
                    }

                    if (ControlGroupBox is GroupBox)
                    {
                        AsignarEvento_EnterLeave(ControlGroupBox);
                    }
                }
            }
        }

        public virtual void PoblarComboBox(ComboBox cmb,
             object datos,
            string PropiedadMostrar = "",
            string propiedadDevolver = "")
        {
            cmb.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb.DataSource = datos;


            if (!string.IsNullOrEmpty(PropiedadMostrar))
            {
                cmb.DisplayMember = PropiedadMostrar;
            }

            if (!string.IsNullOrEmpty(propiedadDevolver))
            {
                cmb.ValueMember = propiedadDevolver;
            }
        }

        public virtual void PoblarComboBox(ComboBox cmb,
            object datos,
            long idSeleccionado,
            string PropiedadMostrar = "",
            string propiedadDevolver = "")
        {
            cmb.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb.DataSource = datos;


            if (!string.IsNullOrEmpty(PropiedadMostrar))
            {
                cmb.DisplayMember = PropiedadMostrar;
            }

            if (!string.IsNullOrEmpty(propiedadDevolver))
            {
                cmb.ValueMember = propiedadDevolver;
            }

            cmb.SelectedValue = idSeleccionado;
        }

        public virtual void FormatearGrilla(DataGridView dgv)
        {
            for (int i = 0; i < dgv.ColumnCount; i++)
            {
                dgv.Columns[i].Visible = false;
                dgv.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }
    }
}
