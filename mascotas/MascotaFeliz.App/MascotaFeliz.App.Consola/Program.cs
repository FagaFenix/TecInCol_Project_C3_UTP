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

        //private static IRepositorioHistoria
          //  _repoHistoria =
            //    new RepositorioHistoria(new Persistencia.AppContext());

        // private static IRepositorioVisitaPyP
        //     _repoVisitaPyP =
        //         new RepositorioVisitaPyP(new Persistencia.AppContext());
        //Métodos Entidad---> Dueno
        private static void AddDueno()
        {
            var dueno =
                new Dueno {
                    Nombres = "Arnoldo",
                    Apellidos = "Cruz",
                    Direccion = "Acacias",
                    Telefono = "157908642",
                    Correo = "Arnoldo@UTP.com"
                };
            _repoDueno.AddDueno (dueno);
            Console.WriteLine("Nuevo Dueño Agregagado: ", dueno);
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

        private static void GetAllDuenos_()
        {
            var allDuenos = _repoDueno.GetAllDuenos();
            foreach (Dueno dueno in allDuenos)
            {
                Console.WriteLine(dueno + " \n");
            }
            Console
                .WriteLine("Todas las Dueños solicitados han sido Listados!");
        }

        private static void listDuenosPorFiltroNombres(string filtroDeNombres)
        {
            var duenos = _repoDueno.GetDuenosPorFiltro(filtroDeNombres);
            foreach (Dueno dueno in duenos)
            {
                Console.WriteLine(dueno + " \n");
            }
            Console
                .WriteLine("Todas los Dueños solicitados han sido Listados!");
        }

        //Métodos Entidad---> Veterinarios
        //
        private static void AddVeterinario()
        {
            var veterinario =
                new Veterinario {
                    Nombres = "Perensejo",
                    Apellidos = "González",
                    Direccion = "Animal Planet",
                    Telefono = "123456",
                    TarjetaProfesional = "Recién graduado"
                };
            _repoVeterinario.AddVeterinario (veterinario);
            Console
                .WriteLine("Nuevo Veterinario Agregagado: " +
                veterinario.Nombres);
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

        //Métodos Entidad---> Mascotas
        //
        private static void AddMascota()
        {
            var mascota =
                new Mascota {
                    Nombre = "Chimuelo",
                    Color = "Negro",
                    Especie = "Dracaris",
                    Raza = "Dragón"
                };
            _repoMascota.AddMascota (mascota);
            Console.WriteLine("Your Pet has been registered in the database.");
        }

        private static void GetMascota_(int IdMascota)
        {
            var mascota = _repoMascota.GetMascota(IdMascota);
            Console
                .WriteLine(mascota.Id +
                " \n" +
                mascota.Nombre +
                " \n" +
                mascota.Color +
                " \n" +
                mascota.Especie +
                " \n" +
                mascota.Raza +
                " \n" +
                mascota.Dueno +
                " \n" +
                mascota.Veterinario +
                " \n" +
                mascota.Historia);
        }

        private static void GetAllMascotas_()
        {
            var AllMascotas = _repoMascota.GetAllMascotas();
            foreach (Mascota mascota in AllMascotas)
            {
                Console
                    .WriteLine("Id: " +
                    mascota.Id +
                    "\nNombre: " +
                    mascota.Nombre +
                    "\nColor " +
                    mascota.Color +
                    "\nEspecie: " +
                    mascota.Especie +
                    "\nRaza: " +
                    mascota.Raza +
                    "\nDueño: " +
                    mascota.Dueno +
                    "\nVeterinario: " +
                    mascota.Veterinario +
                    "\nHistoria: " +
                    mascota.Historia +
                    "\n");
            }
            Console
                .WriteLine("Todas las mascotas solicitadas han sido Ennumeradas!");
        }

        //AsignarVisitaPyP a la Historia
        // private static void AsignarVisitaPyP(int idHistoria)
        // {
        //     var historia = _repoHistoria.GetHistoria(idHistoria);
        //     if (historia != null)
        //     {
        //         if (historia.VisitasPyP != null)
        //         {
        //             historia
        //                 .VisitasPyP
        //                 .Add(new VisitaPyP {
        //                     FechaVisita = new DateTime(2020, 01, 01),
        //                     Temperatura = 38.0F,
        //                     Peso = 30.0F,
        //                     FrecuenciaRespiratoria = 71.0F,
        //                     FrecuenciaCardiaca = 71.0F,
        //                     EstadoAnimo = "Muy cansón",
        //                     CedulaVeterinario = "123",
        //                     Recomendaciones = "Dieta extrema"
        //                 });
        //         }
        //         else
        //         {
        //             historia.VisitasPyP =
        //                 new List<VisitaPyP> {
        //                     new VisitaPyP {
        //                         FechaVisita = new DateTime(2020, 01, 01),
        //                         Temperatura = 38.0F,
        //                         Peso = 30.0F,
        //                         FrecuenciaRespiratoria = 71.0F,
        //                         FrecuenciaCardiaca = 71.0F,
        //                         EstadoAnimo = "Muy cansón",
        //                         CedulaVeterinario = "123",
        //                         Recomendaciones = "Dieta extrema"
        //                     }
        //                 };
        //         }
        //         _repoHistoria.UpdateHistoria (historia);
        //     }
        // }
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
            Console.WriteLine("El proceso ha comenzado...");

            //AddDueno();
            //AddVeterinario();
            //AddMascota();
            //getDueno_(1);
            //getVeterinario_();
            //listDuenosPorFiltroNombres("Juan");
            //GetAllDuenos_();
            //GetMascota_(3);
            //GetAllMascotas_();
        }
    }
}
