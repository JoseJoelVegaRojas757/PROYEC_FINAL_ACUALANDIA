using ACUA_CAPA_NEG.CLASES;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace ACUA_USUARIO.REPORTS
{
    public partial class FrmrMascota : Form
    {
        Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        SqlCommand comando = new SqlCommand();
        public FrmrMascota()
        {
            InitializeComponent();
            con.ConnectionString = x.ConexionSql;
        }

        void cargarcb()
        {
            DataTable dt = new DataTable();
            string consulta = "Select * From VMascota";
            SqlDataAdapter da = new SqlDataAdapter(consulta, con);
            con.Open();
            da.Fill(dt);
            con.Close();
            cbInvMascota.DisplayMember = "nomRaza";
            cbInvMascota.ValueMember = "existencia";
            cbInvMascota.DataSource = dt;

        }

        void cargarreporte()
        {
            DataTable dt = new DataTable();
            string consulta = "";
            if (chTodo.Checked == true)
            {
                consulta = "SELECT * FROM VMascota";
            }
            else
            {
                consulta = $"SELECT * FROM VMascota where existencia = {cbInvMascota.SelectedValue.ToString()}";
            }


            SqlDataAdapter da = new SqlDataAdapter(consulta, con);
            con.Open();
            da.Fill(dt);
            con.Close();

            this.rvInvMascota.LocalReport.DataSources.Clear();
            this.rvInvMascota.LocalReport.ReportEmbeddedResource = "ACUA_USUARIO.REPORTS.rpMascota.rdlc";
            ReportDataSource r = new ReportDataSource("dsMascota", dt);
            this.rvInvMascota.LocalReport.DataSources.Add(r);
            this.rvInvMascota.RefreshReport();

        }
        private void FrmrMascota_Load(object sender, EventArgs e)
        {
            cargarcb();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            cargarreporte();
        }
    }
}
