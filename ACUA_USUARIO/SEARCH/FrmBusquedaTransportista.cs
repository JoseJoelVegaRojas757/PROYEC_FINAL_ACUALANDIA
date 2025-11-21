using ACUA_CAPA_NEG.CLASES;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ACUA_USUARIO.SEARCH
{
    public partial class FrmBusquedaTransportista : Form
    {
        Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        SqlCommand comando = new SqlCommand();
        public FrmBusquedaTransportista()
        {
            InitializeComponent();
            con.ConnectionString = x.ConexionSql;
        }

        void Cargardg()
        {
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand($"SELECT * FROM TRANSPORTISTA WHERE idTrans LIKE '%{txtFiltro.Text}%'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dgTransportista.DataSource = dt;
            con.Close();
        }

        private void dgTransportista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgTransportista.CurrentRow.Index;
            dgTransportista.Rows[i].Selected = true;
        }

        private void FrmBusquedaTransportista_Load(object sender, EventArgs e)
        {
            try
            {
                dgTransportista.Rows[0].Selected = true;
            }
            catch
            {

            }
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
    }
}
