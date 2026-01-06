using ACUA_CAPA_NEG.CLASES;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ACUA_USUARIO.FORMS
{
    public partial class FrmApartado : Form
    {
        Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        SqlCommand comando = new SqlCommand();


        public FrmApartado()
        {
            InitializeComponent();
            con.ConnectionString = x.ConexionSql;
        }

        void CargarTrabajador()
        {
            try
            {
                DataTable dt = new DataTable();
                string consulta = "SELECT * FROM TRABAJADOR";
                SqlDataAdapter da = new SqlDataAdapter(consulta, con);
                con.Open();
                da.Fill(dt);
                con.Close();
                cbTrabajador.DisplayMember = "traNombre";
                cbTrabajador.ValueMember = "idTra";
                cbTrabajador.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar trabajadores: " + ex.Message);
            }
        }

        void CargarCliente()
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message);
            }
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

            if (txtId.Text.Trim() == "" || txtId.Text == "0")
                return false;

            try
            {
                int id = int.Parse(txtId.Text);
                string cadena = $"Select * From APARTADO where idApartado = {id}";
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
            if (cbTrabajador.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un trabajador");
                cbTrabajador.Focus();
                return;
            }

            if (cbCliente.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un cliente");
                cbCliente.Focus();
                return;
            }

            if (txtAnticipo.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el anticipo");
                txtAnticipo.Focus();
                return;
            }

            if (txtFaltante.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el faltante");
                txtFaltante.Focus();
                return;
            }

            if (txtTotal.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el total");
                txtTotal.Focus();
                return;
            }

            decimal anticipo, faltante, total;
            if (!decimal.TryParse(txtAnticipo.Text, out anticipo))
            {
                MessageBox.Show("Anticipo debe ser un número válido");
                txtAnticipo.Focus();
                return;
            }

            if (!decimal.TryParse(txtFaltante.Text, out faltante))
            {
                MessageBox.Show("Faltante debe ser un número válido");
                txtFaltante.Focus();
                return;
            }

            if (!decimal.TryParse(txtTotal.Text, out total))
            {
                MessageBox.Show("Total debe ser un número válido");
                txtTotal.Focus();
                return;
            }

            if (anticipo <= 0)
            {
                MessageBox.Show("El anticipo debe ser mayor que cero");
                txtAnticipo.Focus();
                return;
            }

            if (total <= 0)
            {
                MessageBox.Show("El total debe ser mayor que cero");
                txtTotal.Focus();
                return;
            }

            if (anticipo > total)
            {
                MessageBox.Show("El anticipo no puede ser mayor que el total");
                txtAnticipo.Focus();
                return;
            }

            try
            {
                Apartado x = new Apartado();
                x.idApartado = int.Parse(txtId.Text);
                x.idTrabajador = Convert.ToInt32(cbTrabajador.SelectedValue);
                x.idCliente = Convert.ToInt32(cbCliente.SelectedValue);
                x.fApartado = dtFechaA.Value.ToString("yyyy/MM/dd");
                x.anticipo = int.Parse(txtAnticipo.Text);
                x.faltante = int.Parse(txtFaltante.Text);
                x.total = int.Parse(txtTotal.Text);

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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmApartado_Load(object sender, EventArgs e)
        {
            CargarCliente();
            CargarTrabajador();
            Limpiar();
        }

        private void tsLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void tsEliminar_Click(object sender, EventArgs e)
        {
            if (txtId.Text.Trim() == "" || txtId.Text == "0")
            {
                MessageBox.Show("Seleccione un apartado para eliminar");
                return;
            }

            if (MessageBox.Show("¿Está seguro de eliminar este apartado?", "Confirmar",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    ACUA_CAPA_NEG.CLASES.Apartado x = new ACUA_CAPA_NEG.CLASES.Apartado();
                    x.idApartado = int.Parse(txtId.Text);
                    x.idTrabajador = Convert.ToInt32(cbTrabajador.SelectedValue);
                    x.idCliente = Convert.ToInt32(cbCliente.SelectedValue);
                    x.fApartado = dtFechaA.Value.ToString("yyyy/MM/dd");
                    x.anticipo = int.Parse(txtAnticipo.Text);
                    x.faltante = int.Parse(txtFaltante.Text);
                    x.total = int.Parse(txtTotal.Text);

                    MessageBox.Show(x.Eliminar());
                    Limpiar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar: " + ex.Message);
                }
            }
        }

        private void tsBuscar_Click(object sender, EventArgs e)
        {
            SEARCH.FrmBusquedaApartado x = new SEARCH.FrmBusquedaApartado();
            x.ShowDialog();
            if (x.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                txtId.Text = x.dgApartado.SelectedRows[0].Cells["idApartado"].Value.ToString();
                cbTrabajador.SelectedValue = x.dgApartado.SelectedRows[0].Cells["idTrabajador"].Value.ToString();
                cbCliente.SelectedValue = x.dgApartado.SelectedRows[0].Cells["idCliente"].Value.ToString();
                dtFechaA.Text = x.dgApartado.SelectedRows[0].Cells["fApartado"].Value.ToString();
                txtAnticipo.Text = x.dgApartado.SelectedRows[0].Cells["anticipo"].Value.ToString();
                txtFaltante.Text = x.dgApartado.SelectedRows[0].Cells["faltante"].Value.ToString();
                txtTotal.Text = x.dgApartado.SelectedRows[0].Cells["total"].Value.ToString();
            }
        }

        private void btnMAD_Click(object sender, EventArgs e)
        {
            FrmMADetalle x = new FrmMADetalle();
            x.ShowDialog();

            //FrmGenero x = new FrmGenero();
            //x.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmPADetalle x = new FrmPADetalle();
            x.ShowDialog();
        }

        private void txtAnticipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && ((TextBox)sender).Text.Contains("."))
            {
                e.Handled = true;
            }
        }
    }
}
