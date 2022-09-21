using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Taller.App.Persistencia;
using Taller.App.Dominio.Entidades;

namespace Taller.App.Front.Pages
{
    public class GestionMecanicoModel : PageModel
    {
        private static RepositorioMecanico repoMecanico = new RepositorioMecanico(
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

        public List<Mecanico> listaMecanicos = new List<Mecanico>();

        public Mecanico mecanicoActual;

        public void OnGet()
        {
            this.ObtenerMecanicos();
        }

        public void OnPostAgregarMecanico(Mecanico mecanico)
        {
            try
            {
                repoMecanico.AgregarMecanico(mecanico);
                this.ObtenerMecanicos();
            }
            catch
            {
                throw;
            }
        }

        public void OnPostEliminarMecanico(string id)
        {
            Console.WriteLine("llego"+id);
            try
            {
                repoMecanico.EliminarMecanico(id);
                this.ObtenerMecanicos();
            }
            catch
            {
                throw;
            }
        }
        private void ObtenerMecanicos()
        {
            foreach (Mecanico mecanico in repoMecanico.ObtenerMecanicos())
            {
                this.listaMecanicos.Add(new Mecanico
                {
                    MecanicoId = mecanico.MecanicoId,
                    Nombre = mecanico.Nombre,
                    Apellido = mecanico.Apellido,
                    Telefono = mecanico.Telefono,
                    NivelEstudio = mecanico.NivelEstudio,
                    Rol = mecanico.Rol
                });
            }
        }



    }
}