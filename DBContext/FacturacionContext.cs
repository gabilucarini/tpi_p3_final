using apifinal.Entities;
using Microsoft.EntityFrameworkCore;
using RatingAPI.Enums;

namespace apifinal.DBContext
{
    public class FacturacionContext : DbContext
    {
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public FacturacionContext(DbContextOptions<FacturacionContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasData(new Usuario()  // add usuario al BD
            {
                Id =  1,     
                Name = "Gabriel",
                SurName = "Lucarini",
                Password = "gabo",
                UserName = "gabilucarini18",
                UserType = Permissions.administrator
            });
            modelBuilder.Entity<Usuario>().HasData(new Usuario() 
            {
                Id =  2,     
                Name = "Andres",
                SurName = "Lucarini",
                Password = "andy",
                UserName = "andylucarini18",
                UserType = Permissions.defaultuser
            });
            modelBuilder.Entity<Factura>().HasData(new Factura() 
            {
                Id =  1,     
                NumeroFactura = 100,
                Descripcion = "Factura EPE",
                Precio = "15000"
            });
            modelBuilder.Entity<Factura>().HasData(new Factura() 
            {
                Id =  2,     
                NumeroFactura = 101,
                Descripcion = "Factura Agua",
                Precio = "1500"
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}


    
