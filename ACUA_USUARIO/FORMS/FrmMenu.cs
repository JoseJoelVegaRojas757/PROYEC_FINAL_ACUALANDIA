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
            AbrirFormHijo(new FrmCategoria());
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
            AbrirFormHijo(new FrmColonia());
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
            AbrirFormHijo(new FrmCliente());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new FrmAbono());
        }

        private void btnCIn_Click(object sender, EventArgs e)
        {
            AbrirFormHijo(new FrmCInterno());
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
    }
}
