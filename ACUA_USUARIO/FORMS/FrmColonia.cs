using ACUA_CAPA_NEG.CLASES;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ACUA_USUARIO.FORMS
{
    public partial class FrmColonia : Form
    {
        Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        SqlCommand comando = new SqlCommand();
        public FrmColonia()
        {
            InitializeComponent();
            con.ConnectionString = x.ConexionSql;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmColonia_Load(object sender, EventArgs e)
        {
            CargarMunicipio();
        }

        void CargarMunicipio()
        {
            DataTable dt = new DataTable();
            string consulta = "SELECT * FROM MUNICIPIO";
            SqlDataAdapter da = new SqlDataAdapter(consulta, con);
            con.Open();
            da.Fill(dt);
            con.Close();
            cbMunicipio.DisplayMember = "nombre";
            cbMunicipio.ValueMember = "idMun";
            cbMunicipio.DataSource = dt;
        }
        void Limpiar()
        {
            txtId.Clear();
            txtNombre.Clear();
            txtCodigoP.Clear();
            ACUA_CAPA_NEG.CLASES.Herramientas h = new ACUA_CAPA_NEG.CLASES.Herramientas();
            txtId.Text = h.consecutivo("idCol", "COLONIA").ToString();
            txtNombre.Focus();
            txtCodigoP.Focus();
        }

        bool encontro()
        {
            bool a = false;
            int id = int.Parse(txtId.Text);
            string cadena = $"Select * From COLONIA where idCol = {id}";
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
            Colonia x = new Colonia();
            x.idCol = int.Parse(txtId.Text);
            x.idMun = Convert.ToInt32(cbMunicipio.SelectedValue);
            x.nombre = txtNombre.Text;
            x.cPostal = int.Parse(txtCodigoP.Text);
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
            SEARCH.FrmBusquedaColonia x = new SEARCH.FrmBusquedaColonia();
            x.ShowDialog();
            if (x.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                txtId.Text = x.dgColonia.SelectedRows[0].Cells["idCol"].Value.ToString();
                cbMunicipio.Text = x.dgColonia.SelectedRows[0].Cells["idMun"].Value.ToString();
                txtNombre.Text = x.dgColonia.SelectedRows[0].Cells["nombre"].Value.ToString();
                txtCodigoP.Text = x.dgColonia.SelectedRows[0].Cells["cPostal"].Value.ToString();
            }
        }

        private void tsLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void tsEliminar_Click(object sender, EventArgs e)
        {
            Colonia x = new Colonia();
            x.idCol = int.Parse(txtId.Text);
            x.idMun = Convert.ToInt32(cbMunicipio.SelectedValue);
            x.nombre = txtNombre.Text;
            x.cPostal = int.Parse(txtCodigoP.Text);
            MessageBox.Show(x.Eliminar());
            Limpiar();
        }
    }
}
