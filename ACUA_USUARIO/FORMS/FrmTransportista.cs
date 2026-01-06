using ACUA_CAPA_NEG.CLASES;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ACUA_USUARIO.FORMS
{
    public partial class FrmTransportista : Form
    {
        Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        SqlCommand comando = new SqlCommand();
        public FrmTransportista()
        {
            InitializeComponent();
            con.ConnectionString = x.ConexionSql;
        }

        void CargarPaqueteria()
        {
            DataTable dt = new DataTable();
            string consulta = "SELECT * FROM PAQUETERIA";
            SqlDataAdapter da = new SqlDataAdapter(consulta, con);
            con.Open();
            da.Fill(dt);
            con.Close();
            cbPaqueteria.DisplayMember = "nombre";
            cbPaqueteria.ValueMember = "idPaq";
            cbPaqueteria.DataSource = dt;
        }

        void Limpiar()
        {
            txtId.Clear();
            txtNombre.Clear();
            txtTelefono.Clear();
            ACUA_CAPA_NEG.CLASES.Herramientas h = new ACUA_CAPA_NEG.CLASES.Herramientas();
            txtId.Text = h.consecutivo("idTrans", "TRANSPORTISTA").ToString();
            txtNombre.Focus();
            txtTelefono.Focus();
        }

        bool encontro()
        {
            bool a = false;
            int id = int.Parse(txtId.Text);
            string cadena = $"SELECT * FROM TRANSPORTISTA WHERE idTrans = {id}";
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
            if (cbPaqueteria.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione una paquetería");
                cbPaqueteria.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Ingrese el nombre del transportista");
                txtNombre.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                MessageBox.Show("Ingrese el teléfono");
                txtTelefono.Focus();
                return;
            }

            if (txtTelefono.Text.Length < 8)
            {
                MessageBox.Show("El teléfono debe tener al menos 8 dígitos");
                txtTelefono.Focus();
                return;
            }

            string accion = encontro() ? "actualizar" : "guardar";
            if (MessageBox.Show($"¿Está seguro de {accion} este transportista?", "Confirmar",
                MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            try
            {
                Transportista x = new Transportista();
                x.idTrans = int.Parse(txtId.Text);
                x.idPaq = Convert.ToInt32(cbPaqueteria.SelectedValue);
                x.nombre = txtNombre.Text.Trim();
                x.telefono = txtTelefono.Text.Trim();

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

        private void tsBuscar_Click(object sender, EventArgs e)
        {
            SEARCH.FrmBusquedaTransportista x = new SEARCH.FrmBusquedaTransportista();
            x.ShowDialog();
            if (x.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                txtId.Text = x.dgTransportista.SelectedRows[0].Cells["idTrans"].Value.ToString();
                cbPaqueteria.SelectedValue = x.dgTransportista.SelectedRows[0].Cells["idPaq"].Value.ToString();
                txtNombre.Text = x.dgTransportista.SelectedRows[0].Cells["nombre"].Value.ToString();
                txtTelefono.Text = x.dgTransportista.SelectedRows[0].Cells["telefono"].Value.ToString();
            }
        }

        private void tsLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void tsEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text) || txtId.Text == "0")
            {
                MessageBox.Show("Seleccione un transportista para eliminar");
                return;
            }

            if (MessageBox.Show("¿Está seguro de eliminar este transportista?", "Confirmar",
                MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            try
            {
                Transportista x = new Transportista();
                x.idTrans = int.Parse(txtId.Text);
                x.idPaq = Convert.ToInt32(cbPaqueteria.SelectedValue);
                x.nombre = txtNombre.Text.Trim();
                x.telefono = txtTelefono.Text.Trim();

                MessageBox.Show(x.Eliminar());
                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmTransportista_Load(object sender, EventArgs e)
        {
            CargarPaqueteria();
            Limpiar();
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '+')
            {
                e.Handled = true;
            }
        }

        private void txtNombre_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtNombre.Text.Length >= 100 && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
    }
}
