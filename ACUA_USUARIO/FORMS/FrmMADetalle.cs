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
            int id = int.Parse(txtId.Text);
            string cadena = $"Select * From MADETALLE where idAdetalle = {id}";
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
            MADetalle x = new MADetalle();
            x.idAdetalle = int.Parse(txtId.Text);
            x.idApartado = Convert.ToInt32(cbApartado.SelectedValue);
            x.idMascota = Convert.ToInt32(cbMascota.SelectedValue);
            x.cantidad = int.Parse(txtCantidad.Text);
            x.precio = int.Parse(txtPrecio.Text);
            x.anticipo = int.Parse(txtAnticipo.Text);
            x.subtotal = int.Parse(txtSubTotal.Text);
            if (encontro() == true)
            {
                MessageBox.Show(x.Actualizar());
            }
            else
            {
                MessageBox.Show(x.Guardar());
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
                cbApartado.Text = x.dgMadetalle.SelectedRows[0].Cells["idApartado"].Value.ToString();
                cbMascota.Text = x.dgMadetalle.SelectedRows[0].Cells["idMascota"].Value.ToString();
                txtCantidad.Text = x.dgMadetalle.SelectedRows[0].Cells["cantidad"].Value.ToString();
                txtPrecio.Text = x.dgMadetalle.SelectedRows[0].Cells["precio"].Value.ToString();
                txtAnticipo.Text = x.dgMadetalle.SelectedRows[0].Cells["anticipo"].Value.ToString();
                txtSubTotal.Text = x.dgMadetalle.SelectedRows[0].Cells["subtotal"].Value.ToString();
            }
        }
    }
}
