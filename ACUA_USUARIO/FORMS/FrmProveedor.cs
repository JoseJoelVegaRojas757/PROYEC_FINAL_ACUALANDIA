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
            Proveedor x = new Proveedor();
            x.idProv = int.Parse(txtId.Text);
            x.nomProveedor = txtNombre.Text;
            x.telOficina = txtTelefono.Text;
            x.correo = txtCorreo.Text;
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
            Proveedor x = new Proveedor();
            x.idProv = int.Parse(txtId.Text);
            x.nomProveedor = txtNombre.Text;
            x.telOficina = txtTelefono.Text;
            x.correo = txtCorreo.Text;
            MessageBox.Show(x.Eliminar());
            Limpiar();
        }

        private void FrmProveedor_Load(object sender, EventArgs e)
        {

        }
    }
}
