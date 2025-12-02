using ACUA_CAPA_NEG.CLASES;
using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ACUA_USUARIO.REPORTS
{
    public partial class FrmrProducto : Form
    {
        Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        SqlCommand comando = new SqlCommand();
        public FrmrProducto()
        {
            InitializeComponent();
            con.ConnectionString = x.ConexionSql;
        }

        private void FrmrProducto_Load(object sender, EventArgs e)
        {
            cargarcb();
        }

        void cargarcb()
        {
            DataTable dt = new DataTable();
            string consulta = "Select * From VProducto";
            SqlDataAdapter da = new SqlDataAdapter(consulta, con);
            con.Open();
            da.Fill(dt);
            con.Close();
            cbInvProducto.DisplayMember = "nomProducto";
            cbInvProducto.ValueMember = "existencia";
            cbInvProducto.DataSource = dt;

        }

        void cargarreporte()
        {
            DataTable dt = new DataTable();
            string consulta = "";
            if (chTodo.Checked == true)
            {
                consulta = "SELECT * FROM VProducto";
            }
            else
            {
                consulta = $"SELECT * FROM VProducto where existencia = {cbInvProducto.SelectedValue.ToString()}";
            }


            SqlDataAdapter da = new SqlDataAdapter(consulta, con);
            con.Open();
            da.Fill(dt);
            con.Close();

            this.rvInvProducto.LocalReport.DataSources.Clear();
            this.rvInvProducto.LocalReport.ReportEmbeddedResource = "ACUA_USUARIO.REPORTS.rpProducto.rdlc";
            ReportDataSource r = new ReportDataSource("dsrProducto", dt);
            this.rvInvProducto.LocalReport.DataSources.Add(r);
            this.rvInvProducto.RefreshReport();

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            cargarreporte();

        }

        private void cbInvProducto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
