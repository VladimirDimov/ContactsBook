using Microsoft.EntityFrameworkCore;
using ContactsBook.Domain;
using ContactsBook.Domain.Interfaces;

namespace ContactsBook.Persistence.DatabaseContext
{
    public class ContactsBookDatabaseContext : DbContext
    {
        private readonly IDomainEventDispatcher _dispatcher;

        public ContactsBookDatabaseContext(
            DbContextOptions<ContactsBookDatabaseContext> options, 
            IDomainEventDispatcher dispatcher)
            : base(options)
        {
            _dispatcher = dispatcher;
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

            // ignore events if no dispatcher provided
            if (_dispatcher == null)
                return base.SaveChangesAsync(cancellationToken);

            var test = ChangeTracker.Entries<BaseEntity>().ToList();

            // dispatch events only if save was successful
            var entitiesWithEvents = ChangeTracker.Entries<BaseEntity>()
                .Select(e => e.Entity)
                .Where(e => e.Events.Any())
                .ToArray();

            foreach (var entity in entitiesWithEvents)
            {
                var events = entity.Events.ToArray();
                entity.Events.Clear();
                foreach (var domainEvent in events)
                {
                    _dispatcher.Dispatch(domainEvent);
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
