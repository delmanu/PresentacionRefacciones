using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Manejadores;

namespace PresentacionRefaccionaria
{
    public partial class FrmMenu : Form
    {
        ManejadorPermisos mp;
        public static bool AddHer = false, AddPro = false, AddMar = false, AddUse = false;
        public static bool ModHer = false, ModPro = false, ModMar = false, ModUse = false;
        public static bool ElimHer = false, ElimPro = false, ElimMar = false, ElimUse = false;
              
        public FrmMenu()
        {
            InitializeComponent();
            mp = new ManejadorPermisos();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            AddHer = mp.ConsultarEscritura(FrmLogin.ID, FrmLogin.Herramientas);
            ModHer = mp.ConsultarModificacion(FrmLogin.ID, FrmLogin.Herramientas);
            ElimHer = mp.ConsultarEliminacion(FrmLogin.ID, FrmLogin.Herramientas);
            FrmHerramientas fh = new FrmHerramientas();
            fh.MdiParent = this;
            fh.Show();
        }

        private void tsbRefacciones_Click(object sender, EventArgs e)
        {
            AddPro = mp.ConsultarEscritura(FrmLogin.ID, FrmLogin.Refacciones);
            ModPro = mp.ConsultarModificacion(FrmLogin.ID, FrmLogin.Refacciones);
            ElimPro = mp.ConsultarEliminacion(FrmLogin.ID, FrmLogin.Refacciones);
            FrmProductos fp = new FrmProductos();
            fp.MdiParent = this;
            fp.Show();
        }

        private void tsbMarcas_Click(object sender, EventArgs e)
        {
            AddMar = mp.ConsultarEscritura(FrmLogin.ID, FrmLogin.Marcas);
            ModMar = mp.ConsultarModificacion(FrmLogin.ID, FrmLogin.Marcas);
            ElimMar = mp.ConsultarEliminacion(FrmLogin.ID, FrmLogin.Marcas);
            FrmMarcas fm = new FrmMarcas();
            fm.MdiParent = this;
            fm.Show();
        }

        private void tsbUsuarios_Click(object sender, EventArgs e)
        {
            AddUse = mp.ConsultarEscritura(FrmLogin.ID, FrmLogin.Usuarios);
            ModUse = mp.ConsultarModificacion(FrmLogin.ID, FrmLogin.Usuarios);
            ElimUse = mp.ConsultarEliminacion(FrmLogin.ID, FrmLogin.Usuarios);
            FrmUsuarios fu = new FrmUsuarios();
            fu.MdiParent = this;
            fu.Show();
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {
//            MessageBox.Show($"Lectura Herramientas: {FrmLogin.VlHer}\nLectura Refacciones: {FrmLogin.VlPro}\nLectura Marcas: {FrmLogin.VlMar}\nLectura Usuarios: {FrmLogin.VlUse}","TEST");
            tsbHerramientas.Enabled = FrmLogin.VlHer;
            tsbRefacciones.Enabled = FrmLogin.VlPro;
            tsbMarcas.Enabled = FrmLogin.VlMar;
            tsbUsuarios.Enabled = FrmLogin.VlUse;
            lblNombre.Text = FrmLogin.NombreUsuario;
        }

        private void bntCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
