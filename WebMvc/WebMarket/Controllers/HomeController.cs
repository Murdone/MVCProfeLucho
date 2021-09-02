using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using WebMarket.Models;

namespace WebMarket.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        IServiceProvider _serviceProvider;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
        public HomeController(IServiceProvider serviceProvider)
        {
            
          //  _serviceProvider = serviceProvider;
        }
        public async Task<IActionResult> Index()
        {
            //await CrearRolesAsync(_serviceProvider);
            return View();
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
        //private async Task CrearRolesAsync(IServiceProvider serviceProvider)
        //{
        //    var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        //    string[] rolesName = {"Administrador","Usuario"};
        //    foreach (var item in rolesName)
        //    {
        //        var roleExist = await roleManager.RoleExistsAsync(item); //registra los roles que estan en la lista de roles como verdadero yu falso
        //        if (!roleExist)// aca se ve si existe o no si no eviste lo cambiamos a verdadero y lo registramos a la base de datos
        //        {
        //            await roleManager.CreateAsync(new IdentityRole(item));
        //        }
        //    }
        //}
    }
}
