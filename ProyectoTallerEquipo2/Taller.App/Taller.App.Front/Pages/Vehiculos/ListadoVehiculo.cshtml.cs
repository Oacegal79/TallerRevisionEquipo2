using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Taller.App.Front.Pages
{
    public class ListadoVehiculoModel : PageModel
    {

        public string titulo { get; set; } = "";

        public List<Vehic> listaVehiculos = new List<Vehic>() {
            new Vehic(){placa = "VCT979", tipo = "buseta", marca = "Hyundai",modelo = "2010",capacidad = "12"},
            new Vehic(){placa = "TZN516", tipo = "microbús", marca = "JAC",modelo = "2020",capacidad = "8"},
            new Vehic(){placa = "FEO861", tipo = "buseta", marca = "BMW",modelo = "2018",capacidad = "10"},
            new Vehic(){placa = "JUM069", tipo = "buseta", marca = "Volvo",modelo = "2021",capacidad = "9"}
        };

        public void OnGet()
        {
            titulo = "Listado De Vehiculos Registrados";
        }
    }

    public class Vehic
    {
        public string placa { get; set; }
        public string tipo { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public string capacidad { get; set; }

        public Vehic()
        {
        }
    }
}
