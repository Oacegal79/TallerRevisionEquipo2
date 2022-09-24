using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Taller.App.Persistencia;
using Taller.App.Dominio.Entidades;

namespace Talle.App.Front.Pages
{
    public class EditarRevisionesModel : PageModel
    {
        private static RepositorioRevision repoRevision = new RepositorioRevision(
           new ContextDb()
        );

        private static RepositorioMecanico repoMecanico = new RepositorioMecanico(
            new ContextDb()
        );

        private static RepositorioRepuesto repoRepuesto = new RepositorioRepuesto(
        new ContextDb()
        );
        private static RepositorioVehiculo repoVehiculo = new RepositorioVehiculo(
        new ContextDb()
        );
        public List<Repuesto> listaRepuestos = new List<Repuesto>();
        public Revision revisionActual { get; set;}
        public Mecanico mecanicoActual { get; set;}
        public Repuesto repuestoActual { get; set;}
        public Vehiculo vehiculoActual { get; set;}
        public IActionResult OnGet(string revisionId)
        {
            try {
                this.ObtenerRepuestos();
                this.revisionActual = repoRevision.BuscarRevision(revisionId);
                this.mecanicoActual = repoMecanico.BuscarMecanico(revisionActual.MecanicoId);
                this.vehiculoActual = repoVehiculo.BuscarVehiculo(revisionActual.VehiculoId);
                return Page();
            } catch {
                return RedirectToPage("./Error");
            }
        }

        public IActionResult OnPostEditar(Revision revisionActual, string revisionId)
        {
            try
            {
                revisionActual.MecanicoId = mecanicoActual.MecanicoId;
                revisionActual.VehiculoId = vehiculoActual.VehiculoId;
                repoRevision.EditarRevision(revisionActual, revisionId);
                repoRevision.ObtenerRevisiones();
                return RedirectToPage("/Revisiones/ListadoRevisiones");
            }
            catch
            {
                Console.WriteLine("error");
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
