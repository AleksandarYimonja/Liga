using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Liga
{
    public partial class Meni : Form
    {
        public Meni()
        {
            InitializeComponent();
        }

        private void meceviToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mecevi frmMecevi = new Mecevi();
            frmMecevi.Show();
        }

        private void klubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Klub frmKlub = new Klub();
            frmKlub.Show();
        }

        private void sezonuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sezona frmSezona = new Sezona();
            frmSezona.Show();
        }

        private void igraciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Igraci frmIgraci = new Igraci();
            frmIgraci.Show();
        }
    }
}
