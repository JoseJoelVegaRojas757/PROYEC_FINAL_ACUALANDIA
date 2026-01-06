using ACUA_CAPA_NEG.CLASES;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACUA_USUARIO.FORMS
{
    //Ya jala mejor no hay q moverle nada
    public partial class FrmVentas : Form
    {
        Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        SqlCommand comando = new SqlCommand();
        public FrmVentas()
        {
            InitializeComponent();
            con.ConnectionString = x.ConexionSql;

        }


       
        void CargarTrabajador()
        {
            DataTable dt = new DataTable();
            string consulta = "SELECT * FROM TRABAJADOR";
            SqlDataAdapter da = new SqlDataAdapter(consulta, con);
            con.Open();
            da.Fill(dt);
            con.Close();
            cbTrabajador.DisplayMember = "traNombre";
            cbTrabajador.ValueMember = "idTra";
            cbTrabajador.DataSource = dt;
        }

        void CargarCliente()
        {
            DataTable dt = new DataTable();
            string consulta = "SELECT * FROM CLIENTE";
            SqlDataAdapter da = new SqlDataAdapter(consulta, con);
            con.Open();
            da.Fill(dt);
            con.Close();
            cbCliente.DisplayMember = "cli_Nombre";
            cbCliente.ValueMember = "idCli";
            cbCliente.DataSource = dt;
        }

        void Limpiar()
        {
            txtId.Clear();
            if (cbMetodoP.Items.Count > 0) cbMetodoP.SelectedIndex = 0;
            if (cbEstado.Items.Count > 0) cbEstado.SelectedIndex = 0;
            dgV.Rows.Clear();
            ACUA_CAPA_NEG.CLASES.Herramientas h = new ACUA_CAPA_NEG.CLASES.Herramientas();
            txtId.Text = h.consecutivo("idV", "VENTA").ToString();
        }

        bool encontro()
        {
            bool a = false;
            int id = int.Parse(txtId.Text);
            string cadena = $"Select * From VENTA where idV = {id}";
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
            VentaD x = new VentaD();
            x.idV = string.IsNullOrEmpty(txtId.Text) ? 0 : int.Parse(txtId.Text);
            x.idTrabajador = Convert.ToInt32(cbTrabajador.SelectedValue);
            x.idCliente = Convert.ToInt32(cbCliente.SelectedValue);
            x.fVenta = dtFechaV.Value.ToString("yyyy-MM-dd HH:mm:ss");
            x.MetodoP = cbMetodoP.SelectedItem.ToString();
            x.Estado = cbEstado.SelectedItem.ToString();
            
            x.total = decimal.Parse(txtTotal.Text);
            

            if (encontro()) 
            {
                MessageBox.Show(x.Actualizar());
            }
            else 
            {
                
                int idCreado = x.Guardar();

                
                foreach (DataGridViewRow fila in dgV.Rows)
                {
                    if (fila.Cells["idProd"].Value != null)
                    {
                        int idProd = Convert.ToInt32(fila.Cells["idProd"].Value);
                        int cant = Convert.ToInt32(fila.Cells["Cantidad"].Value);
                        decimal precio = Convert.ToDecimal(fila.Cells["Precio"].Value);

                        x.GuardarDetalle(idCreado, idProd, cant, precio);
                    }
                }
                //cargamos el ticket junto con la venta
                MessageBox.Show("Venta registrada con éxito.");
                REPORTS.FrmrTicket W = new REPORTS.FrmrTicket();
                W.ShowDialog();
            }
            Limpiar();
        }

        private void FrmVentas_Load(object sender, EventArgs e)
        {
            CargarOpcionesFijas();
            CargarProductosGrid();
            CargarCliente();
            CargarTrabajador();
            Limpiar();
        }

        private void tsBuscar_Click(object sender, EventArgs e)
        {
            SEARCH.FrmBusquedaVentas x = new SEARCH.FrmBusquedaVentas();
            x.ShowDialog();
            if (x.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                txtId.Text = x.dgVenta.SelectedRows[0].Cells["idV"].Value.ToString();
                cbCliente.SelectedValue = x.dgVenta.SelectedRows[0].Cells["idCli"].Value.ToString();
                cbTrabajador.SelectedValue = x.dgVenta.SelectedRows[0].Cells["idTra"].Value.ToString();
                dtFechaV.Text = x.dgVenta.SelectedRows[0].Cells["Fecha_Venta"].Value.ToString();
                cbMetodoP.Text = x.dgVenta.SelectedRows[0].Cells["Metodo_Pago"].Value.ToString();
                txtTotal.Text = x.dgVenta.SelectedRows[0].Cells["Total"].Value.ToString();
                cbEstado.Text = x.dgVenta.SelectedRows[0].Cells["Estado"].Value.ToString();
            }
        }

        private void tsLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void tsEliminar_Click(object sender, EventArgs e)
        {
            VentaD x = new VentaD();
            x.idV = int.Parse(txtId.Text);
            x.idTrabajador = Convert.ToInt32(cbTrabajador.SelectedValue);
            x.idCliente = Convert.ToInt32(cbCliente.SelectedValue);
            x.fVenta = dtFechaV.Value.ToString("yyyy/MM/dd");
            x.MetodoP = cbMetodoP.Text;
            x.total = decimal.Parse(txtTotal.Text);
            x.Estado = cbEstado.Text;
            MessageBox.Show(x.Eliminar());
            Limpiar();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FORMS.FrmCliente x = new FORMS.FrmCliente();
            x.ShowDialog();
        }



        private void txtTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void CalcularTotalVenta()
        {
            decimal sumaTotal = 0;
            foreach (DataGridViewRow fila in dgV.Rows) 
            {
               
                if (!fila.IsNewRow)
                {
                    
                    if (fila.Cells["Cantidad"].Value != null && fila.Cells["Precio"].Value != null)
                    {
                        decimal cant = Convert.ToDecimal(fila.Cells["Cantidad"].Value);
                        decimal prec = Convert.ToDecimal(fila.Cells["Precio"].Value);
                        sumaTotal += (cant * prec);
                    }
                }
            }

            
            txtTotal.Text = sumaTotal.ToString("N2");
        }



        private void btnVD_Click(object sender, EventArgs e)
        {
            VentaD x = new VentaD(); 
            int idBusqueda = int.Parse(txtId.Text);

         
            DataTable dt = x.ListarDetalle(idBusqueda);

           
            dgV.Rows.Clear();

            
            foreach (DataRow fila in dt.Rows)
            {
                
                dgV.Rows.Add(fila["idProd"], fila["Cantidad"], fila["Precio_Unitario"]);
            }


            CalcularTotalVenta();
        }

        private void dgV_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex >= 0 && dgV.Columns[e.ColumnIndex].Name == "idProd")
            {
                var comboCol = (DataGridViewComboBoxColumn)dgV.Columns[e.ColumnIndex];
                var row = dgV.Rows[e.RowIndex];

                if (row.Cells["idProd"].Value != null)
                {
                    
                    int idSeleccionado = Convert.ToInt32(row.Cells["idProd"].Value);

                    
                    DataTable dt = (DataTable)comboCol.DataSource;
                    DataRow filaProducto = dt.Select($"idProd = {idSeleccionado}").FirstOrDefault();

                    if (filaProducto != null)
                    {
                        
                        row.Cells["Precio"].Value = filaProducto["pVenta"];

                        
                        if (row.Cells["Cantidad"].Value == null) row.Cells["Cantidad"].Value = 1;
                    }
                }
            }

            CalcularTotalVenta();
        }

        //cargar el load
        void CargarProductosGrid()
        {
            DataTable dtProd = new DataTable();
            string consulta = "Select idProd, nomProducto, pVenta FROM PRODUCTO";
            SqlDataAdapter da = new SqlDataAdapter(consulta, con);
            con.Open();
            da.Fill(dtProd);
            con.Close();

            
            DataGridViewComboBoxColumn col = (DataGridViewComboBoxColumn)dgV.Columns["idProd"];
            col.DataSource = dtProd;
            //muestra el producto al fallo en ves de id
            col.DisplayMember = "nomProducto"; 
            col.ValueMember = "idProd";       
        }

        private void dgV_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgV.Columns[e.ColumnIndex].Name == "Cantidad")
            {
                CalcularTotalVenta();
            }
        }

        private void dgV_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgV.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn && e.RowIndex >= 0)
            {
                dgV.BeginEdit(true);
                ((ComboBox)dgV.EditingControl).DroppedDown = true;
            }
        }

        void CargarOpcionesFijas()
        {
            
            cbMetodoP.Items.Clear();
            cbMetodoP.Items.Add("EFECTIVO");
            cbMetodoP.Items.Add("TARJETA");
            cbMetodoP.Items.Add("TRANSFERENCIA");
            cbMetodoP.SelectedIndex = 0; 

            
            cbEstado.Items.Clear();
            cbEstado.Items.Add("PAGADO");
            cbEstado.Items.Add("PENDIENTE");
            cbEstado.Items.Add("CANCELADO");
            cbEstado.SelectedIndex = 0;
        }
    }
}
