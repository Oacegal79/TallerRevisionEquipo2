using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Taller.App.Persistencia;
using Taller.App.Dominio.Entidades;

namespace Taller.App.Front.Pages
{
    public class ListadoVehiculoModel : PageModel
    {
         public List<String> ciudades = new List<String>(){
            "Bogotá", "Medellín", "Manizales", "Barranquilla"
        };

        public List<String> paises = new List<String>(){
            "Japon", "Corea del Norte", "Estados Unidos", "Alemania"
        };

        public List<String> tiposVehiculo = new List<String>(){
            "Convertible", "Coupe", "Hatchback", "Sedán", "Limusina"
        };
        private static RepositorioVehiculo repoVehiculo = new RepositorioVehiculo(
               new Persistencia.ContextDb()
           );

        private static RepositorioCliente repoCliente = new RepositorioCliente(
            new Persistencia.ContextDb()
        );

        public List<Vehiculo> listaVehiculos = new List<Vehiculo>();
        public List<Cliente> listaClientes = new List<Cliente>();
        public Vehiculo vehiculoActual;
        public Cliente clienteActual;

        public void OnGet()
        {
            this.ObtenerVehiculos();
            this.ObtenerClientes();
        }

        public void OnPostAgregarVehiculo(Vehiculo vehiculo)
        {
            try
            {
                repoVehiculo.AgregarVehiculo(vehiculo);
                this.ObtenerVehiculos();
                this.ObtenerClientes();
            }
            catch
            {
                throw;
            }
        }

        public void OnPostEliminarVehiculo(string id)
        {
            Console.WriteLine("llego" + id);
            try
            {
                repoVehiculo.EliminarVehiculo(id);
                this.ObtenerVehiculos();
            }
            catch
            {
                throw;
            }
        }
        private void ObtenerVehiculos()
        {
            foreach (Vehiculo vehiculo in repoVehiculo.ObtenerVehiculos())
            {
                this.listaVehiculos.Add(new Vehiculo
                {
                    VehiculoId = vehiculo.VehiculoId,
                    Placa = vehiculo.Placa,
                    Tipo = vehiculo.Tipo,
                    Marca = vehiculo.Marca,
                    Modelo = vehiculo.Modelo,
                    NumeroPasajeros = vehiculo.NumeroPasajeros,
                    Cilindraje = vehiculo.Cilindraje,
                    Pais = vehiculo.Pais,
                    Descripcion = vehiculo.Descripcion,
                    ClienteId = vehiculo.ClienteId
                });
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
                    Apellido = cliente.Apellido
                });
            }

        }
    }
}
