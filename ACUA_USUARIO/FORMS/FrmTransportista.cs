using ACUA_CAPA_NEG.CLASES;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ACUA_USUARIO.FORMS
{
    public partial class FrmTransportista : Form
    {
        Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        SqlCommand comando = new SqlCommand();
        public FrmTransportista()
        {
            InitializeComponent();
            con.ConnectionString = x.ConexionSql;
        }

        void CargarPaqueteria()
        {
            DataTable dt = new DataTable();
            string consulta = "SELECT * FROM PAQUETERIA";
            SqlDataAdapter da = new SqlDataAdapter(consulta, con);
            con.Open();
            da.Fill(dt);
            con.Close();
            cbPaqueteria.DisplayMember = "nombre";
            cbPaqueteria.ValueMember = "idPaq";
            cbPaqueteria.DataSource = dt;
        }

        void Limpiar()
        {
            txtId.Clear();
            txtNombre.Clear();
            txtTelefono.Clear();
            ACUA_CAPA_NEG.CLASES.Herramientas h = new ACUA_CAPA_NEG.CLASES.Herramientas();
            txtId.Text = h.consecutivo("idTrans", "TRANSPORTISTA").ToString();
            txtNombre.Focus();
            txtTelefono.Focus();
        }

        bool encontro()
        {
            bool a = false;
            int id = int.Parse(txtId.Text);
            string cadena = $"SELECT * FROM TRANSPORTISTA WHERE idTrans = {id}";
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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Transportista x = new Transportista();
            x.idTrans = int.Parse(txtId.Text);
            x.idPaq = Convert.ToInt32(cbPaqueteria.Text);
            x.nombre = txtNombre.Text;
            x.telefono = txtTelefono.Text;
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
            SEARCH.FrmBusquedaTransportista x = new SEARCH.FrmBusquedaTransportista();
            x.ShowDialog();
            if (x.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                txtId.Text = x.dgTransportista.SelectedRows[0].Cells["idTrans"].Value.ToString();
                cbPaqueteria.Text = x.dgTransportista.SelectedRows[0].Cells["idPaq"].Value.ToString();
                txtNombre.Text = x.dgTransportista.SelectedRows[0].Cells["nombre"].Value.ToString();
                txtTelefono.Text = x.dgTransportista.SelectedRows[0].Cells["telefono"].Value.ToString();
            }
        }

        private void tsLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void tsEliminar_Click(object sender, EventArgs e)
        {
            Transportista x = new Transportista();
            x.idTrans = int.Parse(txtId.Text);
            x.idPaq = Convert.ToInt32(cbPaqueteria.Text);
            x.nombre = txtNombre.Text;
            x.telefono = txtTelefono.Text;
            MessageBox.Show(x.Eliminar());
            Limpiar();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmTransportista_Load(object sender, EventArgs e)
        {
            CargarPaqueteria();
        }
    }
}
