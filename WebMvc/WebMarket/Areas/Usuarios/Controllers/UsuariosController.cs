using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebMarket.Areas.Usuarios.Models;
using WebMarket.Controllers;
using WebMarket.Data;
using WebMarket.Libreria;
using WebMarket.Models;

namespace WebMarket.Areas.Usuarios.Controllers
{
    [Area("Usuarios")]
    [Authorize]
    public class UsuariosController : Controller
    {
        private SignInManager<IdentityUser> _signInManager;
        private LUsuarios _user;
        private static DataPaginador<ImputModelRegistrar> _models;
        public UsuariosController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            _signInManager = signInManager;
            _user = new LUsuarios(userManager, signInManager, roleManager, context);
        }
        public IActionResult Usuarios(int id, string filtrar, int registros)
        {
            if (_signInManager.IsSignedIn(User))
            {
                Object[] objects = new Object[3];
                var data = _user.getTUsuariosAsync(filtrar, 0);
                if (0 < data.Result.Count)
                {
                    var url = Request.Scheme + "://" + Request.Host.Value;
                    objects = new LPaginador<ImputModelRegistrar>().paginador(data.Result,
                        id, registros, "Usuarios", "Usuarios", "Usuarios", url);
                }
                else
                {
                    objects[0] = "No hay datos que mostrar";
                    objects[1] = "No hay datos que mostrar";
                    objects[2] = new List<ImputModelRegistrar>();
                }
                _models = new DataPaginador<ImputModelRegistrar>
                {
                    List = (List<ImputModelRegistrar>)objects[2],
                    Pagi_infor = (String)objects[0],
                    Pagi_navegacion = (String)objects[1],
                    Input = new ImputModelRegistrar(),
                };
                return View(_models);
            }

            else
            {
                return Redirect("/");
            }

        }
        public async Task<IActionResult> Salir()
        {
            await _signInManager.SignOutAsync();//metodo para borrar toda la seccion
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }

}
