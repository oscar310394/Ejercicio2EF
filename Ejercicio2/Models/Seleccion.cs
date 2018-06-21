using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ejercicio2.Models
{
    public partial class Seleccion
    {
        public Seleccion()
        {
            Jugador = new HashSet<Jugador>();
        }

        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        public string Grupo { get; set; }
        public string Confederacion { get; set; }
        public int? IdDirectorT { get; set; }

        public DirectorT IdDirectorTNavigation { get; set; }
        public ICollection<Jugador> Jugador { get; set; }
    }
}
