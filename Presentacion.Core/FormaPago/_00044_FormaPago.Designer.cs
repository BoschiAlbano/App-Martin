namespace Presentacion.Core.FormaPago
{
    partial class _00044_FormaPago
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_00044_FormaPago));
            this.tabControlFormaPago = new System.Windows.Forms.TabControl();
            this.tabPageEfectivo = new System.Windows.Forms.TabPage();
            this.nudMontoEfectivo = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPageCuentaCorriente = new System.Windows.Forms.TabPage();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtMontoAdeudado = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.nudMontoCtaCte = new System.Windows.Forms.NumericUpDown();
            this.label21 = new System.Windows.Forms.Label();
            this.btnBuscarCliente = new System.Windows.Forms.Button();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtApellidoyNombre = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label19 = new System.Windows.Forms.Label();
            this.txtTotalAbonar = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.nudTotal = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.nudTotalCtaCte = new System.Windows.Forms.NumericUpDown();
            this.nudTotalEfectivo = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.IconoSalir = new FontAwesome.Sharp.IconMenuItem();
            this.IconoMaximizar = new FontAwesome.Sharp.IconMenuItem();
            this.IconoOcultar = new FontAwesome.Sharp.IconMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControlFormaPago.SuspendLayout();
            this.tabPageEfectivo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoEfectivo)).BeginInit();
            this.tabPageCuentaCorriente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoCtaCte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotalCtaCte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotalEfectivo)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlFormaPago
            // 
            this.tabControlFormaPago.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControlFormaPago.Controls.Add(this.tabPageEfectivo);
            this.tabControlFormaPago.Controls.Add(this.tabPageCuentaCorriente);
            this.tabControlFormaPago.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabControlFormaPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlFormaPago.Location = new System.Drawing.Point(5, 33);
            this.tabControlFormaPago.Multiline = true;
            this.tabControlFormaPago.Name = "tabControlFormaPago";
            this.tabControlFormaPago.SelectedIndex = 0;
            this.tabControlFormaPago.Size = new System.Drawing.Size(387, 443);
            this.tabControlFormaPago.TabIndex = 2;
            // 
            // tabPageEfectivo
            // 
            this.tabPageEfectivo.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tabPageEfectivo.Controls.Add(this.nudMontoEfectivo);
            this.tabPageEfectivo.Controls.Add(this.label5);
            this.tabPageEfectivo.Controls.Add(this.label1);
            this.tabPageEfectivo.Location = new System.Drawing.Point(25, 4);
            this.tabPageEfectivo.Name = "tabPageEfectivo";
            this.tabPageEfectivo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEfectivo.Size = new System.Drawing.Size(358, 435);
            this.tabPageEfectivo.TabIndex = 0;
            this.tabPageEfectivo.Text = "EFECTIVO";
            // 
            // nudMontoEfectivo
            // 
            this.nudMontoEfectivo.DecimalPlaces = 2;
            this.nudMontoEfectivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.nudMontoEfectivo.Location = new System.Drawing.Point(100, 218);
            this.nudMontoEfectivo.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.nudMontoEfectivo.Name = "nudMontoEfectivo";
            this.nudMontoEfectivo.Size = new System.Drawing.Size(208, 26);
            this.nudMontoEfectivo.TabIndex = 3;
            this.nudMontoEfectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudMontoEfectivo.ValueChanged += new System.EventHandler(this.nudMontoEfectivo_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label5.Location = new System.Drawing.Point(103, 194);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Monto";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(148)))), ((int)(((byte)(218)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(352, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Efectivo";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPageCuentaCorriente
            // 
            this.tabPageCuentaCorriente.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tabPageCuentaCorriente.Controls.Add(this.txtDireccion);
            this.tabPageCuentaCorriente.Controls.Add(this.label26);
            this.tabPageCuentaCorriente.Controls.Add(this.panel4);
            this.tabPageCuentaCorriente.Controls.Add(this.panel3);
            this.tabPageCuentaCorriente.Controls.Add(this.txtMontoAdeudado);
            this.tabPageCuentaCorriente.Controls.Add(this.label20);
            this.tabPageCuentaCorriente.Controls.Add(this.nudMontoCtaCte);
            this.tabPageCuentaCorriente.Controls.Add(this.label21);
            this.tabPageCuentaCorriente.Controls.Add(this.btnBuscarCliente);
            this.tabPageCuentaCorriente.Controls.Add(this.txtTelefono);
            this.tabPageCuentaCorriente.Controls.Add(this.lblTelefono);
            this.tabPageCuentaCorriente.Controls.Add(this.txtApellidoyNombre);
            this.tabPageCuentaCorriente.Controls.Add(this.lblApellido);
            this.tabPageCuentaCorriente.Controls.Add(this.label4);
            this.tabPageCuentaCorriente.Location = new System.Drawing.Point(25, 4);
            this.tabPageCuentaCorriente.Name = "tabPageCuentaCorriente";
            this.tabPageCuentaCorriente.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCuentaCorriente.Size = new System.Drawing.Size(358, 435);
            this.tabPageCuentaCorriente.TabIndex = 3;
            this.tabPageCuentaCorriente.Text = "CTA CTE";
            // 
            // txtDireccion
            // 
            this.txtDireccion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(166)))), ((int)(((byte)(224)))));
            this.txtDireccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDireccion.Enabled = false;
            this.txtDireccion.ForeColor = System.Drawing.Color.Black;
            this.txtDireccion.Location = new System.Drawing.Point(7, 207);
            this.txtDireccion.Margin = new System.Windows.Forms.Padding(2);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(344, 22);
            this.txtDireccion.TabIndex = 138;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(10, 188);
            this.label26.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(75, 16);
            this.label26.TabIndex = 139;
            this.label26.Text = "Direccion";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Location = new System.Drawing.Point(7, 321);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(283, 4);
            this.panel4.TabIndex = 136;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Location = new System.Drawing.Point(7, 242);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(283, 4);
            this.panel3.TabIndex = 135;
            // 
            // txtMontoAdeudado
            // 
            this.txtMontoAdeudado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(166)))), ((int)(((byte)(224)))));
            this.txtMontoAdeudado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMontoAdeudado.Enabled = false;
            this.txtMontoAdeudado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoAdeudado.ForeColor = System.Drawing.Color.Black;
            this.txtMontoAdeudado.Location = new System.Drawing.Point(7, 280);
            this.txtMontoAdeudado.Name = "txtMontoAdeudado";
            this.txtMontoAdeudado.Size = new System.Drawing.Size(343, 26);
            this.txtMontoAdeudado.TabIndex = 134;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(9, 255);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(146, 20);
            this.label20.TabIndex = 133;
            this.label20.Text = "Monto Adeudado";
            // 
            // nudMontoCtaCte
            // 
            this.nudMontoCtaCte.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nudMontoCtaCte.DecimalPlaces = 2;
            this.nudMontoCtaCte.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.nudMontoCtaCte.Location = new System.Drawing.Point(7, 358);
            this.nudMontoCtaCte.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.nudMontoCtaCte.Name = "nudMontoCtaCte";
            this.nudMontoCtaCte.Size = new System.Drawing.Size(343, 26);
            this.nudMontoCtaCte.TabIndex = 132;
            this.nudMontoCtaCte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudMontoCtaCte.ValueChanged += new System.EventHandler(this.nudMontoCtaCte_ValueChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(9, 332);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(59, 20);
            this.label21.TabIndex = 131;
            this.label21.Text = "Monto";
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(148)))), ((int)(((byte)(218)))));
            this.btnBuscarCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBuscarCliente.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarCliente.ForeColor = System.Drawing.Color.Black;
            this.btnBuscarCliente.Location = new System.Drawing.Point(7, 61);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(343, 30);
            this.btnBuscarCliente.TabIndex = 129;
            this.btnBuscarCliente.Text = "Buscar";
            this.btnBuscarCliente.UseVisualStyleBackColor = false;
            this.btnBuscarCliente.Click += new System.EventHandler(this.btnBuscarCliente_Click);
            // 
            // txtTelefono
            // 
            this.txtTelefono.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(166)))), ((int)(((byte)(224)))));
            this.txtTelefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTelefono.Enabled = false;
            this.txtTelefono.ForeColor = System.Drawing.Color.Black;
            this.txtTelefono.Location = new System.Drawing.Point(7, 162);
            this.txtTelefono.Margin = new System.Windows.Forms.Padding(2);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(344, 22);
            this.txtTelefono.TabIndex = 119;
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(13, 144);
            this.lblTelefono.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(70, 16);
            this.lblTelefono.TabIndex = 125;
            this.lblTelefono.Text = "Telefono";
            // 
            // txtApellidoyNombre
            // 
            this.txtApellidoyNombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(166)))), ((int)(((byte)(224)))));
            this.txtApellidoyNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtApellidoyNombre.Enabled = false;
            this.txtApellidoyNombre.ForeColor = System.Drawing.Color.Black;
            this.txtApellidoyNombre.Location = new System.Drawing.Point(7, 117);
            this.txtApellidoyNombre.Margin = new System.Windows.Forms.Padding(2);
            this.txtApellidoyNombre.Name = "txtApellidoyNombre";
            this.txtApellidoyNombre.Size = new System.Drawing.Size(344, 22);
            this.txtApellidoyNombre.TabIndex = 114;
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(10, 100);
            this.lblApellido.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(141, 16);
            this.lblApellido.TabIndex = 116;
            this.lblApellido.Text = "Apellido y Nombre";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(3, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(352, 38);
            this.label4.TabIndex = 1;
            this.label4.Text = "Cuenta Corriente";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(38)))), ((int)(((byte)(70)))));
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSalir.Location = new System.Drawing.Point(640, 369);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(132, 36);
            this.btnSalir.TabIndex = 41;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(38)))), ((int)(((byte)(70)))));
            this.btnConfirmar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConfirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnConfirmar.Location = new System.Drawing.Point(476, 369);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(132, 36);
            this.btnConfirmar.TabIndex = 39;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.ForeColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(476, 336);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(297, 4);
            this.panel2.TabIndex = 38;
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label19.Location = new System.Drawing.Point(508, 67);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(190, 24);
            this.label19.TabIndex = 37;
            this.label19.Text = "Total Abonar:";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTotalAbonar
            // 
            this.txtTotalAbonar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(166)))), ((int)(((byte)(224)))));
            this.txtTotalAbonar.Enabled = false;
            this.txtTotalAbonar.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalAbonar.ForeColor = System.Drawing.Color.Black;
            this.txtTotalAbonar.Location = new System.Drawing.Point(508, 94);
            this.txtTotalAbonar.Name = "txtTotalAbonar";
            this.txtTotalAbonar.Size = new System.Drawing.Size(264, 40);
            this.txtTotalAbonar.TabIndex = 36;
            this.txtTotalAbonar.Text = "0";
            this.txtTotalAbonar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(496, 307);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 20);
            this.label11.TabIndex = 35;
            this.label11.Text = "TOTAL";
            // 
            // nudTotal
            // 
            this.nudTotal.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nudTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nudTotal.DecimalPlaces = 2;
            this.nudTotal.Enabled = false;
            this.nudTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudTotal.ForeColor = System.Drawing.Color.Black;
            this.nudTotal.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudTotal.Location = new System.Drawing.Point(564, 304);
            this.nudTotal.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.nudTotal.Name = "nudTotal";
            this.nudTotal.Size = new System.Drawing.Size(208, 26);
            this.nudTotal.TabIndex = 34;
            this.nudTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudTotal.ValueChanged += new System.EventHandler(this.nudTotal_ValueChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.ForeColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(475, 294);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(297, 4);
            this.panel1.TabIndex = 33;
            // 
            // nudTotalCtaCte
            // 
            this.nudTotalCtaCte.DecimalPlaces = 2;
            this.nudTotalCtaCte.Enabled = false;
            this.nudTotalCtaCte.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudTotalCtaCte.ForeColor = System.Drawing.Color.Black;
            this.nudTotalCtaCte.Location = new System.Drawing.Point(565, 249);
            this.nudTotalCtaCte.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.nudTotalCtaCte.Name = "nudTotalCtaCte";
            this.nudTotalCtaCte.Size = new System.Drawing.Size(208, 26);
            this.nudTotalCtaCte.TabIndex = 32;
            this.nudTotalCtaCte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudTotalCtaCte.ValueChanged += new System.EventHandler(this.nudTotalEfectivo_ValueChanged);
            // 
            // nudTotalEfectivo
            // 
            this.nudTotalEfectivo.DecimalPlaces = 2;
            this.nudTotalEfectivo.Enabled = false;
            this.nudTotalEfectivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudTotalEfectivo.ForeColor = System.Drawing.Color.Black;
            this.nudTotalEfectivo.Location = new System.Drawing.Point(565, 207);
            this.nudTotalEfectivo.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.nudTotalEfectivo.Name = "nudTotalEfectivo";
            this.nudTotalEfectivo.Size = new System.Drawing.Size(208, 26);
            this.nudTotalEfectivo.TabIndex = 29;
            this.nudTotalEfectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudTotalEfectivo.ValueChanged += new System.EventHandler(this.nudTotalEfectivo_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(471, 251);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(97, 20);
            this.label10.TabIndex = 28;
            this.label10.Text = "A Cta. Cte.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(489, 209);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 20);
            this.label7.TabIndex = 25;
            this.label7.Text = "Efectivo";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(535, 159);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(204, 25);
            this.label6.TabIndex = 24;
            this.label6.Text = "Resumen de Pago";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Black;
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(5, 498);
            this.panel7.TabIndex = 47;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Black;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.IconoSalir,
            this.IconoMaximizar,
            this.IconoOcultar});
            this.menuStrip1.Location = new System.Drawing.Point(5, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(793, 33);
            this.menuStrip1.TabIndex = 48;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.menuStrip1_MouseDown);
            // 
            // IconoSalir
            // 
            this.IconoSalir.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.IconoSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.IconoSalir.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.IconoSalir.IconColor = System.Drawing.Color.Red;
            this.IconoSalir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.IconoSalir.Name = "IconoSalir";
            this.IconoSalir.Size = new System.Drawing.Size(37, 29);
            this.IconoSalir.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.IconoSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.IconoSalir.Click += new System.EventHandler(this.IconoSalir_Click);
            // 
            // IconoMaximizar
            // 
            this.IconoMaximizar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.IconoMaximizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.IconoMaximizar.IconChar = FontAwesome.Sharp.IconChar.WindowRestore;
            this.IconoMaximizar.IconColor = System.Drawing.Color.White;
            this.IconoMaximizar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.IconoMaximizar.Name = "IconoMaximizar";
            this.IconoMaximizar.Size = new System.Drawing.Size(37, 29);
            this.IconoMaximizar.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.IconoMaximizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.IconoMaximizar.Click += new System.EventHandler(this.IconoMaximizar_Click);
            // 
            // IconoOcultar
            // 
            this.IconoOcultar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.IconoOcultar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.IconoOcultar.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            this.IconoOcultar.IconColor = System.Drawing.Color.White;
            this.IconoOcultar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.IconoOcultar.Name = "IconoOcultar";
            this.IconoOcultar.Size = new System.Drawing.Size(37, 29);
            this.IconoOcultar.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.IconoOcultar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.IconoOcultar.Click += new System.EventHandler(this.IconoOcultar_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Black;
            this.statusStrip1.Location = new System.Drawing.Point(5, 476);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(793, 22);
            this.statusStrip1.TabIndex = 49;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(402, 37);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 97);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 50;
            this.pictureBox1.TabStop = false;
            // 
            // _00044_FormaPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(798, 498);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.txtTotalAbonar);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.nudTotal);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.nudTotalCtaCte);
            this.Controls.Add(this.nudTotalEfectivo);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tabControlFormaPago);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel7);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "_00044_FormaPago";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Forma de Pago";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this._00044_FormaPago_Load);
            this.tabControlFormaPago.ResumeLayout(false);
            this.tabPageEfectivo.ResumeLayout(false);
            this.tabPageEfectivo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoEfectivo)).EndInit();
            this.tabPageCuentaCorriente.ResumeLayout(false);
            this.tabPageCuentaCorriente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoCtaCte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotalCtaCte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotalEfectivo)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlFormaPago;
        private System.Windows.Forms.TabPage tabPageEfectivo;
        private System.Windows.Forms.NumericUpDown nudMontoEfectivo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPageCuentaCorriente;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtMontoAdeudado;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.NumericUpDown nudMontoCtaCte;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button btnBuscarCliente;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtApellidoyNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtTotalAbonar;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown nudTotal;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown nudTotalCtaCte;
        private System.Windows.Forms.NumericUpDown nudTotalEfectivo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private FontAwesome.Sharp.IconMenuItem IconoSalir;
        private FontAwesome.Sharp.IconMenuItem IconoMaximizar;
        private FontAwesome.Sharp.IconMenuItem IconoOcultar;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}