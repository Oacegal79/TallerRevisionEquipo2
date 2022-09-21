using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taller.App.Dominio.Entidades
{
    public class JefeOperaciones: Persona
    {
        public string JefeOperacionesId {get; set;}
        public string Correo {get; set;}
        public string NivelEstudio {get; set;}
    }
}
