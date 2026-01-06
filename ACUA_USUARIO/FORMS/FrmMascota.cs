using ACUA_CAPA_NEG.CLASES;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ACUA_USUARIO.FORMS
{

    public partial class FrmMascota : Form
    {
        Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        SqlCommand comando = new SqlCommand();
        public FrmMascota()
        {
            InitializeComponent();
            con.ConnectionString = x.ConexionSql;
        }

        void CargarRaza()
        {
            DataTable dt = new DataTable();
            string consulta = "SELECT * FROM RAZA";
            SqlDataAdapter da = new SqlDataAdapter(consulta, con);
            con.Open();
            da.Fill(dt);
            con.Close();
            cbRaza.DisplayMember = "nomRaza";
            cbRaza.ValueMember = "idRaza";
            cbRaza.DataSource = dt;
        }

        void Limpiar()
        {
            txtId.Clear();
            txtCaracteristicas.Clear();

            ACUA_CAPA_NEG.CLASES.Herramientas h = new ACUA_CAPA_NEG.CLASES.Herramientas();
            txtId.Text = h.consecutivo("idMas", "MASCOTA").ToString();
            txtCaracteristicas.Focus();
        }
        bool encontro()
        {
            bool a = false;
            int id = int.Parse(txtId.Text);
            string cadena = $"Select * From MASCOTA where idMas = {id}";
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
            if (cbRaza.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione una raza");
                cbRaza.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCaracteristicas.Text))
            {
                MessageBox.Show("Ingrese las características");
                txtCaracteristicas.Focus();
                return;
            }

            if (txtCaracteristicas.Text.Trim().Length < 3)
            {
                MessageBox.Show("Las características deben tener al menos 3 caracteres");
                txtCaracteristicas.Focus();
                return;
            }

            string accion = encontro() ? "actualizar" : "guardar";
            if (MessageBox.Show($"¿Está seguro de {accion} esta mascota?", "Confirmar",
                MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            try
            {
                Mascota x = new Mascota();
                x.idMas = int.Parse(txtId.Text);
                x.caracteristicas = txtCaracteristicas.Text.Trim();
                x.idRaza = Convert.ToInt32(cbRaza.SelectedValue);

                string resultado;
                if (encontro())
                {
                    resultado = x.Actualizar();
                }
                else
                {
                    resultado = x.Guardar();
                }

                MessageBox.Show(resultado);
                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmMascota_Load(object sender, EventArgs e)
        {
            CargarRaza();
            Limpiar();
            Limpiar();
        }

        private void tsEliminar_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(txtId.Text) || txtId.Text == "0")
            {
                MessageBox.Show("Seleccione una mascota para eliminar");
                return;
            }

            if (MessageBox.Show("¿Está seguro de eliminar esta mascota?", "Confirmar",
                MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            try
            {
                ACUA_CAPA_NEG.CLASES.Mascota x = new ACUA_CAPA_NEG.CLASES.Mascota();
                x.idMas = int.Parse(txtId.Text);
                x.caracteristicas = txtCaracteristicas.Text.Trim();
                x.idRaza = Convert.ToInt32(cbRaza.SelectedValue);

                MessageBox.Show(x.Eliminar());
                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message);
            }
        }

        private void tsBuscar_Click(object sender, EventArgs e)
        {
            SEARCH.FrmBusquedaMascota x = new SEARCH.FrmBusquedaMascota();
            x.ShowDialog();
            if (x.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                txtId.Text = x.dgMascota.SelectedRows[0].Cells["idMas"].Value.ToString();
                txtCaracteristicas.Text = x.dgMascota.SelectedRows[0].Cells["Caracteristicas"].Value.ToString();
                cbRaza.SelectedValue = x.dgMascota.SelectedRows[0].Cells["idRaza"].Value.ToString();
            }
        }

        private void tsLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnRaza_Click(object sender, EventArgs e)
        {
            FORMS.FrmRaza w = new FORMS.FrmRaza();
            w.ShowDialog();
        }
    }
}
