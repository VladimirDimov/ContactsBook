namespace ContactsBook.Application.Features.Contact.Queries.GetAllContacts
{
    public class AddressDetailsDto
    {
        public int Id { get; set; }

        public string Title { get; private set; }

        public string Country { get; private set; }

        public string City { get; private set; }

        public string Street { get; private set; }

        public string? Number { get; private set; }

        public int ContactId { get; set; }
    }
}
