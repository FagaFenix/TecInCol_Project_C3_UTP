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

        private static IRepositorioMascota
            _repoMascota =
                new RepositorioMascota(new Persistencia.AppContext());

        // private static IRepositorioHistoria
        //     _repoHistoria =
        //         new RepositorioHistoria(new Persistencia.AppContext());
        // private static IRepositorioVisitaPyP
        //     _repoVisitaPyP =
        //         new RepositorioVisitaPyP(new Persistencia.AppContext());
        //Métodos Entidad---> Dueno
        private static void AddDueno()
        {
            var dueno =
                new Dueno {
                    //Cedula = "1212",
                    Nombres = "Hector",
                    Apellidos = "Esteban",
                    Direccion = "UPT",
                    Telefono = "0987654321",
                    Correo = "HectorEUTP@gmail.com"
                };
            _repoDueno.AddDueno (dueno);
        }

        private static void getDueno_(int idDueno)
        {
            var dueno = _repoDueno.GetDueno(idDueno);
            Console
                .WriteLine(dueno.Id +
                " \n" +
                dueno.Nombres +
                " \n" +
                dueno.Apellidos +
                " \n" +
                dueno.Direccion +
                " \n" +
                dueno.Telefono +
                " \n" +
                dueno.Correo);
        }

        private static void listDuenosPorFiltroNombres(String filtroDeNombres)
        {
            var duenos = _repoDueno.GetDuenosPorFiltro(filtroDeNombres);
            Console.WriteLine (duenos);
        }

        private static void AddVeterinario()
        {
            var veterinario =
                new Veterinario {
                    Nombres = "Oscar",
                    Apellidos = "Millan",
                    Direccion = "Animal Planet",
                    Telefono = "0987654321",
                    TarjetaProfesional = "El Encantador de perros"
                };
            _repoVeterinario.AddVeterinario (veterinario);
        }

        private static void getVeterinario_(int idVeterinario)
        {
            var veterinario = _repoVeterinario.GetVeterinario(idVeterinario);
            Console
                .WriteLine(veterinario.Id +
                " \n" +
                veterinario.Nombres +
                " \n" +
                veterinario.Apellidos +
                " \n" +
                veterinario.Direccion +
                " \n" +
                veterinario.Telefono +
                " \n" +
                veterinario.TarjetaProfesional);
        }

        private static void AddMascota()
        {
            var mascota =
                new Mascota {
                    Nombre = "SiMurdiera",
                    Color = "Café",
                    Especie = "Criollito",
                    Raza = "Perro"
                };
            _repoMascota.AddMascota (mascota);
            Console.WriteLine("Your Pet has been registered in the database.");
        }

        // private static void AddHistoria()
        // {
        //     var historia = new Historia {
        //                  id = 123456,
        //                  FechaInicial = new DateTime(),
        //                  VisitaPyP = new VisitaPyP []
        //              };
        //     _repoDueno.Addhistoria (historia);
        // }
        static void Main(string[] args)
        {
            Console.WriteLine("The process has started!");

            //AddDueno();
            //AddVeterinario();
            //AddMascota();
            //getDueno_(1);
            //getVeterinario_();
        }
    }
}
