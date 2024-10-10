using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccesoDatos;
using Entidades;

namespace Manejadores
{
    public class ManejadorHerramientas
    {
        Base b = new Base("localhost", "root", "", "taller");
        public string Guardar(TextBox CodigoHerramienta, TextBox Nombre, TextBox Medida, int IdMarca, TextBox Descripcion)
        {
            try
            {
                return b.Comando($"INSERT INTO Herramientas VALUES('{CodigoHerramienta.Text}','{Nombre.Text}','{Medida.Text}', {IdMarca}, '{Descripcion.Text}')");
            }
            catch (Exception)
            {
                return "Error de Valor";
            }
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
        public void Mostrar(DataGridView Tabla, string filtro)
        {
            Tabla.Columns.Clear();
            Tabla.DataSource = b.Consultar($"SELECT * FROM Herramientas WHERE nombre like '%{filtro}%'", "Herramientas").Tables[0];
//            Tabla.Columns.Insert(4, Boton("Eliminar", Color.Red));
//            Tabla.Columns.Insert(5, Boton("Modificar", Color.Green));
            Tabla.AutoResizeColumns();
            Tabla.AutoResizeRows();
        }
        public string Borrar(string id, string dato)
        {
            DialogResult rs = MessageBox.Show($"¿Estas seguro de borrar: {dato}?", "¡Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                MessageBox.Show("Registro Eliminado", "¡Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return b.Comando($"DELETE FROM Herramientas WHERE codigoHerramienta = '{id}'");
            }
            else
                return "Se cancelo la opción.";
        }
        public void Modificar(TextBox codigoHerramienta, TextBox Nombre, TextBox Medida, int IdMarca, TextBox Descripcion)
        {
            b.Comando($"UPDATE herramientas SET nombre = '{Nombre.Text}', medida = '{Medida.Text}', fkIdMarca = {IdMarca}, descripcion = '{Descripcion.Text}' WHERE codigoHerramienta = '{codigoHerramienta.Text}';\r\n");
            MessageBox.Show("Registro Modificado", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
