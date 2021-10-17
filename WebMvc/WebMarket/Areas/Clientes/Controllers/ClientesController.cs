using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMarket.Areas.Clientes.Models;
using WebMarket.Data;
using WebMarket.Libreria;
using WebMarket.Models;

namespace WebMarket.Areas.Clientes.Controllers
{
    [Authorize]
    [Area("Clientes")]
    public class ClientesController : Controller
    {
        private LClientes _customer;
        private SignInManager<IdentityUser> _signInManager;
        private static DataPaginador<ImputModelRegistrar> models;

        public ClientesController(
           SignInManager<IdentityUser> signInManager,
           ApplicationDbContext context)
        {
            _signInManager = signInManager;
            _customer = new LClientes(context);
        }
        public IActionResult Customers(int id, String filtrar)
        {
            if (_signInManager.IsSignedIn(User))
            {
                Object[] objects = new Object[3];
                var data = _customer.getTClients(filtrar, 0);
                if (0 < data.Count)
                {
                    var url = Request.Scheme + "://" + Request.Host.Value;
                    objects = new LPaginador<ImputModelRegistrar>().paginador(data,
                        id, 10, "Customers", "Customers", "Customers", url);
                }
                else
                {
                    objects[0] = "No hay datos que mostrar";
                    objects[1] = "No hay datos que mostrar";
                    objects[2] = new List<ImputModelRegistrar>();
                }
                models = new DataPaginador<ImputModelRegistrar>
                {
                    List = (List<ImputModelRegistrar>)objects[2],
                    Pagi_infor = (String)objects[0],
                    Pagi_navegacion = (String)objects[1],
                    Input = new ImputModelRegistrar(),
                };
                return View(models);
            }
            else
            {
                return Redirect("/");
            }

        }
    }
}
