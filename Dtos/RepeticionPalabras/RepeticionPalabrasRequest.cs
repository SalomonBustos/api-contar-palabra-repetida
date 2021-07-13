using System;
using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.Dtos.RepeticionPalabras
{
    public class RepeticionPalabrasRequest
    {
        [Required(ErrorMessage = "El campo texto es requerido.")]
        public String texto { get; set; }
        [Required(ErrorMessage = "El campo palabra es requerido.")]
        public String palabra { get; set; }
    }
}