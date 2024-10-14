using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccesoDatos;
using Entidades;

namespace Manejadores
{
    public class ManejadorUsuarios
    {
        Base b = new Base("localhost","root","","taller");
        public string Guardar(TextBox Nombre, TextBox ApellidoP, TextBox ApellidoM, DateTimePicker FechaN, TextBox RFC, TextBox Usuario, TextBox Contraseña)
        {
            try
            {
                string fr = $"{FechaN.Text.Substring(6, 4)}-{FechaN.Text.Substring(3, 2)}-{FechaN.Text.Substring(0, 2)}";
                return b.Comando($"INSERT INTO Usuarios VALUES(null,'{Nombre.Text}','{ApellidoP.Text}','{ApellidoM.Text}','{fr}','{RFC.Text}','{Usuario.Text}', SHA1('{Contraseña.Text}'))");
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
            Tabla.DataSource = b.Consultar($"SELECT * FROM Usuarios WHERE nombre like '%{filtro}%'", "Usuarios").Tables[0];
//            Tabla.Columns.Insert(4, Boton("Eliminar", Color.Red));
//           Tabla.Columns.Insert(5, Boton("Modificar", Color.Green));
            Tabla.AutoResizeColumns();
            Tabla.AutoResizeRows();
        }
        public void Borrar(int id, string dato)
        {
            DialogResult rs = MessageBox.Show($"¿Estas seguro de borrar {dato}?", "ATENCION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                b.Comando($"DELETE FROM Permisos Where fkIdUsuario = {id}");
                b.Comando($"DELETE FROM Usuarios WHERE idUsuario = {id}");
                MessageBox.Show("Registro Eliminado", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void Modificar(int id, TextBox Nombre, TextBox ApellidoP, TextBox ApellidoM, DateTimePicker FechaN, TextBox RFC)
        {
            string fr = $"{FechaN.Text.Substring(6, 4)}-{FechaN.Text.Substring(3, 2)}-{FechaN.Text.Substring(0, 2)}";
            b.Comando($"UPDATE usuarios SET nombre = '{Nombre.Text}', apellidoP = '{ApellidoP.Text}', apellidoM = '{ApellidoM.Text}', fechaNacimiento = '{fr}', RFC = '{RFC.Text}' WHERE idUsuario = {id}");
            MessageBox.Show("Registro Modificado", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void CambiarUserPass(int IdUsuario, TextBox Usuario, TextBox Contrasena)
        {
            b.Comando($"UPDATE usuarios SET usuario = '{Usuario.Text}', contrasena = SHA1('{Contrasena.Text}') WHERE idUsuario = {IdUsuario}");
        }

        public int ConsultarID(TextBox Usuario)
        {
            DataSet ds = b.Consultar($"SELECT idUsuario FROM usuarios WHERE usuario = '{Usuario.Text}'", "usuarios");
            DataTable dt = ds.Tables[0];

            return int.Parse(dt.Rows[0]["idUsuario"].ToString());
        }

        public string ObtenerNombre(int ID)
        {
            DataSet ds = b.Consultar($"SELECT nombre FROM usuarios WHERE idUsuario = {ID}", "usuarios");
            DataTable dt = ds.Tables[0];

            return dt.Rows[0]["nombre"].ToString();
        }
    }
}
