using System;
using System.Collections.Generic;

namespace MascotaFeliz.App.Dominio
{
    public class VisitaPyP
    {
        public int id { get; set; }

        public DateTime FechaInicial { get; set; }

        public float Temperatura { get; set; }

        public float Peso { get; set; }

        public float FrecuenciaRespiratoria { get; set; }

        public float FrecuenciaCardiaca { get; set; }

        public string EstadoAnimo { get; set; }

        public int IdVeterinario { get; set; }
    }
}
