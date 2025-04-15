using apiClientes.Model;
using Microsoft.EntityFrameworkCore;

namespace apiClientes.ApplicationDbContext
{
    public class DatabaseDbContext : DbContext
    {
        public DatabaseDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
    }
}
