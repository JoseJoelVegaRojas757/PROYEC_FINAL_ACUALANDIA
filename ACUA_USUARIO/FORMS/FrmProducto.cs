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
            string consulta = "SELECT * FROM CLIENTE";
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
            txtIva.Clear();
            txtVenta.Clear();
            txtOferta.Clear();
            txtProductoOf.Clear();
            txtEstatus.Clear();
            ACUA_CAPA_NEG.CLASES.Herramientas h = new ACUA_CAPA_NEG.CLASES.Herramientas();
            txtId.Text = h.consecutivo("idProd", "PRODUCTO").ToString();
            txtId.Focus();
            txtCodigo.Focus();
            txtNombre.Focus();
            txtCompra.Focus();
            txtIva.Focus();
            txtVenta.Focus();
            txtOferta.Focus();
            txtProductoOf.Focus();
            txtEstatus.Focus();
        }

        bool encontro()
        {
            bool a = false;
            int id = int.Parse(txtId.Text);
            string cadena = $"Select * From PRODUCTO where idProd = {id}";
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

        private void FrmProducto_Load(object sender, EventArgs e)
        {
            CargarCategoria();
        }

        private void tsGuardar_Click(object sender, EventArgs e)
        {
            Producto x = new Producto();
            x.idProd = int.Parse(txtId.Text);
            x.idCat = Convert.ToInt32(cbCategoria.SelectedValue);
            x.codigo = txtCodigo.Text;
            x.nomProducto = txtNombre.Text;
            x.pCompra = int.Parse(txtCompra.Text);
            x.ivaVenta = int.Parse(txtIva.Text);
            x.pVenta = int.Parse(txtVenta.Text);
            x.oferta = txtOferta.Text;
            x.pOferta = int.Parse(txtProductoOf.Text);
            x.estatus = txtEstatus.Text;
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
            SEARCH.FrmBusquedaProducto x = new SEARCH.FrmBusquedaProducto();
            x.ShowDialog();
            if (x.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                txtId.Text = x.dgProducto.SelectedRows[0].Cells["idProd"].Value.ToString();
                cbCategoria.Text = x.dgProducto.SelectedRows[0].Cells["idCat"].Value.ToString();
                txtCodigo.Text = x.dgProducto.SelectedRows[0].Cells["codigo"].Value.ToString();
                txtNombre.Text = x.dgProducto.SelectedRows[0].Cells["nomProducto"].Value.ToString();
                txtCompra.Text = x.dgProducto.SelectedRows[0].Cells["pCompra"].Value.ToString();
                txtIva.Text = x.dgProducto.SelectedRows[0].Cells["ivaCompra"].Value.ToString();
                txtVenta.Text = x.dgProducto.SelectedRows[0].Cells["pVenta"].Value.ToString();
                txtVenta.Text = x.dgProducto.SelectedRows[0].Cells["ivaVenta"].Value.ToString();
                txtOferta.Text = x.dgProducto.SelectedRows[0].Cells["oferta"].Value.ToString();
                txtProductoOf.Text = x.dgProducto.SelectedRows[0].Cells["pOferta"].Value.ToString();
                txtEstatus.Text = x.dgProducto.SelectedRows[0].Cells["estatus"].Value.ToString();
            }
        }

        private void tsLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void tsEliminar_Click(object sender, EventArgs e)
        {
            Producto x = new Producto();
            x.idProd = int.Parse(txtId.Text);
            x.idCat = Convert.ToInt32(cbCategoria.SelectedValue);
            x.codigo = txtCodigo.Text;
            x.nomProducto = txtNombre.Text;
            x.pCompra = int.Parse(txtCompra.Text);
            x.ivaVenta = int.Parse(txtIva.Text);
            x.pVenta = int.Parse(txtVenta.Text);
            x.oferta = txtOferta.Text;
            x.pOferta = int.Parse(txtProductoOf.Text);
            x.estatus = txtEstatus.Text;
            MessageBox.Show(x.Eliminar());
            Limpiar();
        }

        private void tsClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
