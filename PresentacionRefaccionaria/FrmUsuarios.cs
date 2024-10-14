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
    public partial class FrmUsuarios : Form
    {
        public static int fila, columna, IdUsuario, Herramientas = 1, Productos = 2, Marcas = 3, Usuarios = 4;
        public static string Nombre, ApellidoP, ApellidoM, RFC, FechaNacimiento, Usuario;     
        ManejadorUsuarios mu;   
        public FrmUsuarios()
        {
            InitializeComponent();
            mu = new ManejadorUsuarios();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            IdUsuario = 0; Nombre = ""; ApellidoP = ""; ApellidoM = ""; FechaNacimiento = ""; RFC = ""; Usuario = "";

            IdUsuario = int.Parse(dtgvUsuarios.Rows[fila].Cells[0].Value.ToString());
            Nombre = dtgvUsuarios.Rows[fila].Cells[1].Value.ToString();
            ApellidoP = dtgvUsuarios.Rows[fila].Cells[2].Value.ToString();
            ApellidoM = dtgvUsuarios.Rows[fila].Cells[3].Value.ToString();
            FechaNacimiento = dtgvUsuarios.Rows[fila].Cells[4].Value.ToString();
            RFC = dtgvUsuarios.Rows[fila].Cells[5].Value.ToString();
            Usuario = dtgvUsuarios.Rows[fila].Cells[6].Value.ToString();

            FrmAgregarUsuario au = new FrmAgregarUsuario();
            au.ShowDialog();

            mu.Mostrar(dtgvUsuarios, txtBuscar.Text);
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            mu.Mostrar(dtgvUsuarios, txtBuscar.Text);
            btnAgregar.Enabled = FrmMenu.AddUse;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            mu.Mostrar(dtgvUsuarios, txtBuscar.Text);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            IdUsuario = 0; Nombre = ""; ApellidoP = ""; ApellidoM = ""; RFC = "";

            FrmAgregarUsuario au = new FrmAgregarUsuario();
            au.ShowDialog();

            mu.Mostrar(dtgvUsuarios, txtBuscar.Text);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            IdUsuario = int.Parse(dtgvUsuarios.Rows[fila].Cells[0].Value.ToString());
            Nombre = dtgvUsuarios.Rows[fila].Cells[1].Value.ToString();

            mu.Borrar(IdUsuario, Nombre);
            
            mu.Mostrar(dtgvUsuarios, txtBuscar.Text);
        }

        private void dtgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fila = e.RowIndex; columna = e.ColumnIndex;
            if (columna >= 0 && fila > -1)
            {
                if (FrmMenu.ElimUse)
                    btnEliminar.Enabled = true;
                if (FrmMenu.ModUse)
                    btnModificar.Enabled = true;
            }
            else
            {
                btnEliminar.Enabled = false; btnModificar.Enabled = false;
            }
        }

    }
}
