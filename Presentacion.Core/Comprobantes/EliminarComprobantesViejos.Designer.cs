
namespace Presentacion.Core.Comprobantes
{
    partial class EliminarComprobantesViejos
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.IconoSalir = new FontAwesome.Sharp.IconMenuItem();
            this.IconoMaximizar = new FontAwesome.Sharp.IconMenuItem();
            this.IconoOcultar = new FontAwesome.Sharp.IconMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            this.menuStrip1.TabIndex = 1;
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 189);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(384, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(166)))), ((int)(((byte)(224)))));
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(384, 63);
            this.label4.TabIndex = 197;
            this.label4.Text = "Pulse el boton Eliminar para borrar todos los comprobantes viejos del sistema, es" +
    "tos comprobantes tendran una fecha de 3 meses atras.";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(384, 156);
            this.panel1.TabIndex = 198;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = global::Presentacion.Core.Properties.Resources.Eliminar;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(145, 71);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 78);
            this.button1.TabIndex = 200;
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // EliminarComprobantesViejos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 211);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "EliminarComprobantesViejos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EliminarComprobantesViejos";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private FontAwesome.Sharp.IconMenuItem IconoSalir;
        private FontAwesome.Sharp.IconMenuItem IconoMaximizar;
        private FontAwesome.Sharp.IconMenuItem IconoOcultar;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
    }
}