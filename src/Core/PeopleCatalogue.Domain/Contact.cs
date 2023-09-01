namespace ContactsBook.Domain
{
    public class Contact : BaseEntity
    {
        public Contact(
            string firstName,
            string lastName,
            DateTime? dateOfBirth,
            string? address,
            string? phoneNumber,
            string? iban)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Address = address;
            PhoneNumber = phoneNumber;
            Iban = iban;
        }

        public string FirstName { get; private set; } = string.Empty;

        public string LastName { get; private set; } = string.Empty;

        public DateTime? DateOfBirth { get; private set; }

        public string? Address { get; private set; }

        public string? PhoneNumber { get; private set; }

        public string? Iban { get; private set; }
    }
}
