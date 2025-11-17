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

        private void FrmProducto_Load(object sender, EventArgs e)
        {

        }

        private void tsGuardar_Click(object sender, EventArgs e)
        {

        }

        private void tsBuscar_Click(object sender, EventArgs e)
        {

        }

        private void tsLimpiar_Click(object sender, EventArgs e)
        {

        }

        private void tsEliminar_Click(object sender, EventArgs e)
        {

        }

        private void tsClose_Click(object sender, EventArgs e)
        {

        }
    }
}
