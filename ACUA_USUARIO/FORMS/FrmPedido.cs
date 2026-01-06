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
            try
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
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar transportistas: " + ex.Message);
            }
        }

        void Limpiar()
        {
            txtId.Clear();
            txtTotal.Clear();

            
            chkEstado.Checked = true; 

            
            dtFechaP.Value = DateTime.Now;
            dtFechaE.Value = DateTime.Now.AddDays(3); 

            
            ACUA_CAPA_NEG.CLASES.Herramientas h = new ACUA_CAPA_NEG.CLASES.Herramientas();
            txtId.Text = h.consecutivo("idPed", "PEDIDO").ToString();

            txtTotal.Focus();
        }

        bool encontro()
        {
            try
            {
                bool a = false;
                int id = int.Parse(txtId.Text);
                string cadena = $"Select * From PEDIDO where idPed = {id}";

                con.Open();
                comando.CommandText = cadena;
                comando.CommandType = CommandType.Text;
                comando.Connection = con;
                SqlDataReader lector = comando.ExecuteReader();

                if (lector.Read())
                {
                    a = true;
                }
                lector.Close();
                con.Close();
                return a;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                con.Close();
                return false;
            }
        }

        private void tsGuardar_Click(object sender, EventArgs e)
        {
            
            if (cbTransporte.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un transportista");
                return;
            }

            if (dtFechaE.Value < dtFechaP.Value)
            {
                MessageBox.Show("La fecha de entrega no puede ser anterior a la fecha del pedido");
                dtFechaE.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTotal.Text))
            {
                MessageBox.Show("Ingrese el total del pedido");
                txtTotal.Focus();
                return;
            }

            try
            {
                Pedido x = new Pedido();
                x.idPed = int.Parse(txtId.Text);
                x.idTrans = Convert.ToInt32(cbTransporte.SelectedValue);
                x.fPedido = dtFechaP.Value;
                x.fEntrega = dtFechaE.Value;

                
                x.estado = chkEstado.Checked ? "A" : "I"; // "A"=Activo, "I"=Inactivo

                x.total = decimal.Parse(txtTotal.Text);

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
            SEARCH.FrmBusquedaPedido x = new SEARCH.FrmBusquedaPedido();
            x.ShowDialog();

            if (x.DialogResult == DialogResult.OK && x.dgPedido.SelectedRows.Count > 0)
            {
                try
                {
                    DataGridViewRow row = x.dgPedido.SelectedRows[0];

                    txtId.Text = row.Cells["idPed"].Value?.ToString() ?? "";

                    if (row.Cells["idTrans"].Value != null)
                        cbTransporte.SelectedValue = Convert.ToInt32(row.Cells["idTrans"].Value);

                    
                    if (row.Cells["fPedido"].Value != null)
                        dtFechaP.Value = Convert.ToDateTime(row.Cells["fPedido"].Value);

                    if (row.Cells["fEntrega"].Value != null)
                        dtFechaE.Value = Convert.ToDateTime(row.Cells["fEntrega"].Value);

                    
                    if (row.Cells["estado"].Value != null)
                    {
                        string estadoValor = row.Cells["estado"].Value.ToString();
                        chkEstado.Checked = (estadoValor == "A" || estadoValor.ToUpper() == "A");
                    }

                    txtTotal.Text = row.Cells["total"].Value?.ToString() ?? "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar datos: " + ex.Message);
                }
            }


        }

        private void tsLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void tsEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text) || txtId.Text == "0")
            {
                MessageBox.Show("Seleccione un pedido para eliminar");
                return;
            }

            if (MessageBox.Show("¿Está seguro de eliminar este pedido?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    Pedido x = new Pedido();
                    x.idPed = int.Parse(txtId.Text);
                    x.idTrans = Convert.ToInt32(cbTransporte.SelectedValue);
                    x.fPedido = dtFechaP.Value;
                    x.fEntrega = dtFechaE.Value;
                    x.estado = chkEstado.Checked ? "A" : "I";
                    x.total = decimal.Parse(txtTotal.Text);

                    MessageBox.Show(x.Eliminar());
                    Limpiar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void FrmPedido_Load(object sender, EventArgs e)
        {
            CargarTrans();
            Limpiar();
        }

        private void tsClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            
            if (e.KeyChar == '.' && txtTotal.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void dtFechaE_ValueChanged(object sender, EventArgs e)
        {
            if (dtFechaE.Value < dtFechaP.Value)
            {
                MessageBox.Show("La fecha de entrega debe ser posterior a la fecha del pedido");
                dtFechaE.Value = dtFechaP.Value.AddDays(1);
            }
        }

        private void btnT_Click(object sender, EventArgs e)
        {
            FORMS.FrmTransportista w = new FORMS.FrmTransportista();
            w.ShowDialog();
        }
    }
}
