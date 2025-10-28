using ACUA_CAPA_NEG.CLASES;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ACUA_USUARIO.SEARCH
{
    public partial class FrmBusquedaAbono : Form
    {
        Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        SqlCommand comando = new SqlCommand();
        public FrmBusquedaAbono()
        {
            InitializeComponent();
            con.ConnectionString = x.ConexionSql;
        }

        private void FrmBusquedaAbono_Load(object sender, EventArgs e)
        {
            try
            {
                dgAbono.Rows[0].Selected = true;
            }
            catch
            {

            }
        }

        void Cargardg()
        {
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand($"Select * from ABONO where idAbono LIKE '%{txtFiltro.Text}%'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dgAbono.DataSource = dt;
            con.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Cargardg();
        }

        private void dgAbono_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgAbono.CurrentRow.Index;
            dgAbono.Rows[i].Selected = true;
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
