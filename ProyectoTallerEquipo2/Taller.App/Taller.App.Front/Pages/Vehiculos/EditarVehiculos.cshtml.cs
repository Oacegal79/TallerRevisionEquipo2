using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Taller.App.Persistencia;
using Taller.App.Dominio.Entidades;

namespace Talle.App.Front.Pages
{
    public class EditarVehiculosModel : PageModel
    {
        public List<String> paises = new List<String>(){
            "Japon", "Corea del Norte", "Estados Unidos", "Alemania"
        };

        public List<String> tiposVehiculo = new List<String>(){
            "Convertible", "Coupe", "Hatchback", "Sedán", "Limusina"
        };
        private static RepositorioVehiculo repoVehiculo = new RepositorioVehiculo(
               new ContextDb()
        );

        private static RepositorioCliente repoCliente = new RepositorioCliente(
            new ContextDb()
        );

        public List<Cliente> listaClientes = new List<Cliente>();
        public Vehiculo vehiculoActual;
        public Cliente clienteActual;
        public IActionResult OnGet(string vehiculoId)
        {
            try {
                vehiculoActual = repoVehiculo.BuscarVehiculo(vehiculoId);
                clienteActual = repoCliente.BuscarCliente(vehiculoActual.ClienteId);
                return Page();
            } catch {
                return RedirectToPage("./Error");
            }
        }

        public IActionResult OnPostEditar(Vehiculo vehiculoActual, string vehiculoId)
        {
            try
            {
                vehiculoActual.ClienteId = vehiculoId;
                repoVehiculo.EditarVehiculo(vehiculoActual, vehiculoId);
                repoVehiculo.ObtenerVehiculos();
                return RedirectToPage("/Vehiculos/ListadoVehiculo");
            }
            catch
            {
                Console.WriteLine("error");
                throw;
            }
        }
    }
}
