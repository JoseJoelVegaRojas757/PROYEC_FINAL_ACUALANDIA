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
            cbMascota.DisplayMember = "caracteristicas";
            cbMascota.ValueMember = "idMas";
            cbMascota.DataSource = dt;
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void FrmCMascota_Load(object sender, System.EventArgs e)
        {
            CargarCliente();
            CargarMascota();
            Limpiar();
        }

        void Limpiar()
        {
            txtId.Clear();
            txtConsumible.Clear();
            ACUA_CAPA_NEG.CLASES.Herramientas h = new ACUA_CAPA_NEG.CLASES.Herramientas();
            txtId.Text = h.consecutivo("idCmas", "CMASCOTA").ToString();
            txtConsumible.Focus();
        }

        bool encontro()
        {
            bool a = false;

            if (txtId.Text.Trim() == "" || txtId.Text == "0")
                return false;

            try
            {
                int id = int.Parse(txtId.Text);
                string cadena = $"Select * From CMASCOTA where idCmas = {id}";
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

        private void tsGuardar_Click(object sender, System.EventArgs e)
        {
            if (cbCliente.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un cliente");
                cbCliente.Focus();
                return;
            }

            if (cbMascota.SelectedValue == null)
            {
                MessageBox.Show("Seleccione una mascota");
                cbMascota.Focus();
                return;
            }

            if (txtConsumible.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese la cantidad consumible");
                txtConsumible.Focus();
                return;
            }

            int consumible;
            if (!int.TryParse(txtConsumible.Text, out consumible))
            {
                MessageBox.Show("Consumible debe ser un número válido");
                txtConsumible.Focus();
                return;
            }

            if (consumible <= 0)
            {
                MessageBox.Show("El consumible debe ser mayor que cero");
                txtConsumible.Focus();
                return;
            }

            try
            {
                CMascota x = new CMascota();
                x.idCmas = int.Parse(txtId.Text);
                x.idMas = Convert.ToInt32(cbMascota.SelectedValue);
                x.idCli = Convert.ToInt32(cbCliente.SelectedValue);
                x.consumible = int.Parse(txtConsumible.Text);
                x.cFecha = dtFecha.Value.ToString("yyyy/MM/dd");

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

        private void tsBuscar_Click(object sender, EventArgs e)
        {
            SEARCH.FrmBusquedaCMascota x = new SEARCH.FrmBusquedaCMascota();
            x.ShowDialog();
            if (x.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                txtId.Text = x.dgCMascota.SelectedRows[0].Cells["idCmas"].Value.ToString();
                cbMascota.SelectedValue = x.dgCMascota.SelectedRows[0].Cells["idMas"].Value.ToString();
                cbCliente.SelectedValue = x.dgCMascota.SelectedRows[0].Cells["idCli"].Value.ToString();
                dtFecha.Text = x.dgCMascota.SelectedRows[0].Cells["cFecha"].Value.ToString();
                txtConsumible.Text = x.dgCMascota.SelectedRows[0].Cells["consumible"].Value.ToString();
            }
        }

        private void tsLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void tsEliminar_Click(object sender, EventArgs e)
        {
            if (txtId.Text.Trim() == "" || txtId.Text == "0")
            {
                MessageBox.Show("Seleccione un registro para eliminar");
                return;
            }

            if (MessageBox.Show("¿Está seguro de eliminar?", "Confirmar",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    ACUA_CAPA_NEG.CLASES.CMascota x = new ACUA_CAPA_NEG.CLASES.CMascota();
                    x.idCmas = int.Parse(txtId.Text);
                    x.idMas = Convert.ToInt32(cbMascota.SelectedValue);
                    x.idCli = Convert.ToInt32(cbCliente.SelectedValue);
                    x.consumible = int.Parse(txtConsumible.Text);
                    x.cFecha = dtFecha.Value.ToString("yyyy/MM/dd");

                    MessageBox.Show(x.Eliminar());
                    Limpiar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar: " + ex.Message);
                }
            }
        }
    }
}
