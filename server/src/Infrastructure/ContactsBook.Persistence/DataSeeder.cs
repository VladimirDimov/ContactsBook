using ContactsBook.Domain;
using ContactsBook.Persistence.DatabaseContext;

namespace ContactsBook.Persistence
{
    internal class DataSeeder
    {
        public void SeedData(ContactsBookDatabaseContext context)
        {
            if (context.Contacts.Any())
                return;

            var data = new List<Contact>();

            var adam = new Contact(
                    firstName: "Adam",
                    lastName: "Baum",
                    dateOfBirth: new DateTime(1980, 5, 6),
                    phoneNumber: "333-00001",
                    iban: "BG32IORT80944789164663"
                    );

            data.Add(adam);

            var michiu = new Contact(
                    firstName: "Michiu",
                    lastName: "Kaku",
                    dateOfBirth: new DateTime(1980, 5, 6),
                    phoneNumber: "333-00001",
                    iban: "BG32IORT80944789164663"
                    );
            data.Add(michiu);

            context.AddRange(data);

            var addresses = new List<Address>();
            var address1 = new Address("Home", "Bulgaria", "Plovdiv", "Gladston", "2").SetContact(adam);
            var address2 = new Address("Work", "Bulgaria", "Plovdiv", "Gladston", "5").SetContact(adam);
            var address3 = new Address("Home", "USA", "San Hose", "Main Street", "2").SetContact(michiu);

            addresses.Add(address1);
            addresses.Add(address2);
            addresses.Add(address3);

            context.AddRange(addresses);

            context.SaveChanges();
        }
    }
}
