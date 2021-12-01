using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Noel_Prueba.Models
{
    public partial class Persona
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required(ErrorMessage ="Ingrese una fecha")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
         public DateTime? FechaDeNacimiento { get; set; }
    }
}
