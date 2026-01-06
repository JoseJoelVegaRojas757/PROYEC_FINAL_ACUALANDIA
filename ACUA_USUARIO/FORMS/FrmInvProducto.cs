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

            if (txtId.Text.Trim() == "" || txtId.Text == "0")
                return false;

            try
            {
                int id = int.Parse(txtId.Text);
                string cadena = $"Select * From INVPRODUCTO where idInv = {id}";
                con.Open();
                SqlCommand cmd = new SqlCommand(cadena, con);
                SqlDataReader lector = cmd.ExecuteReader();
                if (lector.Read())
                {
                    a = true;
                }
                con.Close();
                return a;
            }
            catch
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
                return false;
            }
        }

        private void FrmInvProducto_Load(object sender, EventArgs e)
        {
            CargarProducto();
            CargarProveedor();
            Limpiar();
        }

        private void tsGuardar_Click(object sender, EventArgs e)
        {
            if (cbProducto.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un producto");
                cbProducto.Focus();
                return;
            }

            if (cbProveedor.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un proveedor");
                cbProveedor.Focus();
                return;
            }

            if (txtMinimo.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el mínimo de inventario");
                txtMinimo.Focus();
                return;
            }

            if (txtExis.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese la existencia actual");
                txtExis.Focus();
                return;
            }

            int minimo, existencia;
            if (!int.TryParse(txtMinimo.Text, out minimo))
            {
                MessageBox.Show("Mínimo debe ser un número válido");
                txtMinimo.Focus();
                return;
            }

            if (!int.TryParse(txtExis.Text, out existencia))
            {
                MessageBox.Show("Existencia debe ser un número válido");
                txtExis.Focus();
                return;
            }

            if (minimo < 0)
            {
                MessageBox.Show("El mínimo no puede ser negativo");
                txtMinimo.Focus();
                return;
            }

            if (existencia < 0)
            {
                MessageBox.Show("La existencia no puede ser negativa");
                txtExis.Focus();
                return;
            }

            try
            {
                InvProducto x = new InvProducto();
                x.idInv = int.Parse(txtId.Text);
                x.idProv = Convert.ToInt32(cbProveedor.SelectedValue);
                x.idProd = Convert.ToInt32(cbProducto.SelectedValue);
                x.minimo = int.Parse(txtMinimo.Text);
                x.existencia = int.Parse(txtExis.Text);

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
            SEARCH.FrmBusquedaInvProducto x = new SEARCH.FrmBusquedaInvProducto();
            x.ShowDialog();
            if (x.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                txtId.Text = x.dgInvProducto.SelectedRows[0].Cells["idInv"].Value.ToString();
                cbProducto.SelectedValue = x.dgInvProducto.SelectedRows[0].Cells["idProd"].Value.ToString();
                cbProveedor.SelectedValue = x.dgInvProducto.SelectedRows[0].Cells["idProv"].Value.ToString();
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
            if (txtId.Text.Trim() == "" || txtId.Text == "0")
            {
                MessageBox.Show("Seleccione un inventario para eliminar");
                return;
            }

            if (MessageBox.Show("¿Está seguro de eliminar este inventario?", "Confirmar",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
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
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar: " + ex.Message);
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            REPORTS.FrmrProducto x = new REPORTS.FrmrProducto();
            x.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
