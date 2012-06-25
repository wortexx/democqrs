using System.Data.Entity;
using Domain.Model;
using Ncqrs.Domain;

namespace Domain
{
    public class PolicyContext : DbContext
    {
        public DbSet<InsuarancePolicy> Policies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AggregateRootMappedByConvention>().Property(x => x.EventSourceId).HasColumnName("Id");
            //modelBuilder.Entity<Location>().Property(x => x.EntityId).HasColumnName("Id");
        }
    }
}