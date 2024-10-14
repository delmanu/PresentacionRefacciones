namespace PresentacionRefaccionaria
{
    partial class FrmMenu
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.bntCerrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.tsbHerramientas = new System.Windows.Forms.ToolStripButton();
            this.tsbRefacciones = new System.Windows.Forms.ToolStripButton();
            this.tsbMarcas = new System.Windows.Forms.ToolStripButton();
            this.tsbUsuarios = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbHerramientas,
            this.toolStripSeparator1,
            this.tsbRefacciones,
            this.toolStripSeparator2,
            this.tsbMarcas,
            this.toolStripSeparator3,
            this.tsbUsuarios});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(81, 720);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(78, 6);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(78, 6);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(78, 6);
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(41)))), ((int)(((byte)(64)))));
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Enabled = false;
            this.splitter1.Location = new System.Drawing.Point(81, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1199, 66);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // bntCerrar
            // 
            this.bntCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bntCerrar.Location = new System.Drawing.Point(1109, 16);
            this.bntCerrar.Name = "bntCerrar";
            this.bntCerrar.Size = new System.Drawing.Size(155, 36);
            this.bntCerrar.TabIndex = 3;
            this.bntCerrar.Text = "Cerrar Sesión";
            this.bntCerrar.UseVisualStyleBackColor = true;
            this.bntCerrar.Click += new System.EventHandler(this.bntCerrar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(41)))), ((int)(((byte)(64)))));
            this.label1.Font = new System.Drawing.Font("Product Sans", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Snow;
            this.label1.Location = new System.Drawing.Point(105, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "Bienvenido";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(41)))), ((int)(((byte)(64)))));
            this.lblNombre.Font = new System.Drawing.Font("Product Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.Snow;
            this.lblNombre.Location = new System.Drawing.Point(105, 31);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(106, 25);
            this.lblNombre.TabIndex = 5;
            this.lblNombre.Text = "[NOMBRE]";
            // 
            // tsbHerramientas
            // 
            this.tsbHerramientas.AutoSize = false;
            this.tsbHerramientas.Font = new System.Drawing.Font("Product Sans", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsbHerramientas.Image = global::PresentacionRefaccionaria.Properties.Resources.support;
            this.tsbHerramientas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbHerramientas.Name = "tsbHerramientas";
            this.tsbHerramientas.Size = new System.Drawing.Size(80, 80);
            this.tsbHerramientas.Text = "Herramientas";
            this.tsbHerramientas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbHerramientas.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.tsbHerramientas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbHerramientas.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // tsbRefacciones
            // 
            this.tsbRefacciones.AutoSize = false;
            this.tsbRefacciones.Font = new System.Drawing.Font("Product Sans", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsbRefacciones.Image = global::PresentacionRefaccionaria.Properties.Resources.shock_absorber;
            this.tsbRefacciones.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRefacciones.Name = "tsbRefacciones";
            this.tsbRefacciones.Size = new System.Drawing.Size(80, 80);
            this.tsbRefacciones.Text = "Refacciones";
            this.tsbRefacciones.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbRefacciones.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbRefacciones.Click += new System.EventHandler(this.tsbRefacciones_Click);
            // 
            // tsbMarcas
            // 
            this.tsbMarcas.AutoSize = false;
            this.tsbMarcas.Font = new System.Drawing.Font("Product Sans", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsbMarcas.Image = global::PresentacionRefaccionaria.Properties.Resources.digger;
            this.tsbMarcas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMarcas.Name = "tsbMarcas";
            this.tsbMarcas.Size = new System.Drawing.Size(80, 80);
            this.tsbMarcas.Text = "Marcas";
            this.tsbMarcas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbMarcas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbMarcas.ToolTipText = "Marcas";
            this.tsbMarcas.Click += new System.EventHandler(this.tsbMarcas_Click);
            // 
            // tsbUsuarios
            // 
            this.tsbUsuarios.AutoSize = false;
            this.tsbUsuarios.Image = global::PresentacionRefaccionaria.Properties.Resources.account;
            this.tsbUsuarios.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUsuarios.Name = "tsbUsuarios";
            this.tsbUsuarios.Size = new System.Drawing.Size(80, 80);
            this.tsbUsuarios.Text = "Cuentas";
            this.tsbUsuarios.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbUsuarios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbUsuarios.ToolTipText = "Cuentas";
            this.tsbUsuarios.Click += new System.EventHandler(this.tsbUsuarios_Click);
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::PresentacionRefaccionaria.Properties.Resources.bgtaller_Mesa_de_trabajo_1_03;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bntCerrar);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.toolStrip1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Product Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "FrmMenu";
            this.Text = "Menu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMenu_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbHerramientas;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbRefacciones;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbMarcas;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbUsuarios;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Button bntCerrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNombre;
    }
}