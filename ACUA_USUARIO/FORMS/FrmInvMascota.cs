using ACUA_CAPA_NEG.CLASES;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ACUA_USUARIO.FORMS
{
    public partial class FrmInvMascota : Form
    {
        Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        SqlCommand comando = new SqlCommand();
        public FrmInvMascota()
        {
            InitializeComponent();
            con.ConnectionString = x.ConexionSql;
        }

        private void FrmInvMascota_Load(object sender, EventArgs e)
        {
            CargarMascota();
            CargarProveedor();
            Limpiar();
        }

        void CargarMascota()
        {
            DataTable dt = new DataTable();
            string consulta = "SELECT * FROM MASCOTA";
            SqlDataAdapter da = new SqlDataAdapter(consulta, con);
            con.Open();
            da.Fill(dt);
            con.Close();
            cbMascota.DisplayMember = "caracteristicas";
            cbMascota.ValueMember = "idMas";
            cbMascota.DataSource = dt;
        }

        void CargarProveedor()
        {
            DataTable dt = new DataTable();
            string consulta = "SELECT * FROM PROVEEDOR";
            SqlDataAdapter da = new SqlDataAdapter(consulta, con);
            con.Open();
            da.Fill(dt);
            con.Close();
            cbProveedor.DisplayMember = "nomProveedor";
            cbProveedor.ValueMember = "idProv";
            cbProveedor.DataSource = dt;
        }

        void Limpiar()
        {
            txtId.Clear();
            txtMin.Clear();
            txtExistencia.Clear();
            ACUA_CAPA_NEG.CLASES.Herramientas h = new ACUA_CAPA_NEG.CLASES.Herramientas();
            txtId.Text = h.consecutivo("idInv", "INVMASCOTA").ToString();
            txtId.Focus();
            txtMin.Focus();
            txtExistencia.Focus();
        }

        bool encontro()
        {
            bool a = false;

            if (txtId.Text.Trim() == "" || txtId.Text == "0")
                return false;

            try
            {
                int id = int.Parse(txtId.Text);
                string cadena = $"Select * From INVMASCOTA where idInv = {id}";
                con.Open();
                SqlCommand cmd = new SqlCommand(cadena, con);
                SqlDataReader lector = cmd.ExecuteReader();
                if (lector.Read())
                {
                    a = true;
                }
                con.Close();
                return a;
            }
            catch
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
                return false;
            }
        }

        private void tsGuardar_Click(object sender, EventArgs e)
        {
            if (cbMascota.SelectedValue == null)
            {
                MessageBox.Show("Seleccione una mascota");
                cbMascota.Focus();
                return;
            }

            if (cbProveedor.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un proveedor");
                cbProveedor.Focus();
                return;
            }

            if (txtMin.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el mínimo de inventario");
                txtMin.Focus();
                return;
            }

            if (txtExistencia.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese la existencia actual");
                txtExistencia.Focus();
                return;
            }

            int minimo, existencia;
            if (!int.TryParse(txtMin.Text, out minimo))
            {
                MessageBox.Show("Mínimo debe ser un número válido");
                txtMin.Focus();
                return;
            }

            if (!int.TryParse(txtExistencia.Text, out existencia))
            {
                MessageBox.Show("Existencia debe ser un número válido");
                txtExistencia.Focus();
                return;
            }

            if (minimo < 0)
            {
                MessageBox.Show("El mínimo no puede ser negativo");
                txtMin.Focus();
                return;
            }

            if (existencia < 0)
            {
                MessageBox.Show("La existencia no puede ser negativa");
                txtExistencia.Focus();
                return;
            }

            try
            {
                InvMascota x = new InvMascota();
                x.idInv = int.Parse(txtId.Text);
                x.idMas = Convert.ToInt32(cbMascota.SelectedValue);
                x.idProv = Convert.ToInt32(cbProveedor.SelectedValue);
                x.minimo = int.Parse(txtMin.Text);
                x.existencia = int.Parse(txtExistencia.Text);

                if (encontro())
                {
                    MessageBox.Show(x.Actualizar());
                }
                else
                {
                    MessageBox.Show(x.Guardar());
                }

                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void tsBuscar_Click(object sender, EventArgs e)
        {
            SEARCH.FrmBusquedaInvMascota x = new SEARCH.FrmBusquedaInvMascota();
            x.ShowDialog();
            if (x.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                txtId.Text = x.dgInvMascota.SelectedRows[0].Cells["idInv"].Value.ToString();
                cbMascota.SelectedValue = x.dgInvMascota.SelectedRows[0].Cells["idMas"].Value.ToString();
                cbProveedor.SelectedValue = x.dgInvMascota.SelectedRows[0].Cells["idProv"].Value.ToString();
                txtMin.Text = x.dgInvMascota.SelectedRows[0].Cells["minimo"].Value.ToString();
                txtExistencia.Text = x.dgInvMascota.SelectedRows[0].Cells["existencia"].Value.ToString();
            }
        }

        private void tsLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void tsEliminar_Click(object sender, EventArgs e)
        {
            if (txtId.Text.Trim() == "" || txtId.Text == "0")
            {
                MessageBox.Show("Seleccione un inventario para eliminar");
                return;
            }

            if (MessageBox.Show("¿Está seguro de eliminar este inventario?", "Confirmar",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    ACUA_CAPA_NEG.CLASES.InvMascota x = new ACUA_CAPA_NEG.CLASES.InvMascota();
                    x.idInv = int.Parse(txtId.Text);
                    x.idMas = Convert.ToInt32(cbMascota.SelectedValue);
                    x.idProv = Convert.ToInt32(cbProveedor.SelectedValue);
                    x.minimo = int.Parse(txtMin.Text);
                    x.existencia = int.Parse(txtExistencia.Text);

                    MessageBox.Show(x.Eliminar());
                    Limpiar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar: " + ex.Message);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsImprimir_Click(object sender, EventArgs e)
        {
            REPORTS.FrmrMascota x = new REPORTS.FrmrMascota();
            x.ShowDialog();
        }
    }
}
