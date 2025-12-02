namespace ACUA_USUARIO.FORMS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMenu));
            this.pMain = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pBar = new System.Windows.Forms.Panel();
            this.btnApartado = new System.Windows.Forms.Button();
            this.btnCMascota = new System.Windows.Forms.Button();
            this.btnCIn = new System.Windows.Forms.Button();
            this.btnTrabajador = new System.Windows.Forms.Button();
            this.btnAbono = new System.Windows.Forms.Button();
            this.btnCliente = new System.Windows.Forms.Button();
            this.btnDomicilio = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnColonia = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCategoria = new System.Windows.Forms.Button();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.pMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // pMain
            // 
            this.pMain.BackColor = System.Drawing.Color.DodgerBlue;
            this.pMain.Controls.Add(this.pictureBox1);
            this.pMain.Location = new System.Drawing.Point(238, 5);
            this.pMain.Name = "pMain";
            this.pMain.Size = new System.Drawing.Size(1198, 895);
            this.pMain.TabIndex = 1;
            this.pMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pMain_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(64, 98);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(997, 552);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // pBar
            // 
            this.pBar.BackColor = System.Drawing.Color.DodgerBlue;
            this.pBar.Controls.Add(this.btnApartado);
            this.pBar.Controls.Add(this.btnCMascota);
            this.pBar.Controls.Add(this.btnCIn);
            this.pBar.Controls.Add(this.btnTrabajador);
            this.pBar.Controls.Add(this.btnAbono);
            this.pBar.Controls.Add(this.btnCliente);
            this.pBar.Controls.Add(this.btnDomicilio);
            this.pBar.Controls.Add(this.button3);
            this.pBar.Controls.Add(this.btnColonia);
            this.pBar.Controls.Add(this.label1);
            this.pBar.Controls.Add(this.btnCategoria);
            this.pBar.Location = new System.Drawing.Point(3, 5);
            this.pBar.Name = "pBar";
            this.pBar.Size = new System.Drawing.Size(204, 895);
            this.pBar.TabIndex = 2;
            // 
            // btnApartado
            // 
            this.btnApartado.FlatAppearance.BorderSize = 0;
            this.btnApartado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApartado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApartado.Location = new System.Drawing.Point(4, 118);
            this.btnApartado.Name = "btnApartado";
            this.btnApartado.Size = new System.Drawing.Size(197, 63);
            this.btnApartado.TabIndex = 11;
            this.btnApartado.Text = "Apartado";
            this.btnApartado.UseVisualStyleBackColor = true;
            this.btnApartado.Click += new System.EventHandler(this.btnApartado_Click);
            // 
            // btnCMascota
            // 
            this.btnCMascota.FlatAppearance.BorderSize = 0;
            this.btnCMascota.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCMascota.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCMascota.Location = new System.Drawing.Point(4, 768);
            this.btnCMascota.Name = "btnCMascota";
            this.btnCMascota.Size = new System.Drawing.Size(197, 63);
            this.btnCMascota.TabIndex = 10;
            this.btnCMascota.Text = "Consumo Mascota";
            this.btnCMascota.UseVisualStyleBackColor = true;
            this.btnCMascota.Click += new System.EventHandler(this.btnCMascota_Click);
            // 
            // btnCIn
            // 
            this.btnCIn.FlatAppearance.BorderSize = 0;
            this.btnCIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCIn.Location = new System.Drawing.Point(3, 699);
            this.btnCIn.Name = "btnCIn";
            this.btnCIn.Size = new System.Drawing.Size(197, 63);
            this.btnCIn.TabIndex = 9;
            this.btnCIn.Text = "Consumo Interno";
            this.btnCIn.UseVisualStyleBackColor = true;
            this.btnCIn.Click += new System.EventHandler(this.btnCIn_Click);
            // 
            // btnTrabajador
            // 
            this.btnTrabajador.FlatAppearance.BorderSize = 0;
            this.btnTrabajador.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTrabajador.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrabajador.Location = new System.Drawing.Point(3, 334);
            this.btnTrabajador.Name = "btnTrabajador";
            this.btnTrabajador.Size = new System.Drawing.Size(197, 63);
            this.btnTrabajador.TabIndex = 6;
            this.btnTrabajador.Text = "Trabajador";
            this.btnTrabajador.UseVisualStyleBackColor = true;
            this.btnTrabajador.Click += new System.EventHandler(this.btnTrabajador_Click);
            // 
            // btnAbono
            // 
            this.btnAbono.FlatAppearance.BorderSize = 0;
            this.btnAbono.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbono.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbono.Location = new System.Drawing.Point(0, 620);
            this.btnAbono.Name = "btnAbono";
            this.btnAbono.Size = new System.Drawing.Size(197, 63);
            this.btnAbono.TabIndex = 8;
            this.btnAbono.Text = "Abono";
            this.btnAbono.UseVisualStyleBackColor = true;
            this.btnAbono.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnCliente
            // 
            this.btnCliente.FlatAppearance.BorderSize = 0;
            this.btnCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCliente.Location = new System.Drawing.Point(4, 551);
            this.btnCliente.Name = "btnCliente";
            this.btnCliente.Size = new System.Drawing.Size(197, 63);
            this.btnCliente.TabIndex = 7;
            this.btnCliente.Text = "Cliente";
            this.btnCliente.UseVisualStyleBackColor = true;
            this.btnCliente.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnDomicilio
            // 
            this.btnDomicilio.FlatAppearance.BorderSize = 0;
            this.btnDomicilio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDomicilio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDomicilio.Location = new System.Drawing.Point(7, 482);
            this.btnDomicilio.Name = "btnDomicilio";
            this.btnDomicilio.Size = new System.Drawing.Size(197, 63);
            this.btnDomicilio.TabIndex = 4;
            this.btnDomicilio.Text = "Domicilio";
            this.btnDomicilio.UseVisualStyleBackColor = true;
            this.btnDomicilio.Click += new System.EventHandler(this.btnDomicilio_Click);
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(0, 413);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(197, 63);
            this.button3.TabIndex = 3;
            this.button3.Text = "Paqueteria";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // btnColonia
            // 
            this.btnColonia.FlatAppearance.BorderSize = 0;
            this.btnColonia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColonia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnColonia.Location = new System.Drawing.Point(3, 265);
            this.btnColonia.Name = "btnColonia";
            this.btnColonia.Size = new System.Drawing.Size(197, 63);
            this.btnColonia.TabIndex = 2;
            this.btnColonia.Text = "Colonia";
            this.btnColonia.UseVisualStyleBackColor = true;
            this.btnColonia.Click += new System.EventHandler(this.btnColonia_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 52);
            this.label1.TabIndex = 1;
            this.label1.Text = "Menu";
            // 
            // btnCategoria
            // 
            this.btnCategoria.FlatAppearance.BorderSize = 0;
            this.btnCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategoria.Location = new System.Drawing.Point(4, 196);
            this.btnCategoria.Name = "btnCategoria";
            this.btnCategoria.Size = new System.Drawing.Size(197, 63);
            this.btnCategoria.TabIndex = 0;
            this.btnCategoria.Text = "Categoria";
            this.btnCategoria.UseVisualStyleBackColor = true;
            this.btnCategoria.Click += new System.EventHandler(this.button1_Click);
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(211, 9);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(10, 884);
            this.vScrollBar1.TabIndex = 3;
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(1451, 900);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.pBar);
            this.Controls.Add(this.pMain);
            this.Name = "FrmMenu";
            this.Text = "FrmMenu";
            this.Load += new System.EventHandler(this.FrmMenu_Load);
            this.pMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pBar.ResumeLayout(false);
            this.pBar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pMain;
        private System.Windows.Forms.Panel pBar;
        private System.Windows.Forms.Button btnTrabajador;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnDomicilio;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnColonia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCategoria;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.Button btnCliente;
        private System.Windows.Forms.Button btnAbono;
        private System.Windows.Forms.Button btnCIn;
        private System.Windows.Forms.Button btnCMascota;
        private System.Windows.Forms.Button btnApartado;
    }
}