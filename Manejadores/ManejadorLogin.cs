using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccesoDatos;

namespace Manejadores
{
    public class ManejadorLogin
    {
        Base b = new Base("localhost", "root", "", "taller");
        
        public string Validar(TextBox nic, TextBox clave)
        {
            try
            {
                DataSet ds = b.Consultar($"call p_Validar('{nic.Text}', '{Sha1(clave.Text)}')", "usuarios");
                DataTable dt = ds.Tables[0];

                if (dt.Rows[0]["rs"].ToString().Equals("C0rr3ct0"))
                    return dt.Rows[0]["rs"].ToString();
                else
                    return "Error";
            }
            catch (Exception)
            {
                MessageBox.Show($"El usuario y/o contraseña son incorrectos", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "Error";
            }

        }

        public static string Sha1(string Texto)
        {
            SHA1 sha1 = SHA1CryptoServiceProvider.Create();
            Byte[] textOriginal = ASCIIEncoding.Default.GetBytes(Texto);
            Byte[] hash = sha1.ComputeHash(textOriginal);
            StringBuilder cadena = new StringBuilder();
            foreach (Byte i in hash)
            {
                cadena.AppendFormat("{0:x2}", i);
            }
            return cadena.ToString();
        }
    }
}
