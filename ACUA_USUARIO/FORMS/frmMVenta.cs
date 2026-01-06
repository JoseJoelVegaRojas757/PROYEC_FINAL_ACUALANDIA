using ACUA_CAPA_NEG.CLASES;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACUA_USUARIO.FORMS
{
    public partial class frmMVenta : Form
    {
        Conexion x = new Conexion();
        SqlConnection con = new SqlConnection();
        SqlCommand comando = new SqlCommand();
        public frmMVenta()
        {
            InitializeComponent();
            con.ConnectionString = x.ConexionSql;
        }

        void CargarRaza()
        {
            DataTable dt = new DataTable();
            string consulta = "SELECT * FROM RAZA";
            SqlDataAdapter da = new SqlDataAdapter(consulta, con);
            con.Open();
            da.Fill(dt);
            con.Close();
            cbRaza.DisplayMember = "nomRaza";
            cbRaza.ValueMember = "idRaza";
            cbRaza.DataSource = dt;
        }
        void Limpiar()
        {
            txtId.Clear();
            txtPco.Clear();
            txtCodigoB.Clear();
            txtIvaC.Clear();
            txtPven.Clear();
            txtIVenta.Clear();
            txtOfert.Clear();
            txtPOfert.Clear();
            txtEstatus.Clear();
            ACUA_CAPA_NEG.CLASES.Herramientas h = new ACUA_CAPA_NEG.CLASES.Herramientas();
            txtId.Text = h.consecutivo("idMas", "MVENTA").ToString();
            txtEstatus.Focus();
            
        }

        bool encontro()
        {
            bool a = false;
            int id = int.Parse(txtId.Text);
            string cadena = $"Select * From MVENTA where idMas = {id}";
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
            MVenta x = new MVenta();
            x.idMas = int.Parse(txtId.Text);
            x.mas_raza = Convert.ToInt32(cbRaza.SelectedValue);
            x.pCompra = int.Parse(txtPco.Text);
            x.codigo = txtCodigoB.Text;
            x.ivacompra = int.Parse(txtIvaC.Text);
            x.pventa = int.Parse(txtPven.Text);
            x.ivaventa = int.Parse(txtIVenta.Text);
            x.oferta = int.Parse(txtOfert.Text);
            x.poferta = int.Parse(txtPOfert.Text);
            x.estatus = int.Parse(txtEstatus.Text);
            if (encontro() == true)
            {
                MessageBox.Show(x.Actualizar());
            }
            else
            {
                MessageBox.Show(x.Guardar());
            }
            Limpiar();

        }

        private void frmMVenta_Load(object sender, EventArgs e)
        {
            CargarRaza();
            Limpiar();
        }

        private void tsBuscar_Click(object sender, EventArgs e)
        {
            SEARCH.FrmBusquedaMVenta x = new SEARCH.FrmBusquedaMVenta();
            x.ShowDialog();
            if (x.DialogResult == System.Windows.Forms.DialogResult.OK) ;
            {
                txtId.Text = x.dgMVenta.SelectedRows[0].Cells["idMas"].Value.ToString();
                cbRaza.SelectedValue = x.dgMVenta.SelectedRows[0].Cells["mas_raza"].Value.ToString();
                txtPco.Text = x.dgMVenta.SelectedRows[0].Cells["pCompra"].Value.ToString();
                txtCodigoB.Text = x.dgMVenta.SelectedRows[0].Cells["codigo"].Value.ToString();
                txtIvaC.Text = x.dgMVenta.SelectedRows[0].Cells["mas_ivaCompra"].Value.ToString();
                txtPven.Text = x.dgMVenta.SelectedRows[0].Cells["pVenta"].Value.ToString();
                txtIVenta.Text = x.dgMVenta.SelectedRows[0].Cells["mas_ivaVenta"].Value.ToString();
                txtOfert.Text = x.dgMVenta.SelectedRows[0].Cells["oferta"].Value.ToString();
                txtPOfert.Text = x.dgMVenta.SelectedRows[0].Cells["pOferta"].Value.ToString();
                txtEstatus.Text = x.dgMVenta.SelectedRows[0].Cells["estatus"].Value.ToString();
            }
        }

        private void tsLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void tsEliminar_Click(object sender, EventArgs e)
        {
            MVenta x = new MVenta();
            x.idMas = int.Parse(txtId.Text);
            x.mas_raza = Convert.ToInt32(cbRaza.SelectedValue);
            x.pCompra = int.Parse(txtPco.Text);
            x.codigo = txtCodigoB.Text;
            x.ivacompra = int.Parse(txtIvaC.Text);
            x.pventa = int.Parse(txtPven.Text);
            x.ivaventa = int.Parse(txtIVenta.Text);
            x.oferta = int.Parse(txtOfert.Text);
            x.poferta = int.Parse(txtPOfert.Text);
            x.estatus = int.Parse(txtEstatus.Text);
            MessageBox.Show(x.Eliminar());
            Limpiar();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
