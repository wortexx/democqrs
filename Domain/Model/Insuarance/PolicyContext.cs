using System.Data.Entity;
using Domain.Model.Insuarance.Model;
using Ncqrs.Domain;

namespace Domain.Model.Insuarance
{
    public class PolicyContext : DbContext
    {
        public DbSet<InsuarancePolicy> Policies { get; set; }
        protected DbSet<Location> Locations { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AggregateRootMappedByConvention>().HasKey(x => x.EventSourceId);
            modelBuilder.Entity<EntityMappedByConvention>()
                                .HasKey(x => x.EntityId);
        }
    }
}