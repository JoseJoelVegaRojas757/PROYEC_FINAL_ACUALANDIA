using ACUA_CAPA_NEG.CLASES;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ACUA_USUARIO.FORMS
{
    public partial class FrmPADetalle : Form
    {
        Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        SqlCommand comando = new SqlCommand();
        public FrmPADetalle()
        {
            InitializeComponent();
            con.ConnectionString = x.ConexionSql;
        }

        private void FrmPADetalle_Load(object sender, EventArgs e)
        {
            CargarApartado();
            CargarProducto();
            Limpiar();
        }

        void subt()
        {
            try
            {
                decimal p = decimal.Parse(txtPrecio.Text);
                decimal c = decimal.Parse(txtCantidad.Text);
                txtSubT.Text = (p * c).ToString();
            }
            catch
            {
                txtSubT.Text = "0";
            }

        }

        void CargarApartado()
        {
            DataTable dt = new DataTable();
            string consulta = "SELECT * FROM APARTADO";
            SqlDataAdapter da = new SqlDataAdapter(consulta, con);
            con.Open();
            da.Fill(dt);
            con.Close();
            cbApartado.DisplayMember = "fApartado";
            cbApartado.ValueMember = "idApartado";
            cbApartado.DataSource = dt;
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
            txtFaltante.Clear();
            txtAnticipo.Clear();
            txtSubT.Clear();
            ACUA_CAPA_NEG.CLASES.Herramientas h = new ACUA_CAPA_NEG.CLASES.Herramientas();
            txtId.Text = h.consecutivo("idAdetalle", "PADETALLE").ToString();
            txtFaltante.Focus();
            txtAnticipo.Focus();
            txtCantidad.Focus();
            txtSubT.Focus();
        }

        bool encontro()
        {
            bool a = false;
            int id = int.Parse(txtId.Text);
            string cadena = $"Select * From PADETALLE where idAdetalle = {id}";
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
            PADetalle x = new PADetalle();
            x.idAdetalle = int.Parse(txtId.Text);
            x.idApartado = Convert.ToInt32(cbApartado.SelectedValue);
            x.idProducto = Convert.ToInt32(cbProducto.SelectedValue);
            x.cantidad = int.Parse(txtCantidad.Text);
            x.precio = int.Parse(txtPrecio.Text);
            x.anticipo = int.Parse(txtAnticipo.Text);
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
            SEARCH.FrmBusquedaPADetalle x = new SEARCH.FrmBusquedaPADetalle();
            x.ShowDialog();
            if (x.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                txtId.Text = x.dgPAdetalle.SelectedRows[0].Cells["idAdetalle"].Value.ToString();
                cbApartado.SelectedValue = x.dgPAdetalle.SelectedRows[0].Cells["idApartado"].Value.ToString();
                cbProducto.SelectedValue = x.dgPAdetalle.SelectedRows[0].Cells["idProducto"].Value.ToString();
                txtCantidad.Text = x.dgPAdetalle.SelectedRows[0].Cells["cantidad"].Value.ToString();
                txtPrecio.Text = x.dgPAdetalle.SelectedRows[0].Cells["precio"].Value.ToString();
                txtAnticipo.Text = x.dgPAdetalle.SelectedRows[0].Cells["anticipo"].Value.ToString();
                txtSubT.Text = x.dgPAdetalle.SelectedRows[0].Cells["subtotal"].Value.ToString();
            }
        }

        private void tsLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void tsEliminar_Click(object sender, EventArgs e)
        {
            ACUA_CAPA_NEG.CLASES.PADetalle x = new ACUA_CAPA_NEG.CLASES.PADetalle();
            x.idAdetalle = int.Parse(txtId.Text);
            x.idApartado = Convert.ToInt32(cbApartado.SelectedValue);
            x.idProducto = Convert.ToInt32(cbProducto.SelectedValue);
            x.cantidad = int.Parse(txtCantidad.Text);
            x.precio = int.Parse(txtPrecio.Text);
            x.anticipo = int.Parse(txtAnticipo.Text);
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            subt();
        }
    }
}
