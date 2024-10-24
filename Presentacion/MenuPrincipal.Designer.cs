namespace Presentacion
{
    partial class MenuPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuPrincipal));
            this.barraTitulo = new System.Windows.Forms.Panel();
            this.BtnRestaurar = new System.Windows.Forms.PictureBox();
            this.BtnMInimizar = new System.Windows.Forms.PictureBox();
            this.BtnMaximizar = new System.Windows.Forms.PictureBox();
            this.BtnCerrar = new System.Windows.Forms.PictureBox();
            this.MenuVertical = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button27 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnRegistrese = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LoginClick = new System.Windows.Forms.Button();
            this.PanelContenedor = new System.Windows.Forms.Panel();
            this.barraTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BtnRestaurar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnMInimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnMaximizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnCerrar)).BeginInit();
            this.MenuVertical.SuspendLayout();
            this.SuspendLayout();
            // 
            // barraTitulo
            // 
            this.barraTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(210)))));
            this.barraTitulo.Controls.Add(this.BtnRestaurar);
            this.barraTitulo.Controls.Add(this.BtnMInimizar);
            this.barraTitulo.Controls.Add(this.BtnMaximizar);
            this.barraTitulo.Controls.Add(this.BtnCerrar);
            this.barraTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.barraTitulo.Location = new System.Drawing.Point(0, 0);
            this.barraTitulo.Name = "barraTitulo";
            this.barraTitulo.Size = new System.Drawing.Size(1080, 38);
            this.barraTitulo.TabIndex = 2;
            this.barraTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.barraTitulo_MouseDown_1);
            // 
            // BtnRestaurar
            // 
            this.BtnRestaurar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnRestaurar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnRestaurar.Image = ((System.Drawing.Image)(resources.GetObject("BtnRestaurar.Image")));
            this.BtnRestaurar.Location = new System.Drawing.Point(1021, 7);
            this.BtnRestaurar.Name = "BtnRestaurar";
            this.BtnRestaurar.Size = new System.Drawing.Size(25, 25);
            this.BtnRestaurar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BtnRestaurar.TabIndex = 3;
            this.BtnRestaurar.TabStop = false;
            this.BtnRestaurar.Visible = false;
            this.BtnRestaurar.Click += new System.EventHandler(this.BtnRestaurar_Click_1);
            // 
            // BtnMInimizar
            // 
            this.BtnMInimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnMInimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnMInimizar.Image = ((System.Drawing.Image)(resources.GetObject("BtnMInimizar.Image")));
            this.BtnMInimizar.Location = new System.Drawing.Point(990, 7);
            this.BtnMInimizar.Name = "BtnMInimizar";
            this.BtnMInimizar.Size = new System.Drawing.Size(25, 25);
            this.BtnMInimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BtnMInimizar.TabIndex = 2;
            this.BtnMInimizar.TabStop = false;
            this.BtnMInimizar.Click += new System.EventHandler(this.BtnMInimizar_Click_1);
            // 
            // BtnMaximizar
            // 
            this.BtnMaximizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnMaximizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnMaximizar.Image = ((System.Drawing.Image)(resources.GetObject("BtnMaximizar.Image")));
            this.BtnMaximizar.Location = new System.Drawing.Point(1021, 7);
            this.BtnMaximizar.Name = "BtnMaximizar";
            this.BtnMaximizar.Size = new System.Drawing.Size(25, 25);
            this.BtnMaximizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BtnMaximizar.TabIndex = 1;
            this.BtnMaximizar.TabStop = false;
            this.BtnMaximizar.Click += new System.EventHandler(this.BtnMaximizar_Click_1);
            // 
            // BtnCerrar
            // 
            this.BtnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("BtnCerrar.Image")));
            this.BtnCerrar.Location = new System.Drawing.Point(1052, 7);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Size = new System.Drawing.Size(25, 25);
            this.BtnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BtnCerrar.TabIndex = 0;
            this.BtnCerrar.TabStop = false;
            this.BtnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click_1);
            // 
            // MenuVertical
            // 
            this.MenuVertical.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.MenuVertical.Controls.Add(this.panel3);
            this.MenuVertical.Controls.Add(this.button27);
            this.MenuVertical.Controls.Add(this.panel2);
            this.MenuVertical.Controls.Add(this.btnRegistrese);
            this.MenuVertical.Controls.Add(this.panel1);
            this.MenuVertical.Controls.Add(this.LoginClick);
            this.MenuVertical.Dock = System.Windows.Forms.DockStyle.Left;
            this.MenuVertical.Location = new System.Drawing.Point(0, 38);
            this.MenuVertical.Name = "MenuVertical";
            this.MenuVertical.Size = new System.Drawing.Size(220, 574);
            this.MenuVertical.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(210)))));
            this.panel3.Location = new System.Drawing.Point(6, 371);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(8, 35);
            this.panel3.TabIndex = 4;
            // 
            // button27
            // 
            this.button27.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.button27.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.button27.FlatAppearance.BorderSize = 0;
            this.button27.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(210)))));
            this.button27.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button27.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.button27.ForeColor = System.Drawing.Color.White;
            this.button27.Location = new System.Drawing.Point(3, 371);
            this.button27.Name = "button27";
            this.button27.Size = new System.Drawing.Size(211, 35);
            this.button27.TabIndex = 3;
            this.button27.Text = "Salir";
            this.button27.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(210)))));
            this.panel2.Location = new System.Drawing.Point(3, 151);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(8, 35);
            this.panel2.TabIndex = 2;
            // 
            // btnRegistrese
            // 
            this.btnRegistrese.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.btnRegistrese.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistrese.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnRegistrese.FlatAppearance.BorderSize = 0;
            this.btnRegistrese.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(210)))));
            this.btnRegistrese.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrese.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.btnRegistrese.ForeColor = System.Drawing.Color.White;
            this.btnRegistrese.Location = new System.Drawing.Point(0, 151);
            this.btnRegistrese.Name = "btnRegistrese";
            this.btnRegistrese.Size = new System.Drawing.Size(211, 35);
            this.btnRegistrese.TabIndex = 1;
            this.btnRegistrese.Text = "Registrese";
            this.btnRegistrese.UseVisualStyleBackColor = false;
            this.btnRegistrese.Click += new System.EventHandler(this.btnRegistrese_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(210)))));
            this.panel1.Location = new System.Drawing.Point(3, 110);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(8, 35);
            this.panel1.TabIndex = 0;
            // 
            // LoginClick
            // 
            this.LoginClick.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.LoginClick.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LoginClick.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.LoginClick.FlatAppearance.BorderSize = 0;
            this.LoginClick.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(210)))));
            this.LoginClick.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoginClick.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.LoginClick.ForeColor = System.Drawing.Color.White;
            this.LoginClick.Location = new System.Drawing.Point(0, 110);
            this.LoginClick.Name = "LoginClick";
            this.LoginClick.Size = new System.Drawing.Size(211, 35);
            this.LoginClick.TabIndex = 0;
            this.LoginClick.Text = "Login";
            this.LoginClick.UseVisualStyleBackColor = false;
            this.LoginClick.Click += new System.EventHandler(this.LoginClick_Click);
            // 
            // PanelContenedor
            // 
            this.PanelContenedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.PanelContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelContenedor.Location = new System.Drawing.Point(220, 38);
            this.PanelContenedor.Name = "PanelContenedor";
            this.PanelContenedor.Size = new System.Drawing.Size(860, 574);
            this.PanelContenedor.TabIndex = 4;
            
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 612);
            this.Controls.Add(this.PanelContenedor);
            this.Controls.Add(this.MenuVertical);
            this.Controls.Add(this.barraTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MenuPrincipal";
            this.Text = "MenuPrincipal";
            this.barraTitulo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BtnRestaurar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnMInimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnMaximizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnCerrar)).EndInit();
            this.MenuVertical.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel barraTitulo;
        private System.Windows.Forms.PictureBox BtnRestaurar;
        private System.Windows.Forms.PictureBox BtnMInimizar;
        private System.Windows.Forms.PictureBox BtnMaximizar;
        private System.Windows.Forms.PictureBox BtnCerrar;
        private System.Windows.Forms.Panel MenuVertical;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnRegistrese;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button LoginClick;
        private System.Windows.Forms.Panel PanelContenedor;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button27;
    }
}