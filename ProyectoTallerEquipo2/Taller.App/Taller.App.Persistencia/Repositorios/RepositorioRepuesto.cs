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

        public Repuesto AgregarRepuesto(Repuesto r)
        {
            var repuestoNuevo = this.dbContext.Repuestos.Add(r);
            this.dbContext.SaveChanges();
            return repuestoNuevo.Entity;
        }
        public IEnumerable<Repuesto> ObtenerRepuestos()
        {
            return this.dbContext.Repuestos;
        }

        public Repuesto BuscarRepuestos(string idRepuesto)
        {
            return this.dbContext.Repuestos.FirstOrDefault(re => re.RepuestoId == idRepuesto);
        }

        public void EditarRepuesto(Repuesto RepuestoNuevo, string idRepuesto)
        {
            var repuestoActual = this.dbContext.Repuestos.FirstOrDefault(m => m.RepuestoId == idRepuesto);
            if (repuestoActual != null)
            {
                repuestoActual.Tipo = RepuestoNuevo.Tipo;
                repuestoActual.Cantidad = RepuestoNuevo.Cantidad;
                repuestoActual.Nombre = RepuestoNuevo.Nombre;
            }
            this.dbContext.SaveChanges();
        }

        public void EliminarRepuesto(string idRepuesto)
        {
            var RepuestoEncontrado = this.dbContext.Repuestos.FirstOrDefault(m => m.RepuestoId == idRepuesto);
            if (RepuestoEncontrado != null)
            {
                this.dbContext.Repuestos.Remove(RepuestoEncontrado);
                this.dbContext.SaveChanges();
            }
            
        }
    }
}