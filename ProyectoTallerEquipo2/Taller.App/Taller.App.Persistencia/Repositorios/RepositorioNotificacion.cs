using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taller.App.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace Taller.App.Persistencia
{
    public class RepositorioNotificacion
    {
        private readonly ContextDb dbContext;

        public RepositorioNotificacion(ContextDb dbContext)
        {
            this.dbContext = dbContext;
        }

        public Notificacion AgregarNotificacion(Notificacion n)
        {
            var notificacionNuevo = this.dbContext.Notificaciones.Add(n);
            this.dbContext.SaveChanges();
            return notificacionNuevo.Entity;
        }
    }
}