using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using System.Drawing;

namespace Manejadores
{
    public class ManejadorRefacciones
    {
        Base b = new Base("localhost", "root", "", "taller");
        public string Guardar(TextBox CodigoBarras, TextBox Nombre, TextBox Descripcion, TextBox fkIdMrca)
        {
            try
            {
                return b.Comando($"INSERT INTO Refacciones VALUES('{CodigoBarras.Text}','{Nombre.Text}','{Descripcion.Text}','{fkIdMrca.Text}')");
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
            Tabla.DataSource = b.Consultar($"SELECT * FROM Refacciones WHERE nombre like '%{filtro}%'", "Refacciones").Tables[0];
            Tabla.Columns.Insert(4, Boton("Eliminar", Color.Red));
            Tabla.Columns.Insert(5, Boton("Modificar", Color.Green));
            Tabla.AutoResizeColumns();
            Tabla.AutoResizeRows();
        }
        public void Borrar(string id, string dato)
        {
            DialogResult rs = MessageBox.Show($"¿Estas seguro de borrar {dato}?", "ATENCION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                b.Comando($"DELETE FROM Refacciones WHERE codigoBarras = {id}");
                MessageBox.Show("Registro Eliminado", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void Modificar(string id, TextBox CodigoBarras, TextBox Nombre, TextBox Descripcion, TextBox fkIdMrca)
        {
            b.Comando($"UPDATE Herramientas SET " + $"codigoBarras='{CodigoBarras.Text}'," + $"nombre='{Nombre.Text}'," + $"descripcion={Descripcion.Text}'," + $"fkIdMarca={fkIdMrca}'," + $"WHERE codigoBarras={id}");
            MessageBox.Show("Registro Modificado", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
