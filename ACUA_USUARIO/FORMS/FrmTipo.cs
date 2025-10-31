using ACUA_CAPA_NEG.CLASES;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ACUA_USUARIO.FORMS
{
    public partial class FrmTipo : Form
    {
        Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        SqlCommand comando = new SqlCommand();
        public FrmTipo()
        {
            InitializeComponent();
            con.ConnectionString = x.ConexionSql;
        }
        void Limpiar()
        {
            txtId.Clear();
            txtNombre.Clear();
            ACUA_CAPA_NEG.CLASES.Herramientas h = new ACUA_CAPA_NEG.CLASES.Herramientas();
            txtId.Text = h.consecutivo("idTipo", "TIPO").ToString();
            txtNombre.Focus();
        }
        bool encontro()
        {
            bool a = false;
            int id = int.Parse(txtId.Text);
            string cadena = $"Select * From TIPO where idTipo = {id}";
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
            Tipo x = new Tipo();
            x.idTipo = int.Parse(txtId.Text);
            x.nomTipo = txtNombre.Text;
            if (encontro() == true)
            {
                MessageBox.Show(x.Actualizar());
            }
            else
            {
                MessageBox.Show(x.Guardar());
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            SEARCH.FrmBusquedaTipo x = new SEARCH.FrmBusquedaTipo();
            x.ShowDialog();
            if (x.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                txtId.Text = x.dgTipo.SelectedRows[0].Cells["idTipo"].Value.ToString();
                txtNombre.Text = x.dgTipo.SelectedRows[0].Cells["nomTipo"].Value.ToString();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmTipo_Load(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void tsEliminar_Click(object sender, EventArgs e)
        {
            ACUA_CAPA_NEG.CLASES.Tipo x = new ACUA_CAPA_NEG.CLASES.Tipo();
            x.idTipo = int.Parse(txtId.Text);
            x.nomTipo = txtNombre.Text;
            MessageBox.Show(x.Eliminar());
            Limpiar();
        }

        private void tsLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();

        }
    }
}
