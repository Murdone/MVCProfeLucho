using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using WebMarket.Areas.Clientes.Models;
using WebMarket.Data;
using WebMarket.Libreria;

namespace WebMarket.Areas.Clientes.Pages.Account
{
    public class DetailsModel : PageModel
    {
        private LClientes _customer;
        public DetailsModel(
            ApplicationDbContext context)
        {
            _customer = new LClientes(context);
        }
        public void OnGet(int id)
        {
            var data = _customer.getTClients(null, id);
            if (0 < data.Count)
            {
                Input = new InputModel
                {
                    DataClient = data.ToList().Last(),
                };
            }
        }
        [BindProperty]
        public InputModel Input { get; set; }
        public class InputModel
        {
            public ImputModelRegistrar DataClient { get; set; }
        }
    }
}
