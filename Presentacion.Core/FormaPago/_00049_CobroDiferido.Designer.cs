namespace Presentacion.Core.FormaPago
{
    partial class _00049_CobroDiferido
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_00049_CobroDiferido));
            this.pnlSeparador = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.IconoSalir = new FontAwesome.Sharp.IconMenuItem();
            this.IconoMaximizar = new FontAwesome.Sharp.IconMenuItem();
            this.IconoOcultar = new FontAwesome.Sharp.IconMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvGrillaPedientePago = new System.Windows.Forms.DataGridView();
            this.dgvGrillaDetalleComprobante = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBuscar = new FontAwesome.Sharp.IconPictureBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrillaPedientePago)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrillaDetalleComprobante)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBuscar)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSeparador
            // 
            this.pnlSeparador.BackColor = System.Drawing.Color.Black;
            this.pnlSeparador.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSeparador.Location = new System.Drawing.Point(0, 0);
            this.pnlSeparador.Name = "pnlSeparador";
            this.pnlSeparador.Size = new System.Drawing.Size(4, 598);
            this.pnlSeparador.TabIndex = 5;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Black;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.IconoSalir,
            this.IconoMaximizar,
            this.IconoOcultar});
            this.menuStrip1.Location = new System.Drawing.Point(4, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(994, 33);
            this.menuStrip1.TabIndex = 7;
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
            this.statusStrip1.Location = new System.Drawing.Point(4, 576);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(994, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(37, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 25);
            this.label3.TabIndex = 27;
            this.label3.Text = "Cliente";
            // 
            // txtBuscar
            // 
            this.txtBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(166)))), ((int)(((byte)(224)))));
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(10, 98);
            this.txtBuscar.Multiline = true;
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(186, 26);
            this.txtBuscar.TabIndex = 26;
            this.txtBuscar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBuscar.Click += new System.EventHandler(this.txtBuscar_Click);
            this.txtBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscar_KeyPress);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BackColor = System.Drawing.Color.Black;
            this.splitContainer1.Location = new System.Drawing.Point(202, 33);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel1.Controls.Add(this.dgvGrillaPedientePago);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel2.Controls.Add(this.dgvGrillaDetalleComprobante);
            this.splitContainer1.Size = new System.Drawing.Size(796, 543);
            this.splitContainer1.SplitterDistance = 267;
            this.splitContainer1.TabIndex = 6;
            // 
            // dgvGrillaPedientePago
            // 
            this.dgvGrillaPedientePago.AllowUserToAddRows = false;
            this.dgvGrillaPedientePago.AllowUserToDeleteRows = false;
            this.dgvGrillaPedientePago.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(245)))));
            this.dgvGrillaPedientePago.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(166)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGrillaPedientePago.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvGrillaPedientePago.ColumnHeadersHeight = 28;
            this.dgvGrillaPedientePago.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(148)))), ((int)(((byte)(218)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvGrillaPedientePago.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvGrillaPedientePago.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGrillaPedientePago.EnableHeadersVisualStyles = false;
            this.dgvGrillaPedientePago.GridColor = System.Drawing.Color.Black;
            this.dgvGrillaPedientePago.Location = new System.Drawing.Point(0, 0);
            this.dgvGrillaPedientePago.Margin = new System.Windows.Forms.Padding(2);
            this.dgvGrillaPedientePago.MultiSelect = false;
            this.dgvGrillaPedientePago.Name = "dgvGrillaPedientePago";
            this.dgvGrillaPedientePago.ReadOnly = true;
            this.dgvGrillaPedientePago.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(166)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGrillaPedientePago.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvGrillaPedientePago.RowHeadersVisible = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(245)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvGrillaPedientePago.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvGrillaPedientePago.RowTemplate.Height = 24;
            this.dgvGrillaPedientePago.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGrillaPedientePago.Size = new System.Drawing.Size(796, 267);
            this.dgvGrillaPedientePago.TabIndex = 34;
            this.dgvGrillaPedientePago.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGrillaPedientePago_RowEnter);
            this.dgvGrillaPedientePago.DoubleClick += new System.EventHandler(this.dgvGrillaPedientePago_DoubleClick);
            // 
            // dgvGrillaDetalleComprobante
            // 
            this.dgvGrillaDetalleComprobante.AllowUserToAddRows = false;
            this.dgvGrillaDetalleComprobante.AllowUserToDeleteRows = false;
            this.dgvGrillaDetalleComprobante.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(245)))));
            this.dgvGrillaDetalleComprobante.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(166)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGrillaDetalleComprobante.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvGrillaDetalleComprobante.ColumnHeadersHeight = 28;
            this.dgvGrillaDetalleComprobante.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(148)))), ((int)(((byte)(218)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvGrillaDetalleComprobante.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvGrillaDetalleComprobante.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGrillaDetalleComprobante.EnableHeadersVisualStyles = false;
            this.dgvGrillaDetalleComprobante.GridColor = System.Drawing.Color.Black;
            this.dgvGrillaDetalleComprobante.Location = new System.Drawing.Point(0, 0);
            this.dgvGrillaDetalleComprobante.Margin = new System.Windows.Forms.Padding(2);
            this.dgvGrillaDetalleComprobante.MultiSelect = false;
            this.dgvGrillaDetalleComprobante.Name = "dgvGrillaDetalleComprobante";
            this.dgvGrillaDetalleComprobante.ReadOnly = true;
            this.dgvGrillaDetalleComprobante.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(166)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGrillaDetalleComprobante.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvGrillaDetalleComprobante.RowHeadersVisible = false;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(245)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvGrillaDetalleComprobante.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvGrillaDetalleComprobante.RowTemplate.Height = 24;
            this.dgvGrillaDetalleComprobante.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGrillaDetalleComprobante.Size = new System.Drawing.Size(796, 272);
            this.dgvGrillaDetalleComprobante.TabIndex = 34;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(14, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 22);
            this.label2.TabIndex = 35;
            this.label2.Text = "Eliminar";
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(148)))), ((int)(((byte)(218)))));
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.ForeColor = System.Drawing.Color.Black;
            this.btnBuscar.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.btnBuscar.IconColor = System.Drawing.Color.Black;
            this.btnBuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBuscar.IconSize = 36;
            this.btnBuscar.Location = new System.Drawing.Point(129, 49);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(38, 36);
            this.btnBuscar.TabIndex = 28;
            this.btnBuscar.TabStop = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(148)))), ((int)(((byte)(218)))));
            this.btnEliminar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEliminar.BackgroundImage")));
            this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Location = new System.Drawing.Point(18, 187);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(65, 65);
            this.btnEliminar.TabIndex = 37;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Black;
            this.panel4.Location = new System.Drawing.Point(4, 142);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(192, 5);
            this.panel4.TabIndex = 40;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(148)))), ((int)(((byte)(218)))));
            this.btnImprimir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImprimir.BackgroundImage")));
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimir.FlatAppearance.BorderSize = 0;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.Location = new System.Drawing.Point(113, 189);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(65, 65);
            this.btnImprimir.TabIndex = 42;
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(109, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 22);
            this.label1.TabIndex = 43;
            this.label1.Text = "Imprimir";
            // 
            // _00049_CobroDiferido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(148)))), ((int)(((byte)(218)))));
            this.ClientSize = new System.Drawing.Size(998, 598);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pnlSeparador);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Location = new System.Drawing.Point(0, 0);
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "_00049_CobroDiferido";
            this.Text = "Cobro Diferido";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrillaPedientePago)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrillaDetalleComprobante)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBuscar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnlSeparador;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private FontAwesome.Sharp.IconMenuItem IconoSalir;
        private FontAwesome.Sharp.IconMenuItem IconoMaximizar;
        private FontAwesome.Sharp.IconMenuItem IconoOcultar;
        private System.Windows.Forms.StatusStrip statusStrip1;
        protected System.Windows.Forms.Label label3;
        protected System.Windows.Forms.TextBox txtBuscar;
        protected FontAwesome.Sharp.IconPictureBox btnBuscar;
        private System.Windows.Forms.SplitContainer splitContainer1;
        protected System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Panel panel4;
        protected System.Windows.Forms.DataGridView dgvGrillaPedientePago;
        protected System.Windows.Forms.DataGridView dgvGrillaDetalleComprobante;
        private System.Windows.Forms.Button btnImprimir;
        protected System.Windows.Forms.Label label1;
    }
}