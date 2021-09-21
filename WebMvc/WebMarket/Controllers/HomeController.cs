using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using WebMarket.Areas.Principal.Controllers;
using WebMarket.Areas.Usuarios.Models;
using WebMarket.Data;
using WebMarket.Libreria;
using WebMarket.Models;

namespace WebMarket.Controllers
{
    public class HomeController : Controller
    {
        private static ImputModelLogin _model;
        private LUsuarios _user;
        IServiceProvider _serviceProvider;
        private SignInManager<IdentityUser> _signInManager;

        public HomeController(IServiceProvider serviceProvider, UserManager<IdentityUser> userManager,
             SignInManager<IdentityUser> signInManager,
             RoleManager<IdentityRole> roleManager,
             ApplicationDbContext context)
        {
            _serviceProvider = serviceProvider;
            _user = new LUsuarios(userManager, signInManager,roleManager,context);
            _signInManager = signInManager;
        }
        public async Task<IActionResult> Index()
        {
            await CreateRolesAsync(_serviceProvider);
            if (_signInManager.IsSignedIn(User))
            {
                return RedirectToAction(nameof(PrincipalController.Principal), "Principal");
            }
            else
            {
                if (_model != null)
                {
                    return View();
                }
                else
                {
                    return View();
                }
            }
           
           
        }
        [HttpPost]
        public async Task<IActionResult> Index(ImputModelLogin model)
        {
            _model = model;
            //await CreateRolesAsync(_serviceProvider);
            if (ModelState.IsValid)
            {
                var result = await _user.UsuarioLoginAsync(model);
                if (result.Succeeded) // si da valor verdadero se logea
                {
                    return Redirect("/Principal/Principal");
                }
                else
                {
                    _model.ErrorMessage = "Correo o contraseña inválidos.";
                    return Redirect("/");
                }
            }
            else
            {
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        _model.ErrorMessage = error.ErrorMessage;
                    }
                }
                return Redirect("/");
            }
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        private async Task CreateRolesAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            String[] rolesName = { "Admin", "User" };
            foreach (var item in rolesName)
            {
                var roleExist = await roleManager.RoleExistsAsync(item);
                if (!roleExist)
                {
                    await roleManager.CreateAsync(new IdentityRole(item));
                }
            }
        }
    }
}
