using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Taller.App.Persistencia;
using Taller.App.Dominio.Entidades;

namespace Taller.App.Front.Pages
{
    public class GestionRepuestoModel : PageModel
    {
        private static RepositorioRepuesto repoRepuesto = new RepositorioRepuesto(
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

        public List<Repuesto> listaRepuestos = new List<Repuesto>();

        public Repuesto repuestoActual;

        public void OnGet()
        {
            this.ObtenerRepuestos();
        }

        public void OnPostAgregarRepuesto(Repuesto repuesto)
        {
            try
            {
                repoRepuesto.AgregarRepuesto(repuesto);
                this.ObtenerRepuestos();
            }
            catch
            {
                throw;
            }
        }

        public void OnPostEliminarRepuesto(string id)
        {
            Console.WriteLine("llego" + id);
            try
            {
                repoRepuesto.EliminarRepuesto(id);
                this.ObtenerRepuestos();
            }
            catch
            {
                throw;
            }
        }
        private void ObtenerRepuestos()
        {
            foreach (Repuesto repuesto in repoRepuesto.ObtenerRepuestos())
            {
                this.listaRepuestos.Add(new Repuesto
                {
                    RepuestoId = repuesto.RepuestoId,
                    Tipo = repuesto.Tipo,
                    Nombre = repuesto.Nombre,
                    Cantidad = repuesto.Cantidad
                });
            }
        }
    }
}
