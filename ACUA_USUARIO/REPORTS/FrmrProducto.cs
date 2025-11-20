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
            cargarreporte();
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
                consulta = $"SELECT * FROM VProducto WHERE idInv = {cbInvProducto.SelectedValue.ToString()}";
            }


            SqlDataAdapter da = new SqlDataAdapter(consulta, con);
            con.Open();
            da.Fill(dt);
            con.Close();

            this.rvMunicipios.LocalReport.DataSources.Clear();
            this.rvMunicipios.LocalReport.ReportEmbeddedResource = "p_Blockbuster.REPORTES.rMunicipio.rdlc";
            ReportDataSource r = new ReportDataSource("dsrMunicipios", dt);
            this.rvMunicipios.LocalReport.DataSources.Add(r);
            this.rvMunicipios.RefreshReport();

        }
    }
}
