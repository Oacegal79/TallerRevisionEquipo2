using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taller.App.Dominio.Entidades
{
    public class Notificacion
    {
        public string NotificacionId {get; set;}
        public string Titulo {get; set;}
        public string Cuerpo {get; set;}
        public string Fecha {get; set;}
        public string Destino {get; set;}
    }
}