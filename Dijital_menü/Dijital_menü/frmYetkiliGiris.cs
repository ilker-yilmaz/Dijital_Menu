using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dijital_menü
{
    public partial class frmYetkiliGiris : Form
    {
        public frmYetkiliGiris()
        {
            InitializeComponent();
        }

        private void labelControl5_Click(object sender, EventArgs e)
        {

        }

        private void labelControl6_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            
        }

        Genel gnl = new Genel();
        private void giris_Load(object sender, EventArgs e)
        {
            Personeller p = new Personeller();
            p.personelGetByInformation(cbKullanici);
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnGirisMusteri_Click(object sender, EventArgs e)
        {
            Personeller p = new Personeller();
            bool result = p.personalEntryControl(txtSifre.Text,gnl._personelId);

            if (result)
            {
                this.Hide();
                frmMenu menu = new frmMenu();
                menu.Show();
            }
        }
    }
}
