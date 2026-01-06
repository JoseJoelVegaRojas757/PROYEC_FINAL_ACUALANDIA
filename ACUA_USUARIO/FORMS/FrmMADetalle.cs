using ACUA_CAPA_NEG.CLASES;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ACUA_USUARIO.FORMS
{
    public partial class FrmMADetalle : Form
    {

        Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        SqlCommand comando = new SqlCommand();
        public FrmMADetalle()
        {
            InitializeComponent();
            con.ConnectionString = x.ConexionSql;
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
        void CargarMascota()
        {
            DataTable dt = new DataTable();
            string consulta = "SELECT * FROM MASCOTA";
            SqlDataAdapter da = new SqlDataAdapter(consulta, con);
            con.Open();
            da.Fill(dt);
            con.Close();
            cbMascota.DisplayMember = "caracteristicas";
            cbMascota.ValueMember = "idMas";
            cbMascota.DataSource = dt;
        }

        void Limpiar()
        {
            txtId.Clear();
            txtCantidad.Clear();
            txtPrecio.Clear();
            txtAnticipo.Clear();
            txtSubTotal.Clear();
            ACUA_CAPA_NEG.CLASES.Herramientas h = new ACUA_CAPA_NEG.CLASES.Herramientas();
            txtId.Text = h.consecutivo("idAdetalle", "MADETALLE").ToString();
            txtPrecio.Focus();
            txtAnticipo.Focus();
            txtCantidad.Focus();
            txtSubTotal.Focus();
        }

        bool encontro()
        {

            bool a = false;

            if (txtId.Text.Trim() == "" || txtId.Text == "0")
                return false;

            try
            {
                int id = int.Parse(txtId.Text);
                string cadena = $"Select * From MADETALLE where idAdetalle = {id}";
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



        private void tsGuardar_Click(object sender, EventArgs e)
        {
            if (cbApartado.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un apartado");
                cbApartado.Focus();
                return;
            }

            if (cbMascota.SelectedValue == null)
            {
                MessageBox.Show("Seleccione una mascota");
                cbMascota.Focus();
                return;
            }

            if (txtCantidad.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese la cantidad");
                txtCantidad.Focus();
                return;
            }

            if (txtPrecio.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el precio");
                txtPrecio.Focus();
                return;
            }

            if (txtAnticipo.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el anticipo");
                txtAnticipo.Focus();
                return;
            }

            int cantidad, precio, anticipo, subtotal;
            if (!int.TryParse(txtCantidad.Text, out cantidad))
            {
                MessageBox.Show("Cantidad debe ser un número");
                txtCantidad.Focus();
                return;
            }

            if (!int.TryParse(txtPrecio.Text, out precio))
            {
                MessageBox.Show("Precio debe ser un número");
                txtPrecio.Focus();
                return;
            }

            if (!int.TryParse(txtAnticipo.Text, out anticipo))
            {
                MessageBox.Show("Anticipo debe ser un número");
                txtAnticipo.Focus();
                return;
            }

            if (!int.TryParse(txtSubTotal.Text, out subtotal))
            {
                MessageBox.Show("Subtotal debe ser un número");
                txtSubTotal.Focus();
                return;
            }

            if (cantidad <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor que cero");
                txtCantidad.Focus();
                return;
            }

            if (precio <= 0)
            {
                MessageBox.Show("El precio debe ser mayor que cero");
                txtPrecio.Focus();
                return;
            }

            if (anticipo <= 0)
            {
                MessageBox.Show("El anticipo debe ser mayor que cero");
                txtAnticipo.Focus();
                return;
            }

            if (anticipo > subtotal)
            {
                MessageBox.Show("El anticipo no puede ser mayor que el subtotal");
                txtAnticipo.Focus();
                return;
            }

            try
            {
                MADetalle x = new MADetalle();
                x.idAdetalle = int.Parse(txtId.Text);
                x.idApartado = Convert.ToInt32(cbApartado.SelectedValue);
                x.idMascota = Convert.ToInt32(cbMascota.SelectedValue);
                x.cantidad = int.Parse(txtCantidad.Text);
                x.precio = int.Parse(txtPrecio.Text);
                x.anticipo = int.Parse(txtAnticipo.Text);
                x.subtotal = int.Parse(txtSubTotal.Text);

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

        private void tsClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmMADetalle_Load(object sender, EventArgs e)
        {
            CargarApartado();
            CargarMascota();
            Limpiar();
        }

        private void tsLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void tsEliminar_Click(object sender, EventArgs e)
        {
            ACUA_CAPA_NEG.CLASES.MADetalle x = new ACUA_CAPA_NEG.CLASES.MADetalle();
            x.idAdetalle = int.Parse(txtId.Text);
            x.idApartado = Convert.ToInt32(cbApartado.SelectedValue);
            x.idMascota = Convert.ToInt32(cbMascota.SelectedValue);
            x.cantidad = int.Parse(txtCantidad.Text);
            x.precio = int.Parse(txtPrecio.Text);
            x.anticipo = int.Parse(txtAnticipo.Text);
            x.subtotal = int.Parse(txtSubTotal.Text);
            MessageBox.Show(x.Eliminar());
            Limpiar();
        }

        private void tsBuscar_Click(object sender, EventArgs e)
        {
            SEARCH.FrmBusquedaMADetalle x = new SEARCH.FrmBusquedaMADetalle();
            x.ShowDialog();
            if (x.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                txtId.Text = x.dgMadetalle.SelectedRows[0].Cells["idAdetalle"].Value.ToString();
                cbApartado.SelectedValue = x.dgMadetalle.SelectedRows[0].Cells["idApartado"].Value.ToString();
                cbMascota.SelectedValue = x.dgMadetalle.SelectedRows[0].Cells["idMascota"].Value.ToString();
                txtCantidad.Text = x.dgMadetalle.SelectedRows[0].Cells["cantidad"].Value.ToString();
                txtPrecio.Text = x.dgMadetalle.SelectedRows[0].Cells["precio"].Value.ToString();
                txtAnticipo.Text = x.dgMadetalle.SelectedRows[0].Cells["anticipo"].Value.ToString();
                txtSubTotal.Text = x.dgMadetalle.SelectedRows[0].Cells["subtotal"].Value.ToString();
            }
        }

        void precioPM()
        {
            string consulta = "SELECT pVenta FROM MVENTA WHERE idMas = " + cbMascota.SelectedValue.ToString();
            SqlCommand cmd = new SqlCommand(consulta, con);
            con.Open();

            object precio = cmd.ExecuteScalar();
            txtPrecio.Text = precio != null ? precio.ToString() : "No esta en Venta";
            con.Close();
        }

        private void cbMascota_TextChanged(object sender, EventArgs e)
        {
            if (cbMascota.SelectedValue != null)
            {
                precioPM();
            }
        }

        void subt()
        {
            try
            {
                decimal p = decimal.Parse(txtPrecio.Text);
                decimal c = decimal.Parse(txtCantidad.Text);
                txtSubTotal.Text = (p * c).ToString();
            }
            catch
            {
                txtSubTotal.Text = "0";
            }

        }

        private void cbMascota_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            subt();
        }
    }
}
