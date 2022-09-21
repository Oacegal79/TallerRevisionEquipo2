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

        private static RepositorioMecanico repoMecanico = new RepositorioMecanico(
            new Persistencia.ContextDb()
        );

        private static RepositorioRepuesto repoRepuesto = new RepositorioRepuesto(
        new Persistencia.ContextDb()
        );
        public List<Revision> listaRevisiones = new List<Revision>();
        public List<Mecanico> listaMecanicos = new List<Mecanico>();
        public List<Repuesto> listaRepuestos = new List<Repuesto>();
        public Revision revisionActual;
        public Mecanico mecanicoActual;
        public Repuesto repuestoActual;

        public void OnGet()
        {
            this.ObtenerRevisiones();
            this.ObtenerMecanicos();
            this.ObtenerRepuestos();
        }

        public void OnPostAgregarRevision(Revision revision)
        {
            try
            {
                repoRevision.AgregarRevision(revision);
                this.ObtenerRevisiones();
                this.ObtenerMecanicos();
                this.ObtenerRepuestos();
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

        private void ObtenerMecanicos()
        {
            foreach (Mecanico mecanico in repoMecanico.ObtenerMecanicos())
            {
                this.listaMecanicos.Add(new Mecanico
                {
                    MecanicoId = mecanico.MecanicoId,
                    Nombre = mecanico.Nombre,
                    Apellido = mecanico.Apellido
                });
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
