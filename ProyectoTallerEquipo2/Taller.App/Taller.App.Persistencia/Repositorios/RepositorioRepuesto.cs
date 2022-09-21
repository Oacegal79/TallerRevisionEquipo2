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
    public class RepositorioRepuesto
    {
        private readonly ContextDb dbContext;

        public RepositorioRepuesto(ContextDb dbContext)
        {
            this.dbContext = dbContext;
        }

        public Repuesto AgregarRespuesto(Repuesto r)
        {
            var repuestoNuevo = this.dbContext.Repuestos.Add(r);
            this.dbContext.SaveChanges();
            return repuestoNuevo.Entity;
        }
    }
}