using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taller.App.Dominio.Entidades
{
    public class Vehiculo
    {
        public string VehiculoId {get; set;}
        public string Placa {get; set;}
        public string Tipo {get; set;}
        public string Marca {get; set;}
        public string Modelo {get; set;}
        public string NumeroPasajeros {get; set;}
        public string Cilindraje {get; set;}
        public string Pais {get; set;}
        public string Descripcion {get; set;}
    }
}