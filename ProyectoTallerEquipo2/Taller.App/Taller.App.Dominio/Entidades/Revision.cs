using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taller.App.Dominio.Entidades
{
    public class Revision
    {
        public string RevisionId {get; set;}
        public string FechaEntrada {get; set;}
        public string FechaSalida {get; set;}
        public string Observaciones {get; set;}
        public string VehiculoId {get;set;}
        public string MecanicoId {get;set;}
        public string RepuestoId{ get; set; }
    }
}