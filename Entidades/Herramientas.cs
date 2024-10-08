using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    internal class Herramientas
    {
        public Herramientas(string codigoHerramientas, string nombreHerramienta, string medida, string descripcion, int fkIDMarca)
        {
            CodigoHerramientas = codigoHerramientas;
            NombreHerramienta = nombreHerramienta;
            Medida = medida;
            Descripcion = descripcion;
            this.fkIDMarca = fkIDMarca;
        }

        public string CodigoHerramientas { get; set; }
        public string NombreHerramienta { get; set; }
        public string Medida { get; set; }
        public string Descripcion { get; set; }
        public int fkIDMarca { get; set; }

    }
}
