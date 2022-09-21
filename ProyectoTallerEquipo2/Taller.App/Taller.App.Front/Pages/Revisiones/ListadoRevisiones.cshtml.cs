using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Taller.App.Persistencia;
using Taller.App.Dominio.Entidades;

namespace Taller.App.Front.Pages
{
    public class ListadoRevisionesModel : PageModel
    {
        private static RepositorioRevision repoRevision = new RepositorioRevision(
           new Persistencia.ContextDb()
       );
        public List<Revision> listaRevisiones = new List<Revision>();

        public Revision revisionActual;

        public void OnGet()
        {
            this.ObtenerRevisiones();
        }

        public void OnPostAgregarRevision(Revision revision)
        {
            try
            {
                repoRevision.AgregarRevision(revision);
                this.ObtenerRevisiones();
            }
            catch
            {
                throw;
            }
        }

        public void OnPostEliminarRevision(string id)
        {
            Console.WriteLine("llego" + id);
            try
            {
                repoRevision.EliminarRevision(id);
                this.ObtenerRevisiones();
            }
            catch
            {
                throw;
            }
        }
        private void ObtenerRevisiones()
        {
            foreach (Revision revision in repoRevision.ObtenerRevisiones())
            {
                this.listaRevisiones.Add(new Revision
                {
                    RevisionId = revision.RevisionId,
                    FechaEntrada = revision.FechaEntrada,
                    FechaSalida = revision.FechaSalida,
                    Observaciones = revision.Observaciones,
                    VehiculoId = revision.VehiculoId,
                    MecanicoId = revision.MecanicoId,
                    RepuestoId = revision.RepuestoId
                });
            }
        }



    }
}
