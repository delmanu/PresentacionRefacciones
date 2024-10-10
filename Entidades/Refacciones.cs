using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    internal class Refacciones
    {
        public Refacciones(string codigoBarras, string nombre, string descripcion, int fkIDMarca)
        {
            CodigoBarras = codigoBarras;
            Nombre = nombre;
            Descripcion = descripcion;
            this.fkIDMarca = fkIDMarca;
        }

        public string CodigoBarras { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int fkIDMarca { get; set; }
    }
}
