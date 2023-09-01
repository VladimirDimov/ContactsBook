using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ContactsBook.Domain;

namespace ContactsBook.Persistence.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(x => x.Country)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(x => x.City)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(x => x.Street)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(x => x.Number)
                .HasMaxLength(20);

            builder.HasOne(x => x.Contact)
                .WithMany(x => x.Address)
                .HasForeignKey(x => x.ContactId);
        }
    }
}
