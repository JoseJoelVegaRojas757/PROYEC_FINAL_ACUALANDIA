using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ACUA_USUARIO
{
    public partial class FrmConSql : Form
    {
        SqlConnection con = new SqlConnection("Data Source = JOEL\\UADEO;Initial Catalog=BSAcualandia; user id = sa; password = Jose2Joel");
        public FrmConSql()
        {
            InitializeComponent();
        }

        private void btnConexion_Click(object sender, EventArgs e)
        {
            con.Open();
            MessageBox.Show("Conexion Exitosa");
            con.Close();
        }
    }
}
