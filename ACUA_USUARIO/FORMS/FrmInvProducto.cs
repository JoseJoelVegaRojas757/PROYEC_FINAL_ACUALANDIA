using ACUA_CAPA_NEG.CLASES;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ACUA_USUARIO.FORMS
{
    public partial class FrmInvProducto : Form
    {
        Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        SqlCommand comando = new SqlCommand();
        public FrmInvProducto()
        {
            InitializeComponent();
            con.ConnectionString = x.ConexionSql;
        }

        void CargarProducto()
        {
            DataTable dt = new DataTable();
            string consulta = "SELECT * FROM PRODUCTO";
            SqlDataAdapter da = new SqlDataAdapter(consulta, con);
            con.Open();
            da.Fill(dt);
            con.Close();
            cbProducto.DisplayMember = "nomProducto";
            cbProducto.ValueMember = "idProd";
            cbProducto.DataSource = dt;
        }

        void CargarProveedor()
        {
            DataTable dt = new DataTable();
            string consulta = "SELECT * FROM PROVEEDOR";
            SqlDataAdapter da = new SqlDataAdapter(consulta, con);
            con.Open();
            da.Fill(dt);
            con.Close();
            cbProveedor.DisplayMember = "nomProveedor";
            cbProveedor.ValueMember = "idProv";
            cbProveedor.DataSource = dt;
        }

        void Limpiar()
        {
            txtId.Clear();
            txtExis.Clear();
            txtMinimo.Clear();
            ACUA_CAPA_NEG.CLASES.Herramientas h = new ACUA_CAPA_NEG.CLASES.Herramientas();
            txtId.Text = h.consecutivo("idInv", "INVPRODUCTO").ToString();
            txtId.Focus();
            txtExis.Focus();
            txtMinimo.Focus();
        }

        bool encontro()
        {
            bool a = false;
            int id = int.Parse(txtId.Text);
            string cadena = $"Select * From INVPRODUCTO where idInv = {id}";
            con.Open();
            SqlCommand cmd = new SqlCommand(cadena, con);
            SqlDataReader lector = cmd.ExecuteReader();
            if (lector.Read())
            {
                a = true;
            }
            else
            {
                a = false;
            }
            con.Close();
            return a;
        }

        private void FrmInvProducto_Load(object sender, EventArgs e)
        {
            CargarProducto();
            CargarProveedor();
        }

        private void tsGuardar_Click(object sender, EventArgs e)
        {
            InvProducto x = new InvProducto();
            x.idInv = int.Parse(txtId.Text);
            x.idProv = Convert.ToInt32(cbProveedor.SelectedValue);
            x.idProd = Convert.ToInt32(cbProducto.SelectedValue);
            x.minimo = int.Parse(txtMinimo.Text);
            x.existencia = int.Parse(txtExis.Text);
            if (encontro() == true)
            {
                MessageBox.Show(x.Actualizar());
            }
            else
            {
                MessageBox.Show(x.Guardar());
            }
        }

        private void tsBuscar_Click(object sender, EventArgs e)
        {
            SEARCH.FrmBusquedaInvProducto x = new SEARCH.FrmBusquedaInvProducto();
            x.ShowDialog();
            if (x.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                txtId.Text = x.dgInvProducto.SelectedRows[0].Cells["idInv"].Value.ToString();
                cbProducto.Text = x.dgInvProducto.SelectedRows[0].Cells["idProd"].Value.ToString();
                cbProveedor.Text = x.dgInvProducto.SelectedRows[0].Cells["idProv"].Value.ToString();
                txtMinimo.Text = x.dgInvProducto.SelectedRows[0].Cells["minimo"].Value.ToString();
                txtExis.Text = x.dgInvProducto.SelectedRows[0].Cells["existencia"].Value.ToString();
            }
        }

        private void tsLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void tsEliminar_Click(object sender, EventArgs e)
        {
            ACUA_CAPA_NEG.CLASES.InvProducto x = new ACUA_CAPA_NEG.CLASES.InvProducto();
            x.idInv = int.Parse(txtId.Text);
            x.idProv = Convert.ToInt32(cbProveedor.SelectedValue);
            x.idProd = Convert.ToInt32(cbProducto.SelectedValue);
            x.minimo = int.Parse(txtMinimo.Text);
            x.existencia = int.Parse(txtExis.Text);
            MessageBox.Show(x.Eliminar());
            Limpiar();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            REPORTS.FrmrProducto x = new REPORTS.FrmrProducto();
            x.ShowDialog();
        }
    }
}
