using ACUA_CAPA_NEG.CLASES;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ACUA_USUARIO.FORMS
{
    public partial class FrmAbono : Form
    {
        Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        SqlCommand comando = new SqlCommand();


        public FrmAbono()
        {
            InitializeComponent();
            con.ConnectionString = x.ConexionSql;

        }

        void CargarApartado()
        {
            DataTable dt = new DataTable();
            string consulta = "SELECT * FROM APARTADO";
            SqlDataAdapter da = new SqlDataAdapter(consulta, con);
            con.Open();
            da.Fill(dt);
            con.Close();
            cbApartado.DisplayMember = "anticipo";
            cbApartado.ValueMember = "idApartado";
            cbApartado.DataSource = dt;
        }

        void Limpiar()
        {
            txtId.Clear();
            txtMonto.Clear();
            ACUA_CAPA_NEG.CLASES.Herramientas h = new ACUA_CAPA_NEG.CLASES.Herramientas();
            txtId.Text = h.consecutivo("idAbono", "ABONO").ToString();
            txtMonto.Focus();
        }

        bool encontro()
        {
            bool a = false;
            int id = int.Parse(txtId.Text);
            string cadena = $"Select * From ABONO where idAbono = {id}";
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
            Abono x = new Abono();
            x.idAbono = int.Parse(txtId.Text);
            x.idApartado = Convert.ToInt32(cbApartado.SelectedValue);
            x.Monto = txtMonto.Text;
            if (encontro() == true)
            {
                MessageBox.Show(x.Actualizar());
            }
            else
            {
                MessageBox.Show(x.Guardar());
            }
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmAbono_Load(object sender, EventArgs e)
        {
            CargarApartado();
        }

        private void tsLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void tsBuscar_Click(object sender, EventArgs e)
        {
            SEARCH.FrmBusquedaAbono x = new SEARCH.FrmBusquedaAbono();
            x.ShowDialog();
            if (x.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                txtId.Text = x.dgAbono.SelectedRows[0].Cells["idAbono"].Value.ToString();
                cbApartado.Text = x.dgAbono.SelectedRows[0].Cells["idApartado"].Value.ToString();
                txtMonto.Text = x.dgAbono.SelectedRows[0].Cells["monto"].Value.ToString();
            }
        }

        private void tsEliminar_Click(object sender, EventArgs e)
        {
            ACUA_CAPA_NEG.CLASES.Abono x = new ACUA_CAPA_NEG.CLASES.Abono();
            x.idAbono = int.Parse(txtId.Text);
            x.idApartado = Convert.ToInt32(cbApartado.SelectedValue);
            x.Monto = txtMonto.Text;
            MessageBox.Show(x.Eliminar());
            Limpiar();
        }
    }
}
