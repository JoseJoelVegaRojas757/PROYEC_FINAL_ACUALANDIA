using ACUA_CAPA_NEG.CLASES;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ACUA_USUARIO.SEARCH
{
    public partial class FrmBusquedaMunicipio : Form
    {
        Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        SqlCommand comando = new SqlCommand();

        public FrmBusquedaMunicipio()
        {
            InitializeComponent();
            con.ConnectionString = x.ConexionSql;
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmBusquedaMunicipio_Load(object sender, EventArgs e)
        {
            try
            {
                dgMunicipio.Rows[0].Selected = true;
            }
            catch
            {

            }
        }
        void Cargardg()
        {
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand($"Select * from MUNICIPIO where idMun LIKE '%{txtFiltro.Text}%'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dgMunicipio.DataSource = dt;
            con.Close();
        }

        private void dgMunicipio_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgMunicipio.CurrentRow.Index;
            dgMunicipio.Rows[i].Selected = true;
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
