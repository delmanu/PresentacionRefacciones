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
    public partial class FrmAgregarHerramienta : Form
    {
        ManejadorMarcas mm;
        ManejadorHerramientas mh;
        public static int IdMarca, fila, columna;
        public static string NombreMarca;
        public FrmAgregarHerramienta()
        {
            InitializeComponent();
            mh = new ManejadorHerramientas();
            mm = new ManejadorMarcas();

            if(!FrmHerramientas.Codigo.Equals(""))
            {
                txtCodigo.Text = FrmHerramientas.Codigo;
                txtNombre.Text = FrmHerramientas.Nombre;
                txtMedida.Text = FrmHerramientas.Medida;
                txtMarca.Text = FrmHerramientas.IdMarca.ToString();
                IdMarca = FrmHerramientas.IdMarca;
                txtDescripcion.Text = FrmHerramientas.Descripcion;

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
                if (!FrmHerramientas.Codigo.Equals(""))
                {
                    mh.Modificar(txtCodigo, txtNombre, txtMedida, IdMarca, txtDescripcion);
                    Close();
                }
                else
                {
                    MessageBox.Show(mh.Guardar(txtCodigo, txtNombre, txtMedida, IdMarca, txtDescripcion), "¡Atención!", MessageBoxButtons.OK);
                    Close();
                }                                  
            }
            catch
            {
                MessageBox.Show("Ha ocurrido un error... \n\n¡Compruebe la información!", "¡ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void FrmAgregarHerramienta_Load(object sender, EventArgs e)
        {
            mm.Mostrar(dtgvMarcas, txtMarca.Text);
            btnSeleccionarMarca.Enabled = false;
        }

        private void txtMarca_TextChanged(object sender, EventArgs e)
        {
            mm.Mostrar(dtgvMarcas, txtMarca.Text);
        }

        private void btnSeleccionarMarca_Click(object sender, EventArgs e)
        {
            IdMarca = int.Parse(dtgvMarcas.Rows[fila].Cells[0].Value.ToString());
            NombreMarca = dtgvMarcas.Rows[fila].Cells[1].Value.ToString();

            txtMarca.Text = $"{IdMarca} -- {NombreMarca}";
        }

        private void dtgvMarcas_CellClick(object sender, DataGridViewCellEventArgs e)
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
    }
}
