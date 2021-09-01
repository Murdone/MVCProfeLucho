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
        public string Rut { get; set; }
        [Display(Name = "Telefono")]
        [Required(ErrorMessage = "El Campo {0} es oblitario")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?[0-9]{2})\)?[-. ]?(0-9){2})[-. ]?([0-9]{5})$", ErrorMessage = "El formato de telefono  ingresado no es valido.")]
        public string NumeroTelefono { get; set; }
        [Display(Name = "Correo Electronico")]
        [Required(ErrorMessage = "El Campo {0} es oblitario")]
        [EmailAddress(ErrorMessage = "El campo {0} no es válido.")]
        public string Email { get; set; }
        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "El Campo {0} es oblitario")]
        [StringLength(50, ErrorMessage ="el número de caracteres de {0} debe ser al menos {2}.",MinimumLength = 6)]
        public string Password { get; set; }
    }
}
