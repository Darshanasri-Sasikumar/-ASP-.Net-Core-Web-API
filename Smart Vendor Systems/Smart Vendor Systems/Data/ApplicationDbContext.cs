using Microsoft.EntityFrameworkCore;
using Smart_Vendor_Systems.Models.Entites;
namespace Smart_Vendor_Systems.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }
        public DbSet<Vendor> Vendor { get; set; }
        public DbSet<Product>Product { get; set; }
        

    }
}
