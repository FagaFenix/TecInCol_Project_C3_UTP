using System;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace MascotaFeliz.App.Persistencia
{
    public class RepositorioMascota : IRepositorioMascota
    {
        /// <summary>
        /// Referencia al contexto de Mascota
        /// </summary>
        private readonly AppContext _appContext;

        /// <summary>
        /// Metodo  Utiliza
        /// Inyeccion de dependencias para indicar el contexto a utilizar
        /// </summary>
        /// <param name="appContext"></param>//
        public RepositorioMascota(AppContext appContext)
        {
            _appContext = appContext;
        }

        public Mascota AddMascota(Mascota mascota)
        {
            var mascotaAdicionado = _appContext.Mascotas.Add(mascota);
            _appContext.SaveChanges();
            return mascotaAdicionado.Entity;
        }

        public void DeleteMascota(int idMascota)
        {
            var mascotaEncontrado =
                _appContext.Mascotas.FirstOrDefault(m => m.Id == idMascota);
            if (mascotaEncontrado == null) return;
            _appContext.Mascotas.Remove (mascotaEncontrado);
            _appContext.SaveChanges();
        }

        public IEnumerable<Mascota> GetAllMascotas()
        {
            return _appContext.Mascotas;
        }

        public IEnumerable<Mascota> GetMascotasPorFiltro(string filtro)
        {
            var mascotas = GetAllMascotas(); // Obtiene todos los saludos
            if (
                mascotas != null //Si se tienen saludos
            )
            {
                if (
                    !String.IsNullOrEmpty(filtro) // Si el filtro tiene algun valor
                )
                {
                    mascotas = mascotas.Where(m => m.Especie.Contains(filtro));
                }
            }
            return mascotas;
        }

        public Mascota GetMascota(int idMascota)
        {
            return _appContext.Mascotas.FirstOrDefault(m => m.Id == idMascota);
        }

        public Mascota UpdateMascota(Mascota mascota)
        {
            var mascotaEncontrado =
                _appContext.Mascotas.FirstOrDefault(d => d.Id == mascota.Id);
            if (mascotaEncontrado != null)
            {
                mascotaEncontrado.Nombre = mascota.Nombre;
                mascotaEncontrado.Color = mascota.Color;
                mascotaEncontrado.Especie = mascota.Especie;
                mascotaEncontrado.Raza = mascota.Raza;
                mascotaEncontrado.Dueno = mascota.Dueno;
                mascotaEncontrado.Veterinario = mascota.Veterinario;
                mascotaEncontrado.Historia = mascota.Historia;

                _appContext.SaveChanges();
            }
            return mascotaEncontrado;
        }

        // public Veterinario AsignarVeterinario(int idMascota, int idVeterinario)
        // {
        //     Console.WriteLine("AsignarVeterinario");
        // }

        // public Dueno AsignarDueno(int idMascota, int idDueno)
        // {
        //     Console.WriteLine("AsignarDueno");
        // }

        // public Historia AsignarHistoria(int idMascota, int idHistoria)
        // {
        //     Console.WriteLine("AsignarHistoria");
        // }
    }
}
