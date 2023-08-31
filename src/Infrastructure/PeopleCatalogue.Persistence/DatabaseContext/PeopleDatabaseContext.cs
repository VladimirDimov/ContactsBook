using Microsoft.EntityFrameworkCore;
using PeopleCatalogue.Domain;

namespace PeopleCatalogue.Persistence.DatabaseContext
{
    public class PeopleDatabaseContext : DbContext
    {
        public PeopleDatabaseContext(DbContextOptions<PeopleDatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PeopleDatabaseContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var changedEntries = base.ChangeTracker.Entries<BaseEntity>()
                                    .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var entry in changedEntries)
            {
                if (entry.State == EntityState.Added)
                    entry.Entity.CreatedOn = DateTime.UtcNow;

                if (entry.State == EntityState.Modified)
                    entry.Entity.UpdatedOn = DateTime.UtcNow;
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
