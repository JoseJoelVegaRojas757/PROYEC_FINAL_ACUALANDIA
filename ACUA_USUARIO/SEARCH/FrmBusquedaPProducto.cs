using ACUA_CAPA_NEG.CLASES;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ACUA_USUARIO.SEARCH
{
    public partial class FrmBusquedaPProducto : Form
    {
        Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        SqlCommand comando = new SqlCommand();
        public FrmBusquedaPProducto()
        {
            InitializeComponent();
            con.ConnectionString = x.ConexionSql;
        }

        private void dgPProducto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgPProducto.CurrentRow.Index;
            dgPProducto.Rows[i].Selected = true;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Cargardg();
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

        private void FrmBusquedaPProducto_Load(object sender, EventArgs e)
        {
            try
            {
                dgPProducto.Rows[0].Selected = true;
            }
            catch
            {

            }
        }
        void Cargardg()
        {
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand($"Select * from PPRODUCTO where idPprod LIKE '%{txtFiltro.Text}%'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dgPProducto.DataSource = dt;
            con.Close();
        }
    }
}
