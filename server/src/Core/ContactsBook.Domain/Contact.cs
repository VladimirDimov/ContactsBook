using ContactsBook.Domain.Events;

namespace ContactsBook.Domain
{
    public class Contact : BaseEntity
    {
        public Contact() { }

        public Contact(
            string firstName,
            string lastName,
            DateTime? dateOfBirth,
            string? phoneNumber,
            string? iban)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
            Iban = iban;
        }

        public string FirstName { get; private set; } = string.Empty;

        public string LastName { get; private set; } = string.Empty;

        public DateTime? DateOfBirth { get; private set; }

        public List<Address> Address { get; private set; } = new List<Address>();

        public string? PhoneNumber { get; private set; }

        public string? Iban { get; private set; }

        public void AddAddress(Address address)
        {
            Address.Add(address);

            Events.Add(new AddressAddedEvent(address));
        }

        public void UpdateAddress(Address address)
        {
            var addressToUpdate = Address.FirstOrDefault(a => a.Id == address.Id);

            if (addressToUpdate is null)
                return;

            addressToUpdate = address;

            Events.Add(new AddressUpdatedEvent(address));
        }

        public void RemoveAddress(Address address)
        {
            Address.Remove(address);

            Events.Add(new AddressDeletedEvent(address));
        }
    }
}
