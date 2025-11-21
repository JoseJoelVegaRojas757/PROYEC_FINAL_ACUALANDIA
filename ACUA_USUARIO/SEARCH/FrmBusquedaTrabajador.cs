using ACUA_CAPA_NEG.CLASES;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ACUA_USUARIO.SEARCH
{
    public partial class FrmBusquedaTrabajador : Form
    {
        Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        SqlCommand comando = new SqlCommand();
        public FrmBusquedaTrabajador()
        {
            InitializeComponent();
            con.ConnectionString = x.ConexionSql;
        }
        void Cargardg()
        {
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand($"SELECT * FROM TRABAJADOR WHERE idTra LIKE '%{txtFiltro.Text}%'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dgTrabajador.DataSource = dt;
            con.Close();
        }

        private void FrmBusquedaTrabajador_Load(object sender, EventArgs e)
        {
            try
            {
                dgTrabajador.Rows[0].Selected = true;
            }
            catch
            {

            }
        }

        private void dgApartado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgTrabajador.CurrentRow.Index;
            dgTrabajador.Rows[i].Selected = true;
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
    }
}
