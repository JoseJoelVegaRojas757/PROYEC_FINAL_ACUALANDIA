namespace ACUA_USUARIO.REPORTS
{
    partial class FrmrMascota
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.rvInvMascota = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.cbInvMascota = new System.Windows.Forms.ComboBox();
            this.chTodo = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // rvInvMascota
            // 
            reportDataSource2.Name = "dsrMunicipios";
            reportDataSource2.Value = null;
            this.rvInvMascota.LocalReport.DataSources.Add(reportDataSource2);
            this.rvInvMascota.LocalReport.ReportEmbeddedResource = "p_Blockbuster.REPORTES.rMunicipio.rdlc";
            this.rvInvMascota.Location = new System.Drawing.Point(-1, 189);
            this.rvInvMascota.Name = "rvInvMascota";
            this.rvInvMascota.ServerReport.BearerToken = null;
            this.rvInvMascota.Size = new System.Drawing.Size(1110, 306);
            this.rvInvMascota.TabIndex = 10;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(708, 81);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(87, 35);
            this.btnAceptar.TabIndex = 9;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // cbInvMascota
            // 
            this.cbInvMascota.FormattingEnabled = true;
            this.cbInvMascota.Location = new System.Drawing.Point(409, 87);
            this.cbInvMascota.Name = "cbInvMascota";
            this.cbInvMascota.Size = new System.Drawing.Size(269, 28);
            this.cbInvMascota.TabIndex = 8;
            // 
            // chTodo
            // 
            this.chTodo.AutoSize = true;
            this.chTodo.Location = new System.Drawing.Point(332, 87);
            this.chTodo.Name = "chTodo";
            this.chTodo.Size = new System.Drawing.Size(71, 24);
            this.chTodo.TabIndex = 7;
            this.chTodo.Text = "Todo";
            this.chTodo.UseVisualStyleBackColor = true;
            // 
            // FrmrMascota
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1108, 495);
            this.Controls.Add(this.rvInvMascota);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.cbInvMascota);
            this.Controls.Add(this.chTodo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmrMascota";
            this.Text = "FrmrMascota";
            this.Load += new System.EventHandler(this.FrmrMascota_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvInvMascota;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.ComboBox cbInvMascota;
        private System.Windows.Forms.CheckBox chTodo;
    }
}