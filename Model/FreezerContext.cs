using FreeezeDotNet.Model;
using Microsoft.EntityFrameworkCore;

namespace FreeezeDotNet.Model
{
    public class FreezerContext : DbContext
    {
        public DbSet<Freezer> Freezers { get; set; }
        public DbSet<Food> Foods{get;set;}
        public DbSet<Drawer> Drawers{get;set;}
        public DbSet<FoodPortion> Portions{get;set;}
        public DbSet<FoodType> Types {get;set;}        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=Freezer;MultipleActiveResultSets=true; User Id=sa; Password=capretta18!");
        }
    }
}