using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebMarket.Areas.Clientes.Models
{
    public class TCliente
    {
        [Key]
        public int IdClient { set; get; }
        public string Rut { set; get; }
        public string Nombre { set; get; }
        public string Apellido { set; get; }
        public string Email { set; get; }
        public string Direction { set; get; }
        public string Telefono { set; get; }
        public DateTime Date { set; get; }
        public bool Credit { set; get; }
        public byte[] Image { get; set; }
        public List<TReports_cliente> TReports_clients { get; set; }
    }
}
