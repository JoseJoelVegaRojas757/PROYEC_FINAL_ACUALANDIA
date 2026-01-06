namespace ACUA_USUARIO.REPORTS
{
    partial class FrmrTicket
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
            this.rvTicket = new Microsoft.Reporting.WinForms.ReportViewer();
            this.cbTicket = new System.Windows.Forms.ComboBox();
            this.chTodo = new System.Windows.Forms.CheckBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rvTicket
            // 
            reportDataSource1.Name = "dsrMunicipios";
            reportDataSource1.Value = null;
            this.rvTicket.LocalReport.DataSources.Add(reportDataSource1);
            this.rvTicket.LocalReport.ReportEmbeddedResource = "p_Blockbuster.REPORTES.rMunicipio.rdlc";
            this.rvTicket.Location = new System.Drawing.Point(35, 94);
            this.rvTicket.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rvTicket.Name = "rvTicket";
            this.rvTicket.ServerReport.BearerToken = null;
            this.rvTicket.Size = new System.Drawing.Size(839, 291);
            this.rvTicket.TabIndex = 9;
            this.rvTicket.Load += new System.EventHandler(this.rvTicket_Load);
            // 
            // cbTicket
            // 
            this.cbTicket.FormattingEnabled = true;
            this.cbTicket.Location = new System.Drawing.Point(358, 34);
            this.cbTicket.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbTicket.Name = "cbTicket";
            this.cbTicket.Size = new System.Drawing.Size(253, 21);
            this.cbTicket.TabIndex = 8;
            // 
            // chTodo
            // 
            this.chTodo.AutoSize = true;
            this.chTodo.Location = new System.Drawing.Point(297, 35);
            this.chTodo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chTodo.Name = "chTodo";
            this.chTodo.Size = new System.Drawing.Size(51, 17);
            this.chTodo.TabIndex = 7;
            this.chTodo.Text = "Todo";
            this.chTodo.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(699, 31);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(58, 23);
            this.btnAceptar.TabIndex = 10;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // FrmrTicket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 428);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.rvTicket);
            this.Controls.Add(this.cbTicket);
            this.Controls.Add(this.chTodo);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FrmrTicket";
            this.Text = "FrmrTicket";
            this.Load += new System.EventHandler(this.FrmrTicket_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvTicket;
        private System.Windows.Forms.ComboBox cbTicket;
        private System.Windows.Forms.CheckBox chTodo;
        private System.Windows.Forms.Button btnAceptar;
    }
}