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
using System.Runtime.Hosting;

namespace Manejadores
{
    public class ManejadorPermisos
    {
        Base b = new Base("localhost", "root", "", "taller");
        
        public bool ConsultarLectura(int idUsuario, int idFormulario) 
        {
            DataSet Lec = b.Consultar($"SELECT Lectura FROM Permisos WHERE fkIdUsuario = {idUsuario} AND fkIdFormulario = {idFormulario}", "Permisos");
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
        
        public bool ConsultarEscritura(int idUsuario, int idFormulario)
        {
            DataSet Esc = b.Consultar($"SELECT Escritura FROM Permisos WHERE fkIdUsuario = {idUsuario} AND fkIdFormulario = {idFormulario}", "Permisos");
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
        
        public bool ConsultarEliminacion(int idUsuario, int idFormulario)
        {
            DataSet Del = b.Consultar($"SELECT Eliminacion FROM Permisos WHERE fkIdUsuario = {idUsuario} AND fkIdFormulario = {idFormulario}", "Permisos");
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
        
        public bool ConsultarModificacion(int idUsuario, int idFormulario)
        {
            DataSet Mod = b.Consultar($"SELECT Actualizacion FROM Permisos WHERE fkIdUsuario = {idUsuario} AND fkIdFormulario = {idFormulario}", "Permisos");
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

        public void ActualizarPermisos(int idu, int idf, CheckBox Lectura, CheckBox Escritura, CheckBox Eliminacion, CheckBox Actualizacion)
        {
            int lectura = 0, escritura = 0, eliminacion = 0, actualizacion = 0;

            if (Lectura.Checked)
                lectura = 1;

            if (Escritura.Checked)
                escritura = 1;

            if (Eliminacion.Checked)
                eliminacion = 1;

            if (Actualizacion.Checked)
                actualizacion = 1;
                        
            b.Comando($"UPDATE Permisos SET Lectura = {lectura}, Escritura = {escritura}, Eliminacion = {eliminacion}, Actualizacion = {actualizacion} WHERE fkiDUsuario = {idu} AND fkiDFormulario = {idf}");
            
        }

        public void AsignarPermisos(int idu, int idf, CheckBox Lectura, CheckBox Escritura, CheckBox Eliminacion, CheckBox Actualizacion)
        {
            int lectura = 0, escritura = 0, eliminacion = 0, actualizacion = 0;

            if (Lectura.Checked)
                lectura = 1;

            if (Escritura.Checked)
                escritura = 1;

            if (Eliminacion.Checked)
                eliminacion = 1;

            if (Actualizacion.Checked)
                actualizacion = 1;

            b.Comando($"INSERT INTO permisos (fkIdFormulario, fkIdUsuario, Lectura, Escritura, Eliminacion, Actualizacion) VALUES ({idf}, {idu}, {lectura}, {escritura}, {eliminacion}, {actualizacion});");
        }
    }
}
