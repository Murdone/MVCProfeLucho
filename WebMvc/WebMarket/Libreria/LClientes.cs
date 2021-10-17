using System;
using System.Collections.Generic;
using System.Linq;
using WebMarket.Areas.Clientes.Models;
using WebMarket.Data;

namespace WebMarket.Libreria
{
    public class LClientes : ListObject
    {
        public LClientes(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<ImputModelRegistrar> getTClients(String valor, int id)
        {
            List<TCliente> listTClients;
            var clientsList = new List<ImputModelRegistrar>();
            if (valor == null && id.Equals(0))
            {
                listTClients = _context.TClientes.ToList();
            }
            else
            {
                if (id.Equals(0))
                {
                    listTClients = _context.TClientes.Where(u => u.Rut.StartsWith(valor) || u.Rut.StartsWith(valor) ||
              u.Apellido.StartsWith(valor) || u.Email.StartsWith(valor)).ToList();
                }
                else
                {
                    listTClients = _context.TClientes.Where(u => u.IdClient.Equals(id)).ToList();
                }
            }
            if (!listTClients.Count.Equals(0))
            {
                foreach (var item in listTClients)
                {
                    clientsList.Add(new ImputModelRegistrar
                    {
                        IdClient = item.IdClient,
                        Rut = item.Rut,
                        Nombre = item.Nombre,
                        Apellido = item.Apellido,
                        Email = item.Email,
                        Telefono = item.Telefono,
                        Credit = item.Credit,
                        Direccion = item.Direccion,
                        Image = item.Image,
                    });
                }
            }
            return clientsList;
        }
        public List<TCliente> getTClient(String Rut)
        {
            var listTClients = new List<TCliente>();
            using (var dbContext = new ApplicationDbContext())
            {
                listTClients = dbContext.TClientes.Where(u => u.Rut.Equals(Rut)).ToList();
            }

            return listTClients;
        }
    }
}
