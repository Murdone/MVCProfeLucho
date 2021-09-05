using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebMarket.Areas.Usuarios.Models;
using WebMarket.Data;
using WebMarket.Libreria;

namespace WebMarket.Areas.Usuarios.Pages.Account
{
    public class DetalllesModel : PageModel
    {
        private SignInManager<IdentityUser> _signInManager;
        private LUsuarios _Usuario;
        public DetalllesModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            _signInManager = signInManager;
            _Usuario = new LUsuarios(userManager, signInManager, roleManager, context);
        }
        public void OnGet(int id)
        {
            var data = _Usuario.getTUsuariosAsync(null, id);
            if (0 < data.Result.Count)
            {
                Input = new InputModel
                {
                    DataUser = data.Result.ToList().Last(),
                };
            }
        }
        [BindProperty]
        public InputModel Input { get; set; }
        public class InputModel
        {
            public ImputModelRegistrar DataUser { get; set; }
        }
    }
}
