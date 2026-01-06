using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using ACUA_CAPA_NEG.CLASES;
using Microsoft.Reporting.WinForms;

namespace ACUA_USUARIO.REPORTS
{
    public partial class FrmrTicket : Form
    {
        Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        SqlCommand comando = new SqlCommand();
        public FrmrTicket()
        {
            InitializeComponent();
            con.ConnectionString = x.ConexionSql;
        }


        void cargarcb()
        {
            DataTable dt = new DataTable();
            string consulta = "Select * From vTicket";
            SqlDataAdapter da = new SqlDataAdapter(consulta, con);
            con.Open();
            da.Fill(dt);
            con.Close();
            cbTicket.DisplayMember = "Cliente";
            cbTicket.ValueMember = "Folio";
            cbTicket.DataSource = dt;

        }

        void cargarreporte()
        {
            DataTable dt = new DataTable();
            string consulta = "";
            if (chTodo.Checked == true)
            {
                consulta = "SELECT * FROM vTicket";
            }
            else
            {
                consulta = $"SELECT * FROM vTicket where Folio = {cbTicket.SelectedValue.ToString()}";
            }


            SqlDataAdapter da = new SqlDataAdapter(consulta, con);
            con.Open();
            da.Fill(dt);
            con.Close();

            this.rvTicket.LocalReport.DataSources.Clear();
            this.rvTicket.LocalReport.ReportEmbeddedResource = "ACUA_USUARIO.REPORTS.rpTicket.rdlc";
            ReportDataSource r = new ReportDataSource("dsTicket", dt);
            this.rvTicket.LocalReport.DataSources.Add(r);
            this.rvTicket.RefreshReport();

        }

        private void FrmrTicket_Load(object sender, EventArgs e)
        {
            cargarcb();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            cargarreporte();
        }

        private void rvTicket_Load(object sender, EventArgs e)
        {

        }
    }
}
