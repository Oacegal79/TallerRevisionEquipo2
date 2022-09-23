using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Taller.App.Persistencia;
using Taller.App.Dominio.Entidades;

namespace Talle.App.Front.Pages
{
    public class EditarClienteModel : PageModel
    {
        private static RepositorioCliente repoCliente = new RepositorioCliente(
            new ContextDb()
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
        public IActionResult OnGet(string clienteId)
        {
            try {
                clienteActual = repoCliente.BuscarCliente(clienteId);
                return Page();
            } catch {
                return RedirectToPage("./Error");
            }
        }

        public IActionResult OnPostEditar(Cliente clienteActual, string clienteId)
        {
            try
            {
                repoCliente.EditarCliente(clienteActual, clienteId);
                repoCliente.ObtenerClientes();
                return RedirectToPage("/Propietarios/RegistroPropietario");
                

            }
            catch
            {
                Console.WriteLine("error");
                throw;
            }
        }
    }
}
