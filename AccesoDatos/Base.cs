using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace AccesoDatos
{
    public class Base
    {
        MySqlConnection con;
        public Base(string s, string u, string p, string bd)
        {
            con = new MySqlConnection($"server={s}; user={u}; password={p}; database={bd};");
        }
        public string Comando(string q)
        {
            string rs = "";
            try
            {
                MySqlCommand i = new MySqlCommand(q, con);
                con.Open();
                i.ExecuteNonQuery();
                con.Close();
                rs = "Correcto";
            }
            catch (Exception ex)
            {
                con.Close();
                rs = ex.Message;
            }
            return rs;
        }
        public DataSet Consultar(string q, string tabla)
        {
            DataSet ds = new DataSet();
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter(q, con);
                con.Open();
                da.Fill(ds, tabla);
                con.Close();
            }
            catch (Exception)
            {
                con.Close();
            }
            return ds;
        }
    }
}
