using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    internal class Usuarios
    {
        public Usuarios(int idUsuario, string nombreUsuario, string apellidoP, string apellidoM, 
            string fechaNacimiento, string rFC, string usuario, string contraseña)
        {
            IdUsuario = idUsuario;
            NombreUsuario = nombreUsuario;
            ApellidoP = apellidoP;
            ApellidoM = apellidoM;
            FechaNacimiento = fechaNacimiento;
            RFC = rFC;
            Usuario = usuario;
            Contraseña = contraseña;
        }

        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string ApellidoP { get; set; }
        public string ApellidoM { get; set; }
        public string FechaNacimiento { get; set; }
        public string RFC { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
    }
}
