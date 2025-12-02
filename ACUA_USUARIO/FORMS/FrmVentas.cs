using ACUA_CAPA_NEG.CLASES;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ACUA_USUARIO.FORMS
{
    public partial class FrmVentas : Form
    {
        Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        SqlCommand comando = new SqlCommand();
        public FrmVentas()
        {
            InitializeComponent();
            con.ConnectionString = x.ConexionSql;

        }

        void CargarTrabajador()
        {
            DataTable dt = new DataTable();
            string consulta = "SELECT * FROM TRABAJADOR";
            SqlDataAdapter da = new SqlDataAdapter(consulta, con);
            con.Open();
            da.Fill(dt);
            con.Close();
            cbTrabajador.DisplayMember = "traNombre";
            cbTrabajador.ValueMember = "idTra";
            cbTrabajador.DataSource = dt;
        }

        void CargarCliente()
        {
            DataTable dt = new DataTable();
            string consulta = "SELECT * FROM CLIENTE";
            SqlDataAdapter da = new SqlDataAdapter(consulta, con);
            con.Open();
            da.Fill(dt);
            con.Close();
            cbCliente.DisplayMember = "cli_Nombre";
            cbCliente.ValueMember = "idCli";
            cbCliente.DataSource = dt;
        }

        void Limpiar()
        {
            txtId.Clear();
            txtEstado.Clear();
            txtTotal.Clear();
            ACUA_CAPA_NEG.CLASES.Herramientas h = new ACUA_CAPA_NEG.CLASES.Herramientas();
            txtId.Text = h.consecutivo("idV", "VENTA").ToString();
            txtEstado.Focus();
            txtTotal.Focus();
        }

        bool encontro()
        {
            bool a = false;
            int id = int.Parse(txtId.Text);
            string cadena = $"Select * From VENTA where idV = {id}";
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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Ventas x = new Ventas();
            x.idV = int.Parse(txtId.Text);
            x.idTrabajador = Convert.ToInt32(cbTrabajador.SelectedValue);
            x.idCliente = Convert.ToInt32(cbCliente.SelectedValue);
            x.fVenta = dtFechaV.Value.ToString("yyyy/MM/dd");
            x.MetodoP = txtMetodoP.Text;
            x.total = decimal.Parse(txtTotal.Text);
            x.Estado = txtEstado.Text;
            if (encontro() == true)
            {
                MessageBox.Show(x.Actualizar());
            }
            else
            {
                MessageBox.Show(x.Guardar());
            }
        }

        private void FrmVentas_Load(object sender, EventArgs e)
        {
            CargarCliente();
            CargarTrabajador();
        }

        private void tsBuscar_Click(object sender, EventArgs e)
        {
            SEARCH.FrmBusquedaVentas x = new SEARCH.FrmBusquedaVentas();
            x.ShowDialog();
            if (x.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                txtId.Text = x.dgVenta.SelectedRows[0].Cells["idV"].Value.ToString();
                cbCliente.Text = x.dgVenta.SelectedRows[0].Cells["idCli"].Value.ToString();
                cbTrabajador.Text = x.dgVenta.SelectedRows[0].Cells["idTra"].Value.ToString();
                dtFechaV.Text = x.dgVenta.SelectedRows[0].Cells["Fecha_Venta"].Value.ToString();
                txtMetodoP.Text = x.dgVenta.SelectedRows[0].Cells["Metodo_Pago"].Value.ToString();
                txtTotal.Text = x.dgVenta.SelectedRows[0].Cells["Total"].Value.ToString();
                txtEstado.Text = x.dgVenta.SelectedRows[0].Cells["Estado"].Value.ToString();
            }
        }

        private void tsLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void tsEliminar_Click(object sender, EventArgs e)
        {
            Ventas x = new Ventas();
            x.idV = int.Parse(txtId.Text);
            x.idTrabajador = Convert.ToInt32(cbTrabajador.SelectedValue);
            x.idCliente = Convert.ToInt32(cbCliente.SelectedValue);
            x.fVenta = dtFechaV.Value.ToString("yyyy/MM/dd");
            x.MetodoP = txtMetodoP.Text;
            x.total = decimal.Parse(txtTotal.Text);
            x.Estado = txtEstado.Text;
            MessageBox.Show(x.Eliminar());
            Limpiar();
        }
    }
}
