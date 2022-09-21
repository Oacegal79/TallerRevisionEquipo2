using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taller.App.Dominio.Entidades
{
    public class Mecanico: Persona
    {
        public string MecanicoId {get; set;}
        public string NivelEstudio {get; set;}
        public string Direccion {get; set;}

        public string Revision {get; set;}
    }
}
