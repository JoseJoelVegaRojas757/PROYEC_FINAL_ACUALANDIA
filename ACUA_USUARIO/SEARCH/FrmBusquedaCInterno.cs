using ACUA_CAPA_NEG.CLASES;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ACUA_USUARIO.SEARCH
{
    public partial class FrmBusquedaCInterno : Form
    {
        Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        SqlCommand comando = new SqlCommand();
        public FrmBusquedaCInterno()
        {
            InitializeComponent();
            con.ConnectionString = x.ConexionSql;
        }

        private void FrmBusquedaCInterno_Load(object sender, System.EventArgs e)
        {
            try
            {
                dgCInterno.Rows[0].Selected = true;
            }
            catch
            {

            }
        }
        void Cargardg()
        {
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand($"Select * from CINTERNO where idInterno LIKE '%{txtFiltro.Text}%'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dgCInterno.DataSource = dt;
            con.Close();
        }

        private void btnBuscar_Click(object sender, System.EventArgs e)
        {
            Cargardg();
        }

        private void dgCInterno_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgCInterno.CurrentRow.Index;
            dgCInterno.Rows[i].Selected = true;
        }

        private void btnAceptar_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnBorrar_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
