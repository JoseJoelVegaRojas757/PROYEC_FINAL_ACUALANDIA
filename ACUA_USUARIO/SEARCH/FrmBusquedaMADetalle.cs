using ACUA_CAPA_NEG.CLASES;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ACUA_USUARIO.SEARCH
{
    public partial class FrmBusquedaMADetalle : Form
    {
        Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        SqlCommand comando = new SqlCommand();
        public FrmBusquedaMADetalle()
        {
            InitializeComponent();
            con.ConnectionString = x.ConexionSql;
        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmBusquedaMADetalle_Load(object sender, EventArgs e)
        {
            try
            {
                dgMadetalle.Rows[0].Selected = true;
            }
            catch
            {

            }
        }

        void Cargardg()
        {
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand($"Select * from MADETALLE where idAdetalle LIKE '%{txtFiltro.Text}%'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dgMadetalle.DataSource = dt;
            con.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Cargardg();
        }

        private void dgMadetalle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgMadetalle.CurrentRow.Index;
            dgMadetalle.Rows[i].Selected = true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
