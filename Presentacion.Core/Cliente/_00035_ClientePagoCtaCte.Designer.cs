namespace Presentacion.Core.Cliente
{
    partial class _00035_ClientePagoCtaCte
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
            this.btnPagar = new System.Windows.Forms.ToolStripButton();
            this.btnLimpiar = new System.Windows.Forms.ToolStripButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nudMontoPagar = new System.Windows.Forms.NumericUpDown();
            this.nudMontoDeuda = new System.Windows.Forms.NumericUpDown();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.IconoSalir = new FontAwesome.Sharp.IconMenuItem();
            this.IconoMaximizar = new FontAwesome.Sharp.IconMenuItem();
            this.IconoOcultar = new FontAwesome.Sharp.IconMenuItem();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoPagar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoDeuda)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSeparador
            // 
            this.pnlSeparador.BackColor = System.Drawing.Color.Black;
            this.pnlSeparador.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSeparador.Location = new System.Drawing.Point(0, 76);
            this.pnlSeparador.Name = "pnlSeparador";
            this.pnlSeparador.Size = new System.Drawing.Size(384, 4);
            this.pnlSeparador.TabIndex = 5;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(148)))), ((int)(((byte)(218)))));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPagar,
            this.btnLimpiar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 33);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(3);
            this.toolStrip1.Size = new System.Drawing.Size(384, 43);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnPagar
            // 
            this.btnPagar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPagar.ForeColor = System.Drawing.Color.Black;
            this.btnPagar.Image = global::Presentacion.Core.Properties.Resources.Pagar;
            this.btnPagar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(77, 34);
            this.btnPagar.Text = "Pagar";
            this.btnPagar.Click += new System.EventHandler(this.btnPagar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.ForeColor = System.Drawing.Color.Black;
            this.btnLimpiar.Image = global::Presentacion.Core.Properties.Resources.Limpiar;
            this.btnLimpiar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(89, 34);
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(54, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 24);
            this.label2.TabIndex = 14;
            this.label2.Text = "Monto a Pagar";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(35, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 24);
            this.label1.TabIndex = 13;
            this.label1.Text = "Monto Adeudado";
            // 
            // nudMontoPagar
            // 
            this.nudMontoPagar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(245)))));
            this.nudMontoPagar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nudMontoPagar.DecimalPlaces = 2;
            this.nudMontoPagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudMontoPagar.Location = new System.Drawing.Point(213, 162);
            this.nudMontoPagar.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudMontoPagar.Name = "nudMontoPagar";
            this.nudMontoPagar.Size = new System.Drawing.Size(133, 29);
            this.nudMontoPagar.TabIndex = 12;
            // 
            // nudMontoDeuda
            // 
            this.nudMontoDeuda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(245)))));
            this.nudMontoDeuda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nudMontoDeuda.DecimalPlaces = 2;
            this.nudMontoDeuda.Enabled = false;
            this.nudMontoDeuda.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudMontoDeuda.Location = new System.Drawing.Point(213, 121);
            this.nudMontoDeuda.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudMontoDeuda.Name = "nudMontoDeuda";
            this.nudMontoDeuda.Size = new System.Drawing.Size(133, 29);
            this.nudMontoDeuda.TabIndex = 11;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Black;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.IconoSalir,
            this.IconoMaximizar,
            this.IconoOcultar});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(384, 33);
            this.menuStrip1.TabIndex = 32;
            this.menuStrip1.Text = "menuStrip1";
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
            // _00035_ClientePagoCtaCte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(384, 211);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudMontoPagar);
            this.Controls.Add(this.nudMontoDeuda);
            this.Controls.Add(this.pnlSeparador);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "_00035_ClientePagoCtaCte";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Realizar Pago";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this._00035_ClientePagoCtaCte_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoPagar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoDeuda)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlSeparador;
        private System.Windows.Forms.ToolStrip toolStrip1;
        protected System.Windows.Forms.ToolStripButton btnPagar;
        private System.Windows.Forms.ToolStripButton btnLimpiar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudMontoPagar;
        private System.Windows.Forms.NumericUpDown nudMontoDeuda;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private FontAwesome.Sharp.IconMenuItem IconoSalir;
        private FontAwesome.Sharp.IconMenuItem IconoMaximizar;
        private FontAwesome.Sharp.IconMenuItem IconoOcultar;
    }
}