using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMarket.Areas.Clientes.Controllers
{
    [Authorize]
    [Area("Clientes")]
    public class ClientesController : Controller
    {
        public IActionResult Clientes()
        {
            return View();
        }
    }
}
