using ACUA_CAPA_NEG.CLASES;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ACUA_USUARIO.FORMS
{
    public partial class FrmMunicipio : Form
    {
        Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        SqlCommand comando = new SqlCommand();
        public FrmMunicipio()
        {
            InitializeComponent();
            con.ConnectionString = x.ConexionSql;
        }

        void Limpiar()
        {
            txtId.Clear();
            txtNombre.Clear();
            ACUA_CAPA_NEG.CLASES.Herramientas h = new ACUA_CAPA_NEG.CLASES.Herramientas();
            txtId.Text = h.consecutivo("idMun", "MUNICIPIO").ToString();
            txtNombre.Focus();
        }
        bool encontro()
        {
            bool a = false;
            int id = int.Parse(txtId.Text);
            string cadena = $"Select * From MUNICIPIO where idMun = {id}";
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
            Municipio x = new Municipio();
            x.idMun = int.Parse(txtId.Text);
            x.nombre = txtNombre.Text;
            if (encontro() == true)
            {
                MessageBox.Show(x.Actualizar());
            }
            else
            {
                MessageBox.Show(x.Guardar());
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void FrmMunicipio_Load(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void tsEliminar_Click(object sender, EventArgs e)
        {
            ACUA_CAPA_NEG.CLASES.Municipio x = new ACUA_CAPA_NEG.CLASES.Municipio();
            x.idMun = int.Parse(txtId.Text);
            x.nombre = txtNombre.Text;
            MessageBox.Show(x.Eliminar());
            Limpiar();
        }

        private void tsBuscar_Click(object sender, EventArgs e)
        {
            SEARCH.FrmBusquedaMunicipio x = new SEARCH.FrmBusquedaMunicipio();
            x.ShowDialog();
            if (x.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                txtId.Text = x.dgMunicipio.SelectedRows[0].Cells["idMun"].Value.ToString();
                txtNombre.Text = x.dgMunicipio.SelectedRows[0].Cells["nombre"].Value.ToString();

            }
        }
    }
}
