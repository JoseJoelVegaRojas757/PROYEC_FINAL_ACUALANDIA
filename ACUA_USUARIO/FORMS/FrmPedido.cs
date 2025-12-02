using ACUA_CAPA_NEG.CLASES;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ACUA_USUARIO.FORMS
{
    public partial class FrmPedido : Form
    {
        Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        SqlCommand comando = new SqlCommand();
        public FrmPedido()
        {
            InitializeComponent();
            con.ConnectionString = x.ConexionSql;
        }

        void CargarTrans()
        {
            DataTable dt = new DataTable();
            string consulta = "SELECT * FROM TRANSPORTISTA";
            SqlDataAdapter da = new SqlDataAdapter(consulta, con);
            con.Open();
            da.Fill(dt);
            con.Close();
            cbTransporte.DisplayMember = "nombre";
            cbTransporte.ValueMember = "idTrans";
            cbTransporte.DataSource = dt;
        }

        void Limpiar()
        {
            txtId.Clear();
            txtEstado.Clear();
            txtTotal.Clear();
            ACUA_CAPA_NEG.CLASES.Herramientas h = new ACUA_CAPA_NEG.CLASES.Herramientas();
            txtId.Text = h.consecutivo("idPed", "PEDIDO").ToString();
            txtId.Focus();
            txtEstado.Focus();
            txtTotal.Focus();
        }

        bool encontro()
        {
            bool a = false;
            int id = int.Parse(txtId.Text);
            string cadena = $"Select * From PEDIDO where idPed = {id}";
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
            Pedido x = new Pedido();
            x.idPed = int.Parse(txtId.Text);
            x.idTrans = Convert.ToInt32(cbTransporte.SelectedValue);
            x.fPedido = dtFechaP.Value.ToString("yyyy/MM/dd");
            x.fEntrega = dtFechaE.Value.ToString("yyyy/MM/dd");
            x.estado = txtEstado.Text;
            x.total = decimal.Parse(txtTotal.Text);
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
            SEARCH.FrmBusquedaPedido x = new SEARCH.FrmBusquedaPedido();
            x.ShowDialog();
            if (x.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                txtId.Text = x.dgPedido.SelectedRows[0].Cells["idPed"].Value.ToString();
                cbTransporte.Text = x.dgPedido.SelectedRows[0].Cells["idTrans"].Value.ToString();
                dtFechaP.Text = x.dgPedido.SelectedRows[0].Cells["fPedido"].Value.ToString();
                dtFechaE.Text = x.dgPedido.SelectedRows[0].Cells["fEntrega"].Value.ToString();
                txtEstado.Text = x.dgPedido.SelectedRows[0].Cells["estado"].Value.ToString();
                txtTotal.Text = x.dgPedido.SelectedRows[0].Cells["total"].Value.ToString();
            }
        }

        private void tsLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void tsEliminar_Click(object sender, EventArgs e)
        {
            Pedido x = new Pedido();
            x.idPed = int.Parse(txtId.Text);
            x.idTrans = Convert.ToInt32(cbTransporte.SelectedValue);
            x.fPedido = dtFechaP.Value.ToString("yyyy/MM/dd");
            x.fEntrega = dtFechaE.Value.ToString("yyyy/MM/dd");
            x.estado = txtEstado.Text;
            x.total = decimal.Parse(txtTotal.Text);
            MessageBox.Show(x.Eliminar());
            Limpiar();
        }

        private void FrmPedido_Load(object sender, EventArgs e)
        {
            CargarTrans();
        }
    }
}
