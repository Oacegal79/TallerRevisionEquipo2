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
        public IEnumerable<Vehiculo> ObtenerVehiculos()
        {
            return this.dbContext.Vehiculos;
        }

        public Vehiculo BuscarVehiculo(String idVehiculo)
        {
            return this.dbContext.Vehiculos.FirstOrDefault(re => re.VehiculoId == idVehiculo);
        }

        public void EditarVehiculo(Vehiculo vehiculoNuevo, string idVehiculo)
        {
            var vehiculoActual = this.dbContext.Vehiculos.FirstOrDefault(m => m.VehiculoId == idVehiculo);
            if (vehiculoActual != null)
            {
                vehiculoActual.Placa = vehiculoNuevo.Placa;
                vehiculoActual.Tipo = vehiculoNuevo.Tipo;
                vehiculoActual.Marca = vehiculoNuevo.Marca;
                vehiculoActual.Modelo = vehiculoNuevo.Modelo;
                vehiculoActual.NumeroPasajeros = vehiculoNuevo.NumeroPasajeros;
                vehiculoActual.Cilindraje = vehiculoNuevo.Cilindraje;
                vehiculoActual.Pais = vehiculoNuevo.Pais;
                vehiculoActual.Descripcion = vehiculoNuevo.Descripcion;
                vehiculoActual.ClienteId = vehiculoNuevo.ClienteId;
            }
            this.dbContext.SaveChanges();
        }

        public void EliminarVehiculo(String idVehiculo)
        {
            var vehiculoEncontrado = this.dbContext.Vehiculos.FirstOrDefault(m => m.VehiculoId == idVehiculo);
            if (vehiculoEncontrado != null)
            {
                this.dbContext.Vehiculos.Remove(vehiculoEncontrado);
                this.dbContext.SaveChanges();
            }
            
        }
    }
}