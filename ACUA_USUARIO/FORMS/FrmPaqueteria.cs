using ACUA_CAPA_NEG.CLASES;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ACUA_USUARIO.FORMS
{
    public partial class FrmPaqueteria : Form
    {
        Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        SqlCommand comando = new SqlCommand();
        public FrmPaqueteria()
        {
            InitializeComponent();
            con.ConnectionString = x.ConexionSql;
        }

        private void FrmPaqueteria_Load(object sender, EventArgs e)
        {
            CargarDomicilio();
        }

        void CargarDomicilio()
        {
            DataTable dt = new DataTable();
            string consulta = "SELECT * FROM DOMICILIO";
            SqlDataAdapter da = new SqlDataAdapter(consulta, con);
            con.Open();
            da.Fill(dt);
            con.Close();
            cbDomicilio.DisplayMember = "referencias";
            cbDomicilio.ValueMember = "idDom";
            cbDomicilio.DataSource = dt;
        }

        void Limpiar()
        {
            txtId.Clear();
            txtNombre.Clear();
            txtTelefono.Clear();
            ACUA_CAPA_NEG.CLASES.Herramientas h = new ACUA_CAPA_NEG.CLASES.Herramientas();
            txtId.Text = h.consecutivo("idPaq", "PAQUETERIA").ToString();
            txtNombre.Focus();
            txtTelefono.Focus();
        }

        bool encontro()
        {
            bool a = false;
            int id = int.Parse(txtId.Text);
            string cadena = $"Select * From PAQUETERIA where idPaq = {id}";
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
            Paqueteria x = new Paqueteria();
            x.idPaq = int.Parse(txtId.Text);
            x.idDom = Convert.ToInt32(cbDomicilio.SelectedValue);
            x.nombre = txtNombre.Text;
            x.telefono = int.Parse(txtTelefono.Text);
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

        }

        private void tsLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void tsEliminar_Click(object sender, EventArgs e)
        {
            ACUA_CAPA_NEG.CLASES.Paqueteria x = new ACUA_CAPA_NEG.CLASES.Paqueteria();
            x.idPaq = int.Parse(txtId.Text);
            x.idDom = Convert.ToInt32(cbDomicilio.SelectedValue);
            x.nombre = txtNombre.Text;
            x.telefono = int.Parse(txtTelefono.Text);
            MessageBox.Show(x.Eliminar());
            Limpiar();
        }
    }
}
