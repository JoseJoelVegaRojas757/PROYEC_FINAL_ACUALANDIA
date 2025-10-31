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
            int id = int.Parse(txtId.Text);
            string cadena = $"Select * From DOMICILIO where idDom = {id}";
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
            Domicilio x = new Domicilio();
            x.idDom = int.Parse(txtId.Text);
            x.idCol = Convert.ToInt32(cbColonia.SelectedValue);
            x.calle = txtCalle.Text;
            x.calle1 = txtCalle1.Text;
            x.calle2 = txtCalle2.Text;
            x.numEx = int.Parse(txtNumE.Text);
            x.numInt = int.Parse(txtNumIn.Text);
            x.referencias = txtReferencia.Text;

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
            SEARCH.FrmBusquedaDomicilio x = new SEARCH.FrmBusquedaDomicilio();
            x.ShowDialog();
            if (x.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                txtId.Text = x.dgDomicilio.SelectedRows[0].Cells["idDom"].Value.ToString();
                cbColonia.Text = x.dgDomicilio.SelectedRows[0].Cells["idCol"].Value.ToString();
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
            ACUA_CAPA_NEG.CLASES.Domicilio x = new ACUA_CAPA_NEG.CLASES.Domicilio();
            x.idDom = int.Parse(txtId.Text);
            x.idCol = Convert.ToInt32(cbColonia.SelectedValue);
            x.calle = txtCalle.Text;
            x.calle1 = txtCalle1.Text;
            x.calle2 = txtCalle2.Text;
            x.numEx = int.Parse(txtNumE.Text);
            x.numInt = int.Parse(txtNumIn.Text);
            x.referencias = txtReferencia.Text;
            MessageBox.Show(x.Eliminar());
            Limpiar();
        }
    }
}
