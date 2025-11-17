using ACUA_CAPA_NEG.CLASES;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ACUA_USUARIO.SEARCH
{
    public partial class FrmBusquedaPMascota : Form
    {
        Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        SqlCommand comando = new SqlCommand();
        public FrmBusquedaPMascota()
        {
            InitializeComponent();
            con.ConnectionString = x.ConexionSql;
        }

        private void FrmBusquedaPMascota_Load(object sender, EventArgs e)
        {
            try
            {
                dgPMascota.Rows[0].Selected = true;
            }
            catch
            {

            }
        }

        void Cargardg()
        {
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand($"SELECT * FROM PMASCOTA where idPmas LIKE '%{txtFiltro.Text}%'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dgPMascota.DataSource = dt;
            con.Close();
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

        private void dgPMascota_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgPMascota.CurrentRow.Index;
            dgPMascota.Rows[i].Selected = true;
        }
    }
}
