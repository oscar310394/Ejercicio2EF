using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ejercicio2.Models
{
    public partial class Jugador
    {
        public int Id { get; set; }
        public int? Numero { get; set; }
        [Required]
        [StringLength(60)]
        public string Nombre { get; set; }
        public string FechaNac { get; set; }
        public string Posicion { get; set; }
        public string Club { get; set; }
        public double? Altura { get; set; }
        public int? IdSel { get; set; }

        public Seleccion IdSelNavigation { get; set; }
    }
}
