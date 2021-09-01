using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebMarket.Areas.Usuarios.Models;

namespace WebMarket.Areas.Usuarios.Pages.Account
{
    public class RegistrarModel : PageModel
    {
        public void OnGet()
        {
        }
        [BindProperty] // propiedad para ingresar a imput model
        public ImputModel Input { get; set; }
        public class ImputModel : ImputModelRegistrar
        {
            public IFormFile AvatarImage { get; set; }
        }
    }
}
