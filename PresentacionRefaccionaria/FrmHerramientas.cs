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
    public partial class FrmHerramientas : Form
    {
        ManejadorHerramientas mh;
        public static string Codigo, Nombre, Medida, Descripcion;
        public static int fila, columna, IdMarca;
        public FrmHerramientas()
        {
            InitializeComponent();
            mh = new ManejadorHerramientas();
        }

        private void FrmHerramientas_Load(object sender, EventArgs e)
        {
            mh.Mostrar(dtgvHerramientas, txtBuscar.Text);

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            mh.Mostrar(dtgvHerramientas, txtBuscar.Text);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Codigo = ""; Nombre = ""; Medida = ""; Descripcion = ""; IdMarca = 0;
            
            FrmAgregarHerramienta ah = new FrmAgregarHerramienta();
            ah.ShowDialog();
            mh.Mostrar(dtgvHerramientas, txtBuscar.Text);

        }

        private void dtgvHerramientas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fila = e.RowIndex; columna = e.ColumnIndex;
            if (columna >= 0 && fila > -1)
            {
                btnEliminar.Enabled = true; btnModificar.Enabled = true;
            }
            else
            {
                btnEliminar.Enabled = false; btnModificar.Enabled = false;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Codigo = dtgvHerramientas.Rows[fila].Cells[0].Value.ToString();
            Nombre = dtgvHerramientas.Rows[fila].Cells[1].Value.ToString();
            Medida = dtgvHerramientas.Rows[fila].Cells[2].Value.ToString();
            if (!dtgvHerramientas.Rows[fila].Cells[3].Value.ToString().Equals(""))
            {
                IdMarca = int.Parse(dtgvHerramientas.Rows[fila].Cells[3].Value.ToString());
            }
            else
            {
                IdMarca = 0;
            }
            Descripcion = dtgvHerramientas.Rows[fila].Cells[4].Value.ToString();

            FrmAgregarHerramienta ah = new FrmAgregarHerramienta();
            ah.ShowDialog();
            mh.Mostrar(dtgvHerramientas, txtBuscar.Text);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Codigo = dtgvHerramientas.Rows[fila].Cells[0].Value.ToString();
            mh.Borrar(Codigo, dtgvHerramientas.Rows[fila].Cells[1].Value.ToString());
            mh.Mostrar(dtgvHerramientas, txtBuscar.Text);
        }
    }
}
