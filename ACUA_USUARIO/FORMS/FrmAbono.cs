using ACUA_CAPA_NEG.CLASES;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ACUA_USUARIO.FORMS
{
    public partial class FrmAbono : Form
    {
        Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        SqlCommand comando = new SqlCommand();


        public FrmAbono()
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
            cbApartado.DisplayMember = "faltante";
            cbApartado.ValueMember = "idApartado";
            cbApartado.DataSource = dt;
        }

        void Limpiar()
        {
            txtId.Clear();
            txtMonto.Clear();
            ACUA_CAPA_NEG.CLASES.Herramientas h = new ACUA_CAPA_NEG.CLASES.Herramientas();
            txtId.Text = h.consecutivo("idAbono", "ABONO").ToString();
            txtMonto.Focus();
        }

        bool encontro()
        {
            bool a = false;
            int id = int.Parse(txtId.Text);
            string cadena = $"Select * From ABONO where idAbono = {id}";
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
            Abono x = new Abono();
            x.idAbono = int.Parse(txtId.Text);
            x.idApartado = Convert.ToInt32(cbApartado.SelectedValue);
            x.Monto = txtMonto.Text;
            if (encontro() == true)
            {
                MessageBox.Show(x.Actualizar());
            }
            else
            {
                MessageBox.Show(x.Guardar());
            }
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
