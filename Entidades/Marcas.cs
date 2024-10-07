using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Marcas
    {
        public Marcas(int idMarcas, string nombre, string descripcion)
        {
            IdMarcas = idMarcas;
            Nombre = nombre;
            Descripcion = descripcion;
        }

        public int IdMarcas { get; set; }
        public string Nombre { get;set; }
        public string Descripcion { get;}
    }
}
