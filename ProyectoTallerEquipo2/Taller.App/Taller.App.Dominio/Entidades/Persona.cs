using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taller.App.Dominio.Entidades
{
    public class Persona
    {
        public string Nombre {get; set;}
        public string Apellido {get; set;}
        public string Telefono {get; set;}
        public string FechaNacimiento {get; set;}
        public string Contrasenia {get; set;}
        public string Rol {get; set;}
    }
}