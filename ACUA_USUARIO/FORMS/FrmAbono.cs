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
            try
            {
                DataTable dt = new DataTable();
                string consulta = "SELECT * FROM APARTADO";
                SqlDataAdapter da = new SqlDataAdapter(consulta, con);
                con.Open();
                da.Fill(dt);
                con.Close();
                cbApartado.DisplayMember = "anticipo";
                cbApartado.ValueMember = "idApartado";
                cbApartado.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar apartados: " + ex.Message);
            }
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

            if (txtId.Text.Trim() == "" || txtId.Text == "0")
                return false;

            try
            {
                int id = int.Parse(txtId.Text);
                string cadena = $"Select * From ABONO where idAbono = {id}";
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


        private void tsGuardar_Click(object sender, EventArgs e)
        {
            if (cbApartado.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un apartado");
                cbApartado.Focus();
                return;
            }

            if (txtMonto.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el monto del abono");
                txtMonto.Focus();
                return;
            }

            decimal monto;
            if (!decimal.TryParse(txtMonto.Text, out monto))
            {
                MessageBox.Show("El monto debe ser un número válido");
                txtMonto.Focus();
                return;
            }

            if (monto <= 0)
            {
                MessageBox.Show("El monto debe ser mayor que cero");
                txtMonto.Focus();
                return;
            }

            try
            {
                Abono x = new Abono();
                x.idAbono = int.Parse(txtId.Text);
                x.idApartado = Convert.ToInt32(cbApartado.SelectedValue);
                x.Monto = txtMonto.Text;

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

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmAbono_Load(object sender, EventArgs e)
        {
            CargarApartado();
            Limpiar();
        }

        private void tsLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void tsBuscar_Click(object sender, EventArgs e)
        {
            SEARCH.FrmBusquedaAbono x = new SEARCH.FrmBusquedaAbono();
            x.ShowDialog();

            if (x.DialogResult == DialogResult.OK && x.dgAbono.SelectedRows.Count > 0)
            {
                try
                {
                    txtId.Text = x.dgAbono.SelectedRows[0].Cells["idAbono"].Value?.ToString() ?? "";

                    if (x.dgAbono.SelectedRows[0].Cells["idApartado"].Value != null)
                        cbApartado.SelectedValue = Convert.ToInt32(x.dgAbono.SelectedRows[0].Cells["idApartado"].Value);

                    txtMonto.Text = x.dgAbono.SelectedRows[0].Cells["monto"].Value?.ToString() ?? "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar datos: " + ex.Message);
                }
            }
        }

        private void tsEliminar_Click(object sender, EventArgs e)
        {
            if (txtId.Text.Trim() == "" || txtId.Text == "0")
            {
                MessageBox.Show("Seleccione un abono para eliminar");
                return;
            }

            if (MessageBox.Show("¿Está seguro de eliminar este abono?", "Confirmar",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    ACUA_CAPA_NEG.CLASES.Abono x = new ACUA_CAPA_NEG.CLASES.Abono();
                    x.idAbono = int.Parse(txtId.Text);
                    x.idApartado = Convert.ToInt32(cbApartado.SelectedValue);
                    x.Monto = txtMonto.Text;

                    MessageBox.Show(x.Eliminar());
                    Limpiar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar: " + ex.Message);
                }
            }
        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && txtMonto.Text.Contains("."))
            {
                e.Handled = true;
            }
        }
    }
}
