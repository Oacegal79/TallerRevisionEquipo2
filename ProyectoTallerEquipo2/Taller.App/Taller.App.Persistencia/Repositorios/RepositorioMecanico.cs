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
    public class RepositorioMecanico
    {

        private readonly ContextDb dbContext;

        public RepositorioMecanico(ContextDb dbContext)
        {
            this.dbContext = dbContext;
        }

        public Mecanico AgregarMecanico(Mecanico m)
        {
            var mecanicoNuevo = this.dbContext.Mecanicos.Add(m);
            this.dbContext.SaveChanges();
            return mecanicoNuevo.Entity;
        }

        public IEnumerable<Mecanico> ObtenerMecanicos()
        {
            return this.dbContext.Mecanicos;
        }

        public Mecanico BuscarMecanico(String idMecanico)
        {
            return this.dbContext.Mecanicos.FirstOrDefault(m => m.MecanicoId == idMecanico);
        }

        public void EditarMecanico(Mecanico mecanicoNuevo, string idMecanico)
        {
            var mecanicoActual = this.dbContext.Mecanicos.FirstOrDefault(m => m.MecanicoId == idMecanico);
            if (mecanicoActual != null)
            {
                mecanicoActual.Nombre = mecanicoNuevo.Nombre;
                mecanicoActual.FechaNacimiento = mecanicoNuevo.FechaNacimiento;
                mecanicoActual.NivelEstudio = mecanicoNuevo.NivelEstudio;
                mecanicoActual.Telefono = mecanicoNuevo.Telefono;
                mecanicoActual.Contrasenia = mecanicoNuevo.Contrasenia;
                mecanicoActual.Rol = mecanicoNuevo.Rol;
            }
            this.dbContext.SaveChanges();
        }

        public void EliminarMecanico(String idMecanico)
        {
            var mecanicoEncontrado = this.dbContext.Mecanicos.FirstOrDefault(m => m.MecanicoId == idMecanico);
            if (mecanicoEncontrado != null)
            {
                this.dbContext.Mecanicos.Remove(mecanicoEncontrado);
                this.dbContext.SaveChanges();
            }
            
        }
    }
}