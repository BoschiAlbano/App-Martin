namespace Presentacion.Core.Caja
{
    partial class _00040_CierreCaja
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
            this.pnlSeparador = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnEjecutar = new System.Windows.Forms.ToolStripButton();
            this.btnLimpiar = new System.Windows.Forms.ToolStripButton();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.pnlTotales = new System.Windows.Forms.Panel();
            this.nudTotalEfectivoCaja = new System.Windows.Forms.NumericUpDown();
            this.lblFechaApertura = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCajaInicial = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtCtaCte2 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCheque2 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtTarjeta2 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtCtaCte = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCheque = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTarjeta = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnVerDetalleGastos = new FontAwesome.Sharp.IconPictureBox();
            this.btnVerDetalleCompra = new FontAwesome.Sharp.IconPictureBox();
            this.txtGastos = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCompras = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnVerDetalleVenta = new FontAwesome.Sharp.IconPictureBox();
            this.txtTotalEfectivo = new System.Windows.Forms.TextBox();
            this.toolStrip1.SuspendLayout();
            this.pnlTotales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotalEfectivoCaja)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnVerDetalleGastos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnVerDetalleCompra)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnVerDetalleVenta)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSeparador
            // 
            this.pnlSeparador.BackColor = System.Drawing.Color.Black;
            this.pnlSeparador.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSeparador.Location = new System.Drawing.Point(0, 58);
            this.pnlSeparador.Name = "pnlSeparador";
            this.pnlSeparador.Size = new System.Drawing.Size(800, 5);
            this.pnlSeparador.TabIndex = 5;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(43)))), ((int)(((byte)(84)))));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnEjecutar,
            this.btnLimpiar,
            this.btnSalir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(3);
            this.toolStrip1.Size = new System.Drawing.Size(800, 58);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnEjecutar
            // 
            this.btnEjecutar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnEjecutar.Image = global::Presentacion.Core.Properties.Resources.Modificar;
            this.btnEjecutar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEjecutar.Name = "btnEjecutar";
            this.btnEjecutar.Size = new System.Drawing.Size(53, 49);
            this.btnEjecutar.Text = "Ejecutar";
            this.btnEjecutar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEjecutar.Click += new System.EventHandler(this.btnEjecutar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnLimpiar.Image = global::Presentacion.Core.Properties.Resources.Limpiar;
            this.btnLimpiar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(51, 49);
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnSalir.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnSalir.Image = global::Presentacion.Core.Properties.Resources.Salir;
            this.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(34, 49);
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // pnlTotales
            // 
            this.pnlTotales.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pnlTotales.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlTotales.Controls.Add(this.lblFechaApertura);
            this.pnlTotales.Controls.Add(this.nudTotalEfectivoCaja);
            this.pnlTotales.Controls.Add(this.label1);
            this.pnlTotales.Controls.Add(this.txtCajaInicial);
            this.pnlTotales.Controls.Add(this.label2);
            this.pnlTotales.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTotales.Location = new System.Drawing.Point(0, 63);
            this.pnlTotales.Name = "pnlTotales";
            this.pnlTotales.Size = new System.Drawing.Size(800, 77);
            this.pnlTotales.TabIndex = 8;
            // 
            // nudTotalEfectivoCaja
            // 
            this.nudTotalEfectivoCaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudTotalEfectivoCaja.Location = new System.Drawing.Point(101, 35);
            this.nudTotalEfectivoCaja.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.nudTotalEfectivoCaja.Name = "nudTotalEfectivoCaja";
            this.nudTotalEfectivoCaja.Size = new System.Drawing.Size(185, 31);
            this.nudTotalEfectivoCaja.TabIndex = 9;
            // 
            // lblFechaApertura
            // 
            this.lblFechaApertura.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaApertura.Location = new System.Drawing.Point(429, 38);
            this.lblFechaApertura.Name = "lblFechaApertura";
            this.lblFechaApertura.Size = new System.Drawing.Size(125, 25);
            this.lblFechaApertura.TabIndex = 8;
            this.lblFechaApertura.Text = "Fecha";
            this.lblFechaApertura.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(49, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(278, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Total de Efectivo en Caja";
            // 
            // txtCajaInicial
            // 
            this.txtCajaInicial.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCajaInicial.Enabled = false;
            this.txtCajaInicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCajaInicial.Location = new System.Drawing.Point(591, 34);
            this.txtCajaInicial.Multiline = true;
            this.txtCajaInicial.Name = "txtCajaInicial";
            this.txtCajaInicial.ReadOnly = true;
            this.txtCajaInicial.Size = new System.Drawing.Size(160, 31);
            this.txtCajaInicial.TabIndex = 5;
            this.txtCajaInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(530, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Caja Inicial";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBox4.Controls.Add(this.txtCtaCte2);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.txtCheque2);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.txtTarjeta2);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(410, 283);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(369, 148);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "[ Total de Salidas ]";
            // 
            // txtCtaCte2
            // 
            this.txtCtaCte2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCtaCte2.Enabled = false;
            this.txtCtaCte2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCtaCte2.Location = new System.Drawing.Point(110, 105);
            this.txtCtaCte2.Multiline = true;
            this.txtCtaCte2.Name = "txtCtaCte2";
            this.txtCtaCte2.Size = new System.Drawing.Size(205, 20);
            this.txtCtaCte2.TabIndex = 9;
            this.txtCtaCte2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(34, 105);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(70, 20);
            this.label12.TabIndex = 8;
            this.label12.Text = "Cta Cte";
            // 
            // txtCheque2
            // 
            this.txtCheque2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCheque2.Enabled = false;
            this.txtCheque2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCheque2.Location = new System.Drawing.Point(110, 72);
            this.txtCheque2.Multiline = true;
            this.txtCheque2.Name = "txtCheque2";
            this.txtCheque2.Size = new System.Drawing.Size(205, 20);
            this.txtCheque2.TabIndex = 5;
            this.txtCheque2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(33, 75);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(71, 20);
            this.label13.TabIndex = 4;
            this.label13.Text = "Cheque";
            // 
            // txtTarjeta2
            // 
            this.txtTarjeta2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTarjeta2.Enabled = false;
            this.txtTarjeta2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTarjeta2.Location = new System.Drawing.Point(110, 40);
            this.txtTarjeta2.Multiline = true;
            this.txtTarjeta2.Name = "txtTarjeta2";
            this.txtTarjeta2.Size = new System.Drawing.Size(205, 20);
            this.txtTarjeta2.TabIndex = 3;
            this.txtTarjeta2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(39, 43);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 20);
            this.label14.TabIndex = 2;
            this.label14.Text = "Tarjeta";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBox3.Controls.Add(this.txtCtaCte);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtCheque);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.txtTarjeta);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(19, 283);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(369, 148);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "[ Total de Ingresos ]";
            // 
            // txtCtaCte
            // 
            this.txtCtaCte.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCtaCte.Enabled = false;
            this.txtCtaCte.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCtaCte.Location = new System.Drawing.Point(114, 105);
            this.txtCtaCte.Multiline = true;
            this.txtCtaCte.Name = "txtCtaCte";
            this.txtCtaCte.Size = new System.Drawing.Size(205, 20);
            this.txtCtaCte.TabIndex = 9;
            this.txtCtaCte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(38, 105);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 20);
            this.label9.TabIndex = 8;
            this.label9.Text = "Cta Cte";
            // 
            // txtCheque
            // 
            this.txtCheque.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCheque.Enabled = false;
            this.txtCheque.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCheque.Location = new System.Drawing.Point(114, 72);
            this.txtCheque.Multiline = true;
            this.txtCheque.Name = "txtCheque";
            this.txtCheque.Size = new System.Drawing.Size(205, 20);
            this.txtCheque.TabIndex = 5;
            this.txtCheque.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(37, 75);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 20);
            this.label10.TabIndex = 4;
            this.label10.Text = "Cheque";
            // 
            // txtTarjeta
            // 
            this.txtTarjeta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTarjeta.Enabled = false;
            this.txtTarjeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTarjeta.Location = new System.Drawing.Point(114, 40);
            this.txtTarjeta.Multiline = true;
            this.txtTarjeta.Name = "txtTarjeta";
            this.txtTarjeta.Size = new System.Drawing.Size(205, 20);
            this.txtTarjeta.TabIndex = 3;
            this.txtTarjeta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(43, 43);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 20);
            this.label11.TabIndex = 2;
            this.label11.Text = "Tarjeta";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBox2.Controls.Add(this.btnVerDetalleGastos);
            this.groupBox2.Controls.Add(this.btnVerDetalleCompra);
            this.groupBox2.Controls.Add(this.txtGastos);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtCompras);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(410, 162);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(369, 115);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "[ Salidas del Día ]";
            // 
            // btnVerDetalleGastos
            // 
            this.btnVerDetalleGastos.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnVerDetalleGastos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(43)))), ((int)(((byte)(84)))));
            this.btnVerDetalleGastos.IconChar = FontAwesome.Sharp.IconChar.EllipsisH;
            this.btnVerDetalleGastos.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(43)))), ((int)(((byte)(84)))));
            this.btnVerDetalleGastos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnVerDetalleGastos.IconSize = 30;
            this.btnVerDetalleGastos.Location = new System.Drawing.Point(320, 65);
            this.btnVerDetalleGastos.Name = "btnVerDetalleGastos";
            this.btnVerDetalleGastos.Size = new System.Drawing.Size(30, 30);
            this.btnVerDetalleGastos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnVerDetalleGastos.TabIndex = 17;
            this.btnVerDetalleGastos.TabStop = false;
            // 
            // btnVerDetalleCompra
            // 
            this.btnVerDetalleCompra.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnVerDetalleCompra.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(43)))), ((int)(((byte)(84)))));
            this.btnVerDetalleCompra.IconChar = FontAwesome.Sharp.IconChar.EllipsisH;
            this.btnVerDetalleCompra.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(43)))), ((int)(((byte)(84)))));
            this.btnVerDetalleCompra.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnVerDetalleCompra.IconSize = 30;
            this.btnVerDetalleCompra.Location = new System.Drawing.Point(320, 33);
            this.btnVerDetalleCompra.Name = "btnVerDetalleCompra";
            this.btnVerDetalleCompra.Size = new System.Drawing.Size(30, 30);
            this.btnVerDetalleCompra.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnVerDetalleCompra.TabIndex = 17;
            this.btnVerDetalleCompra.TabStop = false;
            // 
            // txtGastos
            // 
            this.txtGastos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtGastos.Enabled = false;
            this.txtGastos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGastos.Location = new System.Drawing.Point(131, 68);
            this.txtGastos.Multiline = true;
            this.txtGastos.Name = "txtGastos";
            this.txtGastos.Size = new System.Drawing.Size(183, 20);
            this.txtGastos.TabIndex = 5;
            this.txtGastos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(59, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "Gastos";
            // 
            // txtCompras
            // 
            this.txtCompras.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCompras.Enabled = false;
            this.txtCompras.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompras.Location = new System.Drawing.Point(131, 36);
            this.txtCompras.Multiline = true;
            this.txtCompras.Name = "txtCompras";
            this.txtCompras.Size = new System.Drawing.Size(183, 20);
            this.txtCompras.TabIndex = 3;
            this.txtCompras.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(47, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 20);
            this.label7.TabIndex = 2;
            this.label7.Text = "Compras";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBox1.Controls.Add(this.btnVerDetalleVenta);
            this.groupBox1.Controls.Add(this.txtTotalEfectivo);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(19, 162);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(369, 115);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "[ Ingresos Efectivo del Día ]";
            // 
            // btnVerDetalleVenta
            // 
            this.btnVerDetalleVenta.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnVerDetalleVenta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(43)))), ((int)(((byte)(84)))));
            this.btnVerDetalleVenta.IconChar = FontAwesome.Sharp.IconChar.EllipsisH;
            this.btnVerDetalleVenta.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(43)))), ((int)(((byte)(84)))));
            this.btnVerDetalleVenta.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnVerDetalleVenta.IconSize = 30;
            this.btnVerDetalleVenta.Location = new System.Drawing.Point(266, 50);
            this.btnVerDetalleVenta.Name = "btnVerDetalleVenta";
            this.btnVerDetalleVenta.Size = new System.Drawing.Size(30, 30);
            this.btnVerDetalleVenta.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnVerDetalleVenta.TabIndex = 16;
            this.btnVerDetalleVenta.TabStop = false;
            this.btnVerDetalleVenta.Click += new System.EventHandler(this.btnVerDetalleVenta_Click);
            // 
            // txtTotalEfectivo
            // 
            this.txtTotalEfectivo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotalEfectivo.Enabled = false;
            this.txtTotalEfectivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalEfectivo.Location = new System.Drawing.Point(78, 49);
            this.txtTotalEfectivo.Multiline = true;
            this.txtTotalEfectivo.Name = "txtTotalEfectivo";
            this.txtTotalEfectivo.Size = new System.Drawing.Size(183, 30);
            this.txtTotalEfectivo.TabIndex = 3;
            this.txtTotalEfectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // _00040_CierreCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pnlTotales);
            this.Controls.Add(this.pnlSeparador);
            this.Controls.Add(this.toolStrip1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(816, 489);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "_00040_CierreCaja";
            this.Text = "Cierre de Caja";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.pnlTotales.ResumeLayout(false);
            this.pnlTotales.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotalEfectivoCaja)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnVerDetalleGastos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnVerDetalleCompra)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnVerDetalleVenta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlSeparador;
        private System.Windows.Forms.ToolStrip toolStrip1;
        protected System.Windows.Forms.ToolStripButton btnEjecutar;
        private System.Windows.Forms.ToolStripButton btnLimpiar;
        private System.Windows.Forms.ToolStripButton btnSalir;
        private System.Windows.Forms.Panel pnlTotales;
        private System.Windows.Forms.Label lblFechaApertura;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCajaInicial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtCtaCte2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtCheque2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtTarjeta2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtCtaCte;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCheque;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtTarjeta;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtGastos;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCompras;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTotalEfectivo;
        private System.Windows.Forms.NumericUpDown nudTotalEfectivoCaja;
        private FontAwesome.Sharp.IconPictureBox btnVerDetalleGastos;
        private FontAwesome.Sharp.IconPictureBox btnVerDetalleCompra;
        private FontAwesome.Sharp.IconPictureBox btnVerDetalleVenta;
    }
}