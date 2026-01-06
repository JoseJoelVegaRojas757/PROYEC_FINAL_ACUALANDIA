using ACUA_CAPA_NEG.CLASES;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACUA_USUARIO.SEARCH
{
    public partial class FrmBusquedaMVenta : Form
    {
        Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        SqlCommand comando = new SqlCommand();
        public FrmBusquedaMVenta()
        {
            InitializeComponent();
            con.ConnectionString = x.ConexionSql;
        }

        void Cargardg()
        {
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand($"Select * from MVENTA where idMas LIKE '%{txtFiltro.Text}%'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dgMVenta.DataSource = dt;
            con.Close();
        }



        private void FrmBusquedaMVenta_Load(object sender, EventArgs e)
        {
            try
            {
                dgMVenta.Rows[0].Selected = true;
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

        private void dgMVenta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgMVenta.CurrentRow.Index;
            dgMVenta.Rows[i].Selected = true;
        }
    }
}
