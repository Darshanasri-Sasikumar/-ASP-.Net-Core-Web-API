using Microsoft.EntityFrameworkCore;
using StudentPortal.Models.Enitites;

namespace StudentPortal.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        public DbSet<Student>Students { get; set; }
        public DbSet<StudentMarks> StudentMarks { get; set; }

        public DbSet<StudentCourse> StudentCourse { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .Property(s => s.Fees)
                .HasPrecision(18, 2);
        }
    }
}
