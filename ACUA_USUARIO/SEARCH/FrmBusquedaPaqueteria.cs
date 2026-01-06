using ACUA_CAPA_NEG.CLASES;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ACUA_USUARIO.SEARCH
{
    public partial class FrmBusquedaPaqueteria : Form
    {
        Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        SqlCommand comando = new SqlCommand();
        public FrmBusquedaPaqueteria()
        {
            InitializeComponent();
            con.ConnectionString = x.ConexionSql;
        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void Cargardg()
        {
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand($"Select * from PAQUETERIA where idPaq LIKE '%{txtFiltro.Text}%'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dgPaqueteria.DataSource = dt;
            con.Close();
        }


        private void FrmBusquedaPaqueteria_Load(object sender, EventArgs e)
        {
            try
            {
                dgPaqueteria.Rows[0].Selected = true;
            }
            catch
            {

            }
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Cargardg();
        }

        private void dgPaqueteria_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgPaqueteria.CurrentRow.Index;
            dgPaqueteria.Rows[i].Selected = true;
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
