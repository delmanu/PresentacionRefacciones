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
    public partial class FrmProductos : Form
    {
        public static int fila, columna, IdMarca;
        public static string CodigoBarras, NombreRefaccion, NombreMarca, Descripcion;
        ManejadorRefacciones mr;
                
        public FrmProductos()
        {
            InitializeComponent();
            mr = new ManejadorRefacciones();
        }       

        private void FrmProductos_Load(object sender, EventArgs e)
        {
            mr.Mostrar(dtgvRefacciones, txtBuscar.Text);
            btnAgregar.Enabled = FrmMenu.AddPro;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            mr.Mostrar(dtgvRefacciones, txtBuscar.Text);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            IdMarca = 0; CodigoBarras = ""; NombreMarca = ""; NombreRefaccion = ""; Descripcion = "";

            FrmAgregarProducto ap = new FrmAgregarProducto();
            ap.ShowDialog();

            mr.Mostrar(dtgvRefacciones, txtBuscar.Text);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            CodigoBarras = dtgvRefacciones.Rows[fila].Cells[0].Value.ToString();
            NombreRefaccion = dtgvRefacciones.Rows[fila].Cells[1].Value.ToString();
            IdMarca = int.Parse(dtgvRefacciones.Rows[fila].Cells[2].Value.ToString());
            NombreMarca = dtgvRefacciones.Rows[fila].Cells[3].Value.ToString();
            Descripcion = dtgvRefacciones.Rows[fila].Cells[4].Value.ToString();

            FrmAgregarProducto ap = new FrmAgregarProducto();
            ap.ShowDialog();

            mr.Mostrar(dtgvRefacciones, txtBuscar.Text);
            IdMarca = 0; CodigoBarras = ""; NombreMarca = ""; NombreRefaccion = ""; Descripcion = "";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            CodigoBarras = dtgvRefacciones.Rows[fila].Cells[0].Value.ToString();
            NombreRefaccion = dtgvRefacciones.Rows[fila].Cells[1].Value.ToString();

            mr.Borrar(CodigoBarras, NombreRefaccion);

            mr.Mostrar(dtgvRefacciones, txtBuscar.Text);
        }

        private void dtgvRefacciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fila = e.RowIndex; columna = e.ColumnIndex;
            if (columna >= 0 && fila > -1)
            {
                if (FrmMenu.ElimPro)
                    btnEliminar.Enabled = true;
                if (FrmMenu.ModPro)
                    btnModificar.Enabled = true;
            }
            else
            {
                btnEliminar.Enabled = false; btnModificar.Enabled = false;
            }
        }
    }
}
