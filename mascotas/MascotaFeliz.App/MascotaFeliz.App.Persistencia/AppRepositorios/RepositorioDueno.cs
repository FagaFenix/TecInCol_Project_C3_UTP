using System;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace MascotaFeliz.App.Persistencia
{
    public class RepositorioDueno : IRepositorioDueno
    {
        /// <summary>
        /// Referencia al contexto de Dueno
        /// </summary>
        private readonly AppContext _appContext;

        /// <summary>
        /// Metodo  Utiiza
        /// Inyeccion de dependencias para indicar el contexto a utilizar
        /// </summary>
        /// <param name="appContext"></param>//
        public RepositorioDueno(AppContext appContext)
        {
            _appContext = appContext;
        }

        public Dueno AddDueno(Dueno dueno)
        {
            var duenoAdicionado = _appContext.Duenos.Add(dueno);
            _appContext.SaveChanges();
            return duenoAdicionado.Entity;
        }

        public void DeleteDueno(int idDueno)
        {
            var duenoEncontrado =
                _appContext.Duenos.FirstOrDefault(d => d.Id == idDueno);
            if (duenoEncontrado == null) return;
            _appContext.Duenos.Remove (duenoEncontrado);
            _appContext.SaveChanges();
        }

        public IEnumerable<Dueno> GetAllDuenos()
        {
            return _appContext.Duenos;
        }

        public IEnumerable<Dueno> GetDuenosPorFiltro(string filtro)
        {
            var duenos = GetAllDuenos(); // Obtiene todos los saludos
            if (
                duenos != null //Si se tienen saludos
            )
            {
                if (
                    !String.IsNullOrEmpty(filtro) // Si el filtro tiene algun valor
                )
                {
                    duenos = duenos.Where(s => s.Nombres.Contains(filtro));
                }
            }
            return duenos;
        }

        public Dueno GetDueno(int idDueno)
        {
            return _appContext.Duenos.FirstOrDefault(d => d.Id == idDueno);
        }

        public Dueno UpdateDueno(Dueno dueno)
        {
            var duenoEncontrado =
                _appContext.Duenos.FirstOrDefault(d => d.Id == dueno.Id);
            if (duenoEncontrado != null)
            {
                duenoEncontrado.Nombres = dueno.Nombres;
                duenoEncontrado.Apellidos = dueno.Apellidos;
                duenoEncontrado.Direccion = dueno.Direccion;
                duenoEncontrado.Telefono = dueno.Telefono;
                duenoEncontrado.Correo = dueno.Correo;
                _appContext.SaveChanges();
            }
            return duenoEncontrado;
        }
    }
}
