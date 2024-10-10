using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    internal class Permisos
    {
        public Permisos(int iDPermiso, int fkIDFormulario, int fkIDUsuario, int lectura, 
            int escritura, int eliminacion, int actualizacion)
        {
            IDPermiso = iDPermiso;
            this.fkIDFormulario = fkIDFormulario;
            this.fkIDUsuario = fkIDUsuario;
            Lectura = lectura;
            Escritura = escritura;
            Eliminacion = eliminacion;
            Actualizacion = actualizacion;
        }

        public int IDPermiso { get; set; }
        public int fkIDFormulario { get; set; }
        public int fkIDUsuario { get; set; }
        public int Lectura { get; set; }
        public int Escritura { get; set; }
        public int Eliminacion { get; set; }
        public int Actualizacion { get; set; }
    }
}
