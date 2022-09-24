using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Taller.App.Persistencia;
using Taller.App.Dominio.Entidades;

namespace Talle.App.Front.Pages
{
    public class EditarMecanicoModel : PageModel
    {
        private static RepositorioMecanico repoMecanico = new RepositorioMecanico(
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

        public Mecanico mecanicoActual;
        public IActionResult OnGet(string mecanicoId)
        {
            try {
                mecanicoActual = repoMecanico.BuscarMecanico(mecanicoId);
                return Page();
            } catch {
                return RedirectToPage("./Error");
            }
        }

        public IActionResult OnPostEditar(Mecanico mecanicoActual, string MecanicoId)
        {
            try
            {
                repoMecanico.EditarMecanico(mecanicoActual, MecanicoId);
                repoMecanico.ObtenerMecanicos();
                return RedirectToPage("/Mecanicos/GestionMecanico");
            }
            catch
            {
                Console.WriteLine("error");
                throw;
            }
        }
    }
}
