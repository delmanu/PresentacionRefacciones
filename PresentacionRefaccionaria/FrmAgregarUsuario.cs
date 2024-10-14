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
    public partial class FrmAgregarUsuario : Form
    {
        int IdUsuario, Herramientas = 1, Productos = 2, Marcas = 3, Usuarios = 4;
        bool SeleccionadoTodo = false;
        ManejadorPermisos mp; ManejadorUsuarios mu; 
        public FrmAgregarUsuario()
        {
            InitializeComponent();
            mu = new ManejadorUsuarios();
            mp = new ManejadorPermisos();
            cbCamPassUser.Enabled = false;
            cbCamPassUser.Checked = false;
            cbCamPassUser.Visible = false;
            if (FrmUsuarios.IdUsuario > 0)
            {
                IdUsuario = FrmUsuarios.IdUsuario;
                txtNombre.Text = FrmUsuarios.Nombre;
                txtApellidoP.Text = FrmUsuarios.ApellidoP;
                txtApellidoM.Text = FrmUsuarios.ApellidoM;
                txtRFC.Text = FrmUsuarios.RFC;
                dtpFechaNacimiento.Text = FrmUsuarios.FechaNacimiento;
                txtUsuario.Text = FrmUsuarios.Usuario;
                VerificarPermisos();
                cbCamPassUser.Enabled = true;
                cbCamPassUser.Checked = false;
                cbCamPassUser.Visible = true;
                if (!cbCamPassUser.Checked)
                {
                    txtUsuario.Enabled = false;
                    txtContraseña.Enabled = false;
                }
                btnAgregar.Text = "Modificar";
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }        

        private void cbCamPassUser_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbCamPassUser.Checked)
            {
                txtUsuario.Enabled = false;
                txtContraseña.Enabled = false;
            }
            else
            {
                txtUsuario.Enabled = true;
                txtContraseña.Enabled = true;
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            if (!cbElimH.Checked)
            {
                cbAgH.Checked = true; cbLecH.Checked = true; cbModH.Checked = true; cbElimH.Checked = true;
            }
            else
            {
                cbAgH.Checked = false; cbLecH.Checked = false; cbModH.Checked = false; cbElimH.Checked = false;
            }

        }

        private void label9_Click(object sender, EventArgs e)
        {
            if (!cbElimR.Checked)
            {
                cbAgR.Checked = true; cbLecR.Checked = true; cbModR.Checked = true; cbElimR.Checked = true;
            }
            else
            {
                cbAgR.Checked = false; cbLecR.Checked = false; cbModR.Checked = false; cbElimR.Checked = false;
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {
            if (!cbElimM.Checked)
            {
                cbAgM.Checked = true; cbLecM.Checked = true; cbModM.Checked = true; cbElimM.Checked = true;
            }
            else
            {
                cbAgM.Checked = false; cbLecM.Checked = false; cbModM.Checked = false; cbElimM.Checked = false;
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {
            if (!cbElimU.Checked)
            {
                cbAgU.Checked = true; cbLecU.Checked = true; cbModU.Checked = true; cbElimU.Checked = true;
            }
            else
            {
                cbAgU.Checked = false; cbLecU.Checked = false; cbModU.Checked = false; cbElimU.Checked = false;
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {
            if (!SeleccionadoTodo)
            {
                cbAgH.Checked = true; cbLecH.Checked = true; cbModH.Checked = true; cbElimH.Checked = true;
                cbAgR.Checked = true; cbLecR.Checked = true; cbModR.Checked = true; cbElimR.Checked = true;
                cbAgM.Checked = true; cbLecM.Checked = true; cbModM.Checked = true; cbElimM.Checked = true;
                cbAgU.Checked = true; cbLecU.Checked = true; cbModU.Checked = true; cbElimU.Checked = true;
                SeleccionadoTodo = true;
                label12.Text = "Desmarcar todo";
            }
            else
            {
                cbAgH.Checked = false; cbLecH.Checked = false; cbModH.Checked = false; cbElimH.Checked = false;
                cbAgR.Checked = false; cbLecR.Checked = false; cbModR.Checked = false; cbElimR.Checked = false;
                cbAgM.Checked = false; cbLecM.Checked = false; cbModM.Checked = false; cbElimM.Checked = false;
                cbAgU.Checked = false; cbLecU.Checked = false; cbModU.Checked = false; cbElimU.Checked = false;
                SeleccionadoTodo = false;
                label12.Text = "Seleccionar todo";
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (FrmUsuarios.IdUsuario > 0)
            {
                mu.Modificar(FrmUsuarios.IdUsuario, txtNombre, txtApellidoP, txtApellidoM, dtpFechaNacimiento, txtRFC);
                if (cbCamPassUser.Checked)
                {
                    mu.CambiarUserPass(FrmUsuarios.IdUsuario, txtUsuario, txtContraseña);
                }
                ActualizarPermisos();
            }
            else
            {
                MessageBox.Show(mu.Guardar(txtNombre, txtApellidoP, txtApellidoM, dtpFechaNacimiento, txtRFC, txtUsuario, txtContraseña));
                IdUsuario = mu.ConsultarID(txtUsuario);
                MessageBox.Show(IdUsuario.ToString());
                AñadirPermisos();                
            }
            Close();
        }

        private void AñadirPermisos()
        {            
            mp.AsignarPermisos(IdUsuario, Herramientas, cbLecH, cbAgH, cbElimH, cbModH);
            mp.AsignarPermisos(IdUsuario, Productos, cbLecR, cbAgR, cbElimR, cbModR);
            mp.AsignarPermisos(IdUsuario, Marcas, cbLecM, cbAgM, cbElimM, cbModM);
            mp.AsignarPermisos(IdUsuario, Usuarios, cbLecU, cbAgU, cbElimU, cbModU);
        }

        private void ActualizarPermisos()
        {
            mp.ActualizarPermisos(IdUsuario, Herramientas, cbLecH, cbAgH, cbElimH, cbModH);
            mp.ActualizarPermisos(IdUsuario, Productos, cbLecR, cbAgR, cbElimR, cbModR);
            mp.ActualizarPermisos(IdUsuario, Marcas, cbLecM, cbAgM, cbElimM, cbModM);
            mp.ActualizarPermisos(IdUsuario, Usuarios, cbLecU, cbAgU, cbElimU, cbModU);
        }

        private void VerificarPermisos()
        {
            cbLecH.Checked = mp.ConsultarLectura(IdUsuario, Herramientas);
            cbAgH.Checked = mp.ConsultarEscritura(IdUsuario, Herramientas);
            cbModH.Checked = mp.ConsultarModificacion(IdUsuario, Herramientas);
            cbElimH.Checked = mp.ConsultarEliminacion(IdUsuario, Herramientas);

            cbLecR.Checked = mp.ConsultarLectura(IdUsuario, Productos);
            cbAgR.Checked = mp.ConsultarEscritura(IdUsuario, Productos);
            cbModR.Checked = mp.ConsultarModificacion(IdUsuario, Productos);
            cbElimR.Checked = mp.ConsultarEliminacion(IdUsuario, Productos);

            cbLecM.Checked = mp.ConsultarLectura(IdUsuario, Marcas);
            cbAgM.Checked = mp.ConsultarEscritura(IdUsuario, Marcas);
            cbModM.Checked = mp.ConsultarModificacion(IdUsuario, Marcas);
            cbElimM.Checked = mp.ConsultarEliminacion(IdUsuario, Marcas);

            cbLecU.Checked = mp.ConsultarLectura(IdUsuario, Usuarios);
            cbAgU.Checked = mp.ConsultarEscritura(IdUsuario, Usuarios);
            cbModU.Checked = mp.ConsultarModificacion(IdUsuario, Usuarios);
            cbElimU.Checked = mp.ConsultarEliminacion(IdUsuario, Usuarios);

        }
    }
}