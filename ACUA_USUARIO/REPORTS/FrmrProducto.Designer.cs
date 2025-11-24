namespace ACUA_USUARIO.REPORTS
{
    partial class FrmrProducto
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.cbInvProducto = new System.Windows.Forms.ComboBox();
            this.chTodo = new System.Windows.Forms.CheckBox();
            this.rvInvProducto = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(658, 80);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(87, 35);
            this.btnAceptar.TabIndex = 5;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // cbInvProducto
            // 
            this.cbInvProducto.FormattingEnabled = true;
            this.cbInvProducto.Location = new System.Drawing.Point(359, 86);
            this.cbInvProducto.Name = "cbInvProducto";
            this.cbInvProducto.Size = new System.Drawing.Size(269, 28);
            this.cbInvProducto.TabIndex = 4;
            // 
            // chTodo
            // 
            this.chTodo.AutoSize = true;
            this.chTodo.Location = new System.Drawing.Point(282, 86);
            this.chTodo.Name = "chTodo";
            this.chTodo.Size = new System.Drawing.Size(71, 24);
            this.chTodo.TabIndex = 3;
            this.chTodo.Text = "Todo";
            this.chTodo.UseVisualStyleBackColor = true;
            // 
            // rvInvProducto
            // 
            reportDataSource1.Name = "dsrMunicipios";
            reportDataSource1.Value = null;
            this.rvInvProducto.LocalReport.DataSources.Add(reportDataSource1);
            this.rvInvProducto.LocalReport.ReportEmbeddedResource = "p_Blockbuster.REPORTES.rMunicipio.rdlc";
            this.rvInvProducto.Location = new System.Drawing.Point(5, 209);
            this.rvInvProducto.Name = "rvInvProducto";
            this.rvInvProducto.ServerReport.BearerToken = null;
            this.rvInvProducto.Size = new System.Drawing.Size(1027, 312);
            this.rvInvProducto.TabIndex = 6;
            // 
            // FrmrProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 533);
            this.Controls.Add(this.rvInvProducto);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.cbInvProducto);
            this.Controls.Add(this.chTodo);
            this.Name = "FrmrProducto";
            this.Text = "FrmrProducto";
            this.Load += new System.EventHandler(this.FrmrProducto_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.ComboBox cbInvProducto;
        private System.Windows.Forms.CheckBox chTodo;
        private Microsoft.Reporting.WinForms.ReportViewer rvInvProducto;
    }
}