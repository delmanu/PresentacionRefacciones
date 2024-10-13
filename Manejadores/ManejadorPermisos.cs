using System;
using System.CodeDom.Compiler;
using System.Data;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Entidades;
using System.Windows.Forms;

namespace Manejadores
{
    public class ManejadorPermisos
    {
        Base b = new Base("localhost", "root", "", "taller");
        public bool ConsultarLectura(string id) {
            DataSet Lec = b.Consultar($"SELECT Lectura FROM Permisos WHERE id = '%{id}%'", "Permisos");
            if (Lec == null || Lec.Tables["Permisos"].Rows.Count == 0)
                {
                    return false;
                }
            bool lectura = Convert.ToBoolean(Lec.Tables["Permisos"].Rows[0]["Lectura"]);
            if (lectura == true) {
                return true;
            }
            else
            { 
                return false;
            }
        }
        public bool ConsultarEscritura(string id)
        {
            DataSet Esc = b.Consultar($"SELECT Escritura FROM Permisos WHERE id = '%{id}%'", "Permisos");
            if (Esc == null || Esc.Tables["Permisos"].Rows.Count == 0)
            {
                return false;
            }
            bool escritura = Convert.ToBoolean(Esc.Tables["Permisos"].Rows[0]["Escritura"]);
            if (escritura == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ConsultarEliminacion(string id)
        {
            DataSet Del = b.Consultar($"SELECT Eliminacion FROM Permisos WHERE id = '%{id}%'", "Permisos");
            if (Del == null || Del.Tables["Permisos"].Rows.Count == 0)
            {
                return false;
            }
            bool eliminacion = Convert.ToBoolean(Del.Tables["Permisos"].Rows[0]["Eliminacion"]);
            if (eliminacion == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ConsultarModificacion(string id)
        {
            DataSet Mod = b.Consultar($"SELECT Actualizacion FROM Permisos WHERE id = '%{id}%'", "Permisos");
            if (Mod == null || Mod.Tables["Permisos"].Rows.Count == 0)
            {
                return false;
            }
            bool modificacion = Convert.ToBoolean(Mod.Tables["Permisos"].Rows[0]["Actualizacion"]);
            if (modificacion == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AsignarPermisos(string idu, string idf, RadioButton Todos, RadioButton Lectura, RadioButton Escritura, RadioButton Eliminacion, RadioButton Actualizacion, RadioButton Ninguno)
        {
            if (Todos.Checked) {
                b.Comando($"UPDATE Permisos SET Lectura = 1, Escritura = 1, Eliminacion = 1, Actualizacion = 1 WHERE fkiDUsuario = {idu} AND fkiDFormulario = {idf}");
            }
            else if (Lectura.Checked)
            {
                b.Comando($"UPDATE Permisos SET Lectura = 1, Escritura = 0, Eliminacion = 0, Actualizacion = 0 WHERE fkiDUsuario = {idu} AND fkiDFormulario = {idf}");
            }
            else if (Escritura.Checked)
            {
                b.Comando($"UPDATE Permisos SET Lectura = 0, Escritura = 1, Eliminacion = 0, Actualizacion = 0 WHERE fkiDUsuario = {idu} AND fkiDFormulario = {idf}");
            }
            else if (Eliminacion.Checked)
            {
                b.Comando($"UPDATE Permisos SET Lectura = 0, Escritura = 0, Eliminacion = 1, Actualizacion = 0 WHERE fkiDUsuario = {idu} AND fkiDFormulario = {idf}");
            }
            else if (Actualizacion.Checked)
            {
                b.Comando($"UPDATE Permisos SET Lectura = 0, Escritura = 0, Eliminacion = 0, Actualizacion = 1 WHERE fkiDUsuario = {idu} AND fkiDFormulario = {idf}");
            }
            else if (Ninguno.Checked)
            {
                b.Comando($"UPDATE Permisos SET Lectura = 0, Escritura = 0, Eliminacion = 0, Actualizacion = 0 WHERE fkiDUsuario = {idu} AND fkiDFormulario = {idf}");
            }
        }
    }
}
