namespace BrainLinkConnect
{
    partial class Form2
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textnombre = new System.Windows.Forms.TextBox();
            this.textedad = new System.Windows.Forms.TextBox();
            this.btnguardar = new System.Windows.Forms.Button();
            this.btnlimpiar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.configuraciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imagenesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.señalesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraciónSonidoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(87, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Edad";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // textnombre
            // 
            this.textnombre.Location = new System.Drawing.Point(148, 52);
            this.textnombre.Name = "textnombre";
            this.textnombre.Size = new System.Drawing.Size(228, 20);
            this.textnombre.TabIndex = 2;
            this.textnombre.TextChanged += new System.EventHandler(this.textnombre_TextChanged);
            // 
            // textedad
            // 
            this.textedad.Location = new System.Drawing.Point(148, 92);
            this.textedad.Name = "textedad";
            this.textedad.Size = new System.Drawing.Size(107, 20);
            this.textedad.TabIndex = 3;
            // 
            // btnguardar
            // 
            this.btnguardar.Location = new System.Drawing.Point(398, 39);
            this.btnguardar.Name = "btnguardar";
            this.btnguardar.Size = new System.Drawing.Size(124, 73);
            this.btnguardar.TabIndex = 4;
            this.btnguardar.Text = "Guardar";
            this.btnguardar.UseVisualStyleBackColor = true;
            this.btnguardar.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnlimpiar
            // 
            this.btnlimpiar.Location = new System.Drawing.Point(528, 39);
            this.btnlimpiar.Name = "btnlimpiar";
            this.btnlimpiar.Size = new System.Drawing.Size(110, 73);
            this.btnlimpiar.TabIndex = 5;
            this.btnlimpiar.Text = "Limpiar";
            this.btnlimpiar.UseVisualStyleBackColor = true;
            this.btnlimpiar.Click += new System.EventHandler(this.btnlimpiar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(90, 148);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(548, 199);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configuraciónToolStripMenuItem,
            this.configuraciónSonidoToolStripMenuItem,
            this.señalesToolStripMenuItem,
            this.imagenesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // configuraciónToolStripMenuItem
            // 
            this.configuraciónToolStripMenuItem.Name = "configuraciónToolStripMenuItem";
            this.configuraciónToolStripMenuItem.Size = new System.Drawing.Size(149, 20);
            this.configuraciónToolStripMenuItem.Text = "Configuración Imágenes";
            this.configuraciónToolStripMenuItem.Click += new System.EventHandler(this.configuraciónToolStripMenuItem_Click);
            // 
            // imagenesToolStripMenuItem
            // 
            this.imagenesToolStripMenuItem.Name = "imagenesToolStripMenuItem";
            this.imagenesToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.imagenesToolStripMenuItem.Text = "Imágenes";
            this.imagenesToolStripMenuItem.Click += new System.EventHandler(this.imagenesToolStripMenuItem_Click);
            // 
            // señalesToolStripMenuItem
            // 
            this.señalesToolStripMenuItem.Name = "señalesToolStripMenuItem";
            this.señalesToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.señalesToolStripMenuItem.Text = "Señales";
            this.señalesToolStripMenuItem.Click += new System.EventHandler(this.señalesToolStripMenuItem_Click);
            // 
            // configuraciónSonidoToolStripMenuItem
            // 
            this.configuraciónSonidoToolStripMenuItem.Name = "configuraciónSonidoToolStripMenuItem";
            this.configuraciónSonidoToolStripMenuItem.Size = new System.Drawing.Size(135, 20);
            this.configuraciónSonidoToolStripMenuItem.Text = "Configuración Sonido";
            this.configuraciónSonidoToolStripMenuItem.Click += new System.EventHandler(this.configuraciónSonidoToolStripMenuItem_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuBar;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnlimpiar);
            this.Controls.Add(this.btnguardar);
            this.Controls.Add(this.textedad);
            this.Controls.Add(this.textnombre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form2";
            this.Text = "Menú";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textnombre;
        private System.Windows.Forms.TextBox textedad;
        private System.Windows.Forms.Button btnguardar;
        private System.Windows.Forms.Button btnlimpiar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem configuraciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imagenesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem señalesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuraciónSonidoToolStripMenuItem;
    }
}