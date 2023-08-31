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

            builder.Property(x => x.Address)
                .HasMaxLength(200);

            builder.Property(x => x.Iban)
                .HasMaxLength(34);

            builder.Property(x => x.CreatedOn)
                .IsRequired();

            builder.HasData(
                new Contact
                {
                    Id = 1,
                    FirstName = "Adam",
                    LastName = "Baum",
                    Address = "Sofia, Iztok",
                    Iban = "BG18RZBB91550123456789",
                    CreatedOn= DateTime.UtcNow,
                    DateOfBirth = new DateTime(1980, 5, 6),
                    PhoneNumber = "555-00001"
                },
                new Contact
                {
                    Id = 2,
                    FirstName = "Bob",
                    LastName = "Apple",
                    Address = "Plovdiv, Izgrev",
                    Iban = "BG18RZBB91550123456789",
                    CreatedOn = DateTime.UtcNow,
                    DateOfBirth = new DateTime(1984, 2, 15),
                    PhoneNumber = "555-00002"
                },
                new Contact
                {
                    Id = 3,
                    FirstName = "Dusty",
                    LastName = "Carr",
                    Address = "Sofia, Geo Milev 123",
                    Iban = "BG18RZBB91550123456789",
                    CreatedOn = DateTime.UtcNow,
                    DateOfBirth = new DateTime(1991, 5, 6),
                    PhoneNumber = "777-88881"
                },
                new Contact
                {
                    Id = 4,
                    FirstName = "Chris",
                    LastName = "Cross",
                    Address = "Sofia, Iztok",
                    Iban = "BG18RZBB91550123456789",
                    CreatedOn = DateTime.UtcNow,
                    DateOfBirth = new DateTime(1972, 3, 22),
                    PhoneNumber = "777-51516"
                }
            );
        }
    }
}
