using Microsoft.EntityFrameworkCore;
using ContactsBook.Domain;

namespace ContactsBook.Persistence.DatabaseContext
{
    public class ContactsBookDatabaseContext : DbContext
    {
        public ContactsBookDatabaseContext(DbContextOptions<ContactsBookDatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ContactsBookDatabaseContext).Assembly);

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
