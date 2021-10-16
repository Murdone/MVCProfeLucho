using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebMarket.Areas.Clientes.Models;
using WebMarket.Areas.Usuarios.Models;

namespace WebMarket.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<TUsuario> TUsuarios { get; set; }
        public DbSet<TCliente> TClientes { get; set; }
        public DbSet<TReports_cliente> TReports_clients { get; set; }
    }
}
