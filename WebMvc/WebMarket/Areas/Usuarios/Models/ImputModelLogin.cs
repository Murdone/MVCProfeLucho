using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebMarket.Areas.Usuarios.Models
{
    public class ImputModelLogin
    {
        [Display(Name = "Correo Electronico")]
        [Required(ErrorMessage = "El Campo {0} es oblitario")]
        [EmailAddress(ErrorMessage = "El campo {0} no es válido.")]
        public string Email { get; set; }
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "El Campo {0} es oblitario")]
        [StringLength(50, ErrorMessage = "el número de caracteres de {0} debe ser al menos {2} y debe letras numeros y algun caracter .", MinimumLength = 6)]
        public string Password { get; set; }
        [TempData]
        public string ErrorMessage { get; set; }
    }
}
