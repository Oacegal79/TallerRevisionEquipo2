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
    public class RepositorioVehiculo
    {
        private readonly ContextDb dbContext;

        public RepositorioVehiculo(ContextDb dbContext)
        {
            this.dbContext = dbContext;
        }

        public Vehiculo AgregarVehiculo(Vehiculo ve)
        {
            var vehiculoNuevo = this.dbContext.Vehiculos.Add(ve);
            this.dbContext.SaveChanges();
            return vehiculoNuevo.Entity;
        }
    }
}