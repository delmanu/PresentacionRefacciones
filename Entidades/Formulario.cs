using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    internal class Formulario
    {
        public Formulario(int idFormulario, string nombreFormulario)
        {
            IdFormulario = idFormulario;
            NombreFormulario = nombreFormulario;
        }

        public int IdFormulario { get; set; }
        public string NombreFormulario { get; set; }
    }
}
