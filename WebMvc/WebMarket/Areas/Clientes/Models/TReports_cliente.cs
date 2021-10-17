using System;
using System.ComponentModel.DataAnnotations;

namespace WebMarket.Areas.Clientes.Models
{
    public class TReports_cliente
    {
        [Key]
        public int IdReport { set; get; }
        public Decimal Debt { set; get; }
        public Decimal Monthly { set; get; }
        public Decimal Change { set; get; }
        public Decimal LastPayment { set; get; }
        public DateTime DatePayment { set; get; }
        public Decimal CurrentDebt { set; get; }
        public DateTime DateDebt { set; get; }
        public string Ticket { set; get; }
        public DateTime Deadline { set; get; }
        public int IdClient { get; set; }

        public TCliente TClientes { get; set; }
    }
}
