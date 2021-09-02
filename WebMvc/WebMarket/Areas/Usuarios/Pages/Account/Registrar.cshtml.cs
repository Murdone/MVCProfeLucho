using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using WebMarket.Areas.Usuarios.Models;
using WebMarket.Libreria;

namespace WebMarket.Areas.Usuarios.Pages.Account
{
    public class RegistrarModel : PageModel
    {
        private SignInManager<IdentityUser> _signInManager;
        private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _RoleManager;
        private LUsuariosRoles _UsuariosRole;

        public RegistrarModel(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> RoleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _RoleManager = RoleManager;
            _UsuariosRole = new LUsuariosRoles();
        }

        public void OnGet()
        {
            Input = new ImputModel
            {
                rolesLitas = _UsuariosRole.getRoles(_RoleManager)
            };
        }
        [BindProperty] // propiedad para ingresar a imput model
        public ImputModel Input { get; set; }
        public class ImputModel : ImputModelRegistrar
        {
            public IFormFile AvatarImage { get; set; }
            public string ErrorMessage { get; set; }
            public List<SelectListItem> rolesLitas { get; set; }
        }
    }
}
