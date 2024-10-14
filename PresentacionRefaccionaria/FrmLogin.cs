using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Manejadores;

namespace PresentacionRefaccionaria
{
    public partial class FrmLogin : Form
    {
        ManejadorLogin ml; ManejadorPermisos mp; ManejadorUsuarios mu;
        public static bool VlHer = false, VlPro = false, VlMar = false, VlUse = false;
        public static int ID = 0, Herramientas = 1, Refacciones = 2, Marcas = 3, Usuarios = 4;
        public FrmLogin()
        {
            InitializeComponent();
            ml = new ManejadorLogin();
            mp = new ManejadorPermisos();
            mu = new ManejadorUsuarios();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (txtContraseña.Text.Equals("") || txtUsuario.Text.Equals(""))
            {
                MessageBox.Show("No ha ingresado ningun usuario.");
            }
            else
            {
                string r = ml.Validar(txtUsuario, txtContraseña);
                if (!r.Equals("Error"))
                {
                    lblErrores.Text = "";
                    switch (r)
                    {
                        case "C0rr3ct0":
                        {
                             ID = mu.ConsultarID(txtUsuario);
                             ObtenerPermisos();
                             this.Hide();
                             FrmMenu m = new FrmMenu();
                             m.ShowDialog();
                             txtContraseña.Clear(); txtUsuario.Clear();
                        }
                        break;
                        default:
                            lblErrores.Text = "El usuario y/o contraseña son incorrectos.";

                            break;
                    }
                }
                else
                {
                    lblErrores.Text = "El usuario y/o contraseña son incorrectos.";
                }
                this.Show();
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            lblErrores.Visible = false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ObtenerPermisos()
        {
            VlHer = mp.ConsultarLectura(ID, Herramientas);
            VlPro = mp.ConsultarLectura(ID, Refacciones);
            VlMar = mp.ConsultarLectura(ID, Marcas);
            VlUse = mp.ConsultarLectura(ID, Usuarios);
        }
    }
}
