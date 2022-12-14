namespace CommerceApp
{
    partial class Principal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.seguridadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuEmpleado = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuUsuario = new System.Windows.Forms.ToolStripMenuItem();
            this.clienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuCliente = new System.Windows.Forms.ToolStripMenuItem();
            this.cuentaCorrienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administraciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuConfiguracion = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.provinciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuDepartamento = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuLocalidad = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuMarca = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuRubro = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuArticulo = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuActualizarPrecio = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.IconoSalir = new FontAwesome.Sharp.IconMenuItem();
            this.IconoMaximizar = new FontAwesome.Sharp.IconMenuItem();
            this.IconoOcultar = new FontAwesome.Sharp.IconMenuItem();
            this.comprobanteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFactura = new System.Windows.Forms.ToolStripMenuItem();
            this.CobroDiferido = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuComprobantes = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuBajaComprobantesViejos = new System.Windows.Forms.ToolStripMenuItem();
            this.menuConsolidado = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuReporteFactura = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuReporteArticloStock = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuReporteClientesCuentaCorriente = new System.Windows.Forms.ToolStripMenuItem();
            this.listaDeProductosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblApyNom = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ptbFotoUsuario = new System.Windows.Forms.PictureBox();
            this.btnVenta = new System.Windows.Forms.Button();
            this.btnCobroDiferido = new System.Windows.Forms.Button();
            this.btnArticulo = new System.Windows.Forms.Button();
            this.btnPrecio = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.bntConsolidado = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.txtCuentaCorriente = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.txtEfectivo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbFotoUsuario)).BeginInit();
            this.panel6.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Black;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.seguridadToolStripMenuItem,
            this.administraciónToolStripMenuItem,
            this.IconoSalir,
            this.IconoMaximizar,
            this.IconoOcultar,
            this.comprobanteToolStripMenuItem,
            this.reportesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(998, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.menuStrip1_MouseDown);
            // 
            // seguridadToolStripMenuItem
            // 
            this.seguridadToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuEmpleado,
            this.MenuUsuario,
            this.clienteToolStripMenuItem});
            this.seguridadToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, System.Drawing.FontStyle.Bold);
            this.seguridadToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.seguridadToolStripMenuItem.Name = "seguridadToolStripMenuItem";
            this.seguridadToolStripMenuItem.Size = new System.Drawing.Size(83, 29);
            this.seguridadToolStripMenuItem.Text = "Seguridad";
            // 
            // MenuEmpleado
            // 
            this.MenuEmpleado.Name = "MenuEmpleado";
            this.MenuEmpleado.Size = new System.Drawing.Size(180, 22);
            this.MenuEmpleado.Text = "Empleado";
            this.MenuEmpleado.Click += new System.EventHandler(this.MenuEmpleado_Click);
            // 
            // MenuUsuario
            // 
            this.MenuUsuario.Name = "MenuUsuario";
            this.MenuUsuario.Size = new System.Drawing.Size(180, 22);
            this.MenuUsuario.Text = "Usuario";
            this.MenuUsuario.Click += new System.EventHandler(this.MenuUsuario_Click);
            // 
            // clienteToolStripMenuItem
            // 
            this.clienteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuCliente,
            this.cuentaCorrienteToolStripMenuItem});
            this.clienteToolStripMenuItem.Name = "clienteToolStripMenuItem";
            this.clienteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.clienteToolStripMenuItem.Text = "Cliente";
            // 
            // MenuCliente
            // 
            this.MenuCliente.Name = "MenuCliente";
            this.MenuCliente.Size = new System.Drawing.Size(180, 22);
            this.MenuCliente.Text = "Consulta";
            this.MenuCliente.Click += new System.EventHandler(this.MenuCliente_Click);
            // 
            // cuentaCorrienteToolStripMenuItem
            // 
            this.cuentaCorrienteToolStripMenuItem.Name = "cuentaCorrienteToolStripMenuItem";
            this.cuentaCorrienteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cuentaCorrienteToolStripMenuItem.Text = "Cuenta corriente";
            this.cuentaCorrienteToolStripMenuItem.Click += new System.EventHandler(this.MenuCuentaCorriente_Click);
            // 
            // administraciónToolStripMenuItem
            // 
            this.administraciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuConfiguracion,
            this.toolStripSeparator2,
            this.provinciaToolStripMenuItem,
            this.MenuDepartamento,
            this.MenuLocalidad,
            this.toolStripSeparator1,
            this.MenuMarca,
            this.MenuRubro,
            this.MenuArticulo,
            this.MenuActualizarPrecio,
            this.toolStripMenuItem1});
            this.administraciónToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, System.Drawing.FontStyle.Bold);
            this.administraciónToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.administraciónToolStripMenuItem.Name = "administraciónToolStripMenuItem";
            this.administraciónToolStripMenuItem.Size = new System.Drawing.Size(116, 29);
            this.administraciónToolStripMenuItem.Text = "Administración";
            // 
            // MenuConfiguracion
            // 
            this.MenuConfiguracion.Name = "MenuConfiguracion";
            this.MenuConfiguracion.Size = new System.Drawing.Size(184, 22);
            this.MenuConfiguracion.Text = "Configuracion";
            this.MenuConfiguracion.Click += new System.EventHandler(this.MenuConfiguracion_Click_1);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(181, 6);
            // 
            // provinciaToolStripMenuItem
            // 
            this.provinciaToolStripMenuItem.Name = "provinciaToolStripMenuItem";
            this.provinciaToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.provinciaToolStripMenuItem.Text = "Provincia";
            this.provinciaToolStripMenuItem.Click += new System.EventHandler(this.provinciaToolStripMenuItem_Click);
            // 
            // MenuDepartamento
            // 
            this.MenuDepartamento.Name = "MenuDepartamento";
            this.MenuDepartamento.Size = new System.Drawing.Size(184, 22);
            this.MenuDepartamento.Text = "Departamento";
            this.MenuDepartamento.Click += new System.EventHandler(this.MenuDepartamento_Click);
            // 
            // MenuLocalidad
            // 
            this.MenuLocalidad.Name = "MenuLocalidad";
            this.MenuLocalidad.Size = new System.Drawing.Size(184, 22);
            this.MenuLocalidad.Text = "Localidad";
            this.MenuLocalidad.Click += new System.EventHandler(this.MenuLocalidad_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(181, 6);
            // 
            // MenuMarca
            // 
            this.MenuMarca.Name = "MenuMarca";
            this.MenuMarca.Size = new System.Drawing.Size(184, 22);
            this.MenuMarca.Text = "Marca";
            this.MenuMarca.Click += new System.EventHandler(this.MenuMarca_Click_1);
            // 
            // MenuRubro
            // 
            this.MenuRubro.Name = "MenuRubro";
            this.MenuRubro.Size = new System.Drawing.Size(184, 22);
            this.MenuRubro.Text = "Rubro";
            this.MenuRubro.Click += new System.EventHandler(this.MenuRubro_Click_1);
            // 
            // MenuArticulo
            // 
            this.MenuArticulo.Name = "MenuArticulo";
            this.MenuArticulo.Size = new System.Drawing.Size(184, 22);
            this.MenuArticulo.Text = "Articulo";
            this.MenuArticulo.Click += new System.EventHandler(this.MenuArticulo_Click);
            // 
            // MenuActualizarPrecio
            // 
            this.MenuActualizarPrecio.Name = "MenuActualizarPrecio";
            this.MenuActualizarPrecio.Size = new System.Drawing.Size(184, 22);
            this.MenuActualizarPrecio.Text = "Actualizar Precio";
            this.MenuActualizarPrecio.Click += new System.EventHandler(this.MenuActualizarPrecio_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(181, 6);
            // 
            // IconoSalir
            // 
            this.IconoSalir.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.IconoSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.IconoSalir.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.IconoSalir.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.IconoSalir.IconColor = System.Drawing.Color.Red;
            this.IconoSalir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.IconoSalir.IconSize = 48;
            this.IconoSalir.Name = "IconoSalir";
            this.IconoSalir.Rotation = 0D;
            this.IconoSalir.Size = new System.Drawing.Size(37, 29);
            this.IconoSalir.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.IconoSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.IconoSalir.Click += new System.EventHandler(this.IconoSalir_Click);
            // 
            // IconoMaximizar
            // 
            this.IconoMaximizar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.IconoMaximizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.IconoMaximizar.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.IconoMaximizar.IconChar = FontAwesome.Sharp.IconChar.WindowRestore;
            this.IconoMaximizar.IconColor = System.Drawing.Color.White;
            this.IconoMaximizar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.IconoMaximizar.IconSize = 48;
            this.IconoMaximizar.Name = "IconoMaximizar";
            this.IconoMaximizar.Rotation = 0D;
            this.IconoMaximizar.Size = new System.Drawing.Size(37, 29);
            this.IconoMaximizar.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.IconoMaximizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.IconoMaximizar.Click += new System.EventHandler(this.IconoMaximizar_Click);
            // 
            // IconoOcultar
            // 
            this.IconoOcultar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.IconoOcultar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.IconoOcultar.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.IconoOcultar.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            this.IconoOcultar.IconColor = System.Drawing.Color.White;
            this.IconoOcultar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.IconoOcultar.IconSize = 48;
            this.IconoOcultar.Name = "IconoOcultar";
            this.IconoOcultar.Rotation = 0D;
            this.IconoOcultar.Size = new System.Drawing.Size(37, 29);
            this.IconoOcultar.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.IconoOcultar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.IconoOcultar.Click += new System.EventHandler(this.IconoOcultar_Click);
            // 
            // comprobanteToolStripMenuItem
            // 
            this.comprobanteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFactura,
            this.CobroDiferido,
            this.MenuComprobantes,
            this.MenuBajaComprobantesViejos,
            this.menuConsolidado});
            this.comprobanteToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comprobanteToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.comprobanteToolStripMenuItem.Name = "comprobanteToolStripMenuItem";
            this.comprobanteToolStripMenuItem.Size = new System.Drawing.Size(105, 29);
            this.comprobanteToolStripMenuItem.Text = "Comprobante";
            // 
            // MenuFactura
            // 
            this.MenuFactura.Name = "MenuFactura";
            this.MenuFactura.Size = new System.Drawing.Size(229, 22);
            this.MenuFactura.Text = "Venta";
            this.MenuFactura.Click += new System.EventHandler(this.MenuFactura_Click);
            // 
            // CobroDiferido
            // 
            this.CobroDiferido.Name = "CobroDiferido";
            this.CobroDiferido.Size = new System.Drawing.Size(229, 22);
            this.CobroDiferido.Text = "Cobro Diferido";
            this.CobroDiferido.Click += new System.EventHandler(this.CobroDiferido_Click);
            // 
            // MenuComprobantes
            // 
            this.MenuComprobantes.Name = "MenuComprobantes";
            this.MenuComprobantes.Size = new System.Drawing.Size(229, 22);
            this.MenuComprobantes.Text = "Comision Comprobantes";
            this.MenuComprobantes.Click += new System.EventHandler(this.MenuComprobantes_Click);
            // 
            // MenuBajaComprobantesViejos
            // 
            this.MenuBajaComprobantesViejos.Name = "MenuBajaComprobantesViejos";
            this.MenuBajaComprobantesViejos.Size = new System.Drawing.Size(229, 22);
            this.MenuBajaComprobantesViejos.Text = "Baja de Comprobantes";
            this.MenuBajaComprobantesViejos.Click += new System.EventHandler(this.MenuBajaComprobantesViejos_Click);
            // 
            // menuConsolidado
            // 
            this.menuConsolidado.Name = "menuConsolidado";
            this.menuConsolidado.Size = new System.Drawing.Size(229, 22);
            this.menuConsolidado.Text = "Consolidado";
            this.menuConsolidado.Click += new System.EventHandler(this.menuConsolidado_Click);
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuReporteFactura,
            this.MenuReporteArticloStock,
            this.MenuReporteClientesCuentaCorriente,
            this.listaDeProductosToolStripMenuItem});
            this.reportesToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, System.Drawing.FontStyle.Bold);
            this.reportesToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(76, 29);
            this.reportesToolStripMenuItem.Text = "Reportes";
            // 
            // MenuReporteFactura
            // 
            this.MenuReporteFactura.Name = "MenuReporteFactura";
            this.MenuReporteFactura.Size = new System.Drawing.Size(230, 22);
            this.MenuReporteFactura.Text = "Comprobantes";
            this.MenuReporteFactura.Click += new System.EventHandler(this.MenuReporteFactura_Click);
            // 
            // MenuReporteArticloStock
            // 
            this.MenuReporteArticloStock.Name = "MenuReporteArticloStock";
            this.MenuReporteArticloStock.Size = new System.Drawing.Size(230, 22);
            this.MenuReporteArticloStock.Text = "Existencias de productos";
            this.MenuReporteArticloStock.Click += new System.EventHandler(this.MenuReporteArticloStock_Click);
            // 
            // MenuReporteClientesCuentaCorriente
            // 
            this.MenuReporteClientesCuentaCorriente.Name = "MenuReporteClientesCuentaCorriente";
            this.MenuReporteClientesCuentaCorriente.Size = new System.Drawing.Size(230, 22);
            this.MenuReporteClientesCuentaCorriente.Text = "Deudas de Clientes";
            this.MenuReporteClientesCuentaCorriente.Click += new System.EventHandler(this.MenuReporteClientesCuentaCorriente_Click);
            // 
            // listaDeProductosToolStripMenuItem
            // 
            this.listaDeProductosToolStripMenuItem.Name = "listaDeProductosToolStripMenuItem";
            this.listaDeProductosToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.listaDeProductosToolStripMenuItem.Text = "Lista de Productos";
            this.listaDeProductosToolStripMenuItem.Click += new System.EventHandler(this.listaDeProductosToolStripMenuItem_Click);
            // 
            // lblApyNom
            // 
            this.lblApyNom.AutoSize = true;
            this.lblApyNom.BackColor = System.Drawing.Color.Transparent;
            this.lblApyNom.Font = new System.Drawing.Font("Arial Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApyNom.ForeColor = System.Drawing.Color.Black;
            this.lblApyNom.Location = new System.Drawing.Point(128, 44);
            this.lblApyNom.Name = "lblApyNom";
            this.lblApyNom.Size = new System.Drawing.Size(203, 27);
            this.lblApyNom.TabIndex = 10;
            this.lblApyNom.Text = "Apellido y Nombre";
            this.lblApyNom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Black;
            this.statusStrip1.Location = new System.Drawing.Point(0, 576);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(998, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ptbFotoUsuario
            // 
            this.ptbFotoUsuario.BackColor = System.Drawing.Color.Transparent;
            this.ptbFotoUsuario.Location = new System.Drawing.Point(12, 44);
            this.ptbFotoUsuario.Name = "ptbFotoUsuario";
            this.ptbFotoUsuario.Size = new System.Drawing.Size(110, 110);
            this.ptbFotoUsuario.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbFotoUsuario.TabIndex = 14;
            this.ptbFotoUsuario.TabStop = false;
            // 
            // btnVenta
            // 
            this.btnVenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(166)))), ((int)(((byte)(224)))));
            this.btnVenta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnVenta.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.btnVenta.FlatAppearance.BorderSize = 2;
            this.btnVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVenta.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVenta.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnVenta.Location = new System.Drawing.Point(128, 90);
            this.btnVenta.Name = "btnVenta";
            this.btnVenta.Size = new System.Drawing.Size(136, 30);
            this.btnVenta.TabIndex = 15;
            this.btnVenta.Text = "Venta";
            this.btnVenta.UseVisualStyleBackColor = false;
            this.btnVenta.Click += new System.EventHandler(this.MenuFactura_Click);
            // 
            // btnCobroDiferido
            // 
            this.btnCobroDiferido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(166)))), ((int)(((byte)(224)))));
            this.btnCobroDiferido.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCobroDiferido.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.btnCobroDiferido.FlatAppearance.BorderSize = 2;
            this.btnCobroDiferido.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCobroDiferido.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCobroDiferido.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCobroDiferido.Location = new System.Drawing.Point(128, 126);
            this.btnCobroDiferido.Name = "btnCobroDiferido";
            this.btnCobroDiferido.Size = new System.Drawing.Size(136, 30);
            this.btnCobroDiferido.TabIndex = 16;
            this.btnCobroDiferido.Text = "Cobro Diferido";
            this.btnCobroDiferido.UseVisualStyleBackColor = false;
            this.btnCobroDiferido.Click += new System.EventHandler(this.CobroDiferido_Click);
            // 
            // btnArticulo
            // 
            this.btnArticulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(166)))), ((int)(((byte)(224)))));
            this.btnArticulo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnArticulo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.btnArticulo.FlatAppearance.BorderSize = 2;
            this.btnArticulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArticulo.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArticulo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnArticulo.Location = new System.Drawing.Point(128, 162);
            this.btnArticulo.Name = "btnArticulo";
            this.btnArticulo.Size = new System.Drawing.Size(136, 30);
            this.btnArticulo.TabIndex = 17;
            this.btnArticulo.Text = "Articulo";
            this.btnArticulo.UseVisualStyleBackColor = false;
            this.btnArticulo.Click += new System.EventHandler(this.MenuArticulo_Click);
            // 
            // btnPrecio
            // 
            this.btnPrecio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(166)))), ((int)(((byte)(224)))));
            this.btnPrecio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPrecio.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.btnPrecio.FlatAppearance.BorderSize = 2;
            this.btnPrecio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrecio.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrecio.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnPrecio.Location = new System.Drawing.Point(128, 198);
            this.btnPrecio.Name = "btnPrecio";
            this.btnPrecio.Size = new System.Drawing.Size(136, 30);
            this.btnPrecio.TabIndex = 18;
            this.btnPrecio.Text = "Precio";
            this.btnPrecio.UseVisualStyleBackColor = false;
            this.btnPrecio.Click += new System.EventHandler(this.MenuActualizarPrecio_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(166)))), ((int)(((byte)(224)))));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.button1.FlatAppearance.BorderSize = 2;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(12, 198);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 30);
            this.button1.TabIndex = 19;
            this.button1.Text = "Cta Cte";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.MenuCuentaCorriente_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(166)))), ((int)(((byte)(224)))));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.button2.FlatAppearance.BorderSize = 2;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button2.Location = new System.Drawing.Point(12, 234);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(110, 30);
            this.button2.TabIndex = 20;
            this.button2.Text = "Comision";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.MenuComprobantes_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(166)))), ((int)(((byte)(224)))));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.button3.FlatAppearance.BorderSize = 2;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button3.Location = new System.Drawing.Point(12, 162);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(110, 30);
            this.button3.TabIndex = 21;
            this.button3.Text = "Cliente";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.MenuCliente_Click);
            // 
            // bntConsolidado
            // 
            this.bntConsolidado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(166)))), ((int)(((byte)(224)))));
            this.bntConsolidado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.bntConsolidado.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.bntConsolidado.FlatAppearance.BorderSize = 2;
            this.bntConsolidado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bntConsolidado.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntConsolidado.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bntConsolidado.Location = new System.Drawing.Point(128, 234);
            this.bntConsolidado.Name = "bntConsolidado";
            this.bntConsolidado.Size = new System.Drawing.Size(136, 30);
            this.bntConsolidado.TabIndex = 22;
            this.bntConsolidado.Text = "Consolidado";
            this.bntConsolidado.UseVisualStyleBackColor = false;
            this.bntConsolidado.Click += new System.EventHandler(this.menuConsolidado_Click);
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(166)))), ((int)(((byte)(224)))));
            this.panel6.Controls.Add(this.panel8);
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Controls.Add(this.pictureBox2);
            this.panel6.Location = new System.Drawing.Point(652, 44);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(334, 82);
            this.panel6.TabIndex = 24;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.Transparent;
            this.panel8.Controls.Add(this.txtCuentaCorriente);
            this.panel8.Controls.Add(this.label1);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(205, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(129, 82);
            this.panel8.TabIndex = 3;
            // 
            // txtCuentaCorriente
            // 
            this.txtCuentaCorriente.BackColor = System.Drawing.Color.Transparent;
            this.txtCuentaCorriente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCuentaCorriente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCuentaCorriente.Font = new System.Drawing.Font("Arial Black", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCuentaCorriente.Location = new System.Drawing.Point(0, 30);
            this.txtCuentaCorriente.Name = "txtCuentaCorriente";
            this.txtCuentaCorriente.Size = new System.Drawing.Size(129, 52);
            this.txtCuentaCorriente.TabIndex = 149;
            this.txtCuentaCorriente.Text = "$$$$$$$$$";
            this.txtCuentaCorriente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Arial Black", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 30);
            this.label1.TabIndex = 147;
            this.label1.Text = "Cuenta Corriente";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Transparent;
            this.panel7.Controls.Add(this.txtEfectivo);
            this.panel7.Controls.Add(this.label2);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Location = new System.Drawing.Point(78, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(127, 82);
            this.panel7.TabIndex = 2;
            // 
            // txtEfectivo
            // 
            this.txtEfectivo.BackColor = System.Drawing.Color.Transparent;
            this.txtEfectivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEfectivo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEfectivo.Font = new System.Drawing.Font("Arial Black", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEfectivo.Location = new System.Drawing.Point(0, 30);
            this.txtEfectivo.Name = "txtEfectivo";
            this.txtEfectivo.Size = new System.Drawing.Size(127, 52);
            this.txtEfectivo.TabIndex = 148;
            this.txtEfectivo.Text = "$$$$$$$$$";
            this.txtEfectivo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Arial Black", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 30);
            this.label2.TabIndex = 147;
            this.label2.Text = "Efectivo";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(78, 82);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CommerceApp.Properties.Resources.Principal;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(998, 598);
            this.ControlBox = false;
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.bntConsolidado);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnPrecio);
            this.Controls.Add(this.btnArticulo);
            this.Controls.Add(this.btnCobroDiferido);
            this.Controls.Add(this.btnVenta);
            this.Controls.Add(this.ptbFotoUsuario);
            this.Controls.Add(this.lblApyNom);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "Principal";
            this.Opacity = 0.98D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Control de Inventario";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Principal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbFotoUsuario)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem administraciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem provinciaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuDepartamento;
        private System.Windows.Forms.ToolStripMenuItem MenuLocalidad;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem MenuConfiguracion;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem MenuArticulo;
        private System.Windows.Forms.ToolStripMenuItem MenuRubro;
        private System.Windows.Forms.ToolStripMenuItem MenuMarca;
        private System.Windows.Forms.ToolStripMenuItem seguridadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuEmpleado;
        private System.Windows.Forms.ToolStripMenuItem clienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuUsuario;
        private System.Windows.Forms.ToolStripMenuItem MenuCliente;
        private FontAwesome.Sharp.IconMenuItem IconoSalir;
        private FontAwesome.Sharp.IconMenuItem IconoMaximizar;
        private FontAwesome.Sharp.IconMenuItem IconoOcultar;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Label lblApyNom;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem MenuActualizarPrecio;
        private System.Windows.Forms.ToolStripMenuItem comprobanteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuFactura;
        private System.Windows.Forms.ToolStripMenuItem CobroDiferido;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuReporteFactura;
        private System.Windows.Forms.PictureBox ptbFotoUsuario;
        private System.Windows.Forms.ToolStripMenuItem cuentaCorrienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuComprobantes;
        private System.Windows.Forms.ToolStripMenuItem MenuReporteArticloStock;
        private System.Windows.Forms.ToolStripMenuItem MenuReporteClientesCuentaCorriente;
        private System.Windows.Forms.Button btnVenta;
        private System.Windows.Forms.Button btnCobroDiferido;
        private System.Windows.Forms.Button btnArticulo;
        private System.Windows.Forms.ToolStripMenuItem MenuBajaComprobantesViejos;
        private System.Windows.Forms.Button btnPrecio;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ToolStripMenuItem menuConsolidado;
        private System.Windows.Forms.Button bntConsolidado;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label txtCuentaCorriente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label txtEfectivo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ToolStripMenuItem listaDeProductosToolStripMenuItem;
    }
}

