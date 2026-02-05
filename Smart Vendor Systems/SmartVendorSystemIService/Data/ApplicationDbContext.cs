using Microsoft.EntityFrameworkCore;
using SmartVendorSystemData.Models.Entites;
namespace SmartVendorSystemData.Data
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
