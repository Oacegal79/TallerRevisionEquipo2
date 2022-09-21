using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Taller.App.Front.Pages
{
    public class ListadoVehiculoDetalleModel : PageModel
    {
    public string titulo { get; set; } = "";
    public string valorPlaca { get; set; } = "";
        public List<VehicDetalle> listaVehiculosDetallado = new List<VehicDetalle>() {
            new VehicDetalle(){placa = "VCT979", tipo = "buseta", marca = "Hyundai",modelo = "2010",capacidad = "12",cilindraje = "2200",paisOrigen = "India",descripcion = "A/C, Pantallas"},
            new VehicDetalle(){placa = "TZN516", tipo = "microbús", marca = "JAC",modelo = "2020",capacidad = "8",cilindraje = "1600",paisOrigen = "China",descripcion = "A/C"},
            new VehicDetalle(){placa = "FEO861", tipo = "buseta", marca = "BMW",modelo = "2018",capacidad = "10",cilindraje = "2000",paisOrigen = "Alemania",descripcion = "A/C, Pantallas, Turbo"},
            new VehicDetalle(){placa = "JUM069", tipo = "buseta", marca = "Volvo",modelo = "2021",capacidad = "9",cilindraje = "1000",paisOrigen = "Korea",descripcion = "A/C"}
        };
                public void OnGet()
        {
            titulo = "Consulta de Vehículos Registrados";
            valorPlaca  ="";
        }
    }

    public class VehicDetalle
    {
        public string placa { get; set; }
        public string tipo { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public string capacidad { get; set; }
        public string cilindraje { get; set; }
        public string paisOrigen { get; set; }
        public string descripcion { get; set; }

        public VehicDetalle()
        {
        }
    }
}
