using FreeezeDotNet.Model;
using Microsoft.EntityFrameworkCore;

namespace EFCoreWebDemo
{
    public class EFCoreWebDemoContext : DbContext
    {
        public DbSet<Test> Tests { get; set; }
        // public DbSet<Author> Authors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=Freezer;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}