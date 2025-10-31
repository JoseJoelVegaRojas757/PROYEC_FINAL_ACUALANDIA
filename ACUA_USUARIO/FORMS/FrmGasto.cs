using ACUA_CAPA_NEG.CLASES;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ACUA_USUARIO.FORMS
{
    public partial class FrmGasto : Form
    {
        Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        SqlCommand comando = new SqlCommand();
        public FrmGasto()
        {
            InitializeComponent();
            con.ConnectionString = x.ConexionSql;
        }
        void Limpiar()
        {
            txtId.Clear();
            txtDesG.Clear();
            txtMonto.Clear();
            ACUA_CAPA_NEG.CLASES.Herramientas h = new ACUA_CAPA_NEG.CLASES.Herramientas();
            txtId.Text = h.consecutivo("id", "GASTO").ToString();
            txtId.Clear();
            txtDesG.Clear();
            txtMonto.Clear();
        }

        bool encontro()
        {
            bool a = false;
            int id = int.Parse(txtId.Text);
            string cadena = $"Select * From GASTO where id = {id}";
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
            Gasto x = new Gasto();
            x.id = int.Parse(txtId.Text);
            x.descripcion = txtDesG.Text;
            x.monto = int.Parse(txtMonto.Text);
            if (encontro() == true)
            {
                MessageBox.Show(x.Actualizar());
            }
            else
            {
                MessageBox.Show(x.Guardar());
            }
        }

        private void tsBuscar_Click(object sender, System.EventArgs e)
        {
            SEARCH.FrmBusquedaGasto x = new SEARCH.FrmBusquedaGasto();
            x.ShowDialog();
            if (x.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                txtId.Text = x.dgGasto.SelectedRows[0].Cells["id"].Value.ToString();
                txtDesG.Text = x.dgGasto.SelectedRows[0].Cells["descripcion"].Value.ToString();
                txtMonto.Text = x.dgGasto.SelectedRows[0].Cells["monto"].Value.ToString();
            }
        }

        private void tsEliminar_Click(object sender, System.EventArgs e)
        {
            ACUA_CAPA_NEG.CLASES.Gasto x = new ACUA_CAPA_NEG.CLASES.Gasto();
            x.id = int.Parse(txtId.Text);
            x.descripcion = txtDesG.Text;
            x.monto = int.Parse(txtMonto.Text);
            MessageBox.Show(x.Eliminar());
            Limpiar();
        }

        private void tsLimpiar_Click(object sender, System.EventArgs e)
        {
            Limpiar();
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
