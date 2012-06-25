using System.Data.Entity;
using Domain.Design;

namespace Domain.Model
{
    public class PolicyContext : DbContext
    {
        public DbSet<InsuarancePolicy> Policies { get; set; }
        protected DbSet<Location> Locations { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entity>().HasKey(x => x.Id);
        }
    }
}