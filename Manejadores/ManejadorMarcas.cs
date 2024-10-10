using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manejadores
{
    public class ManejadorMarcas
    {
        Base b = new Base("localhost", "root", "", "taller");
        public string Guardar(TextBox Nombre, TextBox Descripcion)
        {
            try
            {
                return b.Comando($"INSERT INTO marcas VALUES (NULL, '{Nombre.Text}', '{Descripcion.Text}')");
            }
            catch (Exception)
            {
                return "Error de Valor";
            }
        }
        
        public void Mostrar(DataGridView Tabla, string filtro)
        {
            Tabla.Columns.Clear();
            Tabla.DataSource = b.Consultar($"SELECT * FROM marcas WHERE nombre like '%{filtro}%'", "marcas").Tables[0];
            //            Tabla.Columns.Insert(4, Boton("Eliminar", Color.Red));
            //            Tabla.Columns.Insert(5, Boton("Modificar", Color.Green));
            Tabla.AutoResizeColumns();
            Tabla.AutoResizeRows();
        }

        public string Borrar(int id, string dato)
        {
            DialogResult rs = MessageBox.Show($"¿Estas seguro de borrar: {dato}?", "¡Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                MessageBox.Show("Registro Eliminado", "¡Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return b.Comando($"DELETE FROM marcas WHERE idMarca = {id}");
            }
            else
                return "Se cancelo la opción.";
        }

        public void Modificar(int IdMarca, TextBox Nombre, TextBox Descripcion)
        {
            b.Comando($"UPDATE marcas SET nombre = '{Nombre.Text}', Descripcion = '{Descripcion.Text}' WHERE idMarca = {IdMarca}");
            MessageBox.Show("Registro Modificado", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        DataGridViewButtonColumn Boton(string t, Color f)
        {
            DataGridViewButtonColumn x = new DataGridViewButtonColumn();
            x.Text = t;
            x.UseColumnTextForButtonValue = true;
            x.FlatStyle = FlatStyle.Popup;
            x.DefaultCellStyle.ForeColor = Color.White;
            x.DefaultCellStyle.BackColor = f;
            return x;
        }
    }
}

