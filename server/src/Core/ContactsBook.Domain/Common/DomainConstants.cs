namespace ContactsBook.Domain.Common
{
    public class DomainConstants
    {
        public class AddressValidationConstants
        {
            public const int AddressTitleMaxLength = 20;
            public const int CountryMaxLength = 30;
            public const int CityMaxLength = 30;
            public const int StreetLength = 30;
            public const int NumberLength = 20;
        }

        public class ContactValidationConstants
        {
            public const int FirstNameMaxLength = 20;
            public const int LastNameMaxLength = 30;
            public const int PhoneNumberMaxLength = 20;
            public const int IbanMaxLength = 34;
            public const int IbanMinLength = 4;
            public const int FirstNameMinLength = 2;
            public const int LastNameMinLength = 2;

        }
    }
}
