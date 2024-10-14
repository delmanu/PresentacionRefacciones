using Manejadores;
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
    public partial class FrmAgregarProducto : Form
    {
        ManejadorMarcas mm;
        ManejadorRefacciones mr;
        public static int IdMarca = 0, fila, columna;
        public static string NombreMarca;
        public FrmAgregarProducto()
        {
            InitializeComponent();
            mr = new ManejadorRefacciones();
            mm = new ManejadorMarcas();

            if (!FrmProductos.CodigoBarras.Equals(""))
            {
                txtCodigo.Text = FrmProductos.CodigoBarras;
                txtCodigo.Enabled = false;
                txtNombre.Text = FrmProductos.NombreRefaccion;
                txtMarca.Text = $"{FrmProductos.IdMarca} -- {FrmProductos.NombreMarca}";
                IdMarca = FrmProductos.IdMarca;
                txtDescripcion.Text = FrmProductos.Descripcion;

                btnAgregar.Text = "Editar";

            }
        }               
          
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FrmProductos.CodigoBarras.Equals(""))
                {
                    mr.Modificar(txtCodigo, txtNombre, txtDescripcion, IdMarca);
                    Close();
                }
                else
                {
                    if (IdMarca != 0)
                    {
                        MessageBox.Show(mr.Guardar(txtCodigo, txtNombre, txtDescripcion, IdMarca), "¡Atención!", MessageBoxButtons.OK);
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Tiene que seleccionar una marca para guardar.", "¡Cuidado!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }                  
                }
            }
            catch
            {
                MessageBox.Show("Ha ocurrido un error... \n\n¡Compruebe la información!", "¡ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void txtMarca_TextChanged(object sender, EventArgs e)
        {
            mm.Mostrar(dtgvMarcas, txtMarca.Text);
        }

        private void FrmAgregarProducto_Load(object sender, EventArgs e)
        {
            mm.Mostrar(dtgvMarcas, txtMarca.Text);
            btnSeleccionarMarca.Enabled = false;
        }

        private void dtgvMarcas_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            fila = e.RowIndex; columna = e.ColumnIndex;
            if (columna >= 0 && fila > -1)
            {
                btnSeleccionarMarca.Enabled = true;
            }
            else
            {
                btnSeleccionarMarca.Enabled = false;
            }
        }

        private void btnSeleccionarMarca_Click(object sender, EventArgs e)
        {
            IdMarca = int.Parse(dtgvMarcas.Rows[fila].Cells[0].Value.ToString());
            NombreMarca = dtgvMarcas.Rows[fila].Cells[1].Value.ToString();

            txtMarca.Text = $"{IdMarca} -- {NombreMarca}";
        }
    }
}
