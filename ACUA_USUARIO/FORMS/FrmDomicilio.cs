using ACUA_CAPA_NEG.CLASES;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ACUA_USUARIO.FORMS
{
    public partial class FrmDomicilio : Form
    {
        Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        SqlCommand comando = new SqlCommand();
        public FrmDomicilio()
        {
            InitializeComponent();
            con.ConnectionString = x.ConexionSql;
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmDomicilio_Load(object sender, EventArgs e)
        {
            CargarColonia();
            Limpiar();
        }

        void CargarColonia()
        {
            DataTable dt = new DataTable();
            string consulta = "SELECT * FROM COLONIA";
            SqlDataAdapter da = new SqlDataAdapter(consulta, con);
            con.Open();
            da.Fill(dt);
            con.Close();
            cbColonia.DisplayMember = "nombre";
            cbColonia.ValueMember = "idCol";
            cbColonia.DataSource = dt;
        }

        void Limpiar()
        {
            txtId.Clear();
            txtCalle.Clear();
            txtCalle1.Clear();
            txtCalle2.Clear();
            txtNumE.Clear();
            txtNumIn.Clear();
            txtReferencia.Clear();
            ACUA_CAPA_NEG.CLASES.Herramientas h = new ACUA_CAPA_NEG.CLASES.Herramientas();
            txtId.Text = h.consecutivo("idDom", "DOMICILIO").ToString();
            txtId.Focus();
            txtCalle.Focus();
            txtCalle1.Focus();
            txtCalle2.Focus();
            txtNumE.Focus();
            txtNumIn.Focus();
            txtReferencia.Focus();
        }

        bool encontro()
        {

            bool a = false;
            if (txtId.Text.Trim() == "" || txtId.Text == "0")
                return false;

            try
            {
                int id = int.Parse(txtId.Text);
                string cadena = $"Select * From DOMICILIO where idDom = {id}";
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
            if (cbColonia.SelectedValue == null)
            {
                MessageBox.Show("Seleccione una colonia");
                cbColonia.Focus();
                return;
            }

            if (txtCalle.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese la calle principal");
                txtCalle.Focus();
                return;
            }

            if (txtNumE.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el número exterior");
                txtNumE.Focus();
                return;
            }

            int numExterior;
            if (!int.TryParse(txtNumE.Text, out numExterior))
            {
                MessageBox.Show("Número exterior debe ser un número");
                txtNumE.Focus();
                return;
            }

            if (numExterior <= 0)
            {
                MessageBox.Show("Número exterior debe ser mayor que cero");
                txtNumE.Focus();
                return;
            }

            try
            {
                Domicilio x = new Domicilio();
                x.idDom = int.Parse(txtId.Text);
                x.idCol = Convert.ToInt32(cbColonia.SelectedValue);
                x.calle = txtCalle.Text;
                x.calle1 = txtCalle1.Text;
                x.calle2 = txtCalle2.Text;
                x.numEx = int.Parse(txtNumE.Text);

                if (!string.IsNullOrWhiteSpace(txtNumIn.Text))
                    x.numInt = int.Parse(txtNumIn.Text);

                x.referencias = txtReferencia.Text;

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
            SEARCH.FrmBusquedaDomicilio x = new SEARCH.FrmBusquedaDomicilio();
            x.ShowDialog();
            if (x.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                txtId.Text = x.dgDomicilio.SelectedRows[0].Cells["idDom"].Value.ToString();
                cbColonia.SelectedValue = x.dgDomicilio.SelectedRows[0].Cells["idCol"].Value.ToString();
                txtCalle.Text = x.dgDomicilio.SelectedRows[0].Cells["calle"].Value.ToString();
                txtCalle1.Text = x.dgDomicilio.SelectedRows[0].Cells["calle1"].Value.ToString();
                txtCalle2.Text = x.dgDomicilio.SelectedRows[0].Cells["calle2"].Value.ToString();
                txtNumE.Text = x.dgDomicilio.SelectedRows[0].Cells["numExterior"].Value.ToString();
                txtNumIn.Text = x.dgDomicilio.SelectedRows[0].Cells["numInterior"].Value.ToString();
                txtReferencia.Text = x.dgDomicilio.SelectedRows[0].Cells["referencias"].Value.ToString();
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
                MessageBox.Show("Seleccione un domicilio para eliminar");
                return;
            }

            if (MessageBox.Show("¿Está seguro de eliminar este domicilio?", "Confirmar",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    ACUA_CAPA_NEG.CLASES.Domicilio x = new ACUA_CAPA_NEG.CLASES.Domicilio();
                    x.idDom = int.Parse(txtId.Text);
                    x.idCol = Convert.ToInt32(cbColonia.SelectedValue);
                    x.calle = txtCalle.Text;
                    x.calle1 = txtCalle1.Text;
                    x.calle2 = txtCalle2.Text;
                    x.numEx = int.Parse(txtNumE.Text);

                    if (!string.IsNullOrWhiteSpace(txtNumIn.Text))
                        x.numInt = int.Parse(txtNumIn.Text);

                    x.referencias = txtReferencia.Text;

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
