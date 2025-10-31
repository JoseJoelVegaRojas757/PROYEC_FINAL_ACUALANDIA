using ACUA_CAPA_NEG.CLASES;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ACUA_USUARIO.FORMS
{
    public partial class FrmCliente : Form
    {
        Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        SqlCommand comando = new SqlCommand();

        public FrmCliente()
        {
            InitializeComponent();
            con.ConnectionString = x.ConexionSql;
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        void CargarDomiclio()
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
            txtA_Paterno.Clear();
            txtA_Materno.Clear();
            txtFechaNa.Clear();
            txtTel.Clear();
            txtSociales.Clear();
            ACUA_CAPA_NEG.CLASES.Herramientas h = new ACUA_CAPA_NEG.CLASES.Herramientas();
            txtId.Text = h.consecutivo("idCli", "CLIENTE").ToString();
            txtNombre.Focus();
            txtA_Paterno.Focus();
            txtA_Materno.Focus();
            txtTel.Focus();
            txtFechaNa.Focus();
            txtSociales.Focus();
        }

        bool encontro()
        {
            bool a = false;
            int id = int.Parse(txtId.Text);
            string cadena = $"Select * From CLIENTE where idCli = {id}";
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

        private void FrmCliente_Load(object sender, System.EventArgs e)
        {
            CargarDomiclio();
        }

        private void tsGuardar_Click(object sender, System.EventArgs e)
        {
            Cliente x = new Cliente();
            x.idCli = int.Parse(txtId.Text);
            x.idDom = Convert.ToInt32(cbDomicilio.SelectedValue);
            x.Nombre = txtNombre.Text;
            x.Paterno = txtA_Paterno.Text;
            x.Materno = txtA_Materno.Text;
            x.Nacimiento = txtFechaNa.Text;
            x.Telefono = txtTel.Text;
            x.RSociales = txtSociales.Text;
            if (encontro() == true)
            {
                MessageBox.Show(x.Actualizar());
            }
            else
            {
                MessageBox.Show(x.Guardar());
            }
        }

        private void tsLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void tsBuscar_Click(object sender, EventArgs e)
        {
            SEARCH.FrmBusquedaCliente x = new SEARCH.FrmBusquedaCliente();
            x.ShowDialog();
            if (x.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                txtId.Text = x.dgCliente.SelectedRows[0].Cells["idCli"].Value.ToString();
                cbDomicilio.Text = x.dgCliente.SelectedRows[0].Cells["idDom"].Value.ToString();
                txtNombre.Text = x.dgCliente.SelectedRows[0].Cells["cli_Nombre"].Value.ToString();
                txtA_Paterno.Text = x.dgCliente.SelectedRows[0].Cells["cli_Paterno"].Value.ToString();
                txtA_Materno.Text = x.dgCliente.SelectedRows[0].Cells["cli_Materno"].Value.ToString();
                txtTel.Text = x.dgCliente.SelectedRows[0].Cells["cli_Tel"].Value.ToString();
                txtSociales.Text = x.dgCliente.SelectedRows[0].Cells["cli_Sociales"].Value.ToString();
                txtFechaNa.Text = x.dgCliente.SelectedRows[0].Cells["cli_Nacimiento"].Value.ToString();
            }
        }

        private void tsEliminar_Click(object sender, EventArgs e)
        {
            ACUA_CAPA_NEG.CLASES.Cliente x = new ACUA_CAPA_NEG.CLASES.Cliente();
            x.idCli = int.Parse(txtId.Text);
            x.idDom = Convert.ToInt32(cbDomicilio.SelectedValue);
            x.Nombre = txtNombre.Text;
            x.Paterno = txtA_Paterno.Text;
            x.Materno = txtA_Materno.Text;
            x.Nacimiento = txtFechaNa.Text;
            x.Telefono = txtTel.Text;
            x.RSociales = txtSociales.Text;
            MessageBox.Show(x.Eliminar());
            Limpiar();
        }
    }
}
