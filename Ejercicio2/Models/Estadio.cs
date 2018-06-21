using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ejercicio2.Models
{
    public partial class Estadio
    {
        public Estadio()
        {
            Partido = new HashSet<Partido>();
        }

        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        public string Ciudad { get; set; }
        [Range(1,45000)]
        public int? Capacidad { get; set; }

        public ICollection<Partido> Partido { get; set; }
    }
}
