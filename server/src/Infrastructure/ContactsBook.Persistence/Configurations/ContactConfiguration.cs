using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ContactsBook.Domain;

namespace ContactsBook.Persistence.Configurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(x => x.DateOfBirth);

            builder.Property(x => x.PhoneNumber)
                .HasMaxLength(20);

            builder.HasMany(x => x.Address)
                .WithOne(x => x.Contact)
                .HasForeignKey(x => x.ContactId);

            builder.Property(x => x.Iban)
                .HasMaxLength(34);

            builder.Property(x => x.CreatedOn)
                .IsRequired();
        }
    }
}
