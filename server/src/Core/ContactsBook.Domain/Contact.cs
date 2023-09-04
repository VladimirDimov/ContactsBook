using ContactsBook.Domain.Common;
using ContactsBook.Domain.Events;
using ContactsBook.Domain.Exceptions;
using static ContactsBook.Domain.Common.DomainConstants;

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
            SetFirstName(firstName);
            SetLastName(lastName);
            SetDateOfBirth(dateOfBirth);
            SetPhoneNumber(phoneNumber);
            Iban = iban;
        }

        public string FirstName { get; private set; } = string.Empty;

        public string LastName { get; private set; } = string.Empty;

        public DateTime? DateOfBirth { get; private set; }

        public List<Address> Address { get; private set; } = new List<Address>();

        public string? PhoneNumber { get; private set; }

        public string? Iban { get; private set; }

        public void SetFirstName(string firstName)
        {
            Guard.AgainstEmptyString<InvalidContactException>(firstName, nameof(FirstName));

            Guard.ForStringLength<InvalidContactException>(
                firstName,
                ContactValidationConstants.FirstNameMinLength,
                ContactValidationConstants.FirstNameMaxLength,
                nameof(FirstName));

            FirstName = firstName;
        }

        public void SetLastName(string lastName)
        {
            Guard.AgainstEmptyString<InvalidContactException>(lastName, nameof(LastName));

            Guard.ForStringLength<InvalidContactException>(
                lastName,
                ContactValidationConstants.LastNameMinLength,
                ContactValidationConstants.LastNameMaxLength,
                nameof(LastName));

            LastName = lastName;
        }

        public void SetDateOfBirth(DateTime? date)
        {
            DateOfBirth = date;
        }

        public void SetPhoneNumber(string phone)
        {
            Guard.ForStringLength<InvalidContactException>(
                phone,
                0,
                ContactValidationConstants.PhoneNumberMaxLength,
                nameof(PhoneNumber));

            PhoneNumber = phone;
        }

        public void SetIban(string iban)
        {
            Guard.ForStringLength<InvalidContactException>(
                iban,
                ContactValidationConstants.IbanMinLength,
                ContactValidationConstants.IbanMaxLength,
                nameof(Iban));

            Iban = iban;
        }

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
