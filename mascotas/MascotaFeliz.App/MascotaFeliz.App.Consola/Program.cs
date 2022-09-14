using System;
using System.Collections.Generic;
using MascotaFeliz.App.Dominio;
using MascotaFeliz.App.Persistencia;

namespace MascotaFeliz.App.Consola
{
    class Program
    {
        private static IRepositorioDueno
            _repoDueno = new RepositorioDueno(new Persistencia.AppContext());

        private static IRepositorioVeterinario
            _repoVeterinario =
                new RepositorioVeterinario(new Persistencia.AppContext());

        // private static IRepositorioMascota
        //     _repoMascota =
        //         new RepositorioMascota(new Persistencia.AppContext());
        // private static IRepositorioHistoria
        //     _repoHistoria =
        //         new RepositorioHistoria(new Persistencia.AppContext());
        // private static IRepositorioVisitaPyP
        //     _repoVisitaPyP =
        //         new RepositorioVisitaPyP(new Persistencia.AppContext());
        private static void AddDueno()
        {
            var dueno =
                new Dueno {
                    //Cedula = "1212",
                    Nombres = "Juan",
                    Apellidos = "Sin Miedo",
                    Direccion = "Bajo un puente",
                    Telefono = "1234567891",
                    Correo = "juansinmiedo@gmail.com"
                };
            _repoDueno.AddDueno (dueno);
        }

        private static void AddVeterinario()
        {
            var veterinario =
                new Veterinario {
                    //Cedula = "1212",
                    Nombres = "Oscar",
                    Apellidos = "Millan",
                    Direccion = "Animal Planet",
                    Telefono = "0987654321",
                    TarjetaProfesional = "El Encantador de perros"
                };
            _repoVeterinario.AddVeterinario (veterinario);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //AddDueno();
            AddVeterinario();
        }
    }
}
