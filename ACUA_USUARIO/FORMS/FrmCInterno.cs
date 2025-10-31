using ACUA_CAPA_NEG.CLASES;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ACUA_USUARIO.FORMS
{
    public partial class FrmCInterno : Form
    {
        Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        SqlCommand comando = new SqlCommand();
        public FrmCInterno()
        {
            InitializeComponent();
            con.ConnectionString = x.ConexionSql;
        }

        private void FrmCInterno_Load(object sender, EventArgs e)
        {

        }

        void Limpiar()
        {
            txtId.Clear();
            txtFecha.Clear();
            txtTipo.Clear();
            ACUA_CAPA_NEG.CLASES.Herramientas h = new ACUA_CAPA_NEG.CLASES.Herramientas();
            txtId.Text = h.consecutivo("idInterno", "CINTERNO").ToString();
            txtFecha.Focus();
            txtTipo.Clear();
        }

        bool encontro()
        {
            bool a = false;
            int id = int.Parse(txtId.Text);
            string cadena = $"Select * From CINTERNO where idInterno = {id}";
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
            CInterno x = new CInterno();
            x.idInterno = int.Parse(txtId.Text);
            x.fecha = txtFecha.Text;
            x.tipo = txtTipo.Text;
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
            SEARCH.FrmBusquedaCInterno x = new SEARCH.FrmBusquedaCInterno();
            x.ShowDialog();
            if (x.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                txtId.Text = x.dgCInterno.SelectedRows[0].Cells["idInterno"].Value.ToString();
                txtFecha.Text = x.dgCInterno.SelectedRows[0].Cells["fecha"].Value.ToString();
                txtTipo.Text = x.dgCInterno.SelectedRows[0].Cells["tipo"].Value.ToString();
            }
        }

        private void tsEliminar_Click(object sender, EventArgs e)
        {
            CInterno x = new CInterno();
            x.idInterno = int.Parse(txtId.Text);
            x.fecha = txtFecha.Text;
            x.tipo = txtTipo.Text;
            MessageBox.Show(x.Eliminar());
            Limpiar();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
