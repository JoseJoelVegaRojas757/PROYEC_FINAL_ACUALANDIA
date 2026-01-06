using ACUA_CAPA_NEG.CLASES;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ACUA_USUARIO.FORMS
{
    public partial class FrmCategoria : Form
    {
        Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        SqlCommand comando = new SqlCommand();
        public FrmCategoria()
        {
            InitializeComponent();
            con.ConnectionString = x.ConexionSql;
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void FrmCategoria_Load(object sender, System.EventArgs e)
        {
            Limpiar();
        }

        void Limpiar()
        {
            txtId.Clear();
            txtNombre.Clear();
            ACUA_CAPA_NEG.CLASES.Herramientas h = new ACUA_CAPA_NEG.CLASES.Herramientas();
            txtId.Text = h.consecutivo("idCat", "CATEGORIA").ToString();
            txtNombre.Focus();
        }

        bool encontro()
        {
            bool a = false;
            int id = int.Parse(txtId.Text);
            string cadena = $"Select * From CATEGORIA where idCat = {id}";
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

        private void tsGuardar_Click(object sender, System.EventArgs e)
        {
            Categoria x = new Categoria();
            x.Id = int.Parse(txtId.Text);
            x.Nombre = txtNombre.Text;
            if (encontro() == true)
            {
                MessageBox.Show(x.Actualizar());
            }
            else
            {
                MessageBox.Show(x.Guardar());
            }
        }

        private void tsLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void tsBuscar_Click(object sender, EventArgs e)
        {
            SEARCH.FrmBusquedaCategoria x = new SEARCH.FrmBusquedaCategoria();
            x.ShowDialog();
            if (x.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                txtId.Text = x.dgCategoria.SelectedRows[0].Cells["idCat"].Value.ToString();
                txtNombre.Text = x.dgCategoria.SelectedRows[0].Cells["nomCat"].Value.ToString();
            }
        }

        private void tsEliminar_Click(object sender, EventArgs e)
        {
            Categoria x = new Categoria();
            x.Id = int.Parse(txtId.Text);
            x.Nombre = txtNombre.Text;
            MessageBox.Show(x.Eliminar());
            Limpiar();
        }
    }
}