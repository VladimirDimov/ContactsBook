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

            //var data = new List<Contact>();

            //var adam = new Contact(
            //        firstName: "Adam",
            //        lastName: "Baum",
            //        dateOfBirth: new DateTime(1980, 5, 6),
            //        phoneNumber: "333-00001",
            //        iban: "BG32IORT80944789164663"
            //        );

            //adam.AddAddress(new Address("Bulgaria", "Plovdiv", "Gladston", "2"));
            //adam.Id = 1;
            //data.Add(adam);

            //var john = new Contact(
            //        firstName: "John",
            //        lastName: "Doe",
            //        dateOfBirth: new DateTime(1974, 3, 16),
            //        phoneNumber: "444-00001",
            //        iban: "BG63STSA93008378282582"
            //        );

            //john.AddAddress(new Address("Bulgaria", "Sofia", "Rakovski", "10"));
            //john.Id = 2;
            //data.Add(john);

            //var georgi = new Contact(
            //        firstName: "Georgi",
            //        lastName: "Georgiev",
            //        dateOfBirth: new DateTime(1983, 11, 20),
            //        phoneNumber: "777-00001",
            //        iban: "BG44RZBB91559214866875"
            //        );
            //georgi.AddAddress(new Address("Bulgaria", "Varna", "Black See", "45"));
            //georgi.Id = 3;
            //data.Add(georgi);

            //var michio = new Contact(
            //        firstName: "Michio",
            //        lastName: "Kaku",
            //        dateOfBirth: new DateTime(1992, 12, 6),
            //        phoneNumber: "888-00001",
            //        iban: "BG95BNPA94409533726557"
            //        );
            //michio.AddAddress(new Address("Bulgaria", "Sofia", "Vasil Levski", "12"));
            //michio.Id = 4;
            //data.Add(michio);

            //builder.HasData(data);
        }
    }
}
