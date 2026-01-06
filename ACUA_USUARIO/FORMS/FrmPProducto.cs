using ACUA_CAPA_NEG.CLASES;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ACUA_USUARIO.FORMS
{
    public partial class FrmPProducto : Form
    {
        Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        SqlCommand comando = new SqlCommand();
        public FrmPProducto()
        {
            InitializeComponent();
            con.ConnectionString = x.ConexionSql;
        }

        private void FrmPProducto_Load(object sender, EventArgs e)
        {
            CargarPedido();
            CargarProducto();
        }
        void CargarPedido()
        {
            DataTable dt = new DataTable();
            string consulta = "SELECT * FROM PEDIDO";
            SqlDataAdapter da = new SqlDataAdapter(consulta, con);
            con.Open();
            da.Fill(dt);
            con.Close();
            cbPedido.DisplayMember = "fPedido";
            cbPedido.ValueMember = "idPed";
            cbPedido.DataSource = dt;
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

        void Limpiar()
        {
            txtId.Clear();
            txtCantidad.Clear();
            txtPrecio.Clear();
            txtSubT.Clear();
            ACUA_CAPA_NEG.CLASES.Herramientas h = new ACUA_CAPA_NEG.CLASES.Herramientas();
            txtId.Text = h.consecutivo("idPprod", "PPRODUCTO").ToString();
            txtCantidad.Focus();
            txtPrecio.Focus();
            txtSubT.Focus();
        }

        bool encontro()
        {
            bool a = false;
            int id = int.Parse(txtId.Text);
            string cadena = $"Select * From PPRODUCTO where idPprod = {id}";
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

        private void tsGuardar_Click(object sender, EventArgs e)
        {
            PProducto x = new PProducto();
            x.idPprod = int.Parse(txtId.Text);
            x.idPed = Convert.ToInt32(cbPedido.SelectedValue);
            x.idProd = Convert.ToInt32(cbProducto.SelectedValue);
            x.cantidad = int.Parse(txtCantidad.Text);
            x.precio = int.Parse(txtPrecio.Text);
            x.subtotal = int.Parse(txtSubT.Text);
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
            SEARCH.FrmBusquedaPProducto x = new SEARCH.FrmBusquedaPProducto();
            x.ShowDialog();
            if (x.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                txtId.Text = x.dgPProducto.SelectedRows[0].Cells["idPprod"].Value.ToString();
                cbPedido.SelectedValue = x.dgPProducto.SelectedRows[0].Cells["idPed"].Value.ToString();
                cbProducto.SelectedValue = x.dgPProducto.SelectedRows[0].Cells["idProd"].Value.ToString();
                txtCantidad.Text = x.dgPProducto.SelectedRows[0].Cells["cantidad"].Value.ToString();
                txtPrecio.Text = x.dgPProducto.SelectedRows[0].Cells["precio"].Value.ToString();
                txtSubT.Text = x.dgPProducto.SelectedRows[0].Cells["subtotal"].Value.ToString();
            }
        }

        private void tsLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void tsEliminar_Click(object sender, EventArgs e)
        {
            PProducto x = new PProducto();
            x.idPprod = int.Parse(txtId.Text);
            x.idPed = Convert.ToInt32(cbPedido.SelectedValue);
            x.idProd = Convert.ToInt32(cbProducto.SelectedValue);
            x.cantidad = int.Parse(txtCantidad.Text);
            x.precio = int.Parse(txtPrecio.Text);
            x.subtotal = int.Parse(txtSubT.Text);
            MessageBox.Show(x.Eliminar());
            Limpiar();
        }

        void precioc()
        {
            string consulta = "SELECT pVenta FROM PRODUCTO WHERE idProd = " + cbProducto.SelectedValue.ToString();
            SqlCommand cmd = new SqlCommand(consulta, con);
            con.Open();

            object precio = cmd.ExecuteScalar();
            txtPrecio.Text = precio != null ? precio.ToString() : "0";
            con.Close();
        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbProducto_TextChanged(object sender, EventArgs e)
        {
            if (cbProducto.SelectedValue != null)
            {
                precioc();
            }
        }
    }
}
