using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentacionRefaccionaria
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FrmHerramientas fh = new FrmHerramientas();
            fh.MdiParent = this;
            fh.Show();
        }

        private void tsbRefacciones_Click(object sender, EventArgs e)
        {
            FrmProductos fp = new FrmProductos();
            fp.MdiParent = this;
            fp.Show();
        }

        private void tsbMarcas_Click(object sender, EventArgs e)
        {
            FrmMarcas fm = new FrmMarcas();
            fm.MdiParent = this;
            fm.Show();
        }
    }
}
