using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ejercicio2.Models
{
    public partial class DirectorT
    {
        public DirectorT()
        {
            Seleccion = new HashSet<Seleccion>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre del técnico es Requerido")]
        [StringLength(60)]
        public string Nombre { get; set; }
        public string Nacionalidad { get; set; }

        public ICollection<Seleccion> Seleccion { get; set; }
    }
}
