using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Taller.App.Front.Pages
{
    public class RegistroPropietarioModel : PageModel
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

        public void OnGet()
        {
        }
    }
}
