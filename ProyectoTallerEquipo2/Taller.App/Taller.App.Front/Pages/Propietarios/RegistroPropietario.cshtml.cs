using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Taller.App.Persistencia;
using Taller.App.Dominio.Entidades;

namespace Taller.App.Front.Pages
{
    public class RegistroPropietarioModel : PageModel
    {

        private static RepositorioCliente repoCliente = new RepositorioCliente(
            new Persistencia.ContextDb()
        );

        public List<String> ciudades = new List<String>(){
            "Bogotá", "Medellín", "Manizales", "Barranquilla"
        };

        public List<String> especialidades = new List<String>(){
            "Eléctrico", "Mecánico", "Pintor", "Soldador"
        };

        public List<String> nivelEstudio = new List<String>(){
            "Bachiller", "Técnico", "Tecnólogo"
        };

        public List<Cliente> listaClientes = new List<Cliente>();

        public Cliente clienteActual;

        public void OnGet()
        {
            this.ObtenerClientes();
        }

        public void OnPostAgregarCliente(Cliente cliente)
        {
            try
            {
                repoCliente.AgregarCliente(cliente);
                this.ObtenerClientes();
            }
            catch
            {
                throw;
            }
        }

        public void OnPostEliminarCliente(string id)
        {
            Console.WriteLine("llego" + id);
            try
            {
                repoCliente.EliminarCliente(id);
                this.ObtenerClientes();
            }
            catch
            {
                throw;
            }
        }
        private void ObtenerClientes()
        {
            foreach (Cliente cliente in repoCliente.ObtenerClientes())
            {
                this.listaClientes.Add(new Cliente
                {
                    ClienteId = cliente.ClienteId,
                    Nombre = cliente.Nombre,
                    Apellido = cliente.Apellido,
                    Telefono = cliente.Telefono,
                    Rol = cliente.Rol,
                    Correo = cliente.Correo,
                    CiudadResidencia = cliente.CiudadResidencia
                });
            }
        }
    }
}
