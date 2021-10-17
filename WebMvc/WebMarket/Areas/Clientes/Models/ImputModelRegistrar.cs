using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace WebMarket.Areas.Clientes.Models
{
    public class ImputModelRegistrar
    {
        [Required(ErrorMessage = "El Campo {0} es oblitario")]
        [MaxLength(10, ErrorMessage = "El campo {0} no puede ser mayor a {1} caracteres")]
        [RegularExpression(@"^(\d{1,3}(?:\d{1,3}){2}-[\dkK])$", ErrorMessage = "Rut con caracteres incorrectos")]
        public string Rut { set; get; }

        [Required(ErrorMessage = "El Campo {0} es oblitario")]
        public string Nombre { set; get; }
        [Required(ErrorMessage = "El Campo {0} es oblitario")]
        public string Apellido { set; get; }
        [Display(Name = "Correo Electronico")]
        [Required(ErrorMessage = "El Campo {0} es oblitario")]
        [EmailAddress(ErrorMessage = "El campo {0} no es válido.")]
        public string Email { set; get; }
        [Required(ErrorMessage = "El Campo {0} es oblitario")]
        public string Direccion { set; get; }

        [Display(Name = "Telefono")]
        [Required(ErrorMessage = "El Campo {0} es oblitario")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{2})\)?[-. ]?([0-9]{2})[-. ]?([0-9]{5})$", ErrorMessage = "El formato telefono ingresado no es válido.")]
        public string Telefono { set; get; }
        [Required(ErrorMessage = "El Campo {0} es oblitario")]
        [DataType(DataType.Date)]
        public DateTime Date { set; get; }
        public bool Credit { set; get; }
        public byte[] Image { get; set; }
        public int IdClient { set; get; }

        [TempData]
        public string ErrorMessage { get; set; }
    }
}
