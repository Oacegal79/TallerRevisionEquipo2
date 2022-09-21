using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taller.App.Dominio.Entidades
{
    public class Repuesto
    {
        public string RepuestoId {get; set;}
        public string Tipo {get; set;}
        public string Nombre {get; set;}
        public string Cantidad {get; set;}
    }
}