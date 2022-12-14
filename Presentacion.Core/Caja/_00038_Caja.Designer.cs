namespace Presentacion.Core.Caja
{
    partial class _00038_Caja
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.pnlBusqueda = new System.Windows.Forms.Panel();
            this.chkFechas = new System.Windows.Forms.CheckBox();
            this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.pnlSeparador = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.TabControlUsuarios = new System.Windows.Forms.TabControl();
            this.tabApertura = new System.Windows.Forms.TabPage();
            this.dgvGrillaApertura = new System.Windows.Forms.DataGridView();
            this.tabCierre = new System.Windows.Forms.TabPage();
            this.dgvGrillaCierre = new System.Windows.Forms.DataGridView();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.btnAbrirCaja = new System.Windows.Forms.ToolStripButton();
            this.btnCierreCaja = new System.Windows.Forms.ToolStripButton();
            this.btnActualizar = new System.Windows.Forms.ToolStripButton();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.pnlBusqueda.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.TabControlUsuarios.SuspendLayout();
            this.tabApertura.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrillaApertura)).BeginInit();
            this.tabCierre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrillaCierre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(43)))), ((int)(((byte)(84)))));
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // pnlBusqueda
            // 
            this.pnlBusqueda.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlBusqueda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBusqueda.Controls.Add(this.iconPictureBox1);
            this.pnlBusqueda.Controls.Add(this.chkFechas);
            this.pnlBusqueda.Controls.Add(this.dtpFechaHasta);
            this.pnlBusqueda.Controls.Add(this.dtpFechaDesde);
            this.pnlBusqueda.Controls.Add(this.txtBuscar);
            this.pnlBusqueda.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBusqueda.Location = new System.Drawing.Point(0, 64);
            this.pnlBusqueda.Name = "pnlBusqueda";
            this.pnlBusqueda.Size = new System.Drawing.Size(800, 56);
            this.pnlBusqueda.TabIndex = 8;
            // 
            // chkFechas
            // 
            this.chkFechas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkFechas.AutoSize = true;
            this.chkFechas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFechas.Location = new System.Drawing.Point(124, 14);
            this.chkFechas.Name = "chkFechas";
            this.chkFechas.Size = new System.Drawing.Size(87, 24);
            this.chkFechas.TabIndex = 4;
            this.chkFechas.Text = "Fechas";
            this.chkFechas.UseVisualStyleBackColor = true;
            this.chkFechas.CheckedChanged += new System.EventHandler(this.chkFechas_CheckedChanged);
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFechaHasta.Enabled = false;
            this.dtpFechaHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaHasta.Location = new System.Drawing.Point(341, 13);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(115, 26);
            this.dtpFechaHasta.TabIndex = 3;
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFechaDesde.Enabled = false;
            this.dtpFechaDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDesde.Location = new System.Drawing.Point(218, 13);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(117, 26);
            this.dtpFechaDesde.TabIndex = 2;
            this.dtpFechaDesde.ValueChanged += new System.EventHandler(this.dtpFechaDesde_ValueChanged);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(462, 12);
            this.txtBuscar.Multiline = true;
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(279, 27);
            this.txtBuscar.TabIndex = 1;
            this.txtBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscar_KeyPress);
            // 
            // pnlSeparador
            // 
            this.pnlSeparador.BackColor = System.Drawing.Color.Black;
            this.pnlSeparador.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSeparador.Location = new System.Drawing.Point(0, 59);
            this.pnlSeparador.Name = "pnlSeparador";
            this.pnlSeparador.Size = new System.Drawing.Size(800, 5);
            this.pnlSeparador.TabIndex = 7;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(43)))), ((int)(((byte)(84)))));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAbrirCaja,
            this.btnCierreCaja,
            this.toolStripSeparator1,
            this.btnActualizar,
            this.btnSalir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(3);
            this.toolStrip1.Size = new System.Drawing.Size(800, 59);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 53);
            // 
            // TabControlUsuarios
            // 
            this.TabControlUsuarios.Controls.Add(this.tabApertura);
            this.TabControlUsuarios.Controls.Add(this.tabCierre);
            this.TabControlUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControlUsuarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabControlUsuarios.Location = new System.Drawing.Point(0, 120);
            this.TabControlUsuarios.Name = "TabControlUsuarios";
            this.TabControlUsuarios.SelectedIndex = 0;
            this.TabControlUsuarios.Size = new System.Drawing.Size(800, 308);
            this.TabControlUsuarios.TabIndex = 28;
            // 
            // tabApertura
            // 
            this.tabApertura.Controls.Add(this.dgvGrillaApertura);
            this.tabApertura.Location = new System.Drawing.Point(4, 25);
            this.tabApertura.Name = "tabApertura";
            this.tabApertura.Padding = new System.Windows.Forms.Padding(3);
            this.tabApertura.Size = new System.Drawing.Size(792, 279);
            this.tabApertura.TabIndex = 0;
            this.tabApertura.Text = "Apertura";
            this.tabApertura.UseVisualStyleBackColor = true;
            // 
            // dgvGrillaApertura
            // 
            this.dgvGrillaApertura.AllowUserToAddRows = false;
            this.dgvGrillaApertura.AllowUserToDeleteRows = false;
            this.dgvGrillaApertura.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dgvGrillaApertura.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGrillaApertura.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvGrillaApertura.ColumnHeadersHeight = 28;
            this.dgvGrillaApertura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvGrillaApertura.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGrillaApertura.EnableHeadersVisualStyles = false;
            this.dgvGrillaApertura.GridColor = System.Drawing.Color.Black;
            this.dgvGrillaApertura.Location = new System.Drawing.Point(3, 3);
            this.dgvGrillaApertura.Margin = new System.Windows.Forms.Padding(2);
            this.dgvGrillaApertura.MultiSelect = false;
            this.dgvGrillaApertura.Name = "dgvGrillaApertura";
            this.dgvGrillaApertura.ReadOnly = true;
            this.dgvGrillaApertura.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGrillaApertura.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvGrillaApertura.RowHeadersVisible = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvGrillaApertura.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvGrillaApertura.RowTemplate.Height = 24;
            this.dgvGrillaApertura.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGrillaApertura.Size = new System.Drawing.Size(786, 273);
            this.dgvGrillaApertura.TabIndex = 27;
            this.dgvGrillaApertura.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGrillaApertura_RowEnter);
            // 
            // tabCierre
            // 
            this.tabCierre.Controls.Add(this.dgvGrillaCierre);
            this.tabCierre.Location = new System.Drawing.Point(4, 25);
            this.tabCierre.Name = "tabCierre";
            this.tabCierre.Padding = new System.Windows.Forms.Padding(3);
            this.tabCierre.Size = new System.Drawing.Size(792, 279);
            this.tabCierre.TabIndex = 1;
            this.tabCierre.Text = "Cierre";
            this.tabCierre.UseVisualStyleBackColor = true;
            // 
            // dgvGrillaCierre
            // 
            this.dgvGrillaCierre.AllowUserToAddRows = false;
            this.dgvGrillaCierre.AllowUserToDeleteRows = false;
            this.dgvGrillaCierre.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dgvGrillaCierre.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGrillaCierre.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvGrillaCierre.ColumnHeadersHeight = 28;
            this.dgvGrillaCierre.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvGrillaCierre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGrillaCierre.EnableHeadersVisualStyles = false;
            this.dgvGrillaCierre.GridColor = System.Drawing.Color.Black;
            this.dgvGrillaCierre.Location = new System.Drawing.Point(3, 3);
            this.dgvGrillaCierre.Margin = new System.Windows.Forms.Padding(2);
            this.dgvGrillaCierre.MultiSelect = false;
            this.dgvGrillaCierre.Name = "dgvGrillaCierre";
            this.dgvGrillaCierre.ReadOnly = true;
            this.dgvGrillaCierre.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGrillaCierre.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvGrillaCierre.RowHeadersVisible = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvGrillaCierre.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvGrillaCierre.RowTemplate.Height = 24;
            this.dgvGrillaCierre.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGrillaCierre.Size = new System.Drawing.Size(786, 273);
            this.dgvGrillaCierre.TabIndex = 27;
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.iconPictureBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.iconPictureBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(43)))), ((int)(((byte)(84)))));
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.iconPictureBox1.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(43)))), ((int)(((byte)(84)))));
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox1.IconSize = 36;
            this.iconPictureBox1.Location = new System.Drawing.Point(747, 10);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(38, 36);
            this.iconPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.iconPictureBox1.TabIndex = 20;
            this.iconPictureBox1.TabStop = false;
            this.iconPictureBox1.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnAbrirCaja
            // 
            this.btnAbrirCaja.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbrirCaja.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnAbrirCaja.Image = global::Presentacion.Core.Properties.Resources.Caja_Apertura;
            this.btnAbrirCaja.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAbrirCaja.Name = "btnAbrirCaja";
            this.btnAbrirCaja.Size = new System.Drawing.Size(120, 50);
            this.btnAbrirCaja.Text = "Apertura de Caja";
            this.btnAbrirCaja.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAbrirCaja.Click += new System.EventHandler(this.btnAbrirCaja_Click);
            // 
            // btnCierreCaja
            // 
            this.btnCierreCaja.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCierreCaja.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnCierreCaja.Image = global::Presentacion.Core.Properties.Resources.Caja_Cierre;
            this.btnCierreCaja.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCierreCaja.Name = "btnCierreCaja";
            this.btnCierreCaja.Size = new System.Drawing.Size(104, 50);
            this.btnCierreCaja.Text = "Cierre de Caja";
            this.btnCierreCaja.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCierreCaja.Click += new System.EventHandler(this.btnCierreCaja_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnActualizar.Image = global::Presentacion.Core.Properties.Resources.Actualizar;
            this.btnActualizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(76, 50);
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnSalir.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnSalir.Image = global::Presentacion.Core.Properties.Resources.Salir;
            this.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(42, 50);
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // _00038_Caja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TabControlUsuarios);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pnlBusqueda);
            this.Controls.Add(this.pnlSeparador);
            this.Controls.Add(this.toolStrip1);
            this.Name = "_00038_Caja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Apertura y Cierre de Cajas";
            this.Load += new System.EventHandler(this._00038_Caja_Load);
            this.pnlBusqueda.ResumeLayout(false);
            this.pnlBusqueda.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.TabControlUsuarios.ResumeLayout(false);
            this.tabApertura.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrillaApertura)).EndInit();
            this.tabCierre.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrillaCierre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel pnlBusqueda;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Panel pnlSeparador;
        private System.Windows.Forms.ToolStrip toolStrip1;
        protected System.Windows.Forms.ToolStripButton btnAbrirCaja;
        protected System.Windows.Forms.ToolStripButton btnCierreCaja;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        protected System.Windows.Forms.ToolStripButton btnActualizar;
        protected System.Windows.Forms.ToolStripButton btnSalir;
        private System.Windows.Forms.DateTimePicker dtpFechaDesde;
        private System.Windows.Forms.CheckBox chkFechas;
        private System.Windows.Forms.DateTimePicker dtpFechaHasta;
        protected FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private System.Windows.Forms.TabControl TabControlUsuarios;
        private System.Windows.Forms.TabPage tabApertura;
        private System.Windows.Forms.TabPage tabCierre;
        protected System.Windows.Forms.DataGridView dgvGrillaApertura;
        protected System.Windows.Forms.DataGridView dgvGrillaCierre;
    }
}