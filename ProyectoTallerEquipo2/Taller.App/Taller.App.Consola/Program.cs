using System;
using Taller.App.Persistencia;
using Taller.App.Dominio.Entidades;

namespace Taller.App.Consola
{

    class Program
    {
        private static RepositorioMecanico repoMecanico = new RepositorioMecanico(
            new Persistencia.ContextDb()
        );

        static void Main(string[] args)
        {
            //Console.WriteLine("");
            AgregarMecanico();
            ObtenerMecanicos();
            BuscarMecanico("3");
            //EditarMecanico();
            EliminarMecanico("3");

        }

        static void AgregarMecanico()
        {
            var mecanico = new Mecanico
            {
                MecanicoId = "5",
                NivelEstudio = "Tecnologo",
                Direccion = "Calle falsa 123",
                Nombre = "Pedro",
                Apellido = "Davila",
                Telefono = "4340292",
                FechaNacimiento = "10",
                Contrasenia = "123456",
                Rol = "jefeoperaciones"

            };
            repoMecanico.AgregarMecanico(mecanico);
        }
        static void ObtenerMecanicos()
        {
            foreach (Mecanico mecanico in repoMecanico.ObtenerMecanicos())
            {
                Console.WriteLine(mecanico.Nombre);
            }
        }

        static void BuscarMecanico(string idMecanico)
        {

            var mecanico = repoMecanico.BuscarMecanico(idMecanico);
            Console.WriteLine("Nombre Mecanico: " + mecanico.Nombre.ToString());

        }

        static void EditarMecanico(string idMecanico)
        {
            Mecanico m = new Mecanico
            {
                MecanicoId = idMecanico,
                Nombre = "Jairo",
                FechaNacimiento = "",
                NivelEstudio = "Ingeniero",
                Contrasenia = "123456",
                Rol = "jefeoperaciones",
                Telefono = "4340292"
            };
            repoMecanico.EditarMecanico(m, idMecanico);
        }

        static void EliminarMecanico (string idMecanico){
            repoMecanico.EliminarMecanico(idMecanico);
        }
    }
}