namespace ContactsBook.Domain
{
    public class Address : BaseEntity
    {
        public Address() { }

        public Address(
            string title,
            string country,
            string city,
            string street,
            string? number)
        {
            Country = country;
            City = city;
            Street = street;
            Number = number;
        }

        public string Title { get; private set; }

        public string Country { get; private set; }

        public string City { get; private set; }

        public string Street { get; private set; }

        public string? Number { get; private set; }

        public int ContactId { get; set; }

        public Contact Contact { get; set; }
    }
}
