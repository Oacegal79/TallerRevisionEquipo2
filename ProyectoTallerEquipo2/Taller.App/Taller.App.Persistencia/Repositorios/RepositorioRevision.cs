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
        public IEnumerable<Revision> ObtenerRevisiones()
        {
            return this.dbContext.Revisiones;
        }

        public Revision BuscarRevision(String idRevision)
        {
            return this.dbContext.Revisiones.FirstOrDefault(re => re.RevisionId == idRevision);
        }

        public void EditarRevision(Revision RevisionNuevo, string idRevision)
        {
            var revisionActual = this.dbContext.Revisiones.FirstOrDefault(m => m.RevisionId == idRevision);
            if (revisionActual != null)
            {
                revisionActual.FechaEntrada = RevisionNuevo.FechaEntrada;
                revisionActual.FechaSalida = RevisionNuevo.FechaSalida;
                revisionActual.Observaciones = RevisionNuevo.Observaciones;
                revisionActual.VehiculoId = RevisionNuevo.VehiculoId;
                revisionActual.MecanicoId = RevisionNuevo.MecanicoId;
                revisionActual.RepuestoId = RevisionNuevo.RepuestoId;
            }
            this.dbContext.SaveChanges();
        }

        public void EliminarRevision(String idRevision)
        {
            var RevisionEncontrado = this.dbContext.Revisiones.FirstOrDefault(m => m.RevisionId == idRevision);
            if (RevisionEncontrado != null)
            {
                this.dbContext.Revisiones.Remove(RevisionEncontrado);
                this.dbContext.SaveChanges();
            }
            
        }
    }
}