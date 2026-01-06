using ACUA_CAPA_NEG.CLASES;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ACUA_USUARIO.FORMS
{
    public partial class FrmProveedor : Form
    {
        Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        SqlCommand comando = new SqlCommand();
        public FrmProveedor()
        {
            InitializeComponent();
            con.ConnectionString = x.ConexionSql;
        }

        void Limpiar()
        {
            txtId.Clear();
            txtNombre.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            ACUA_CAPA_NEG.CLASES.Herramientas h = new ACUA_CAPA_NEG.CLASES.Herramientas();
            txtId.Text = h.consecutivo("idProv", "PROVEEDOR").ToString();
            txtNombre.Focus();
            txtTelefono.Focus();
            txtCorreo.Focus();
        }

        bool encontro()
        {
            bool a = false;
            int id = int.Parse(txtId.Text);
            string cadena = $"Select * From PROVEEDOR where idProv = {id}";
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
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Ingrese el nombre del proveedor");
                txtNombre.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                MessageBox.Show("Ingrese el teléfono");
                txtTelefono.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                MessageBox.Show("Ingrese el correo electrónico");
                txtCorreo.Focus();
                return;
            }

            if (!txtCorreo.Text.Contains("@") || !txtCorreo.Text.Contains("."))
            {
                MessageBox.Show("Ingrese un correo electrónico válido");
                txtCorreo.Focus();
                return;
            }

            string accion = encontro() ? "actualizar" : "guardar";
            if (MessageBox.Show($"¿Está seguro de {accion} este proveedor?", "Confirmar",
                MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            try
            {
                Proveedor x = new Proveedor();
                x.idProv = int.Parse(txtId.Text);
                x.nomProveedor = txtNombre.Text.Trim();
                x.telOficina = txtTelefono.Text.Trim();
                x.correo = txtCorreo.Text.Trim();

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
            SEARCH.FrmBusquedaProveedor x = new SEARCH.FrmBusquedaProveedor();
            x.ShowDialog();
            if (x.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                txtId.Text = x.dgProveedor.SelectedRows[0].Cells["idProv"].Value.ToString();
                txtNombre.Text = x.dgProveedor.SelectedRows[0].Cells["nomProveedor"].Value.ToString();
                txtTelefono.Text = x.dgProveedor.SelectedRows[0].Cells["telOficina"].Value.ToString();
                txtCorreo.Text = x.dgProveedor.SelectedRows[0].Cells["correo"].Value.ToString();
            }
        }

        private void tsLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text) || txtId.Text == "0")
            {
                MessageBox.Show("Seleccione un proveedor para eliminar");
                return;
            }

            if (MessageBox.Show("¿Está seguro de eliminar este proveedor?", "Confirmar",
                MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            try
            {
                Proveedor x = new Proveedor();
                x.idProv = int.Parse(txtId.Text);
                x.nomProveedor = txtNombre.Text.Trim();
                x.telOficina = txtTelefono.Text.Trim();
                x.correo = txtCorreo.Text.Trim();

                MessageBox.Show(x.Eliminar());
                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message);
            }
        }

        private void FrmProveedor_Load(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '+' && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        private void txtCorreo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                if (!txtCorreo.Text.Contains("@") || !txtCorreo.Text.Contains("."))
                {
                    MessageBox.Show("Ingrese un correo electrónico válido");
                    txtCorreo.Focus();
                    e.Cancel = true; // Esto evita que salga del TextBox hasta que sea válido
                }
            }
        }
    }
}
