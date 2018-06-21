using System;
using System.Collections.Generic;

namespace Ejercicio2.Models
{
    public partial class Partido
    {
        public int Id { get; set; }
        public string Fecha { get; set; }
        public string Local { get; set; }
        public string Visita { get; set; }
        public int? Marcador { get; set; }
        public int? IdEstadio { get; set; }

        public Estadio IdEstadioNavigation { get; set; }
    }
}
