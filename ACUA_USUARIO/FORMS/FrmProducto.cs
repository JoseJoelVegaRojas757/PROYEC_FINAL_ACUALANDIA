using ACUA_CAPA_NEG.CLASES;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ACUA_USUARIO.FORMS
{
    public partial class FrmProducto : Form
    {
        Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        SqlCommand comando = new SqlCommand();
        public FrmProducto()
        {
            InitializeComponent();
            con.ConnectionString = x.ConexionSql;
        }

        void CargarCategoria()
        {
            DataTable dt = new DataTable();
            string consulta = "SELECT * FROM CATEGORIA";
            SqlDataAdapter da = new SqlDataAdapter(consulta, con);
            con.Open();
            da.Fill(dt);
            con.Close();
            cbCategoria.DisplayMember = "nomCat";
            cbCategoria.ValueMember = "idCat";
            cbCategoria.DataSource = dt;
        }

        void Limpiar()
        {
            txtId.Clear();
            txtCodigo.Clear();
            txtNombre.Clear();
            txtCompra.Clear();
            txtIvaCompra.Clear();
            txtVenta.Clear();
            txtIvaVenta.Clear();
            txtPrecioOferta.Clear();

            
            chkOferta.Checked = false;
            chkEstatus.Checked = true; 

            ACUA_CAPA_NEG.CLASES.Herramientas h = new ACUA_CAPA_NEG.CLASES.Herramientas();
            txtId.Text = h.consecutivo("idProd", "PRODUCTO").ToString();

            txtCodigo.Focus();
        }

        bool encontro()
        {
            bool a = false;
            int id = int.Parse(txtId.Text);
            string cadena = $"Select * From PRODUCTO where idProd = {id}";

            con.Open();
            comando.CommandText = cadena;
            comando.CommandType = CommandType.Text;
            comando.Connection = con;
            SqlDataReader lector = comando.ExecuteReader();

            if (lector.Read())
            {
                a = true;
            }
            lector.Close();
            con.Close();
            return a;

        }

        private void FrmProducto_Load(object sender, EventArgs e)
        {
            CargarCategoria();
            Limpiar();
        }

        private void tsGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                MessageBox.Show("Ingrese el código del producto");
                txtCodigo.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Ingrese el nombre del producto");
                txtNombre.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCompra.Text))
            {
                MessageBox.Show("Ingrese el precio de compra");
                txtCompra.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtVenta.Text))
            {
                MessageBox.Show("Ingrese el precio de venta");
                txtVenta.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtIvaCompra.Text)) txtIvaCompra.Text = "0";
            if (string.IsNullOrWhiteSpace(txtIvaVenta.Text)) txtIvaVenta.Text = "0";
            if (string.IsNullOrWhiteSpace(txtPrecioOferta.Text)) txtPrecioOferta.Text = "0";

            try
            {
                Producto x = new Producto();
                x.idProd = int.Parse(txtId.Text);
                x.idCat = Convert.ToInt32(cbCategoria.SelectedValue);
                x.codigo = txtCodigo.Text;
                x.nomProducto = txtNombre.Text;
                x.pCompra = decimal.Parse(txtCompra.Text);
                x.ivaCompra = decimal.Parse(txtIvaCompra.Text);
                x.pVenta = decimal.Parse(txtVenta.Text);
                x.ivaVenta = decimal.Parse(txtIvaVenta.Text);
                x.oferta = chkOferta.Checked;
                x.pOferta = decimal.Parse(txtPrecioOferta.Text);
                x.estatus = chkEstatus.Checked;

                if (encontro())
                {
                    MessageBox.Show(x.Actualizar());
                }
                else
                {
                    MessageBox.Show(x.Guardar());
                }

                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void tsBuscar_Click(object sender, EventArgs e)
        {
            SEARCH.FrmBusquedaProducto x = new SEARCH.FrmBusquedaProducto();
            x.ShowDialog();

            if (x.DialogResult == DialogResult.OK && x.dgProducto.SelectedRows.Count > 0)
            {
                DataGridViewRow row = x.dgProducto.SelectedRows[0];

                txtId.Text = row.Cells["idProd"].Value?.ToString() ?? "";

                if (row.Cells["idCat"].Value != null)
                    cbCategoria.SelectedValue = Convert.ToInt32(row.Cells["idCat"].Value);

                txtCodigo.Text = row.Cells["codigo"].Value?.ToString() ?? "";
                txtNombre.Text = row.Cells["nomProducto"].Value?.ToString() ?? "";
                txtCompra.Text = row.Cells["pCompra"].Value?.ToString() ?? "";
                txtIvaCompra.Text = row.Cells["ivaCompra"].Value?.ToString() ?? "";
                txtVenta.Text = row.Cells["pVenta"].Value?.ToString() ?? "";
                txtIvaVenta.Text = row.Cells["ivaVenta"].Value?.ToString() ?? "";

                if (row.Cells["oferta"].Value != null)
                {
                    string ofertaValor = row.Cells["oferta"].Value.ToString();
                    chkOferta.Checked = (ofertaValor == "1" || ofertaValor.ToLower() == "true");
                }

                txtPrecioOferta.Text = row.Cells["pOferta"].Value?.ToString() ?? "";

                if (row.Cells["estatus"].Value != null)
                {
                    string estatusValor = row.Cells["estatus"].Value.ToString();
                    chkEstatus.Checked = (estatusValor == "1" || estatusValor.ToLower() == "true");
                }
            }
        }

        private void tsLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void tsEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text) || txtId.Text == "0")
            {
                MessageBox.Show("Seleccione un producto para eliminar");
                return;
            }

            if (MessageBox.Show("¿Eliminar este producto?", "Confirmar",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Producto x = new Producto();
                x.idProd = int.Parse(txtId.Text);
                x.idCat = Convert.ToInt32(cbCategoria.SelectedValue);
                x.codigo = txtCodigo.Text;
                x.nomProducto = txtNombre.Text;
                x.pCompra = decimal.Parse(txtCompra.Text);
                x.ivaCompra = string.IsNullOrWhiteSpace(txtIvaCompra.Text) ? 0 : decimal.Parse(txtIvaCompra.Text);
                x.pVenta = decimal.Parse(txtVenta.Text);
                x.ivaVenta = string.IsNullOrWhiteSpace(txtIvaVenta.Text) ? 0 : decimal.Parse(txtIvaVenta.Text);
                x.oferta = chkOferta.Checked;
                x.pOferta = string.IsNullOrWhiteSpace(txtPrecioOferta.Text) ? 0 : decimal.Parse(txtPrecioOferta.Text);
                x.estatus = chkEstatus.Checked;

                MessageBox.Show(x.Eliminar());
                Limpiar();
            }
        }

        private void tsClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkOferta_CheckedChanged(object sender, EventArgs e)
        {
            txtPrecioOferta.Enabled = chkOferta.Checked;
            if (!chkOferta.Checked)
                txtPrecioOferta.Text = "0";
        }

        private void txtCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FORMS.FrmInvProducto w = new FORMS.FrmInvProducto();
            w.ShowDialog();
        }


    }
}
