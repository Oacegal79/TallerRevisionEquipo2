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

        public void EditarCliente(Cliente clienteNuevo, string IdCliente)
        {
            var clienteTemp = this.dbContext.Clientes.FirstOrDefault(c =>c.ClienteId==IdCliente);
            if (clienteTemp != null)
            {
                clienteTemp.ClienteId = clienteNuevo.ClienteId;
                clienteTemp.Nombre = clienteNuevo.Nombre;
                clienteTemp.Apellido = clienteNuevo.Apellido;
                clienteTemp.Telefono = clienteNuevo.Telefono;
                clienteTemp.FechaNacimiento = clienteNuevo.FechaNacimiento;
                clienteTemp.Contrasenia = clienteNuevo.Contrasenia;
                clienteTemp.Rol = clienteNuevo.Rol;
                clienteTemp.CiudadResidencia = clienteNuevo.CiudadResidencia;
                clienteTemp.Correo = clienteNuevo.Correo;
                
            }
            this.dbContext.SaveChanges();
            this.ObtenerClientes();
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