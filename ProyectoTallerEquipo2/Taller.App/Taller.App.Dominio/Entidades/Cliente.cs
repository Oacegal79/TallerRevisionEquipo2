using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taller.App.Dominio.Entidades
{
    public class Cliente: Persona
    {
        public string ClienteId {get; set;}
        public string CiudadResidencia {get; set;}
        public string Correo {get; set;}
    }
}