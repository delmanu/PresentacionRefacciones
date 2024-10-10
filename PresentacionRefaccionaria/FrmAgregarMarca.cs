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
    public partial class FrmAgregarMarca : Form
    {
        ManejadorMarcas mm;
        public FrmAgregarMarca()
        {
            InitializeComponent();
            mm = new ManejadorMarcas();

            if(FrmMarcas.IdMarca > 0)
            {
                txtNombre.Text = FrmMarcas.Nombre;
                txtDescripcion.Text = FrmMarcas.Descripcion;

                btnAgregar.Text = "Editar";
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(FrmMarcas.IdMarca > 0)
            {
                mm.Modificar(FrmMarcas.IdMarca, txtNombre, txtDescripcion);
                Close();
            }
            else
            {
                MessageBox.Show(mm.Guardar(txtNombre, txtDescripcion), "¡Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
