using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebMarket.Areas.Usuarios.Models
{
    public class ImputModelRegistrar
    {

        [Required(ErrorMessage = "El Campo {0} es oblitario")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede ser mayor a {1} caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El Campo {0} es oblitario")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede ser mayor a {1} caracteres")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "El Campo {0} es oblitario")]
        [MaxLength(10, ErrorMessage = "El campo {0} no puede ser mayor a {1} caracteres")]
        [RegularExpression(@"^(\d{1,3}(?:\d{1,3}){2}-[\dkK])$", ErrorMessage = "Rut con caracteres incorrectos")]
        public string Rut { get; set; }
        [Display(Name = "Telefono")]
        [Required(ErrorMessage = "El Campo {0} es oblitario")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{2})\)?[-. ]?([0-9]{2})[-. ]?([0-9]{5})$", ErrorMessage = "El formato telefono ingresado no es válido.")]
        public string NumeroTelefono { get; set; }
        [Display(Name = "Correo Electronico")]
        [Required(ErrorMessage = "El Campo {0} es oblitario")]
        [EmailAddress(ErrorMessage = "El campo {0} no es válido.")]
        public string Email { get; set; }
        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "El Campo {0} es oblitario")]
        [StringLength(50, ErrorMessage = "el número de caracteres de {0} debe ser al menos {2} y debe letras numeros y algun caracter .", MinimumLength = 6)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Seleccione Un Rol")]
        public string Roles { get; set; }
        public string ID { get; set; }
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public int NUmeros { get; set; }
        public IdentityUser IdentityUser { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }
    }
}
