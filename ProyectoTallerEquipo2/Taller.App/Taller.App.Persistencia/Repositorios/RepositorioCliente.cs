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
    public class RepositorioCliente
    {
        private readonly ContextDb dbContext;

        public RepositorioCliente(ContextDb dbContext)
        {
            this.dbContext = dbContext;
        }

        public Cliente AgregarCliente(Cliente c)
        {
            var clienteNuevo = this.dbContext.Clientes.Add(c);
            this.dbContext.SaveChanges();
            return clienteNuevo.Entity;
        }
        public IEnumerable<Cliente> ObtenerClientes()
        {
            return this.dbContext.Clientes;
        }

        public Cliente BuscarCliente(string idCliente)
        {
            return this.dbContext.Clientes.FirstOrDefault(re => re.ClienteId == idCliente);
        }

        public void EditarCliente(Cliente clienteNuevo)
        {
            var clienteActual = this.dbContext.Clientes.FirstOrDefault(c => c.ClienteId == clienteNuevo.ClienteId);

            if (clienteActual != null)
            {
                clienteActual.Nombre = clienteNuevo.Nombre;
                clienteActual.Apellido = clienteNuevo.Apellido;
                clienteActual.Telefono = clienteNuevo.Telefono;
                clienteActual.FechaNacimiento = clienteNuevo.FechaNacimiento;
                clienteActual.Contrasenia = clienteNuevo.Contrasenia;
                clienteActual.Rol = clienteNuevo.Rol;
                clienteActual.CiudadResidencia = clienteNuevo.CiudadResidencia;
                clienteActual.Correo = clienteNuevo.Correo;
            }
            this.dbContext.SaveChanges();
        }

        public void EliminarCliente(string idCliente)
        {
            var clienteEncontrado = this.dbContext.Clientes.FirstOrDefault(m => m.ClienteId == idCliente);
            if (clienteEncontrado != null)
            {
                this.dbContext.Clientes.Remove(clienteEncontrado);
                this.dbContext.SaveChanges();
            }
            
        }
    }
}