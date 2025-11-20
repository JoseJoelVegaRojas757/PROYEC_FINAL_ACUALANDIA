using ACUA_CAPA_NEG.CLASES;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ACUA_USUARIO.SEARCH
{
    public partial class FrmBusquedaProducto : Form
    {
        Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        SqlCommand comando = new SqlCommand();
        public FrmBusquedaProducto()
        {
            InitializeComponent();
            con.ConnectionString = x.ConexionSql;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Cargardg();
        }

        private void dgProducto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgProducto.CurrentRow.Index;
            dgProducto.Rows[i].Selected = true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmBusquedaProducto_Load(object sender, EventArgs e)
        {
            try
            {
                dgProducto.Rows[0].Selected = true;
            }
            catch
            {

            }
        }

        void Cargardg()
        {
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand($"SELECT * FROM PRODUCTO where idProd LIKE '%{txtFiltro.Text}%'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dgProducto.DataSource = dt;
            con.Close();
        }
    }
}
