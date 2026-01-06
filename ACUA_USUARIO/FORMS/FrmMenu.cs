using System;
using System.Windows.Forms;

namespace ACUA_USUARIO.FORMS
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new FrmProducto());
        }

        private void AbrirFormHijo(object frmHijo)
        {
            if (this.pMain.Controls.Count > 0)
                this.pMain.Controls.RemoveAt(0);
            Form fh = frmHijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.pMain.Controls.Add(fh);
            this.pMain.Tag = fh;
            fh.Show();

        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {

        }

        private void btnColonia_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new FrmInvMascota());
        }

        private void btnTrabajador_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new FrmTrabajador());
        }

        private void btnDomicilio_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new FrmDomicilio());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new FrmProveedor());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new FrmAbono());
        }

        private void btnCIn_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new FrmMascota());
        }

        private void btnCMascota_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new FrmCMascota());
        }

        private void btnApartado_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new FrmApartado());
        }

        private void btnPMas_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new FrmPMascota());
        }

        private void pMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            AbrirFormHijo(new FrmVentas());
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            AbrirFormHijo(new FrmPedido());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new FrmPaqueteria());
        }
    }
}
