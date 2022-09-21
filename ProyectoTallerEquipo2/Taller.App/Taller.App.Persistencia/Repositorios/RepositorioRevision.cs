using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taller.App.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace Taller.App.Persistencia.AppRepositorios
{
    public class RepositorioRevision
    {
        private readonly ContextDb dbContext;

        public RepositorioRevision(ContextDb dbContext)
        {
            this.dbContext = dbContext;
        }

        public Revision AgregarRevision(Revision re)
        {
            var revisionNuevo = this.dbContext.Revisiones.Add(re);
            this.dbContext.SaveChanges();
            return revisionNuevo.Entity;
        }
    }
}