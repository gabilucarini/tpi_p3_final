using apifinal.Entities;
using Microsoft.EntityFrameworkCore;

namespace apifinal.DBContext
{
    public class FacturacionContext : DbContext
    {
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public FacturacionContext(DbContextOptions<FacturacionContext> options) : base(options)
        {

        }
        }
}

    
