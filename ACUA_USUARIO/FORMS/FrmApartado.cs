using ACUA_CAPA_NEG.CLASES;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ACUA_USUARIO.FORMS
{
    public partial class FrmApartado : Form
    {
        Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        SqlCommand comando = new SqlCommand();


        public FrmApartado()
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
            txtAnticipo.Clear();
            txtFaltante.Clear();
            txtTotal.Clear();
            ACUA_CAPA_NEG.CLASES.Herramientas h = new ACUA_CAPA_NEG.CLASES.Herramientas();
            txtId.Text = h.consecutivo("idApartado", "APARTADO").ToString();
            txtAnticipo.Focus();
            txtFaltante.Focus();
            txtTotal.Focus();
        }

        bool encontro()
        {
            bool a = false;
            int id = int.Parse(txtId.Text);
            string cadena = $"Select * From APARTADO where idApartado = {id}";
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
            Apartado x = new Apartado();
            x.idApartado = int.Parse(txtId.Text);
            x.idTrabajador = Convert.ToInt32(cbTrabajador.SelectedValue);
            x.idCliente = Convert.ToInt32(cbCliente.SelectedValue);
            x.fApartado = dtFechaA.Value.ToString("yyyy/MM/dd");
            x.anticipo = int.Parse(txtAnticipo.Text);
            x.faltante = int.Parse(txtFaltante.Text);
            x.total = int.Parse(txtTotal.Text);
            if (encontro() == true)
            {
                MessageBox.Show(x.Actualizar());
            }
            else
            {
                MessageBox.Show(x.Guardar());
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmApartado_Load(object sender, EventArgs e)
        {
            CargarCliente();
            CargarTrabajador();
        }

        private void tsLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void tsEliminar_Click(object sender, EventArgs e)
        {
            ACUA_CAPA_NEG.CLASES.Apartado x = new ACUA_CAPA_NEG.CLASES.Apartado();
            x.idApartado = int.Parse(txtId.Text);
            x.idTrabajador = Convert.ToInt32(cbTrabajador.SelectedValue);
            x.idCliente = Convert.ToInt32(cbCliente.SelectedValue);
            x.fApartado = dtFechaA.Value.ToString("yyyy/MM/dd");
            x.anticipo = int.Parse(txtAnticipo.Text);
            x.faltante = int.Parse(txtFaltante.Text);
            x.total = int.Parse(txtTotal.Text);
            MessageBox.Show(x.Eliminar());
            Limpiar();
        }

        private void tsBuscar_Click(object sender, EventArgs e)
        {
            SEARCH.FrmBusquedaApartado x = new SEARCH.FrmBusquedaApartado();
            x.ShowDialog();
            if (x.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                txtId.Text = x.dgApartado.SelectedRows[0].Cells["idApartado"].Value.ToString();
                cbTrabajador.Text = x.dgApartado.SelectedRows[0].Cells["idTrabajador"].Value.ToString();
                cbCliente.Text = x.dgApartado.SelectedRows[0].Cells["idCliente"].Value.ToString();
                dtFechaA.Text = x.dgApartado.SelectedRows[0].Cells["fApartado"].Value.ToString();
                txtAnticipo.Text = x.dgApartado.SelectedRows[0].Cells["anticipo"].Value.ToString();
                txtFaltante.Text = x.dgApartado.SelectedRows[0].Cells["faltante"].Value.ToString();
                txtTotal.Text = x.dgApartado.SelectedRows[0].Cells["total"].Value.ToString();
            }
        }

        private void btnMAD_Click(object sender, EventArgs e)
        {
            FrmMADetalle x = new FrmMADetalle();
            x.ShowDialog();

            //FrmGenero x = new FrmGenero();
            //x.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmPADetalle x = new FrmPADetalle();
            x.ShowDialog();
        }
    }
}
