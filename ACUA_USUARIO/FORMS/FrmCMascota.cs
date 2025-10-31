using ACUA_CAPA_NEG.CLASES;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ACUA_USUARIO.FORMS
{
    public partial class FrmCMascota : Form
    {
        Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        SqlCommand comando = new SqlCommand();

        public FrmCMascota()
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

        void CargarMascota()
        {
            DataTable dt = new DataTable();
            string consulta = "SELECT * FROM MASCOTA";
            SqlDataAdapter da = new SqlDataAdapter(consulta, con);
            con.Open();
            da.Fill(dt);
            con.Close();
            cbCliente.DisplayMember = "caracteristicas";
            cbCliente.ValueMember = "idCmas";
            cbCliente.DataSource = dt;
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void FrmCMascota_Load(object sender, System.EventArgs e)
        {
            CargarCliente();
            CargarMascota();
        }

        void Limpiar()
        {
            txtId.Clear();
            txtConsumible.Clear();
            txtFecha.Clear();
            ACUA_CAPA_NEG.CLASES.Herramientas h = new ACUA_CAPA_NEG.CLASES.Herramientas();
            txtId.Text = h.consecutivo("idCmas", "CMASCOTA").ToString();
            txtConsumible.Focus();
            txtFecha.Focus();
        }

        bool encontro()
        {
            bool a = false;
            int id = int.Parse(txtId.Text);
            string cadena = $"Select * From CMASCOTA where idCmas = {id}";
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

        private void tsGuardar_Click(object sender, System.EventArgs e)
        {
            CMascota x = new CMascota();
            x.idCmas = int.Parse(txtId.Text);
            x.idMas = Convert.ToInt32(cbMascota.SelectedValue);
            x.idCli = Convert.ToInt32(cbCliente.SelectedValue);
            x.consumible = int.Parse(txtConsumible.Text);
            x.cFecha = txtFecha.Text;
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
            SEARCH.FrmBusquedaCMascota x = new SEARCH.FrmBusquedaCMascota();
            x.ShowDialog();
            if (x.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                txtId.Text = x.dgCMascota.SelectedRows[0].Cells["idCmas"].Value.ToString();
                cbMascota.Text = x.dgCMascota.SelectedRows[0].Cells["idMas"].Value.ToString();
                cbCliente.Text = x.dgCMascota.SelectedRows[0].Cells["idCli"].Value.ToString();
                txtFecha.Text = x.dgCMascota.SelectedRows[0].Cells["cFecha"].Value.ToString();
                txtConsumible.Text = x.dgCMascota.SelectedRows[0].Cells["consumible"].Value.ToString();
            }
        }

        private void tsLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void tsEliminar_Click(object sender, EventArgs e)
        {
            ACUA_CAPA_NEG.CLASES.CMascota x = new ACUA_CAPA_NEG.CLASES.CMascota();
            x.idCmas = int.Parse(txtId.Text);
            x.idMas = Convert.ToInt32(cbMascota.SelectedValue);
            x.idCli = Convert.ToInt32(cbCliente.SelectedValue);
            x.consumible = int.Parse(txtConsumible.Text);
            x.cFecha = txtFecha.Text;
            MessageBox.Show(x.Eliminar());
            Limpiar();
        }
    }
}
