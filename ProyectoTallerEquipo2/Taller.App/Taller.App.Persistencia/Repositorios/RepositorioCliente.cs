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
    }
}