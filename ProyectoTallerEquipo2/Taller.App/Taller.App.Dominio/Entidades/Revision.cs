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
        public virtual Vehiculo Vehiculo {get;set;}
        public String MecanicoId {get;set;}
        public virtual Mecanico Mecanico {get;set;}
        public virtual ICollection<Repuesto> Repuestos { get; set; }
    }
}