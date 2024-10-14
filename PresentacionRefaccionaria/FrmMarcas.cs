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
    public partial class FrmMarcas : Form
    {
        ManejadorMarcas mm;
        public static int fila, columna, IdMarca;
        public static string Nombre, Descripcion;
        public FrmMarcas()
        {
            InitializeComponent();
            mm = new ManejadorMarcas();
        }

        private void FrmMarcas_Load(object sender, EventArgs e)
        {
            mm.Mostrar(dtgvMarcas, txtBuscar.Text);
            btnAgregar.Enabled = FrmMenu.AddMar;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            IdMarca = 0; Nombre = ""; Descripcion = "";

            FrmAgregarMarca am = new FrmAgregarMarca();
            am.ShowDialog();
            mm.Mostrar(dtgvMarcas, txtBuscar.Text);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            IdMarca = int.Parse(dtgvMarcas.Rows[fila].Cells[0].Value.ToString());
            Nombre = dtgvMarcas.Rows[fila].Cells[1].Value.ToString();
            Descripcion = dtgvMarcas.Rows[fila].Cells[2].Value.ToString();

            FrmAgregarMarca am = new FrmAgregarMarca();
            am.ShowDialog();

            mm.Mostrar(dtgvMarcas, txtBuscar.Text);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            mm.Mostrar(dtgvMarcas, txtBuscar.Text);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            IdMarca = int.Parse(dtgvMarcas.Rows[fila].Cells[0].Value.ToString());
            Nombre = dtgvMarcas.Rows[fila].Cells[1].Value.ToString();
            mm.Borrar(IdMarca, Nombre);
        }

        private void dtgvMarcas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fila = e.RowIndex; columna = e.ColumnIndex;
            if (columna >= 0 && fila > -1)
            {
                if (FrmMenu.ElimMar)
                    btnEliminar.Enabled = true;
                if (FrmMenu.ModMar)
                    btnModificar.Enabled = true;
            }
            else
            {
                btnEliminar.Enabled = false; btnModificar.Enabled = false;
            }
        }
    }
}
