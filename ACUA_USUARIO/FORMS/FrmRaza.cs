using ACUA_CAPA_NEG.CLASES;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ACUA_USUARIO.FORMS
{
    public partial class FrmRaza : Form
    {
        Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        SqlCommand comando = new SqlCommand();
        public FrmRaza()
        {
            InitializeComponent();
            con.ConnectionString = x.ConexionSql;
        }
        void CargarTipo()
        {
            DataTable dt = new DataTable();
            string consulta = "SELECT * FROM TIPO";
            SqlDataAdapter da = new SqlDataAdapter(consulta, con);
            con.Open();
            da.Fill(dt);
            con.Close();
            cbTipo.DisplayMember = "nomTipo";
            cbTipo.ValueMember = "idTipo";
            cbTipo.DataSource = dt;
        }
        void Limpiar()
        {
            txtId.Clear();
            txtNombre.Clear();
            ACUA_CAPA_NEG.CLASES.Herramientas h = new ACUA_CAPA_NEG.CLASES.Herramientas();
            txtId.Text = h.consecutivo("idRaza", "RAZA").ToString();
            txtNombre.Focus();
        }
        bool encontro()
        {
            bool a = false;
            int id = int.Parse(txtId.Text);
            string cadena = $"Select * From RAZA where idRaza = {id}";
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

        private void tsClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsGuardar_Click(object sender, EventArgs e)
        {
            Raza x = new Raza();
            x.idRaza = int.Parse(txtId.Text);
            x.idTipo = Convert.ToInt32(cbTipo.SelectedValue);
            x.nomRaza = txtNombre.Text;
            if (encontro() == true)
            {
                MessageBox.Show(x.Actualizar());
            }
            else
            {
                MessageBox.Show(x.Guardar());
            }
        }

        private void FrmRaza_Load(object sender, EventArgs e)
        {
            CargarTipo();
            Limpiar();
        }

        private void tsLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void tsBuscar_Click(object sender, EventArgs e)
        {
            SEARCH.FrmBusquedaRaza x = new SEARCH.FrmBusquedaRaza();
            x.ShowDialog();
            if (x.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                txtId.Text = x.dgRaza.SelectedRows[0].Cells["idRaza"].Value.ToString();
                cbTipo.SelectedValue = x.dgRaza.SelectedRows[0].Cells["idTipo"].Value.ToString();
                txtNombre.Text = x.dgRaza.SelectedRows[0].Cells["nomRaza"].Value.ToString();
            }
        }

        private void tsEliminar_Click(object sender, EventArgs e)
        {
            ACUA_CAPA_NEG.CLASES.Raza x = new ACUA_CAPA_NEG.CLASES.Raza();
            x.idRaza = int.Parse(txtId.Text);
            x.idTipo = Convert.ToInt32(cbTipo.SelectedValue);
            x.nomRaza = txtNombre.Text;
            MessageBox.Show(x.Eliminar());
            Limpiar();
        }
    }
}
