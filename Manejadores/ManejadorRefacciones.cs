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
        public string Guardar(TextBox CodigoBarras, TextBox Nombre, TextBox Descripcion, int IdMarca)
        {
            try
            {
                return b.Comando($"INSERT INTO Refacciones VALUES('{CodigoBarras.Text}','{Nombre.Text}','{Descripcion.Text}',{IdMarca})");
            }
            catch (Exception)
            {
                return "Error de Valor";
            }
        }
        
        public void Mostrar(DataGridView Tabla, string filtro)
        {
            Tabla.Columns.Clear();
            Tabla.DataSource = b.Consultar($"SELECT r.codigoBarras, r.nombre, m.idMarca, m.nombre AS 'Marca', r.descripcion FROM refacciones r JOIN marcas m WHERE fkIdMarca = IdMarca AND r.nombre like '%{filtro}%'", "Refacciones").Tables[0];
//            Tabla.Columns.Insert(4, Boton("Eliminar", Color.Red));
//            Tabla.Columns.Insert(5, Boton("Modificar", Color.Green));
            Tabla.AutoResizeColumns();
            Tabla.AutoResizeRows();
        }
        public void Borrar(string id, string dato)
        {
            DialogResult rs = MessageBox.Show($"¿Estas seguro de borrar {dato}?", "ATENCION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                b.Comando($"DELETE FROM Refacciones WHERE codigoBarras = '{id}'");
                MessageBox.Show("Registro Eliminado", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void Modificar(TextBox CodigoBarras, TextBox Nombre, TextBox Descripcion, int IdMarca)
        {
//            MessageBox.Show($"UPDATE refacciones SET nombre = '{Nombre.Text}', descripcion = '{Descripcion.Text}', fkIdMarca = {IdMarca} WHERE codigoBarras = '{CodigoBarras.Text}'", "TEST");
            b.Comando($"UPDATE refacciones SET nombre = '{Nombre.Text}', descripcion = '{Descripcion.Text}', fkIdMarca = {IdMarca} WHERE codigoBarras = '{CodigoBarras.Text}'");
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
