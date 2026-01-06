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
    public partial class FrmBusquedaPedido : Form
    {
        Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        SqlCommand comando = new SqlCommand();
        public FrmBusquedaPedido()
        {
            InitializeComponent();
            con.ConnectionString = x.ConexionSql;
        }


        private void dgPedido_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmBusquedaPedido_Load(object sender, EventArgs e)
        {
            try
            {
                dgPedido.Rows[0].Selected = true;
            }
            catch
            {

            }
        }


        void Cargardg()
        {
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand($"Select * from PEDIDO where idPed LIKE '%{txtFiltro.Text}%'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dgPedido.DataSource = dt;
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

        private void dgPedido_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgPedido.CurrentRow.Index;
            dgPedido.Rows[i].Selected = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
