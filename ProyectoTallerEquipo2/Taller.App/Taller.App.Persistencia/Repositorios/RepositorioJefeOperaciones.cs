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
    public class RepositorioJefeOperaciones
    {
        private readonly ContextDb dbContext;

        public RepositorioJefeOperaciones(ContextDb dbContext)
        {
            this.dbContext = dbContext;
        }

        public JefeOperaciones AgregarJefeOperaciones(JefeOperaciones jo)
        {
            var jefeNuevo = this.dbContext.JefesOperaciones.Add(jo);
            this.dbContext.SaveChanges();
            return jefeNuevo.Entity;
        }
    }
}