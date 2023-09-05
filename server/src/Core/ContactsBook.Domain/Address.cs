using ContactsBook.Domain.Common;
using ContactsBook.Domain.Exceptions;

using static ContactsBook.Domain.Common.DomainConstants;

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
            SetTitle(title);
            SetCountry(country);
            SetCity(city);
            SetStreet(street);
            SetNumber(number);
        }

        public string Title { get; private set; }

        public string Country { get; private set; }

        public string City { get; private set; }

        public string Street { get; private set; }

        public string? Number { get; private set; }

        public int ContactId { get; private set; }

        public Contact Contact { get; private set; }

        public Address SetContact(Contact contact)
        {
            Contact = contact;

            return this;
        }

        public Address SetContactId(int contactId)
        {
            ContactId = contactId;

            return this;
        }

        public Address SetTitle(string country)
        {
            Guard.AgainstEmptyString<InvalidAddressException>(country, nameof(Title));

            Guard.ForStringLength<InvalidAddressException>(
                country,
                0,
                AddressValidationConstants.AddressTitleMaxLength,
                nameof(Title));

            Title = country;

            return this;
        }

        public Address SetCountry(string country)
        {
            Guard.AgainstEmptyString<InvalidAddressException>(country, nameof(Title));

            Guard.ForStringLength<InvalidAddressException>(
                country,
                0,
                AddressValidationConstants.CountryMaxLength,
                nameof(Title));

            Country = country;

            return this;
        }

        public Address SetCity(string city)
        {
            Guard.AgainstEmptyString<InvalidAddressException>(city, nameof(City));

            Guard.ForStringLength<InvalidAddressException>(
                city,
                0,
                AddressValidationConstants.CityMaxLength,
                nameof(Title));

            City = city;

            return this;
        }

        public Address SetStreet(string street)
        {
            Guard.AgainstEmptyString<InvalidAddressException>(street, nameof(Street));

            Guard.ForStringLength<InvalidAddressException>(
                street,
                0,
                AddressValidationConstants.StreetMaxLength,
                nameof(Title));

            Street = street;

            return this;
        }

        public Address SetNumber(string? number)
        {
            Guard.ForStringLength<InvalidAddressException>(
                number,
                0,
                AddressValidationConstants.NumberMaxLength,
                nameof(Title));

            Number = number;

            return this;
        }
    }
}
