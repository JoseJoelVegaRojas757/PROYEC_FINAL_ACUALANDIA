using ACUA_CAPA_NEG.CLASES;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ACUA_USUARIO.FORMS
{
    public partial class FrmTrabajador : Form
    {
        Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        SqlCommand comando = new SqlCommand();
        public FrmTrabajador()
        {
            InitializeComponent();
            con.ConnectionString = x.ConexionSql;
        }
        void CargarDomicilio()
        {
            DataTable dt = new DataTable();
            string consulta = "SELECT * FROM DOMICILIO";
            SqlDataAdapter da = new SqlDataAdapter(consulta, con);
            con.Open();
            da.Fill(dt);
            con.Close();
            cbDomicilio.DisplayMember = "referencias";
            cbDomicilio.ValueMember = "idDom";
            cbDomicilio.DataSource = dt;
        }

        void CargarPuesto()
        {
            DataTable dt = new DataTable();
            string consulta = "SELECT * FROM PUESTO";
            SqlDataAdapter da = new SqlDataAdapter(consulta, con);
            con.Open();
            da.Fill(dt);
            con.Close();
            cbPuesto.DisplayMember = "nombre";
            cbPuesto.ValueMember = "idPuesto";
            cbPuesto.DataSource = dt;
        }

        void Limpiar()
        {
            txtId.Clear();
            txtNombre.Clear();
            txtAPaterno.Clear();
            txtAMaterno.Clear();
            txtFechaN.Clear();
            txtTelefono.Clear();
            txtRedesS.Clear();
            ACUA_CAPA_NEG.CLASES.Herramientas h = new ACUA_CAPA_NEG.CLASES.Herramientas();
            txtId.Text = h.consecutivo("idTra", "TRABAJADOR").ToString();
            txtNombre.Focus();
            txtAPaterno.Focus();
            txtAMaterno.Focus();
            txtFechaN.Focus();
            txtTelefono.Focus();
            txtRedesS.Focus();
        }

        bool encontro()
        {
            bool a = false;
            int id = int.Parse(txtId.Text);
            string cadena = $"SELECT * FROM TRABJADOR WHERE idTra = {id}";
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsGuardar_Click(object sender, EventArgs e)
        {
            Trabajador x = new Trabajador();
            x.idTra = int.Parse(txtId.Text);
            x.traNombre = txtNombre.Text;
            x.traNombre = txtAPaterno.Text;
            x.traPaterno = txtAPaterno.Text;
            x.traMaterno = txtAMaterno.Text;
            x.traDom = int.Parse(cbDomicilio.SelectedValue.ToString());
            x.traTel = txtTelefono.Text;
            x.idPuesto = int.Parse(cbPuesto.SelectedValue.ToString());
            x.traNacimiento = txtFechaN.Text;
            x.traSociales = txtRedesS.Text;
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
            SEARCH.FrmBusquedaTrabajador x = new SEARCH.FrmBusquedaTrabajador();
            x.ShowDialog();
            if (x.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                txtId.Text = x.dgTrabajador.SelectedRows[0].Cells["idTra"].Value.ToString();
                cbPuesto.Text = x.dgTrabajador.SelectedRows[0].Cells["idPuesto"].Value.ToString();
                cbDomicilio.Text = x.dgTrabajador.SelectedRows[0].Cells["traDom"].Value.ToString();
                txtNombre.Text = x.dgTrabajador.SelectedRows[0].Cells["traNombre"].Value.ToString();
                txtAPaterno.Text = x.dgTrabajador.SelectedRows[0].Cells["traPaterno"].Value.ToString();
                txtAMaterno.Text = x.dgTrabajador.SelectedRows[0].Cells["traMaterno"].Value.ToString();
                txtFechaN.Text = x.dgTrabajador.SelectedRows[0].Cells["traNacimiento"].Value.ToString();
                txtTelefono.Text = x.dgTrabajador.SelectedRows[0].Cells["traTel"].Value.ToString();
                txtRedesS.Text = x.dgTrabajador.SelectedRows[0].Cells["traSociales"].Value.ToString();
            }
        }

        private void tsLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void tsEliminar_Click(object sender, EventArgs e)
        {
            Trabajador x = new Trabajador();
            x.idTra = int.Parse(txtId.Text);
            x.traNombre = txtNombre.Text;
            x.traNombre = txtAPaterno.Text;
            x.traPaterno = txtAPaterno.Text;
            x.traMaterno = txtAMaterno.Text;
            x.traDom = int.Parse(cbDomicilio.SelectedValue.ToString());
            x.traTel = txtTelefono.Text;
            x.idPuesto = int.Parse(cbPuesto.SelectedValue.ToString());
            x.traNacimiento = txtFechaN.Text;
            x.traSociales = txtRedesS.Text;
            MessageBox.Show(x.Eliminar());
            Limpiar();
        }

        private void FrmTrabajador_Load(object sender, EventArgs e)
        {
            CargarDomicilio();
            CargarPuesto();
        }
    }
}
