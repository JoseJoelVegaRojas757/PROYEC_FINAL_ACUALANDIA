using ACUA_CAPA_NEG.CLASES;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ACUA_USUARIO.FORMS
{
    public partial class FrmPMascota : Form
    {
        Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        SqlCommand comando = new SqlCommand();
        public FrmPMascota()
        {
            InitializeComponent();
            con.ConnectionString = x.ConexionSql;
        }

        private void FrmPMascota_Load(object sender, EventArgs e)
        {
            CargarMascota();
            CargarPedido();
            Limpiar();
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

        void Limpiar()
        {
            txtId.Clear();
            txtPrecio.Clear();
            txtCantidad.Clear();
            txtSubT.Clear();
            ACUA_CAPA_NEG.CLASES.Herramientas h = new ACUA_CAPA_NEG.CLASES.Herramientas();
            txtId.Text = h.consecutivo("idPmas", "PMASCOTA").ToString();
            txtPrecio.Focus();
            txtCantidad.Focus();
            txtSubT.Focus();
        }

        bool encontro()
        {
            bool a = false;
            int id = int.Parse(txtId.Text);
            string cadena = $"SELECT * FROM PMASCOTA WHERE idPmas = {id}";
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
            PMascota x = new PMascota();
            x.idPmas = int.Parse(txtId.Text);
            x.idPed = Convert.ToInt32(cbPedido.SelectedValue);
            x.idMas = Convert.ToInt32(cbMascota.SelectedValue);
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
            SEARCH.FrmBusquedaPMascota x = new SEARCH.FrmBusquedaPMascota();
            x.ShowDialog();
            if (x.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                txtId.Text = x.dgPMascota.SelectedRows[0].Cells["idPmas"].Value.ToString();
                cbMascota.SelectedValue = x.dgPMascota.SelectedRows[0].Cells["idMas"].Value.ToString();
                cbPedido.SelectedValue = x.dgPMascota.SelectedRows[0].Cells["idPed"].Value.ToString();
                txtCantidad.Text = x.dgPMascota.SelectedRows[0].Cells["cantidad"].Value.ToString();
                txtPrecio.Text = x.dgPMascota.SelectedRows[0].Cells["precio"].Value.ToString();
                txtSubT.Text = x.dgPMascota.SelectedRows[0].Cells["subtotal"].Value.ToString();
            }
        }

        private void tsLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void tsEliminar_Click(object sender, EventArgs e)
        {
            ACUA_CAPA_NEG.CLASES.PMascota x = new ACUA_CAPA_NEG.CLASES.PMascota();
            x.idPmas = int.Parse(txtId.Text);
            x.idPed = Convert.ToInt32(cbPedido.SelectedValue);
            x.idMas = Convert.ToInt32(cbMascota.SelectedValue);
            x.cantidad = int.Parse(txtCantidad.Text);
            x.precio = int.Parse(txtPrecio.Text);
            x.subtotal = int.Parse(txtSubT.Text);
            MessageBox.Show(x.Eliminar());
            Limpiar();
        }

        private void tsClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
